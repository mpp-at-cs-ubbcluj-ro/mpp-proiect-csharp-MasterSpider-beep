namespace TemaC.repository;

public interface IUsersRepository
{
    public bool ExistsUser(string username, string password);
}