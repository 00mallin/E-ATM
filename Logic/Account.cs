using Dapper;

namespace Logic;


public class Account
{
    private static Database db = new();
    public int ID { get; set; }
    public float Balance { get; set; }
    public string AccountNumber { get; set; }

    public Account() { }

    public override string ToString()
    {
        return "Konto nummer: " + AccountNumber + "\n   Belopp: " + Balance;
    }
    public List<User> GetUsers()
    {
        return db.Connection.Query<User>($"SELECT user.id, user.first_name AS FirstName, user.last_name AS LastName, user.personal_number AS PersonalNumber, user.address, user.phone_number AS PhoneNumber FROM account_user INNER JOIN user ON account_user.user_id = user.id WHERE account_user.account_id = {ID}").ToList();
    }

    public List<Card> GetCards()
    {
        List<Card> cardsList = new();
        var cardsFromDB = db.Connection.Query($"SELECT card.id AS cardId, card.card_number AS cardNumber, card.expiry_date AS expiryDate, card.is_valid AS isValid, card.user_id AS userID, user.first_name AS firstName, user.last_name AS lastName FROM card INNER JOIN user ON card.user_id = user.id WHERE card.account_id = {ID}").ToList();

        foreach (var row in cardsFromDB)
        {
            Card card = new();
            card.ID = row.cardId;
            card.UserID = row.userID;
            card.CardNumber = row.cardNumber;
            card.CardHolder = $"{row.firstName} {row.lastName}";
            card.ExpiryDate = row.expiryDate;
            card.IsValid = row.isValid;
            cardsList.Add(card);
        }

        return cardsList;
    }

    public List<Transactions> GetTransactions()
    {
        return db.Connection.Query<Transactions>($"SELECT id, date, amount FROM transaction WHERE account_id = {ID}").ToList();
    }

    public bool Deposit(float amount)
    {
        try
        {
            if (amount > 0)
            {
                Balance += amount;
                db.Connection.Execute($"UPDATE account SET account.balance = '{Balance}' WHERE id = '{ID}'");
                this.LogTransaction(amount);
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
                this.LogTransaction(-(amount));
            }
            return true;
        }
        catch { return false; }
    }

    private void LogTransaction(float amount)
    {
        if (db.Connection.Execute($"INSERT INTO transaction(amount, date, account_id) VALUES ('{amount}', '{DateTime.Now}', '{ID}')") < 1)
        {
            throw new Exception(message: "Couldn't log the transaction!");
        } 
    }
}
