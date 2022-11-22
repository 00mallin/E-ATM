public class Transactions
{
    public int ID { get; set; }
    public DateTime Date { get; set; }
    public decimal Amount { get; set; }

    public override string ToString()
    {
        return "Amount: " + Amount + " kr, " + Date.ToShortDateString();
    }
}