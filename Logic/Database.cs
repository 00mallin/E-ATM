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

    /// <summary>
    /// Gets all accounts linked to USER by user ID
    /// </summary>
    /// <returns></returns>
    public List<Account> GetUserAccounts(int userID)
    {
        List<Account> listAccounts = new();
        var accounts = Connection.Query($"SELECT account.id AS accountId, account.account_number AS accountNumber, account.balance as balance, user.id AS userId, card.id as cardId FROM account INNER JOIN account_user ON account.id = account_user.account_id INNER JOIN user ON account_user.user_id = user.id INNER JOIN card ON account.id = card.account_id WHERE account_user.user_id = {userID}").ToList();

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

    /// <summary>
    /// Gets all the users linked to an account
    /// </summary>
    /// <param name="userID">User ID</param>
    /// <returns></returns>
    public List<User> GetUsersByID(int userID)
    {
        return Connection.Query<User>($"SELECT id, first_name AS FirstName, last_name AS LastName, personal_number AS PersonalNumber, address, phone_number AS PhoneNumber FROM user WHERE id = {userID}").ToList();
    }

    /// <summary>
    /// Gets all the cards linked to an account
    /// </summary>
    /// <param name="cardID">Card ID</param>
    /// <returns>List of cards</returns>
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

    /// <summary>
    /// Gets transactions for one specific account.
    /// </summary>
    /// <param name="accountID">Account ID</param>
    /// <returns>List of Transactions</returns>
    public List<Transactions> GetTransactions(int accountID)
    {
        return Connection.Query<Transactions>($"SELECT id, date, amount FROM transaction WHERE account_id = {accountID}").ToList();
    }

    public bool CheckCard(string CardNumber)
    {
        var Cardfound = Connection.QuerySingleOrDefault($"SELECT COUNT(id) FROM card WHERE card_number = '{CardNumber}'");

        if (Cardfound >= 1)
        {
            return true;
        }
        else
        {
            return false;
        } 
    }
    public Account GetAccount(string accountID)
    {
        return Connection.QuerySingleOrDefault<Account>($"SELECT id, account_number AS AccountNumber, balance FROM account WHERE id = '{accountID}'");
    }
}
