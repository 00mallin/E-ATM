namespace Logic;

using Dapper;

public class BankAccount
{
    private static Database db = new();
    public int ID { get; set; }
    public float Balance { get; set; }
    public int AccountNumber { get; set; }
    public List<User> user = new();
    public List<Card> card = new();
    public List<Transactions> transactions = new();

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