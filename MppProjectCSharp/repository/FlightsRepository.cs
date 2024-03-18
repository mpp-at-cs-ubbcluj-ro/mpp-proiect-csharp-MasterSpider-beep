using log4net;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemaC.domain;
using TemaC.domain.DTOs;
using TemaC.repository;

namespace MppProjectCSharp.repository
{
    internal class FlightsRepository : IFlightsRepository
    {

        private static readonly ILog log = LogManager.GetLogger("FlightsRepository");
        IDictionary<String, string> props;
        public FlightsRepository(IDictionary<String, string> props)
        {
            this.props = props;
        }
        public List<Flight> GetAll()
        {
            return GetFiltered(new FlightFilter());
        }

        private string GetSqlString(FlightFilter filter)
        {
            string sql = "select * from Flights";
            if(filter.Destination==null && filter.DepartureDate == null)
            {
                return sql;
            }
            else
            {
                sql += " where";
            }
            if (filter.Destination != null)
            {
                sql += " destination=@destination";
            }
            if(filter.DepartureDate != null && filter.Destination != null)
            {
                sql += " and departureDate=@departureDate";
            }else if(filter.DepartureDate !=null){
                sql += " departureDate=@departureDate";
            }
            return sql;
        }

        public List<Flight> GetFiltered(FlightFilter filter)
        {
            log.InfoFormat("Entering GetFiltered with destination:{0} , date{1}", filter.Destination, filter.DepartureDate);
            string sqlString = GetSqlString(filter);
            using (var connection = DBUtils.DBUtils.getConnection(props))
            {
                using(var command = connection.CreateCommand()) {
                    command.CommandText = sqlString;
                    if(filter.Destination != null)
                    {
                        var paramDest = command.CreateParameter();
                        paramDest.ParameterName = "@destination";
                        paramDest.Value = filter.Destination;
                        command.Parameters.Add(paramDest);
                    }
                    if(filter.DepartureDate!= null)
                    {
                        var paramDep = command.CreateParameter();
                        paramDep.ParameterName = "@departureDate";
                        paramDep.Value = filter.DepartureDate.Value.ToString("yyyy-MM-dd");
                        command.Parameters.Add(paramDep);
                    }
                    List<Flight> flights = new List<Flight>();
                    using(var result = command.ExecuteReader())
                    {
                        while (result.Read())
                        {
                            int id = result.GetInt32(0);
                            string destination = result.GetString(1);
                            DateOnly departureDate = DateOnly.Parse(result.GetString(2));
                            TimeOnly departureTime = TimeOnly.Parse(result.GetString(3));
                            int availableSeats = result.GetInt32(4);
                            string airport = result.GetString(5);
                            Flight flight = new Flight(destination, departureDate, departureTime, availableSeats, airport);
                            flight.Id = id;
                            flights.Add(flight);
                        }
                    }
                    log.InfoFormat("Exisitn findFiltered, found {0} flights!", flights.Count);
                    return flights;
                }
            }

        }

        public bool Update(Flight flight)
        {
            log.InfoFormat("Entering Update with flight id {0}", flight.Id);
            var connection = DBUtils.DBUtils.getConnection(props);
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "update flights set " +
                    "destination=@destination, departureDate=@departureDate, " +
                    "departureTime=@departureTime, availableSeats=@availableSeats, " +
                    "airport=@airport where id = @id";

                var paramDest = command.CreateParameter();
                paramDest.ParameterName = "@destination";
                paramDest.Value = flight.Destination;
                command.Parameters.Add(paramDest);

                var paramDepDate = command.CreateParameter();
                paramDepDate.ParameterName = "@departureDate";
                paramDepDate.Value = flight.DepartureDate.ToString("yyyy-MM-dd");
                command.Parameters.Add(paramDepDate);

                var paramDepTime = command.CreateParameter();
                paramDepTime.ParameterName = "@departureTime";
                paramDepTime.Value = flight.DepartureTime.ToString("HH:mm");
                command.Parameters.Add(paramDepTime);

                var paramSeats = command.CreateParameter();
                paramSeats.ParameterName = "@availableSeats";
                paramSeats.Value = flight.AvailableSeats;
                command.Parameters.Add(paramSeats);

                var parapAir = command.CreateParameter();
                parapAir.ParameterName = "@airport";
                parapAir.Value = flight.Airport;
                command.Parameters.Add(parapAir);

                var paramId = command.CreateParameter();
                paramId.ParameterName = "@id";
                paramId.Value = flight.Id;
                command.Parameters.Add(paramId);

                var result = command.ExecuteNonQuery();
                if(result==0)
                {
                    log.InfoFormat("Exiting Update with value {0}", false);
                    return false;
                }
                else
                {
                    log.InfoFormat("Exiting Update with value {0}", true);
                    return true;
                }
            }

        }
    }
}
