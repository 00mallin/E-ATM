using MySqlConnector;
using Dapper;

namespace Logic;

public class Database
{
    public MySqlConnection Connection { get; private set; }
    private string connectionString = "Server=familjenlindh.se;Database=e_atm;Uid=eatm;Pwd=atm123";

    public Database()
    {
        Connection = new(connectionString);
    }

    public List<Account> GetAllAccounts()
    {
        List<Account> listAccounts = new();
        var accounts = Connection.Query("SELECT account.id AS accountId, account.account_number AS accountNumber, account.balance as balance, user.id AS userId, card.id as cardId FROM account INNER JOIN account_user ON account.id = account_user.account_id INNER JOIN user ON account_user.user_id = user.id INNER JOIN card ON account.id = card.account_id").ToList();

        foreach (var row in accounts)
        {
            Account account = new();
            account.ID = row.accountId;
            account.AccountNumber = row.accountNumber;
            account.Balance = row.balance;
            account.Users = GetUsersByID(row.userId);
            account.Cards = GetCardsByID(row.cardId);
            account.Transactions = GetTransactions(row.accountId);
            listAccounts.Add(account);
        }

        return listAccounts;
    }

    public List<User> GetUsersByID(int userID)
    {
        return Connection.Query<User>($"SELECT id, first_name AS FirstName, last_name AS LastName, personal_number AS PersonalNumber, address, phone_number AS PhoneNumber FROM user WHERE id = {userID}").ToList();
    }

    public List<Card> GetCardsByID(int cardID)
    {
        List<Card> listCards = new();
        var cards = Connection.Query($"SELECT card.id AS cardId, card.card_number AS cardNumber, card.expiry_date AS expiryDate, card.is_valid AS isValid, user.first_name AS firstName, user.last_name AS lastName FROM card INNER JOIN user ON card.user_id = user.id").ToList();

        foreach (var row in cards)
        {
            Card card = new();
            card.ID = row.cardId;
            card.CardNumber = row.cardNumber;
            card.CardHolder = $"{row.firstName} {row.lastName}";
            card.ExpiryDate = row.expiryDate;
            card.IsValid = row.isValid;
            listCards.Add(card);
        }

        return listCards;
    }

    public List<Transactions> GetTransactions(int accountID)
    {
        return Connection.Query<Transactions>($"SELECT id, date, amount FROM transaction WHERE account_id = {accountID}").ToList();
    }
}
