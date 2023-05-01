namespace GrimFortico.models;

public class Client
{
    public int _id;
    public string _firstName;
    public string _lastName;
    public string _email;
    public string _password;
    public string _pin;

    public Client(int id, string firstName, string lastName, string email, string password, string pin)
    {
        this._id = id;
        this._firstName = firstName;
        this._lastName = lastName;
        this._email = email;
        this._password = password;
        this._pin = pin;
    }
}