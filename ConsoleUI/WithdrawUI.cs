using Logic;

public class WithdrawUI
{
    public static void Show(Card card)
    {
        Console.Clear();

        Database db = new();

        Account selectedAccount = db.GetAccount(card.AccountID);

        Console.WriteLine("You have: " + selectedAccount.Balance + " kr in your account.");

        float input = ErrorHandler.ReadFloat("Withdrawal amount: ");

        if (selectedAccount.Withdraw(input))
        {
            Console.WriteLine($"Success! Your account balance: {selectedAccount.Balance} kr");
        }
        else
        {
            Console.WriteLine("Withdrawal wasn't succesful!");
        }

        Enter pressEnter = new();
        pressEnter.PressEnter();
    }

}