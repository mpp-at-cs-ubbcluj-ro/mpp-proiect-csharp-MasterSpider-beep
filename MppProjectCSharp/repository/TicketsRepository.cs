using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemaC.domain;
using TemaC.repository;

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
            throw new NotImplementedException();
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
                        List<string> realtourists = tourists.Split(" ").ToList();
                        Ticket ticket = new Ticket(clientName, address, noSeats);
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
                        List<string> realtourists = tourists.Split(" ").ToList();
                        Ticket ticket = new Ticket(clientName, address, noSeats);
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
