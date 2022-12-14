using Logic;

public class BalanceUI
{
    public static void Show(Card card)
    {
        Database db = new();

        Console.Clear();

        List<Account> userAccounts = db.GetUserAccounts(card.UserID);

        for (int i = 0; i < userAccounts.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {userAccounts[i]}");
        }

        Enter pressEnter = new();
        pressEnter.PressEnter();
    }
}