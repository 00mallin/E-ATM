using Logic;

internal class Program
{
    private static void Main(string[] args)
    {
        
        bool running = true;
        while(running)
        {
            var keypress = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("\t----- Welcome to your local bank -----");
                Console.WriteLine(
                "[I]nsert\n" +
                "[W]ithdraw\n" +
                "[B]alance\n" + 
                "[H]istory\n" + 
                "[E]xit");

            switch(keypress)
            {
                
                

                case 'I':
                case 'i':
                    Console.Write("Input the amount you would like to insert");
                    Console.ReadLine();
                    break;

                case 'W':
                case 'w':
                    Console.Write("Input the amout you would like to withdraw");
                    Console.ReadLine();
                    break;

                case 'B':
                case 'b':
                    Console.Write("Your balance is: ");
                    Console.ReadLine();
                    break;

                case 'H':
                case 'h':
                    Console.Write("History of your transactions: " );
                    break;

                case 'E':
                case 'e':
                    return;
                    
                default: 
                    Console.WriteLine("There is no choice matching your input, please try again");
                    break;
            }
        }
        
    }
}