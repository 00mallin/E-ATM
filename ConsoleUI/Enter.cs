public class Enter
{
    public void PressEnter()
    {
        Console.Write("\nPress enter to return to menu...");

        while (true)
        {
            ConsoleKey enter = Console.ReadKey(true).Key;
            if (enter == ConsoleKey.Enter)
            {
                break;
            }
        }
    }
}