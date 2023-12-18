using System;
using System.Collections.Generic;

namespace Exam.PackageManagerLite
{
    public class PackageManager : IPackageManager
    {
        public void AddDependency(string packageId, string dependencyId)
        {
            throw new NotImplementedException();
        }

        public bool Contains(Package package)
        {
            throw new NotImplementedException();
        }

        public int Count()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Package> GetDependants(Package package)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Package> GetIndependentPackages()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Package> GetOrderedPackagesByReleaseDateThenByVersion()
        {
            throw new NotImplementedException();
        }

        public void RegisterPackage(Package package)
        {
            throw new NotImplementedException();
        }

        public void RemovePackage(string packageId)
        {
            throw new NotImplementedException();
        }
    }
}
