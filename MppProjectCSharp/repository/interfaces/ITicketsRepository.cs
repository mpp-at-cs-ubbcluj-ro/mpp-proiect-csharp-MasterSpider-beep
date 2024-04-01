using TemaC.domain;

namespace MppProjectCSharp.repository.interfaces;

public interface ITicketsRepository
{
    public Ticket GetOne(int id);
    public List<Ticket> GetAll();
    public bool AddOne(Ticket ticket);
}