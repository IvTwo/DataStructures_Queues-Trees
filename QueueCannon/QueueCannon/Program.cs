using System.Threading.Tasks;
namespace QueueCannon
{
    internal class Program
    {
        // global variables
        static int numShells = 5;
        static Queue<string> ammunition = new Queue<string>();
        static Queue<string> storedAmmo = new Queue<string>();

        static void Main(string[] args)
        {
            // add numShells to the ammunition queue
            for (int i = 0; i < numShells; i++)
            {
                ammunition.Enqueue("shell " + i);
            }

            // text ui
            Console.WriteLine();
            Console.WriteLine("Welcome To The Cannon Test----!");
            Console.WriteLine("Press enter to fire the cannon and esc to quit the program");
            Console.WriteLine("---");

            // main game loop
            ConsoleKeyInfo keyInfo = Console.ReadKey();
            while(keyInfo.Key != ConsoleKey.Escape)
            {
                if (keyInfo.Key == ConsoleKey.Enter && ammunition.Count > 0)
                {
                    // fire shell
                    storedAmmo.Enqueue(ammunition.Dequeue());   // put ammo into a storage queue
                    
                    Console.WriteLine("shell fired");
                    keyInfo = Console.ReadKey();
                }
                else if (keyInfo.Key == ConsoleKey.Enter)
                {
                    Console.WriteLine("Out of Ammo!");
                    keyInfo = Console.ReadKey();
                }
            }
            Console.WriteLine();
            Console.WriteLine("TThank you :)");
        }
    }
}