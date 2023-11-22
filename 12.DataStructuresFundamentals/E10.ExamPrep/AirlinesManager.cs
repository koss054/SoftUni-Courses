using System;
using System.Collections.Generic;
using System.Linq;

namespace Exam.DeliveriesManager
{
	public class AirlinesManager : IAirlinesManager
	{
		private readonly List<Airline> _airlines = new List<Airline>();
		private readonly List<Flight> _flights = new List<Flight>();

		public void AddAirline(Airline airline)
		{
			_airlines.Add(airline);
		}

		public void AddFlight(Airline airline, Flight flight)
		{
			var currentAirline = _airlines
				.FirstOrDefault(x => x.Id.Equals(airline.Id));

			if (currentAirline is null)
				throw new ArgumentException();

			_flights.Add(flight);
			currentAirline.Flights.Add(flight);
		}

		public bool Contains(Airline airline)
			=> _airlines.Any(x => x.Id.Equals(airline.Id));

		public bool Contains(Flight flight)
			=> _flights.Any(x => x.Id.Equals(flight.Id));

		public void DeleteAirline(Airline airline)
		{
			var airlineToDelete = _airlines
				.FirstOrDefault(x => x.Id.Equals(airline.Id));

			if (airlineToDelete is null)
				throw new ArgumentException();

			var flightsToDelete = airlineToDelete.Flights;

			_flights.RemoveAll(x => flightsToDelete.Contains(x));
			_airlines.Remove(airlineToDelete);
		}

		public IEnumerable<Airline> GetAirlinesOrderedByRatingThenByCountOfFlightsThenByName()
			=> _airlines
				.OrderByDescending(x => x.Rating)
				.ThenByDescending(x => x.Flights.Count)
				.ThenBy(x => x.Name);

		public IEnumerable<Airline> GetAirlinesWithFlightsFromOriginToDestination(string origin, string destination)
			=> _airlines
				.Where(a => a.Flights
					.Where(f => !f.IsCompleted
						&& f.Origin.Equals(origin)
						&& f.Destination.Equals(destination))
					.Count() >= 1);

		public IEnumerable<Flight> GetAllFlights()
			=> _flights;

		public IEnumerable<Flight> GetCompletedFlights()
			=> _flights
				.Where(f => f.IsCompleted);

		public IEnumerable<Flight> GetFlightsOrderedByCompletionThenByNumber()
			=> _flights
				.OrderBy(x => x.IsCompleted)
				.ThenBy(x => x.Number);

		public Flight PerformFlight(Airline airline, Flight flight)
		{
			var flightToComplete = _flights
				.FirstOrDefault(x => x.Id.Equals(flight.Id));

			if (!_airlines.Any(x => x.Id.Equals(airline.Id)) || flightToComplete is null)
				throw new ArgumentException();

			flightToComplete.IsCompleted = true;
			return flightToComplete;
		}
	}
}
