using GrimFortico.models;

namespace GrimFortico.controllers;

public class ClientController
{
    public bool auth(string email, string pin)
    {
        Client cred = new ClientQuery().GetClient("email", email, "");
        if (pin == cred._pin)
        {
            kernel.Session._sessionId = cred._id;
            return true;
        }
        return false;
    }
}