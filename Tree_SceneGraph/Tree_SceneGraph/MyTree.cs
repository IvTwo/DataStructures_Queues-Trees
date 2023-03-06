using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
// Reference Used: https://stackoverflow.com/questions/66893/tree-data-structure-in-c-sharp

namespace Tree_SceneGraph
{
    internal class MyTree<T>
    {
        private T data;
        private LinkedList<MyTree<T>> children;

        // constructor
        public MyTree(T data)
        {
            this.data = data;
            children = new LinkedList<MyTree<T>>();
        }

        public void AddChild(T data)
        {
            children.AddLast(new MyTree<T>(data));
        }

        public void RemoveChild(T data)
        {
            // code here
        }

        public void PrintTree(MyTree<T> node, int padNum)
        {
            // padding based on tree nesting
            Console.WriteLine("-> ".PadLeft(padNum) + node.data.ToString());

            foreach (MyTree<T> kid in node.children)
            {
                PrintTree(kid, padNum + 6);
            }
        }

        public bool PlayerInsert(MyTree<T> node, T newData, T parentData)
        {
            Console.WriteLine("parentdata: " + parentData);
            Console.WriteLine("nodeData: " + node.data);
            // if you find the parent node, add newData as a child of node
            // then return true -->
            if (node.data.Equals(parentData))
            {
                Console.WriteLine("added " + newData + " as a child of " + node.data);
                node.AddChild(newData);
                return true;
            }

            // recursion
            foreach (MyTree<T> kid in node.children)
            {
                Console.WriteLine("kidData: " + kid.data);
                // kid becomes the new node, and search resumes
                if(PlayerInsert(kid, newData, parentData))
                {
                    return true;
                }
            }

            // if no new node was added
            return false;
        }
    }
}
