using MySqlConnector;
using Dapper;

namespace Logic;

public class Database
{
    public MySqlConnection Connection { get; private set; }
    private string connectionString = "Server=familjenlindh.se;Database=e_atm;Uid=eatm;Pwd=atm123";

    public Database()
    {
        Connection = new(connectionString);
    }

    public bool GetCard(string CardNumber)
    {
        var Cardfound = Connection.QuerySingleOrDefault($"SELECT COUNT(id) FROM card WHERE card_number = '{CardNumber}'");

        if (Cardfound >= 1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
