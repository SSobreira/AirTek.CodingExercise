using AirTek.CodingExercise;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
 
public partial class Program
{
    /// <summary>
    /// Method to extract the file path from command line arguments
    /// </summary>
    /// <param name="args"></param>
    /// <returns></returns>
    public static string GetFlightSchedulePath(string[] args)
    {
        for (int i = 0; i < args.Length; i++)
        {
            if (args[i] == "-flights" && i + 1 < args.Length)
            {
                return args[i + 1];
            }
        }
        return null;
    }

    /// <summary>
    /// Method to load the flight schedule data from a JSON file
    /// </summary>
    /// <param name="filePath"></param>
    /// <returns></returns>
    public static List<FlightSchedule> LoadFlightSchedule(string filePath)
    {
        List<FlightSchedule> defaultFlights = new List<FlightSchedule>() { new FlightSchedule (1,"YUL","YYZ", 1),
                                                                        new FlightSchedule (2,"YUL","YYC", 1),
                                                                        new FlightSchedule (3,"YUL","YVR", 1),
                                                                        new FlightSchedule (4,"YUL","YYZ", 2),
                                                                        new FlightSchedule (5,"YUL","YYC", 2),
                                                                        new FlightSchedule (6,"YUL","YVR", 2)};
        if (filePath == null)
        {
            Console.WriteLine($"Continuing with default data.\n ");
            return defaultFlights;
        }

        try
        {
            string jsonContent = File.ReadAllText(filePath);
            List<FlightSchedule> flightSchedules = JsonSerializer.Deserialize<List<FlightSchedule>>(jsonContent);
            return flightSchedules;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Unable to read JSON file, continuing with default data.\n ");
            return defaultFlights;
        }
    }

    /// <summary>
    /// Analyzing and returning Flights
    /// </summary>
    /// <param name="orders"></param>
    /// <param name="FlightSchedule"></param>
    public static void GenerateFlightSchedules(Dictionary<string, Order> orders, List<FlightSchedule> FlightSchedule)
    {
        // assuming orders list is empty in FlightSchedule
        // assuming orders are already sorted

        foreach (var order in orders)
        {
            var availableSchedule = FlightSchedule.FirstOrDefault(x => x.Arrival == order.Value.destination &&
                                                                        x.Orders.Count() < x.Capacity, null);
            if (availableSchedule != null)
            {
                availableSchedule.Orders.Add(order.Value);
                Console.WriteLine($"order: {order.Key}, flightNumber: {availableSchedule.Id}, " +
                                    $"departure: {availableSchedule.Departure}, arrival: {availableSchedule.Arrival}, day: {availableSchedule.Day}");
            }
            else
            {
                Console.WriteLine($"order: {order.Key}, flightNumber: not scheduled");
            }
        }
    }
} 
