
namespace Artillery.DataProcessor
{
    using Artillery.Data;
    using Artillery.DataProcessor.ExportDto;
    using Newtonsoft.Json;
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;

    public class Serializer
    {
        public static string ExportShells(ArtilleryContext context, double shellWeight)
        {
            var shells = context
                 .Shells
                 .ToArray()
                 .Where(s => s.ShellWeight > shellWeight)
                 .Select(s => new
                 {
                     ShellWeight = s.ShellWeight,
                     Caliber = s.Caliber,
                     Guns = s.Guns
                         .Where(g => g.ShellId == s.Id && g.GunType.ToString() == "AntiAircraftGun")
                         .Select(g => new
                         {
                             GunType = g.GunType.ToString(),
                             GunWeight = g.GunWeight,
                             BarrelLength = g.BarrelLength,
                             Range = g.Range > 3000 ? "Long-range" : "Regular range"
                         })
                         .OrderByDescending(g => g.GunWeight)
                         .ToArray()
                 })
                 .OrderBy(s => s.ShellWeight)
                 .ToArray();

            string json = JsonConvert.SerializeObject(shells, Formatting.Indented);
            return json;
        }

        public static string ExportGuns(ArtilleryContext context, string manufacturer)
        {
            var guns = context
                .Guns
                .Where(g => g.Manufacturer.ManufacturerName == manufacturer)
                .Select(g => new ExportGunWithCountriesDto()
                {
                    Manufacturer = g.Manufacturer.ManufacturerName,
                    GunType = g.GunType.ToString(),
                    GunWeight = g.GunWeight,
                    BarrelLength = g.BarrelLength,
                    Range = g.Range,
                    Countries = g.CountriesGuns
                        .Where(cg => cg.GunId == g.Id && cg.Country.ArmySize > 4500000)
                        .Select(cg => new ExportGunCountriesDto()
                        {
                            Country = cg.Country.CountryName,
                            ArmySize = cg.Country.ArmySize
                        })
                        .OrderBy(cg => cg.ArmySize)
                        .ToArray()
                })
                .OrderBy(g => g.BarrelLength)
                .ToArray();

            var sb = new StringBuilder();

            using (StringWriter writer = new StringWriter(sb))
            {
                XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
                namespaces.Add(string.Empty, string.Empty);

                XmlRootAttribute xmlRoot = new XmlRootAttribute("Guns");
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportGunWithCountriesDto[]), xmlRoot);

                xmlSerializer.Serialize(writer, guns, namespaces);
            }

            return sb.ToString().TrimEnd();
        }
    }
}
