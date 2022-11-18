using Logic;

public class HistoryUI
{
    public static void Show(Card card)
    {
        Console.Clear();
        Database db = new();

        Account selectedAccount = db.GetAccount(card.AccountID);
        List<Transactions> transactionsList = selectedAccount.GetTransactions();


        for (int i = 0; i < transactionsList.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {transactionsList[i]}");
        }

        Console.WriteLine("\nTryck ENTER för att tillbaka till huvudet meny");

        while (true)
        {
            ConsoleKey input = Console.ReadKey(true).Key;
            if (input == ConsoleKey.Enter)
            {
                break;
            }
        }

        Console.ReadKey();
    }
}