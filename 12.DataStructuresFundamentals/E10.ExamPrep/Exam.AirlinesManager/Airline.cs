using System;
using System.Collections.Generic;

namespace Exam.DeliveriesManager
{
    public class Airline : IComparable<Airline>
    {
        public Airline(string id, string name, double rating)
        {
            Id = id;
            Name = name;
            Rating = rating;
            Flights = new List<Flight>();
        }

        public string Id { get; set; }

        public string Name { get; set; }

        public double Rating { get; set; }

        public List<Flight> Flights { get; set; }

        public int CompareTo(Airline other)
        {
            return Flights.Count.CompareTo(other.Flights.Count);
        }
    }

    public class RatingComparer : IComparer<Airline>
    {
        public int Compare(Airline x, Airline y)
        {
            return x.Rating.CompareTo(y.Rating);
        }
    }

    public class FlightCountComparer : IComparer<Airline>
    {
        public int Compare(Airline x, Airline y)
        {
            return x.Flights.Count.CompareTo(y.Flights.Count);
        }
    }

    public class RatingFlightCountNameComparer : IComparer<Airline>
    {
        public int Compare(Airline x, Airline y)
        {
            // Rating - descending.
            var compareResult = y.Rating.CompareTo(x.Rating);
            if (compareResult != 0)
                return compareResult;

            // Flights count - ascending.
            compareResult = y.Flights.Count.CompareTo(x.Flights.Count);
            if (compareResult != 0)
                return compareResult;

            // Name - ascending.
            compareResult = x.Name.CompareTo(y.Name);
            return compareResult;
        }
    }
}
