using System.Windows.Controls;
using GrimFortico.kernel;
using GrimFortico.models;

namespace GrimFortico.view;

public partial class Account : Page
{
    public Account()
    {
        InitializeComponent();
        string istring = Session._sessionId.ToString();
        Client client = new ClientQuery().GetClient("id", istring, "");
        this.clientConnected.Text = $"Bonjour, {client._firstName} {client._lastName}";
    }
}