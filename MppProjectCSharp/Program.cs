using log4net.Config;
using MppProjectCSharp.repository;
using System.Configuration;
using System.Diagnostics;
using TemaC.domain;
using TemaC.domain.DTOs;
using TemaC.repository;

namespace MppProjectCSharp
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        //static void Main()
        //{
        //    // To customize application configuration such as set high DPI settings or default font,
        //    // see https://aka.ms/applicationconfiguration.
        //    ApplicationConfiguration.Initialize();
        //    Application.Run(new Form1());
        //}

        static void Main(string[] args)
        {
            XmlConfigurator.Configure();
            IDictionary<String, string> props = new SortedList<String, String>();
            props.Add("ConnectionString", GetConnectionStringByName("AgentieDB"));
            test(props);
            
        }

        static private void test(IDictionary<String, string> props)
        {
            IUsersRepository users = new UsersRepository(props);
            Debug.Assert(users.ExistsUser("admin", "admin"));

            IFlightsRepository repoFlights = new FlightsRepository(props);
            List<Flight> flights = repoFlights.GetFiltered(new FlightFilter("test"));
            Debug.Assert(flights.Count == 2);
            flights = repoFlights.GetFiltered(new FlightFilter("test", new DateOnly(2024, 1, 1)));
            Debug.Assert(flights.Count == 1);
            Flight flight = flights.ElementAt(0);
            flight.AvailableSeats = 20;
            repoFlights.Update(flight);
            flights = repoFlights.GetFiltered(new FlightFilter("test", new DateOnly(2024, 1, 1)));
            Debug.Assert(flights.ElementAt(0).AvailableSeats == 20);
            flight.AvailableSeats = 10;
            repoFlights.Update(flight);

        }
        static string GetConnectionStringByName(string name)
        {
            // Assume failure.
            string returnValue = null;

            // Look for the name in the connectionStrings section.
            ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings[name];

            // If found, return the connection string.
            if (settings != null)
                returnValue = settings.ConnectionString;

            return returnValue;
        }
    }
}