using TemaC.domain;

namespace TemaC.repository;

public interface ITicketsRepository
{
    public Ticket GetOne(int id);
    public List<Ticket> GetAll();
    public bool AddOne(Ticket ticket);
}