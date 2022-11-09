namespace Logic;

using Dapper;

public class Account
{
    private static Database db = new();
    public int ID { get; set; }
    public float Balance { get; set; }
    public string AccountNumber { get; set; }
    public List<User> Users = new();
    public List<Card> Cards = new();
    public List<Transactions> Transactions = new();

    public bool Deposit(float amount)
    {
        try
        {
            if (amount > 0.0)
            {
                Balance += amount;
                db.Connection.Execute($"UPDATE account SET account.balance = '{Balance}' WHERE id = '{ID}'");
            }
            return true;
        }
        catch { return false; }
    }

    public bool Withdraw(float amount)
    {
        try
        {
            if (Balance >= amount)
            {
                Balance -= amount;
                db.Connection.Execute($"UPDATE account SET account.balance = '{Balance}' WHERE id = '{ID}'");
            }
            return true;
        }
        catch { return false; }
    }
}
