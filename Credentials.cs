namespace MyEasyBank_CSharp_BootCampApp;

internal class Credentials
{
    public string Username { get; private set; }
    public string Password { get; private set; }
    public string Mail { get; private set; }

    public Credentials(string username, string password, string mail)
    {
        this.Username = username;
        this.Password = password;
        this.Mail = mail;
    }
}