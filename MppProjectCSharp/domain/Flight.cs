namespace TemaC.domain;

public class Flight : Entity
{
    private string destination;
    private DateOnly departureDate;
    private TimeOnly departureTime;
    private int availableSeats;
    private string airport;

    public string Destination { get => destination; set => destination = value; }
    public DateOnly DepartureDate { get => departureDate; set => departureDate = value; }
    public TimeOnly DepartureTime { get => departureTime; set => departureTime = value; }
    public int AvailableSeats { get => availableSeats; set => availableSeats = value; }
    public string Airport { get => airport; set => airport = value; }

    public Flight(string destination, DateOnly departureDate, TimeOnly departureTime, int availableSeats, string airport)
    {
        Destination = destination;
        DepartureDate = departureDate;
        DepartureTime = departureTime;
        AvailableSeats = availableSeats;
        Airport = airport;
    }


}