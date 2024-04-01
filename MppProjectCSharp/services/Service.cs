using MppProjectCSharp.repository.interfaces;
using MppProjectCSharp.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemaC.domain;
using TemaC.domain.DTOs;
using System.Runtime.CompilerServices;
using MppProjectCSharp.validators;

namespace MppProjectCSharp.services
{
    public class Service
    {
        private IFlightsRepository flightsRepository;
        private ITicketsRepository ticketsRepository;
        private IUsersRepository usersRepository;

        private FlightValidator flightValidator = new FlightValidator();
        private TicketValidator ticketValidator = new TicketValidator();

        public Service(IFlightsRepository flightsRepository, ITicketsRepository ticketsRepository, IUsersRepository usersRepository)
        {
            this.flightsRepository = flightsRepository;
            this.ticketsRepository = ticketsRepository;
            this.usersRepository = usersRepository;
        }

        public User? LogIn(string username, string password)
        {
            if(usersRepository.ExistsUser(username, password))
            {
                return usersRepository.GetOne(username);
            }
            else
            {
                throw new LogInException("Inccorect username and password combination!");
            }
        }

        public List<Flight> getAllFlights()
        {
            return flightsRepository.GetAll();
        }

        public List<Flight> getAllFilteredFlights(string? destination, DateOnly? departureDate)
        {
            var filter = new FlightFilter(destination, departureDate);
            return flightsRepository.GetFiltered(filter);

        }

        public bool buyTicket(int flightId, string clientName, string tourists, string address, int noSeats)
        {
            Flight flight;
            flight = flightsRepository.GetFlight(flightId);
            if(flight == null)
            {
                throw new ServiceException("This flight no longer exists!");
            }
            if(flight.AvailableSeats <= 0)
            {
                throw new ServiceException("This flight is full!");
            }
            List<string> touristsList = tourists.Split(';').ToList();
            Ticket ticket = new Ticket(clientName, address, noSeats, flight.Id);
            foreach(string tourist in touristsList)
            {
                ticket.AddTourist(tourist);
            }
            flight.AvailableSeats = flight.AvailableSeats - noSeats;
            if (!flightValidator.validate(flight))
            {
                throw new ServiceException("Not enough seats avialble!");
            }
            if (!ticketValidator.validate(ticket))
            {
                throw new ServiceException("Incorrect ticket data!");
            }
            flightsRepository.Update(flight);
            ticketsRepository.AddOne(ticket);
            return true;
        }

    }
}
