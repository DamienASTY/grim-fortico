using GrimFortico.controllers.parser;
using GrimFortico.kernel;
using MySql.Data.MySqlClient;


namespace GrimFortico.models;

public class ClientQuery: Factory
{
    public Client GetClient(string selector, string selectorValue, string valuesToRetrieve)
    {
        //string query = "SELECT" +valuesToRetrieve+ " FROM client ";
        string query = "SELECT * FROM client ";
        switch (selector)
        {
            case "id":
                query += "WHERE id = " + selectorValue;
                break;
            case "email":
                query += " WHERE email = '" + selectorValue + "'"; 
                break;
            default:
                //trouvez un moyen propre de régler cet posibilités
                return null; 
                break;
        }
        MySqlCommand command = new MySqlCommand(query, _connection);
        MySqlDataReader reader = command.ExecuteReader();
        string[] values = new string[6];
        if (reader.Read())
        {
            for (int i = 0; i < reader.FieldCount; i++)
            {
                values[i] = reader.GetString(i);
            }
            closeReader(reader);
            return ClientParser.Parse(values);
        }
        closeReader(reader);
        return null;
    }
    
    //Pour la réalisation de ce travaille on imagine que l'on ne créera plus de client
    public bool CreateClient()
    {
        return false;
    }
    
    //Pour la réalisation de ce travaille on imagine que l'on ne mettera plus à jour de client
    public bool UpdateClient()
    {
        return false;
    }
    
    //Pour la réalisation de ce travaille on imagine que l'on ne supprimera pas de client
    public bool RemoveClient()
    {
        return false;
    }
}