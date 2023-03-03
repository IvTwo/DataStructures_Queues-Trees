namespace QueueCannon
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numShells = 5;
            Queue<string> ammunition = new Queue<string>();

            // add numShells to the ammunition queue
            for (int i = 0; i < numShells; i++)
            {
                ammunition.Enqueue("shell " + i);
            }

            // main game loop
            ConsoleKeyInfo keyInfo = Console.ReadKey();
            while(keyInfo.Key != ConsoleKey.Escape)
            {
                if (keyInfo.Key == ConsoleKey.Enter)
                {
                    // fire shell
                }
            }
        }
    }
}