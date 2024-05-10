using AirTek.CodingExercise;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Metadata;
using System.Text.Json;
using static Program;

public partial class Program
{
    public static void Main(string[] args)
    {
        var fs = Main_UserStory1(args);
        Main_UserStory2(args, fs); 
    }

    /// <summary>
    /// This function expects  an argument "-flights" for a 'flight.json', otherwise will use the default one.
    /// </summary>
    /// <param name="args"></param>
    public static List<FlightSchedule> Main_UserStory1(string[] args)
    {
        Console.WriteLine("Starting Coding Exercise - User Story #1:");

        List<FlightSchedule> flightSchedules = LoadFlightSchedule(GetFlightSchedulePath(args));
        flightSchedules.ForEach(flightSchedule => Console.WriteLine($"Flight: {flightSchedule.Id}, departure: {flightSchedule.Departure}, arrival: {flightSchedule.Arrival}, day: {flightSchedule.Day}"));
        Console.WriteLine("\n \n ");

        return flightSchedules;
    }

    /// <summary>
    /// This function embedded json.
    /// </summary>
    /// <param name="args"></param>
    public static void Main_UserStory2(string[] args, List<FlightSchedule> flightSchedules)
    {
        Console.WriteLine("Starting Coding Exercise - User Story #2:\n ");


        string jsonString = string.Empty;
        using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("AirTek.CodingExercise.coding-assigment-orders.json"))
        {
            using (StreamReader reader = new StreamReader(stream))
            {
                jsonString = reader.ReadToEnd();
            }
        }
        Dictionary<string, Order> orders = JsonSerializer.Deserialize<Dictionary<string, Order>>(jsonString);


        GenerateFlightSchedules(orders, flightSchedules);
    } 
 }
