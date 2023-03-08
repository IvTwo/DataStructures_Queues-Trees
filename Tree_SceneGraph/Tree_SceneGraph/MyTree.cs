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

        public void RemoveChild(MyTree<T> node)
        {
            children.Remove(node);
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

        /****************************************************************************
         * Insert a node where "node.data" = "newdata" into the tree based as a child
         * of "parentdata"
         * 
         * Each iteration checks if the current node.data is equal to parent data
         * if its equal, then add the new data as a child of the node
         * if not, then recursive call, and check if the current node has children
         * and search the children
         * --> continue searching tree until a matching node is found, or the whole
         * tree is searched
         * 
         * Return true if a node was inserted, false if no new node was added
        ****************************************************************************/
        public bool PlayerInsert(MyTree<T> node, T newData, T parentData)
        {
            // if you find the parent node, add newData as a child of node
            // then return true -->
            if (node.data.Equals(parentData))
            {
                node.AddChild(newData);
                return true;
            }

            // recursion
            foreach (MyTree<T> kid in node.children)
            {
                // kid becomes the new node, and search resumes
                // if the node is found, it return true
                if(PlayerInsert(kid, newData, parentData))
                {
                    return true;    // exit the recursive loop
                }
            }

            // if no new node was added
            return false;
        }

        // if you find the node you want to delete, return [something]? which
        // signals the program to --> send parent node to call RemoveChild
        public bool PlayerDelete(MyTree<T> node, MyTree<T> parentNode, T data)
        {
            // if node is found and it equals the data you want to remove
            // remove node from parentNode
            if (node.data.Equals(data))
            {
                Console.WriteLine("end, loop: " + node.data);
                Console.WriteLine("removed " + parentNode.data + " as a child of " + parentNode.data);
                parentNode.RemoveChild(node);
                return true;
            }

            foreach (MyTree<T> kid in node.children)
            {
                if (PlayerDelete(kid,node, data))
                {
                    return true;    // stop the recursive call
                }
            }

            // no node was deleted
            return false;
        }
    }
}
