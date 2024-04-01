namespace TemaC.domain;

public class User : Entity
{
    private string username;
    private string password;

    public User(string username, string password)
    {
        this.password = password;
        this.username = username;
    }

    public string Username { get => username; set => username = value; }
    public string Password { get => password; set => password = value; }
}