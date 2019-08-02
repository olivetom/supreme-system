using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace LeetCode.Cormen
{

    // A binary search tree is a red-black tree if it satisfies the following red-black properties:
    // 1. Every node is either red or black
    // 2. Every leaf (nil node) is black
    // 3. If a node is red, the both its children are black
    // 4. Every simple path from a node to a descendant leaf contains the same number of black nodes
    //
    // The basic idea of red-black tree is to represent 2-3-4 trees as standard BSTs but to add one extra bit of information
    // per node to encode 3-nodes and 4-nodes.
    // 4-nodes will be represented as:          B
    //                                                              R            R
    // 3 -node will be represented as:           B             or         B
    //                                                              R          B               B       R
    //
    // For a detailed description of the algorithm, take a look at "Algorithm" by Rebert Sedgewick.

    //internal delegate bool TreeWalkPredicate<T>(SortedSet<T>.Node node);

    internal enum TreeRotation
    {
        Left = 1,
        Right = 2,
        RightLeft = 3,
        LeftRight = 4,
    }


    [SuppressMessage("Microsoft.Naming", "CA1710:IdentifiersShouldHaveCorrectSuffix", Justification = "by design name choice")]




    class RedBlackTree
    {
        #region field members
        Node Root { get; set; }

        #endregion

        #region Node class
        public class Node
        {
            //public int Key { get; set; }
            //public int Value { get; set; }
            //internal Node Right { get; set; }
            //internal Node Left { get; set; }
            //internal Node P { get; set; }
            //internal TreeRotation Color { get; set; }

            public Node(int item) : this(item, true)
            {
                
            }
            public Node(int item, bool isRed)
            {
                // The default color is red since we usually don't need to create a black node directly.
                Item = item;
                IsRed = isRed;
            }

            //public T Item { get; set; }
            public int Item { get; set; }

            public Node Left { get; set; }

            public Node Right { get; set; }

            public Node Parent { get; set; }

            public bool IsRed { get; set; }

            public bool IsBlack => !IsRed;

            public bool Is2Node => IsBlack && IsNullOrBlack(Left) && IsNullOrBlack(Right);

            public bool Is4Node => IsNonNullRed(Left) && IsNonNullRed(Right);

            public static bool IsNonNullRed(Node node) => node != null && node.IsRed;

            public static bool IsNullOrBlack(Node node) => node == null || node.IsBlack;

        }
        #endregion


        #region Constructors
        #endregion


        #region function members
        bool TreeInsert(Node z)
        {
            Node y = null;
            Node x = Root;

            while (x != null)
            {
                y = x;
                if (z.Item < x.Item)
                    x = x.Left;
                else
                    if (z.Item > x.Item)
                    x = x.Right;
                else if (z.Item == x.Item)
                    return false;
            }
            z.Parent = y;

            if (y == null)
                Root = z;
            else if (z.Item < y.Item)
                y.Left = z;
            else y.Right = z;

            return true;
        }

        void RBInsert(Node x)
        {
            if (!TreeInsert(x)) return;
            x.IsRed = true;
            while (x != Root && x.Parent.IsRed)
            {
                if (x.Parent == x.Parent.Parent.Left) //x's parent is left child of x's grandparent 
                {
                    Node y = x.Parent.Parent.Right;
                    if (y != null && y.IsRed)
                    {
                        x.Parent.IsRed = false;
                        y.IsRed = false;
                        x.Parent.Parent.IsRed = true;
                        x = x.Parent.Parent;
                    }
                    else
                    {
                        if (x.Parent.Right == x)
                        {
                            x = x.Parent;
                            LeftRotate(x);
                        }
                        x.Parent.IsRed = false;
                        x.Parent.Parent.IsRed = true;
                        RightRotate(x.Parent.Parent);
                    }
                }
                else if (x.Parent == x.Parent.Parent.Right) //x's parent is right child of x's grandparent
				{
                    Node y = x.Parent.Parent.Left;
                    if (y != null && y.IsRed)
                    {
                        x.Parent.IsRed = false;
                        y.IsRed = false;
                        x.Parent.Parent.IsRed = true;
                        x = x.Parent.Parent;
                    }
                    else
                    {
                        if (x.Parent.Left == x)
                        {
                            x = x.Parent;
                            RightRotate(x);
                        }
                        x.Parent.IsRed = false;
                        x.Parent.Parent.IsRed = true;
                        LeftRotate(x.Parent.Parent);
                    }

                }
            }
            Root.IsRed = false;
        }

        void LeftRotate(Node x)
        {
            Node y = x.Right;

            x.Right = y.Left;

            // p(left(y)) = x if not nil
            if (y.Left != null)
            {
                y.Left.Parent = x;
            }

            //set x's parent as y's parent
            y.Parent = x.Parent;

            if (x.Parent == null)
            {
                Root = y;
            }
            else if (x == x.Parent.Left)  //en el padre de x debemos apuntar a y
            {
                x.Parent.Left = y;
            }
            else
            {
                x.Parent.Right = y;
            }

            y.Left = x;  //poner x a la izquierda de y
            x.Parent = y; //poner y como padre de x
        }

        void RightRotate(Node x)
        {
            Node y = x.Left;

            x.Left = y.Right;

            if (y.Right != null) //el subarbol derecho de y tiene a x como padre
            {
                y.Right.Parent = x;
            }
            //set y as x father
            y.Parent = x.Parent;
            if (y.Parent == null)
            {
                Root = y;
            }
            else if (x == x.Parent.Left)
            {
                x.Parent.Left = y;
            }
            else x.Parent.Right = y;
            y.Right = x;
            x.Parent = y;
        }

        //public int Posicion(Node x)
        //{
        //    int p = x.LeftSize + 1; // x is greater than left subtree
        //    Node y = x;
        //    while (y != null)
        //    {
        //        if (y.Parent != null && y == y.Parent.Right) // traversing from right subtree upwards
        //        {
        //            p += y.Parent.LeftSize + 1;
        //        }
        //        y = y.Parent;
        //    }
        //    return p;
        //}

        public Node IesimoMenorElemento(Node root, int i)
        {
            return null;
            //add left tree size and right subtree size to each node
            // depth first search the tree substracting from i the quantity of nodes "visited" or left behind.
            //int r = root.LeftSize + 1;
            // if (r == i) return root;
            // if (i < r) return IesimoMenorElemento(root.Left, i);
            // else return IesimoMenorElemento(root.Right, i - r);
        }

		/*public int RankOrPosition(Node root, int x)
        { // return 0 means error. 
            Node i = root;
            int r = root.LeftSize + 1;
            while (i != null)
            {
                if (x < i.Item)
				{
                    r -= 1;
					i = i.Left;
                }
                else if (x > i.Item) 
                {
                    r += 1;
					i = i.Right;
				}
                else 
                { // element found
                    return x.LeftSize + r + 1;
                }
            }
            return 0;

            /* cormen algorithm
            x = puntero al nodo que se quiere determinar el orden
            el algoritmo vuelve hasta la raiz 
            r = x.LeftSize + 1;
            y = x;
            while (y != root)
            {
                if (y.Parent.Right == y)
                {
                    r = r + y.Parent.LeftSize + 1;
                }
                y = y.Parent;
            }
            return r;
	}
            */

		/*
         * b.1. Devolver la suma de todos los valores almacenados en el árbol.
b.2. Imprimir todos los valores almacenados en los nodos que corresponden a niveles impares. El nivel de un nodo es la longitud del camino desde la raíz hasta dicho nodo.
b.3. Devolver el mayor y el menor número almacenado en el árbol.
b.4. Encontrar la máxima diferencia (en valor absoluto) entre dos hojas adyacentes. Para el árbol del ejemplo, la máxima diferencia es 6 ( | 3 – 9| ).
b.5. Almacenar en un arreglo la rama más liviana, es decir aquella rama que contiene valores cuya suma es menor a los de cualquier otra rama en el árbol. Para el árbol del ejemplo, almacenar <8, 5, 3> .
         * 
         */
		#endregion


		#region Driver Program
		public static void Program()
        {
            RedBlackTree rbt = new RedBlackTree();
			rbt.RBInsert(new Node(7));
			rbt.RBInsert(new Node(9));
			rbt.RBInsert(new Node(20));
			rbt.RBInsert(new Node(25));
			rbt.RBInsert(new Node(14));
			rbt.RBInsert(new Node(18));
			rbt.RBInsert(new Node(11));
			rbt.RBInsert(new Node(17));
			rbt.RBInsert(new Node(16));
			rbt.RBInsert(new Node(12));
			rbt.RBInsert(new Node(13));
			//rbt.RBInsert(3);
			//rbt.RBInsert(7);
			//rbt.RBInsert(1);
			//rbt.RBInsert(9);
			//rbt.RBInsert(-1);
			//rbt.RBInsert(11);
			//rbt.RBInsert(6);
			//rbt.Displayrbt();
			//rbt.Delete(-1);
			//rbt.Displayrbt();
			//rbt.Delete(9);
			//rbt.Displayrbt();
			//rbt.Delete(5);
			//rbt.DisplayTree();
        }
        #endregion
    }


}
