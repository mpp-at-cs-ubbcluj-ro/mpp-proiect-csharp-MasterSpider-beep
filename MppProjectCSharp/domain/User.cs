namespace TemaC.domain;

public class User : Entity
{
    private string username;
    private string password;

    public string Username { get => username; set => username = value; }
    public string Password { get => password; set => password = value; }
}