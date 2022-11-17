using Logic;

public class HistoryUI
{
    public static void Show(Card card)
    {
        Console.Clear();
        Database db = new();

        Account selectedAccount = db.GetAccount(card.AccountID);
        Transactions accountTransaction = new();

        foreach (var item in selectedAccount.GetTransactions())
        {
            Console.Write(item);
            accountTransaction.ToString();
            Console.ReadKey();
        }

    }
}