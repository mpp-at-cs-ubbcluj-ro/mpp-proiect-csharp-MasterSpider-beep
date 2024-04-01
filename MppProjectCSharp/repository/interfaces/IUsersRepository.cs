using TemaC.domain;

namespace MppProjectCSharp.repository.interfaces;

public interface IUsersRepository
{
    public bool ExistsUser(string username, string password);
    public User? GetOne(String username);
}