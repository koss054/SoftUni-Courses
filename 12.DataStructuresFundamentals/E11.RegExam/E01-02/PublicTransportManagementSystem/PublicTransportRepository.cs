using System;
using System.Collections.Generic;
using System.Linq;

namespace PublicTransportManagementSystem
{
    public class PublicTransportRepository : IPublicTransportRepository
    {
        private Dictionary<string, Passenger> passengers
            = new Dictionary<string, Passenger>();

        private Dictionary<string, Bus> buses =
            new Dictionary<string, Bus>();

        private Dictionary<string, string> passengersInBus =
            new Dictionary<string, string>();

        public void AddBus(Bus bus)
        {
            buses.Add(bus.Id, bus);
        }

        public void BoardBus(Passenger passenger, Bus bus)
        {
            if (!passengers.ContainsKey(passenger.Id) || !buses.ContainsKey(bus.Id))
                throw new ArgumentException();

            passengersInBus.Add(passenger.Id, bus.Id);
        }

        public bool Contains(Passenger passenger)
            => passengers.ContainsKey(passenger.Id);

        public bool Contains(Bus bus)
            => buses.ContainsKey(bus.Id);

        public IEnumerable<Bus> GetBuses()
            => buses.Values;

        public IEnumerable<Bus> GetBusesOrderedByOccupancy()
        {
            var busesByPassengerId = new Dictionary<string, List<string>>();

            foreach (var passenger in passengersInBus)
            {
                if (!busesByPassengerId.ContainsKey(passenger.Value))
                    busesByPassengerId[passenger.Value] = new List<string>();

                busesByPassengerId[passenger.Value].Add(passenger.Key);
            }

            return busesByPassengerId
                .OrderByDescending(x => x.Value.Count)
                .Select(x => buses[x.Key]);
        }

        public IEnumerable<Bus> GetBusesWithCapacity(int capacity)
            => buses.Values.Where(x => x.Capacity >= capacity);

        public IEnumerable<Passenger> GetPassengersOnBus(Bus bus)
        {
            var passengersKeys = passengersInBus
                .Where(x => x.Value == bus.Id)
                .Select(x => x.Key);

            var passengersToReturn = new List<Passenger>();

            foreach (var passengerKey in passengersKeys)
                passengersToReturn.Add(passengers[passengerKey]);

            return passengersToReturn;
        }

        public void LeaveBus(Passenger passenger, Bus bus)
        {
            if (!passengers.ContainsKey(passenger.Id) || !buses.ContainsKey(bus.Id))
                throw new ArgumentException();

            var passengersKeys = passengersInBus
                .Where(x => x.Value == bus.Id)
                .Select(x => x.Key);

            if (!passengersKeys.Contains(passenger.Id))
                throw new ArgumentException();

            passengersInBus.Remove(passenger.Id);
        }

        public void RegisterPassenger(Passenger passenger)
        {
            passengers.Add(passenger.Id, passenger);
        }
    }
}