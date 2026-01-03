namespace Proiect_POO;

public class Admin
{
    private string _password1 = "admin";
    private string _password2 = "ADMIN";
    public string Password { get; }

    private int _matchPassword;

    public Admin(string password)
    {
        if (string.IsNullOrWhiteSpace(password))
            throw new ArgumentException("Parola invalida");
        
        Password = password;
    }

    public int MatchPassword()
    {
        if (Password == _password1 ||  Password == _password2)
            _matchPassword = 1;
        else
            _matchPassword = 0;
        
        return _matchPassword;
    }
}