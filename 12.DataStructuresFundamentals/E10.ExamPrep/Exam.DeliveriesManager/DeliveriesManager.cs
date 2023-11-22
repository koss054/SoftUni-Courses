using System;
using System.Collections.Generic;
using System.Linq;

namespace Exam.DeliveriesManager
{
    public class DeliveriesManager : IDeliveriesManager
    {
        private Dictionary<string, Deliverer> deliverersById = 
            new Dictionary<string, Deliverer>();

        private Dictionary<string, Package> packagesById = 
            new Dictionary<string, Package>();

        private Dictionary<string, string> packagesByDeliverer = 
            new Dictionary<string, string>();

        public void AddDeliverer(Deliverer deliverer)
        {
            deliverersById.Add(deliverer.Id, deliverer);
        }

        public void AddPackage(Package package)
        {
            packagesById.Add(package.Id, package);
        }

        public void AssignPackage(Deliverer deliverer, Package package)
        {
            if (!deliverersById.ContainsKey(deliverer.Id)
                || !packagesById.ContainsKey(package.Id))
                throw new ArgumentException();

            packagesByDeliverer.Add(package.Id, deliverer.Id);
        }

        public bool Contains(Deliverer deliverer)
            => deliverersById.ContainsKey(deliverer.Id);

        public bool Contains(Package package)
            => packagesById.ContainsKey(package.Id);

        public IEnumerable<Deliverer> GetDeliverers()
            => deliverersById.Values;

        public IEnumerable<Deliverer> GetDeliverersOrderedByCountOfPackagesThenByName()
        {
            var deliverersByPackageId = new Dictionary<string, List<string>>();

            foreach (var package in packagesByDeliverer)
            {
                if (!deliverersByPackageId.ContainsKey(package.Value))
                    deliverersByPackageId.Add(package.Value, new List<string>());

                deliverersByPackageId[package.Value].Add(package.Key);
            }

            return deliverersByPackageId
                .OrderByDescending(x => x.Value.Count)
                .ThenBy(x => deliverersById[x.Key].Name)
                .Select(x => deliverersById[x.Key]);
        }

        public IEnumerable<Package> GetPackages()
            => packagesById.Values;

        public IEnumerable<Package> GetPackagesOrderedByWeightThenByReceiver()
            => packagesById.Values
                .OrderByDescending(x => x.Weight)
                .ThenBy(x => x.Receiver);

        public IEnumerable<Package> GetUnassignedPackages()
            => packagesById
                .Where(x => !packagesByDeliverer.ContainsKey(x.Key))
                .Select(x => x.Value);
    }
}
