using System.Diagnostics;
using System.Threading.Tasks;
namespace QueueCannon
{
    internal class Program
    {
        // GLOBAL VARIABLES
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
            // while player does not press esc do{}
            ConsoleKeyInfo keyInfo;
            do
            {
                keyInfo = Console.ReadKey();    // read user input

                if (keyInfo.Key == ConsoleKey.Enter && ammunition.Count > 0)
                {
                    // fire shell
                    storedAmmo.Enqueue(ammunition.Dequeue());   // put ammo into a storage queue

                    Console.WriteLine("shell fired");
                    Reload();
                }
                else if (keyInfo.Key == ConsoleKey.Enter)
                {
                    // player is out of ammo
                    Console.WriteLine("Out of Ammo!");
                }
            } while (keyInfo.Key != ConsoleKey.Escape);
            
            Console.WriteLine();
            Console.WriteLine("TThank you :)");
        }

        public static void Reload()
        {
            Task.Delay(TimeSpan.FromSeconds(4.5)).ContinueWith(_ =>   // wait X seconds
            {
                ammunition.Enqueue(storedAmmo.Dequeue());   // reuse ammo
                Console.WriteLine("RELOADED");
            });
        }
    }
}