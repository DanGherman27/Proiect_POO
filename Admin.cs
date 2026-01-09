namespace Proiect_POO;

public class Admin
{
    private string _password1 = "admin";
    private string _password2 = "ADMIN";
    public string Password { get; }

    public Admin(string password)
    {
        Password = password ?? throw new ArgumentException();
    }

    public bool MatchPassword()
    {
        return Password == _password1 || Password == _password2;
    }
}