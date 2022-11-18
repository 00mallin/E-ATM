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

        Console.Write(Environment.NewLine + "Press any key to return...");
        Console.ReadKey();
    }
}