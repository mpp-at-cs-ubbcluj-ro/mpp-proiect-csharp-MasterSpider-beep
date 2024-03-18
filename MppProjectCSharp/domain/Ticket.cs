using System.Runtime.InteropServices.JavaScript;

namespace TemaC.domain;

public class Ticket : Entity
{
    private readonly List<string> tourists;
    private string clientName;
    private string address;
    private int noSeats;

    public Ticket(string clientName, string address, int noSeats)
    {
        ClientName = clientName;
        tourists = new List<string>();
        Address = address;
        this.NoSeats = noSeats;
    }

    public string ClientName { get => clientName; set => clientName = value; }
    public List<string> Tourists => tourists;
    public string Address { get => address; set => address = value; }
    public int NoSeats { get => noSeats; set => noSeats = value; }

    public void AddTourist(string tourist)
    {
        Tourists.Add(tourist);
    }
}