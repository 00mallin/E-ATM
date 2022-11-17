public class Transactions
{
    public int ID { get; set; }
    public DateTime Date { get; set; }
    public float Amount { get; set; }

    public override string ToString()
    {
        return ID + ".  Amount: " + Amount + " kr  " + Date + "\n";
    }
}