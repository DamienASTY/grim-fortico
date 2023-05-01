using System.Collections.Generic;
using System.Data;
using System.Windows.Documents;
using GrimFortico.kernel;

using MySql.Data.MySqlClient;
using GrimFortico.models;
namespace GrimFortico.models;

public class CurrentAccountQuery: Factory
{
    
    //@client est en fait l'id stocké dans la session
    public DataTable getAllAccounts(string client)
    {
        string query = $"SELECT * FROM currentaccount WHERE client = {client}";
        /*MySqlCommand command = new MySqlCommand(query, _connection);
        command.ExecuteNonQuery();

        List<CurrentAccount> accounts = new List<CurrentAccount>();
        MySqlDataReader reader = command.ExecuteReader();

        while (reader.Read())
        {
            int id = reader.GetInt32("id");
            int client = reader.GetInt32("client");
            string firstName = reader.GetString("first_name");
            string lastName = reader.GetString("last_name");
            string email = reader.GetString("email");

            CurrentAccount account = new CurrentAccount(id, client, firstName, lastName, email);
            accounts.Add(account);
        }

        reader.Close();*/
        MySqlDataAdapter dataAdapter = new MySqlDataAdapter(query, _connection);
        DataTable datas = new DataTable();
        dataAdapter.Fill(datas);
        return datas;
    }
    
    public void deposit(float amount, string to)
    {
        float lastBalance = GetBalance(to);
        
        string query = $"UPDATE currentaccount SET balance = {amount+lastBalance} WHERE number = '{to}'";        
        MySqlCommand command = new MySqlCommand(query, _connection);
        command.ExecuteNonQuery();
        TransactionQuery tq = new TransactionQuery();
        tq.make(amount, "distributeur", to, "deposit");
    }
    
    public float GetBalance(string account)
    {
        string query = $"SELECT balance FROM currentaccount WHERE number = '{account}'";
        MySqlCommand command = new MySqlCommand(query, _connection);
        MySqlDataReader reader = command.ExecuteReader();
        reader.Read();
        float balance = float.Parse(reader.GetString(0));
        reader.Close();
        return balance;
    }
}