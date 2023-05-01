using System;
using MySql.Data.MySqlClient;

namespace GrimFortico.kernel;

/*  Cette classe sert à instancier la connexion pour ne pas répeter
    L'opération à chaque controller (MySQL Controller)
 */
public class Factory
{
    private static string _connectionString;
    protected static MySqlConnection _connection;
    
    public static bool setConnection(string db, string user, string password)
    {
        _connectionString = "server=localhost;database=" + db + ";user=" + user + ";password=" + password;
        try
        {
            _connection = new MySqlConnection(_connectionString);
            _connection.Open();
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return false;
        }
    }
    
    public void closeReader(MySqlDataReader reader)
    {
        if (reader != null)
        {
            reader.Close();
        }
    }
    
    ~Factory()
    {
        _connection.Close();
    }
}