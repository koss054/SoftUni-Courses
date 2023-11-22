using System;
using System.Collections.Generic;
using System.Linq;

namespace Exam.DeliveriesManager
{
    public class AirlinesManager : IAirlinesManager
    {
        private Dictionary<string, Airline> _airlinesById = new Dictionary<string, Airline>();
        private Dictionary<string, Flight> _flightsById = new Dictionary<string, Flight>();
        private Dictionary<string, string> _flightsByAirline = new Dictionary<string, string>();

        public void AddAirline(Airline airline)
        {
            _airlinesById.Add(airline.Id, airline);
        }

        public void AddFlight(Airline airline, Flight flight)
        {
            if (!_airlinesById.ContainsKey(airline.Id))
                throw new ArgumentException();

            _flightsById.Add(flight.Id, flight);
            _flightsByAirline.Add(flight.Id, airline.Id);
        }

        public bool Contains(Airline airline)
            => _airlinesById.ContainsKey(airline.Id);

        public bool Contains(Flight flight)
            => _flightsById.ContainsKey(flight.Id);

        public void DeleteAirline(Airline airline)
        {
            if (!_airlinesById.ContainsKey(airline.Id))
                throw new ArgumentException();

            foreach (var flight in _flightsById.Values)
                _flightsById.Remove(flight.Id);

            _airlinesById.Remove(airline.Id);
        }

        public IEnumerable<Airline> GetAirlinesOrderedByRatingThenByCountOfFlightsThenByName()
            => _airlinesById.Values
                .OrderByDescending(x => x.Rating)
                .ThenByDescending(x => x.Flights.Count)
                .ThenBy(x => x.Name);

        public IEnumerable<Airline> GetAirlinesWithFlightsFromOriginToDestination(string origin, string destination)
            => _airlinesById.Values
                .Where(a => a.Flights
                    .Any(f => !f.IsCompleted
                        && f.Origin.Equals(origin)
                        && f.Destination.Equals(destination)));

        public IEnumerable<Flight> GetAllFlights()
            => _flightsById.Values;

        public IEnumerable<Flight> GetCompletedFlights()
            => _flightsById.Values
                .Where(f => f.IsCompleted);

        public IEnumerable<Flight> GetFlightsOrderedByCompletionThenByNumber()
            => _flightsById.Values
                .OrderBy(x => x.IsCompleted)
                .ThenBy(x => x.Number);

        public Flight PerformFlight(Airline airline, Flight flight)
        {
            if (!_airlinesById.ContainsKey(airline.Id) || !_flightsById.ContainsKey(flight.Id))
                throw new ArgumentException(); 
            
            _flightsById[flight.Id].IsCompleted = true;
            return _flightsById[flight.Id];
        }
    }
}
