using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using GrimFortico.controllers;
using GrimFortico.kernel;
using GrimFortico.view;

namespace GrimFortico
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            bool connected = Factory.setConnection("heliobank", "root", "");
            if (connected)
            {
                Debug.Write("Database connected");
            }
            else
            {
                Debug.Write("Error during database connection");
            }
            main.Content = new Loggin();
        }
    }
}