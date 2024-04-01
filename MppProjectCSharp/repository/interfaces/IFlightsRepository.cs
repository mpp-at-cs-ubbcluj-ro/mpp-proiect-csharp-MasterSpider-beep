using System.Runtime.InteropServices;
using TemaC.domain;
using TemaC.domain.DTOs;

namespace MppProjectCSharp.repository.interfaces;

public interface IFlightsRepository
{
    public List<Flight> GetAll();
    public List<Flight> GetFiltered(FlightFilter filter);
    public bool Update(Flight flight);
    public Flight? GetFlight(int id);
}