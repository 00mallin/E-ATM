namespace Logic;

public class Card
{
    public int ID { get; set; }
    public int AccountID { get; set; }
    public string CardNumber { get; set; }
    public string CardHolder { get; set; }
    public DateTime ExpiryDate { get; set; }
    public bool IsValid { get; set; }

    public Card(){}

}