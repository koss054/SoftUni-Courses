﻿using System.Xml.Serialization;

namespace Artillery.DataProcessor.ExportDto
{
    [XmlType("Gun")]
    public class ExportGunWithCountriesDto
    {
        [XmlAttribute("Manufacturer")]
        public string Manufacturer { get; set; }

        [XmlAttribute("GunType")]
        public string GunType { get; set; }

        [XmlAttribute("GunWeight")]
        public int GunWeight { get; set; }

        [XmlAttribute("BarrelLength")]
        public double BarrelLength { get; set; }

        [XmlAttribute("Range")]
        public int Range { get; set; }

        [XmlArray("Countries")]
        public ExportGunCountriesDto[] Countries { get; set; }
    }
}
