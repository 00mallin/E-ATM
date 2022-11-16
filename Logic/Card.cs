using Dapper;

namespace Logic;

public class Card
{
    private static Database db = new();
    public int ID { get; set; }
    public int AccountID { get; set; }
    public int UserID { get; set; }
    public string CardNumber { get; set; }
    public string CardHolder { get; set; }
    public DateTime ExpiryDate { get; set; }
    public bool IsValid { get; set; }

    public Card(){}

    public void LockCard()
    {
        if(db.Connection.Execute($"UPDATE card SET is_valid = false WHERE id = {ID}") > 0)
        {
            IsValid = false;
        }
        else
        {
            throw new Exception(message: "Could not update the database.");
        }
    }
}