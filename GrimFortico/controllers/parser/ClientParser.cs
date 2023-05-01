using GrimFortico.models;

namespace GrimFortico.controllers.parser;

public class ClientParser
{
    public static Client Parse(string[] values)
    {
        int id = int.Parse(values[0]);
        //comment savoir qu'elle valeur à été renvoyé ?
        return new Client(id, values[1], values[2], values[3], values[4], values[5]);
    }
}