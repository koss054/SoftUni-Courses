namespace Artillery.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Artillery.Data;
    using Artillery.Data.Models;
    using Artillery.Data.Models.Enums;
    using Artillery.DataProcessor.ImportDto;
    using Newtonsoft.Json;

    public class Deserializer
    {
        private const string ErrorMessage =
                "Invalid data.";
        private const string SuccessfulImportCountry =
            "Successfully import {0} with {1} army personnel.";
        private const string SuccessfulImportManufacturer =
            "Successfully import manufacturer {0} founded in {1}.";
        private const string SuccessfulImportShell =
            "Successfully import shell caliber #{0} weight {1} kg.";
        private const string SuccessfulImportGun =
            "Successfully import gun {0} with a total weight of {1} kg. and barrel length of {2} m.";

        public static string ImportCountries(ArtilleryContext context, string xmlString)
        {
            var sb = new StringBuilder();

            XmlRootAttribute xmlRoot = new XmlRootAttribute("Countries");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportCountryDto[]), xmlRoot);

            using StringReader reader = new StringReader(xmlString);
            var countryDtos = (ImportCountryDto[])xmlSerializer.Deserialize(reader);

            ICollection<Country> validCountries = new List<Country>();

            foreach (var cDto in countryDtos)
            {
                if (!IsValid(cDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var country = new Country()
                {
                    CountryName = cDto.CountryName,
                    ArmySize = cDto.ArmySize
                };

                validCountries.Add(country);
                sb.AppendLine(String.Format(SuccessfulImportCountry, country.CountryName, country.ArmySize));
            }

            context.Countries.AddRange(validCountries);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportManufacturers(ArtilleryContext context, string xmlString)
        {
            var sb = new StringBuilder();

            XmlRootAttribute xmlRoot = new XmlRootAttribute("Manufacturers");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportManufacturerDto[]), xmlRoot);

            using StringReader reader = new StringReader(xmlString);
            var manufacturerDtos = (ImportManufacturerDto[])xmlSerializer.Deserialize(reader);

            ICollection<Manufacturer> validManufacturers = new List<Manufacturer>();

            foreach (var mDto in manufacturerDtos)
            {
                if (!IsValid(mDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (validManufacturers.Any(vm => vm.ManufacturerName == mDto.ManufacturerName))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var manufacturer = new Manufacturer()
                {
                    ManufacturerName = mDto.ManufacturerName,
                    Founded = mDto.Founded
                };

                string[] foundedArray = mDto.Founded.Split(", ");
                string townAndCountryName = string.Empty;

                if (foundedArray.Length == 3)
                {
                    townAndCountryName = foundedArray[1] + ", " + foundedArray[2];
                }
                else if (foundedArray.Length == 4)
                {
                    townAndCountryName = foundedArray[2] + ", " + foundedArray[3];
                }
                else if (foundedArray.Length == 5)
                {
                    townAndCountryName = foundedArray[3] + ", " + foundedArray[4];
                }

                validManufacturers.Add(manufacturer);
                sb.AppendLine(String.Format(SuccessfulImportManufacturer, manufacturer.ManufacturerName, townAndCountryName));
            }

            context.Manufacturers.AddRange(validManufacturers);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportShells(ArtilleryContext context, string xmlString)
        {
            var sb = new StringBuilder();

            XmlRootAttribute xmlRoot = new XmlRootAttribute("Shells");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportShellDto[]), xmlRoot);

            using StringReader reader = new StringReader(xmlString);
            var shellDtos = (ImportShellDto[])xmlSerializer.Deserialize(reader);

            ICollection<Shell> validShells = new List<Shell>();

            foreach (var sDto in shellDtos)
            {
                if (!IsValid(sDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var shell = new Shell()
                {
                    ShellWeight = sDto.ShellWeight,
                    Caliber = sDto.Caliber
                };

                validShells.Add(shell);
                sb.AppendLine(String.Format(SuccessfulImportShell, shell.Caliber, shell.ShellWeight));
            }

            context.Shells.AddRange(validShells);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportGuns(ArtilleryContext context, string jsonString)
        {
            var sb = new StringBuilder();

            ImportGunWithCountriesDto[] gunDtos =
                JsonConvert.DeserializeObject<ImportGunWithCountriesDto[]>(jsonString);

            ICollection<Gun> validGuns = new List<Gun>();

            foreach (var gDto in gunDtos)
            {
                if (!IsValid(gDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                bool isGunTypeValid =
                    Enum.TryParse(typeof(GunType), gDto.GunType, out object gunTypeObj);

                if (!isGunTypeValid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var gun = new Gun()
                {
                    ManufacturerId = gDto.ManufacturerId,
                    GunWeight = gDto.GunWeight,
                    BarrelLength = gDto.BarrelLength,
                    NumberBuild = gDto.NumberBuild,
                    Range = gDto.Range,
                    GunType = (GunType)gunTypeObj,
                    ShellId = gDto.ShellId
                };

                foreach (var cDto in gDto.Countries)
                {
                    var countryGun = new CountryGun()
                    {
                        Gun = gun,
                        CountryId = cDto.Id
                    };

                    gun.CountriesGuns.Add(countryGun);
                }

                validGuns.Add(gun);
                sb.AppendLine(String.Format(SuccessfulImportGun, gun.GunType, gun.GunWeight, gun.BarrelLength));
            }

            context.Guns.AddRange(validGuns);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }
        private static bool IsValid(object obj)
        {
            var validator = new ValidationContext(obj);
            var validationRes = new List<ValidationResult>();

            var result = Validator.TryValidateObject(obj, validator, validationRes, true);
            return result;
        }
    }
}
