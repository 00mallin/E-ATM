namespace Logic;

using Dapper;

public class Account
{
    private static Database db = new();
    public int ID { get; set; }
    public float Balance { get; set; }
    public string AccountNumber { get; set; }
    public List<User> Users { get; set; }
    public List<Card> Cards { get; set; }
    public List<Transactions> Transactions { get; set; }

    public Account()
    {
        if (ID > 0)
        {
            Users = db.Connection.Query<User>($"SELECT user.id, user.first_name AS FirstName, user.last_name AS LastName, user.personal_number AS PersonalNumber, user.address, user.phone_number AS PhoneNumber FROM account_user INNER JOIN user ON account_user.user_id = user.id WHERE account_user.account_id = {ID}").ToList();
            Transactions = db.Connection.Query<Transactions>($"SELECT id, date, amount FROM transaction WHERE account_id = {ID}").ToList();
            var cardsFromDB = db.Connection.Query($"SELECT card.id AS cardId, card.card_number AS cardNumber, card.expiry_date AS expiryDate, card.is_valid AS isValid, user.first_name AS firstName, user.last_name AS lastName FROM card INNER JOIN user ON card.user_id = user.id WHERE card.account_id = {ID}").ToList();

            foreach (var row in cardsFromDB)
            {
                Card card = new();
                card.ID = row.cardId;
                card.CardNumber = row.cardNumber;
                card.CardHolder = $"{row.firstName} {row.lastName}";
                card.ExpiryDate = row.expiryDate;
                card.IsValid = row.isValid;
                Cards.Add(card);
            }
        }
        else
        {
            throw new Exception(message: "Could not create an Account-object because it has no ID!");
        }
    }

    public override string ToString()
    {
        return Balance + " " + AccountNumber;
    }

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
