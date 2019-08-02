using System;

namespace BstAmazon

{
    class Program
    {

        static bool Solve(Node root, int valueToFind)
        {
            /***
             *  your code here 
             ***/

            if (treeRoot == null) return false;

            if (valueToFind >= 231) return false; //value invalid

            if (treeRoot.value == valueToFind) return true;

            Node current = treeRoot;
            Node parent;


            while (true)
            {
                parent = current;
                if (valueToFind < current.value)
                {  //smaller than root -> left
                    current = current.left;
                    if (current == null)
                    {
                        return false;
                    }
                }
                else if (valueToFind > current.value)
                { // bigger than root --> right
                    current = current.right;
                    if (current == null)
                    {
                        return false;
                    }
                }
                else // value found
                    return true;
            }


        }

        static Node treeRoot;
        static void Main(string[] args)
        {
            int value = readParameter(args);
            bool output = Solve(treeRoot, value);
            Print(output);
        }

        private static int readParameter(String[] args)
        {
            string[] array = Console.ReadLine().Split(' ');
            for (int i = 0; i < array.Length - 1; i++)
                addNodeInTree(Convert.ToInt32(array[i]), treeRoot);

            return Convert.ToInt32(array[array.Length - 1]);
        }


        private static void Print(bool result)
        {
            Console.Write(result ? "T" : "F");
        }

        private static void addNodeInTree(int value, Node parent)
        {
            if (parent == null)
            {
                treeRoot = new Node(value);
                return;
            }
            if (parent.value < value)
            {
                if (parent.left == null)
                {
                    parent.left = new Node(value);
                }
                else
                {
                    addNodeInTree(value, parent.left);
                }
            }
            else
            {
                if (parent.right == null)
                {
                    parent.right = new Node(value);
                }
                else
                {
                    addNodeInTree(value, parent.right);
                }
            }
        }
    }

    internal class Node
    {
        internal int value;
        internal Node left;
        internal Node right;
        internal Node(int val)
        {
            left = right = null;
            value = val;
        }
    }
}