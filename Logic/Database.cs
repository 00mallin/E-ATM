using MySqlConnector;

namespace Logic;

class Database
{
    public MySqlConnection Connection { get; private set; }
    private string connectionString = "Server=familjenlindh.se;Database=e_atm;Uid=eatm;Pwd=atm123";

    public Database()
    {
        Connection = new(connectionString);
    }
}
