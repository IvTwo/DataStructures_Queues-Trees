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

        // print tree
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
         * Returns:
         *      1 = node inserted
         *      0 = no node inserted
         *      -1 = duplicate node found
        ****************************************************************************/
        public int PlayerInsert(MyTree<T> node, T newData, T parentData)
        {
            // check for duplicates
            if (node.data.Equals(newData))
            {
                return -1;
            }

            // recursion
            foreach (MyTree<T> kid in node.children)
            {
                // kid becomes the new node, and search resumes
                // if the node is found, it return true
                int result = PlayerInsert(kid, newData, parentData);
                if (result == 1)
                {
                    return 1;    // exit the recursive loop
                }
                else if (result == -1)
                {
                    return -1;
                }
            }

            // if you find the parent node, add newData as a child of node
            // then return true -->
            if (node.data.Equals(parentData))
            {
                node.AddChild(newData);
                return 1;
            }

            // if no new node was added
            return 0;
        }


        /****************************************************************************
         * Delete a node with "T data"
         * 
         * Each iteration checks if the current note data == the data you want to delete
         * if this node is found, remove it from its parent node
         * if not, recursive call and check its children
         * 
         * Return true if a node was deleted, false if no node was deleted
        ****************************************************************************/
        public bool PlayerDelete(MyTree<T> node, MyTree<T> parentNode, T data)
        {

            foreach (MyTree<T> kid in node.children)
            {
                if (PlayerDelete(kid,node, data))
                {
                    return true;    // stop the recursive call
                }
            }

            // if node is found and it equals the data you want to remove
            // remove node from parentNode
            if (node.data.Equals(data))
            {
                parentNode.RemoveChild(node);
                return true;
            }

            // no node was deleted
            return false;
        }
    }
}
