namespace TemaC.domain.DTOs;

public class FlightFilter
{
    private DateOnly? departureDate;
    private string? destination;

    public string? Destination { get => destination; set => destination = value; }
    public DateOnly? DepartureDate { get => departureDate; set => departureDate = value; }

    public FlightFilter(string destination, DateOnly departureDate)
    {
        Destination = destination;
        DepartureDate = departureDate;
    }

    public FlightFilter(string destination)
    {
        Destination = destination;
        DepartureDate = null;
    }

    public FlightFilter(DateOnly departureDate)
    {
        DepartureDate = departureDate;
        Destination = null;
    }

    public FlightFilter()
    {
        DepartureDate = null;
        Destination = null;
    }
}