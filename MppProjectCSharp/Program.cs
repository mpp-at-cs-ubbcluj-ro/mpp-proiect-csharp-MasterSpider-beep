using log4net.Config;
using MppProjectCSharp.repository;
using MppProjectCSharp.repository.interfaces;
using System.Configuration;
using System.Diagnostics;
using System.Windows;
using TemaC.domain;
using TemaC.domain.DTOs;
using MppProjectCSharp.services;
using MppProjectCSharp.GUI;

namespace MppProjectCSharp
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        //static void Main()
        //{
        //    // To customize application configuration such as set high DPI settings or default font,
        //    // see https://aka.ms/applicationconfiguration.
        //    ApplicationConfiguration.Initialize();
        //    Application.Run(new Form1());
        //}

        private static services.Service createService(IDictionary<String, string> props)
        {
            IFlightsRepository flightsRepository = new FlightsRepository(props);
            ITicketsRepository ticketsRepository = new TicketsRepository(props);
            IUsersRepository usersRepository = new UsersRepository(props);

            return new services.Service(flightsRepository, ticketsRepository, usersRepository);
        }

        [STAThread]
        static void Main(string[] args)
        {
            XmlConfigurator.Configure();
            IDictionary<String, string> props = new SortedList<String, String>();
            props.Add("ConnectionString", GetConnectionStringByName("AgentieDB"));
            test(props);
            ApplicationConfiguration.Initialize();
            Service service = createService(props);
            LoginGUI loginGUI = new LoginGUI(service);
            Application.Run(loginGUI);
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
            Flight flight1;
            flight1 = repoFlights.GetFlight(1);
            Debug.Assert(flight1 == null);
            flight1 = repoFlights.GetFlight(3);
            Debug.Assert(flight1.Id == 3);
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