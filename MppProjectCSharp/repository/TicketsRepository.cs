using log4net;
using MppProjectCSharp.repository.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemaC.domain;

namespace MppProjectCSharp.repository
{
    internal class TicketsRepository:ITicketsRepository
    {
        private static readonly ILog log = LogManager.GetLogger("UsersRepository");

        IDictionary<String, string> props;

        public TicketsRepository(IDictionary<String, string> props)
        {
            this.props = props;
        }

        public bool AddOne(Ticket ticket)
        {
            log.InfoFormat("Entering AddOne with ticket: {0}", ticket.ToString());
            using(var connection = DBUtils.DBUtils.getConnection(props))
            {
                var command = connection.CreateCommand();
                command.CommandText = "insert into Tickets(tourists, clientName, address, noSeats, flight_id) values (@tourists, @clientName, @address, @noSeats, @flightId)";

                string tourists = "";
                var touristsTemp = ticket.Tourists;
                foreach(var tourist in touristsTemp)
                {
                    tourists += tourist + ";";
                }
                var paramTourists = command.CreateParameter();
                paramTourists.ParameterName = "@tourists";
                paramTourists.Value = tourists;
                command.Parameters.Add(paramTourists);

                var paramClient = command.CreateParameter();
                paramClient.ParameterName = "@clientName";
                paramClient.Value = ticket.ClientName;
                command.Parameters.Add(paramClient);

                var paramAddress = command.CreateParameter();
                paramAddress.ParameterName = "@address";
                paramAddress.Value = ticket.Address;
                command.Parameters.Add(paramAddress);

                var paramSeats = command.CreateParameter();
                paramSeats.ParameterName = "@noSeats";
                paramSeats.Value = ticket.NoSeats;
                command.Parameters.Add(paramSeats);

                var paramFlight = command.CreateParameter();
                paramFlight.ParameterName = "@flightId";
                paramFlight.Value = ticket.FlightId;
                command.Parameters.Add(paramFlight);

                var result = command.ExecuteNonQuery();
                return result > 0;
            }
        }

        public List<Ticket> GetAll()
        {
            log.InfoFormat("Entering GetAll");
            List<Ticket> tickets = new List<Ticket>();
            var connection = DBUtils.DBUtils.getConnection(props);
            using(var command =  connection.CreateCommand())
            {
                command.CommandText = "select * from tickets";
                using(var result = command.ExecuteReader())
                {
                    while(result.Read())
                    {
                        int id = result.GetInt32(0);
                        string clientName = result.GetString(1);
                        string tourists = result.GetString(2);
                        string address = result.GetString(3);
                        int noSeats = result.GetInt32(4);
                        int flightId = result.GetInt32(5);
                        List<string> realtourists = tourists.Split(";").ToList();
                        Ticket ticket = new Ticket(clientName, address, noSeats,flightId);
                        ticket.Id= id;
                        foreach(var tourist in realtourists)
                        {
                            ticket.AddTourist(tourist);
                        }
                        tickets.Add(ticket);
                    }
                    log.InfoFormat("Exiting GetAll with tickets {0}", tickets.Count);
                    return tickets;
                }
            }
        }

        public Ticket GetOne(int id)
        {
            log.InfoFormat("Entering GetOne with id {0}", id);
            var connection = DBUtils.DBUtils.getConnection(props);
            using(var command = connection.CreateCommand())
            {
                command.CommandText = "select * from tickets where id=@id";
                var paramId = command.CreateParameter();
                paramId.ParameterName = "@id";
                paramId.Value = id;
                command.Parameters.Add(paramId);
                using(var result = command.ExecuteReader())
                {
                    if(result.Read())
                    {
                        string clientName = result.GetString(1);
                        string tourists = result.GetString(2);
                        string address = result.GetString(3);
                        int noSeats = result.GetInt32(4);
                        int flightId = result.GetInt32(5);
                        List<string> realtourists = tourists.Split(";").ToList();
                        Ticket ticket = new Ticket(clientName, address, noSeats, flightId);
                        ticket.Id = id;
                        foreach(var tourist in realtourists)
                        {
                            ticket.AddTourist(tourist);
                        }
                        log.InfoFormat("Exiting GetOne with ticket {0}", ticket);
                        return ticket;
                    }
                    return null;
                }
            }
        }
    }
}
