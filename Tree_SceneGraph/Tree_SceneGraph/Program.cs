namespace Tree_SceneGraph
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // testing
            MyTree<string> tree = new MyTree<string>("scene");  // create instance of tree
            tree.PlayerInsert(tree, "child", "scene");
            Console.WriteLine();
            tree.PlayerInsert(tree, "child2", "child");

            Console.WriteLine();
            tree.PrintTree();

            //MyMenu();
        }

        // accept user input as a string
        public static void MyMenu()
        {
            MyTree<string> tree = new MyTree<string>("scene");  // create instance of tree

            bool keepGoing = true;

            while (keepGoing)
            {
                Console.WriteLine();
                Console.WriteLine("Welcome To The Scene Graph Simulator----!");
                Console.WriteLine();
                Console.WriteLine("The current tree looks like:");
                // display the current tree
                Console.WriteLine();
                Console.WriteLine("\t1. Enter a Command\n" + "\t2. Quit\n");

                switch (UserInput())    // handle user input
                {
                    case "1":
                        
                        break;

                    case "2":
                        keepGoing = false;
                        break;

                    default:
                        Console.WriteLine("---");
                        Console.WriteLine("Invalid Input!");
                        break;
                }

            }
        }

        // return the user input |  O(1)
        public static string UserInput()
        {
            Console.Write("\t * Your Input: ");
            return Console.ReadLine();
        }
    }
}