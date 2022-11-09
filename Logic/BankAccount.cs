public class BankAccount
{
    public float Withdraw { get; set; }
    public float Insert { get; set; }
    public float Summery { get; set; }
    public int AccountNumber { get; set; }
    public List<User> user = new();
    public List<Card> card = new();
    public List<Transactions> transactions = new();


}