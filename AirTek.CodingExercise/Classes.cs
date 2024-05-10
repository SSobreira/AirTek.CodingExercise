using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTek.CodingExercise
{
    public class Order
    {
        public string destination { get; set; }
    }

    public class FlightSchedule
    {
        public FlightSchedule(int id, string departure, string arrival, int day)
        {
            Id = id;
            Departure = departure;
            Arrival = arrival;
            Day = day;
        }

        public int Id { get; set; }
        public int Day { get; set; }
        public string Departure { get; set; }
        public string Arrival { get; set; }
        public List<Order> Orders { get; set; } = new List<Order>();//Could add limitation here in regards to capacity, but keeping it simple as requested

        public int Capacity = 20;

    }
}
