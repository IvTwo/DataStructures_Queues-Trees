using System.Xml.Linq;

namespace Tree_SceneGraph
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // TESTING ------------
            //MyTree<string> tree = new MyTree<string>("scene");  // create instance of tree
            //tree.PlayerInsert(tree, "child", "scene");
            //tree.PlayerInsert(tree, "child2", "child");
            //tree.PlayerInsert(tree, "child3", "child");
            //tree.PlayerInsert(tree, "child4", "scene");
            //Console.WriteLine();
            //bool test = tree.PlayerInsert(tree, "child5", "child3");
            //Console.WriteLine(test);
            //tree.PlayerInsert(tree, "child6", "child5");

            //Console.WriteLine();
            //tree.PrintTree(tree, 0);
            //Console.WriteLine();

            //bool test2 = tree.PlayerDelete(tree, tree, "child5");
            //Console.WriteLine(test2);
            //Console.WriteLine();
            //tree.PrintTree(tree, 0);

            // PROGRAM START ------
            MyMenu();
        }

        // accept user input as a string
        public static void MyMenu()
        {
            MyTree<string> tree = new MyTree<string>("scene");  // create instance of tree

            bool keepGoing = true;
            Console.WriteLine();
            Console.WriteLine("Welcome To The Scene Graph Simulator----!");
            Console.WriteLine("Please enter a command | To exit the program input \"q\"");

            while (keepGoing)
            {
                Console.WriteLine();
                string userInput = UserInput();
                string[] words = userInput.Split(' ');

                switch (words[0])   // handle user input
                {
                    case "insert":
                        UI_PlayerInsert(tree, words);
                        break;

                    case "delete":
                        break;

                    case "print":
                        Console.WriteLine("---");
                        Console.WriteLine("Current Tree:");
                        tree.PrintTree(tree, 0);    // print the tree
                        break;

                    case "q":
                        keepGoing= false;
                        break;

                    default:
                        Console.WriteLine("---");
                        Console.WriteLine("Invalid Input!");
                        break;
                }
            }
        }

        // Text UI for the insert command
        public static void UI_PlayerInsert(MyTree<string> tree, string[] words)
        {

            // if the command doesn't start with "insert" or there are more than 3 words, exit the method
            if (!words[0].Equals("insert") || words.Length > 3)
            {
                Console.WriteLine("---");
                Console.WriteLine("Invalid Input!");
                return;
            }

            // insert the node
            bool didInsert = tree.PlayerInsert(tree, words[1], words[2]);
            if(didInsert)
            {
                Console.WriteLine("---");
                Console.WriteLine("Inserted " + words[1] + " as a child of " + words[2]);
            }
            else
            {
                Console.WriteLine("---");
                Console.WriteLine("Parent node not found!");
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