using System.Runtime.InteropServices.JavaScript;

namespace TemaC.domain;

public class Ticket : Entity
{
    private readonly List<string> tourists;
    private string clientName;
    private string address;
    private int noSeats;
    private int flightId;

    public Ticket(string clientName, string address, int noSeats, int flightId)
    {
        tourists = new List<string>();
        this.clientName = clientName;
        this.address = address;
        this.noSeats = noSeats;
        this.flightId = flightId;
    }

    public int FlightId { get => flightId; set => flightId = value; }
    public string ClientName { get => clientName; set => clientName = value; }
    public List<string> Tourists => tourists;
    public string Address { get => address; set => address = value; }
    public int NoSeats { get => noSeats; set => noSeats = value; }

    public void AddTourist(string tourist)
    {
        Tourists.Add(tourist);
    }
}