using System;

namespace Exam.PackageManagerLite
{
    public class Package
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public DateTime ReleaseDate { get; set; }

        public string Version { get; set; }

        public Package(string id, string name, DateTime releaseDate, string version)
        {
            Id = id;
            Name = name;
            ReleaseDate = releaseDate;
            Version = version;
        }
    }
}
