using GrimFortico.kernel;
using MySql.Data.MySqlClient;

namespace GrimFortico.models;

public class TransactionQuery: Factory
{
    public void make(float amount, string from, string to, string type)
    {
        string query = $"INSERT INTO transaction (from_account, to_account, amount, type) VALUES ('{from}', '{to}', {amount}, '{type}')";
        MySqlCommand command = new MySqlCommand(query, _connection);
        command.ExecuteNonQuery();
    }
}