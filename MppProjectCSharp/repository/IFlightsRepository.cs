using TemaC.domain;
using TemaC.domain.DTOs;

namespace TemaC.repository;

public interface IFlightsRepository
{
    public List<Flight> GetAll();
    public List<Flight> GetFiltered(FlightFilter filter);
    public bool Update(Flight flight);
}