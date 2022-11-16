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
        var accounts = Connection.Query($"SELECT account.id AS accountId, account.account_number AS accountNumber, account.balance as balance FROM account INNER JOIN account_user ON account.id = account_user.account_id INNER JOIN user ON account_user.user_id = user.id INNER JOIN card ON account.id = card.account_id WHERE account_user.user_id = {userID}").ToList();

        foreach (var row in accounts)
        {
            Account account = new();
            account.ID = row.accountId;
            account.AccountNumber = row.accountNumber;
            account.Balance = row.balance;
            listAccounts.Add(account);
        }

        return listAccounts;
    }

    public bool CheckCard(string CardNumber)
    {
        var Cardfound = Connection.QuerySingleOrDefault($"SELECT COUNT(id) FROM card WHERE card_number = '{CardNumber}'"); //cardfound är en objekt 

        if (Cardfound != null)
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

    public Card GetCard(string card_number, string pin)
    {
        var row = Connection.QuerySingleOrDefault($"SELECT card.id AS cardId, card.card_number AS cardNumber, card.expiry_date AS expiryDate, card.is_valid AS isValid, card.account_id AS accountID, card.user_id AS userID, user.first_name AS firstName, user.last_name AS lastName FROM card INNER JOIN user ON card.user_id = user.id WHERE card.card_number = '{card_number}' AND card.pin = '{pin}'");

        Card card = new();
        card.ID = row.cardId;
        card.AccountID = row.accountID;
        card.UserID = row.userID;
        card.CardNumber = row.cardNumber;
        card.CardHolder = $"{row.firstName} {row.lastName}";
        card.ExpiryDate = row.expiryDate;
        card.IsValid = row.isValid;

        return card;
    }
}