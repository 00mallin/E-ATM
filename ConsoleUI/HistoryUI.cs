using Logic;

public class HistoryUI
{
    public static void Show(Card card)
    {
        Console.Clear();
        Database db = new();

        Account selectedAccount = db.GetAccount(card.AccountID);
        Transactions accountTransaction = new();

        foreach (Transactions account in selectedAccount.GetTransactions())
        {
            Console.Write(account);
        }


        while (true)
        {
            Console.WriteLine("\nTryck ENTER för att tillbaka till huvudet meny");
            ConsoleKey input = Console.ReadKey(true).Key;
            if (input == ConsoleKey.Enter)
            {
                break;
            }
        }
        accountTransaction.ToString();



    }
}