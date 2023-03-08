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

            while (keepGoing)
            {
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("Welcome To The Scene Graph Simulator----!");
                Console.WriteLine();
                Console.WriteLine("\t1. Insert Node\n" + "\t2. Delete Node\n" +
                                "\t3. Print Current Tree\n" + "\t4. Quit\n");

                switch (UserInput())    // handle user input
                {
                    case "1":
                        UI_PlayerInsert(tree);
                        break;

                    case "2":
                        break;

                    case "3":
                        Console.WriteLine("---");
                        Console.WriteLine("Current Tree:");
                        tree.PrintTree(tree, 0);    // print the tree
                        break;

                    case "4":
                        keepGoing = false;
                        break;

                    default:
                        Console.WriteLine("---");
                        Console.WriteLine("Invalid Input!");
                        break;
                }

            }
        }

        // Text UI for the insert command
        public static void UI_PlayerInsert(MyTree<string> tree)
        {
            Console.WriteLine("---");
            Console.WriteLine("Please input your command as: \"insert A B\"");
            Console.WriteLine("(A = child, B = parent)");
            Console.WriteLine();

            string userInput = UserInput();
            string[] words = userInput.Split(' ');

            // if the command doesn't start with "insert" or there are more than 3 words, exit the method
            if (!words[0].Equals("insert") || words.Length > 3)
            {
                Console.WriteLine("---");
                Console.WriteLine("Invalid Input!");
                return;
            }

            bool didInsert = tree.PlayerInsert(tree, words[1], words[2]);
            if(didInsert)
            {
                Console.WriteLine("---");
                Console.WriteLine("Node Inserted!")
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