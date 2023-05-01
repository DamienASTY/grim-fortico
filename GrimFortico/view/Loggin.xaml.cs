using System.Windows;
using System.Windows.Controls;
using GrimFortico.controllers;
using MySqlX.XDevAPI;
using GrimFortico.kernel;
using Session = GrimFortico.kernel.Session;
using GrimFortico.view;

namespace GrimFortico.view;

public partial class Loggin : Page
{
    MainWindow window = (GrimFortico.MainWindow)App.Current.MainWindow;
    public Loggin()
    {
        InitializeComponent();
    }
    
    private void connection_button(object sender, RoutedEventArgs e)
    {
        string clientNumber = this.clientnumber.Text;
        string pin = this.pin.Text;
        login(clientNumber, pin);
    }

    private void login(string clientNumber, string pin)
    {
        ClientController cltrl = new ClientController();
        if (cltrl.auth(clientNumber, pin))
        {
            window.main.Content = new Account();
        }
        else
        {
            this.statusOutput.Text = "Error invalid credentials";
        }
    }
}