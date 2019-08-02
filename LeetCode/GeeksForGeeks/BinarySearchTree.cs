using System;
using System.Collections.Generic;

namespace LeetCode.GeeksForGeeks
{
    class BinarySearchTree
    {
        BSTNode Root; // BST Tree can be unbalanced. See Red-Black Tree for a balanced tree.

        public class BSTNode
        {
            internal int Value;
            internal BSTNode Right;
            internal BSTNode Left;
            int LeftHeight, RightEight;

            public BSTNode(int value)
            {
                Value = value;
                Left = Right = null;
                LeftHeight = RightEight = -1;
            }

            public Boolean IsLeaf()
            {
                return Left is null && Right is null;
            }

            //public Boolean operator ==

            public override String ToString()
            {
                return Value.ToString();
            }
        }

        BinarySearchTree()
        {
            Root = null;
        }

        public int Minimum()
        {
            BSTNode cur = Root, prev = Root;
            while (cur != null)
            {
                prev = cur;
                cur = cur.Left;
            }
            return prev.Value;
        }

        void Insert(int element)
        {
            BSTNode newNode = new BSTNode(element);
            Root = InsertRecursive(Root, Root, newNode);
        }

        BSTNode RotateRight(BSTNode raiz)
        {
            if (raiz.Left != null && raiz.Right == null && raiz.Left.Right == null && raiz.Left.Left != null)
            {
                BSTNode aux = raiz.Left;
                raiz.Left.Right = raiz;
                raiz.Left = null;
                raiz = aux;
            }
            return raiz;
        }

        BSTNode RotateLeft(BSTNode raiz)
        {
            if (raiz.Right != null && raiz.Left == null && raiz.Right.Left == null && raiz.Right.Right != null)
            {
                BSTNode aux = raiz.Right;
                raiz.Right.Left = raiz;
                raiz.Right = null;
                raiz = aux;
            }
            return raiz;

        }

        BSTNode InsertRecursive(BSTNode raiz, BSTNode parent, BSTNode newNode)
        {
            if (raiz == null)
            {
                raiz = newNode;
                return raiz;
            }

            if (raiz.Value == newNode.Value)
                return raiz; //aqui habria que definir en la clase BSTNode el operador ==

            if (newNode.Value < raiz.Value)
            {
                raiz.Left = InsertRecursive(raiz.Left, raiz, newNode);
                raiz = RotateRight(raiz);


                //} //   parent = RotateRight(raiz, parent, newNode);
            }
            else
            {
                raiz.Right = InsertRecursive(raiz.Right, raiz, newNode);
                raiz = RotateLeft(raiz);
                //raiz = raiz.Right;
                //if (raiz != parent && raiz.Left == null && parent.Left == null)
                //{
                //    parent.Right = null;
                //    raiz.Left = parent;
                //}
                //parent = RotateLeft(raiz, parent, newNode);
            }
            return raiz;
        }

        public void InsertIntoBST(BSTNode root, int data)
        {
            BSTNode _newNode = new BSTNode(data);
            BSTNode _current = root;
            BSTNode _previous = _current;
            while (_current != null)
            {
                if (data < _current.Value)
                {
                    _previous = _current;
                    _current = _current.Left;
                }
                else if (data > _current.Value)
                {
                    _previous = _current;
                    _current = _current.Right;
                }
            }
            if (data < _previous.Value)
                _previous.Left = _newNode;
            else
                _previous.Right = _newNode;
        }

        public void InOrderNoRecursion()
        {
            Stack<BSTNode> auxStack = new Stack<BSTNode>();

            BSTNode currentNode = this.Root;

            auxStack.Push(currentNode);

            while (auxStack.Count > 0)
            {

                if (currentNode != null && currentNode.Left != null)
                {
                    //auxStack.Push(currentNode);
                    currentNode = currentNode.Left;
                    //Console.WriteLine(currentNode._value);
                }
                else
                {
                    BSTNode popped = auxStack.Pop();
                    Console.WriteLine(popped.Value);
                    currentNode = popped.Right;
                }
                if (currentNode != null) auxStack.Push(currentNode);
            }

        }

        public List<int> InorderTraversal(BSTNode root)
        {
            List<int> list = new List<int>();

            Stack<BSTNode> stack = new Stack<BSTNode>();
            BSTNode cur = root;

            while (cur != null || stack.Count > 0)
            {
                while (cur != null)
                {
                    stack.Push(cur);
                    cur = cur.Left;
                }
                cur = stack.Pop();
                list.Add(cur.Value);
                cur = cur.Right;
            }

            return list;
        }

        public Boolean IterativeTreeSearch(int element)
        {
            BSTNode pointer = this.Root;

            while (pointer != null)
            {
                if (element == pointer.Value) return true;
                if (element < pointer.Value)
                    pointer = pointer.Left;
                else pointer = pointer.Right;
            }
            return false;
        }

        public Boolean CheckIfBST(BSTNode root)
        {
            //Check if a binary tree is BST or not

            Boolean rightSubtree, leftSubtree = rightSubtree = false;

            if (root == null) return true;

            if (root.Left != null)
            {
                if (root.Value > root.Left.Value)
                    leftSubtree = CheckIfBST(root.Left);
                else return false;
            }
            else leftSubtree = true;

            if (!leftSubtree) return false;

            if (root.Right != null)
            {

                if (root.Value < root.Right.Value)
                    rightSubtree = CheckIfBST(root.Right);
                else rightSubtree = false;
            }
            else rightSubtree = true;

            return leftSubtree && rightSubtree;
        }

        //Lowest Common Ancestor of A and B in a Binary Search Tree. Supose two parameters exist in tree.
        public int LowestCommonAncestor(int a, int b)
        {
            if (Root == null) return 0; //corner case

            if (a == b) return a; // corner case

            int lca = 0;
            BSTNode cur = Root;

            int lowerParam = (a < b) ? a : b;
            int higherParam = (a < b) ? b : a;

            while (cur != null)
            {
                if ((lowerParam < cur.Value && cur.Value < higherParam) ||
                    (lowerParam == cur.Value || higherParam == cur.Value))
                {
                    lca = cur.Value;
                    break;
                }
                if (higherParam < cur.Value)
                {
                    cur = cur.Left;
                }
                else if (lowerParam > cur.Value)
                {
                    cur = cur.Right;
                }

            }
            return lca;


        }

      

        public static int[] BST2Array(BSTNode bt, int N)
        { //BST must be balanced
            //auxiliary method to pass from tree to array
            var Q = new Queue<BSTNode>();

            var result = new int[N];

            Q.Enqueue(bt);

            int pos = 0;

            var L = new Queue<int>();

            result[pos++] = bt.Value;

            while (Q.Count > 0)
            {
                var current = Q.Dequeue();

                if (current.Left != null)
                {
                    result[pos] = current.Left.Value;
                    Q.Enqueue(current.Left);
                    L.Enqueue(pos++);
                }

                if (current.Right != null)
                {
                    result[pos] = current.Right.Value;
                    Q.Enqueue(current.Right);
                    L.Enqueue(pos++);
                }
            }

            return result;
        }

        public static int Parent(int i)
        {
            return (int)Math.Floor((double)(i) / 2);
        }

        public static int[][] Array2Matrix(int[] A)
        {
			//There is a binary tree of size N. 
            // All nodes are numbered between 1-N(inclusive). 
            // There is a N*N integer matrix Arr[N][N], all elements are initialized to zero. So for all the nodes A and B, put Arr[A][B] = 1 if A is an ancestor of B (NOT just the immediate ancestor).
			int N = A.Length;

            int[][] result = new int[N][];
            for (int i = 0; i < N; i++)
            {
                result[i] = new int[N];
            }

            for (int i = N - 1; i > 0; i--)
            {
                int currentDescendant = i;
                int p;
                while ((p = Parent(currentDescendant)) >= 0)
                {
                    result[p][i] = 1;
                    if (p == 0) break;
                    currentDescendant = p;
                }
            }
            return result;
        }

        public static List<BSTNode> LongestLeafToLeafPathRoute(BSTNode root)
        { //DFS

            // Do DFS and call at each node of the same level the function that returns longest path
            if (root == null) return new List<BSTNode>();

            var visited = new List<BSTNode>();

            var parent = new Dictionary<int, int>();

            var S = new Stack<BSTNode>();

            S.Push(root);

            BSTNode vertex;

            while (S.Count > 0)
            {
                vertex = S.Pop();
                if (visited.Contains(vertex))
                    continue;

                visited.Add(vertex);

                //recorrer ambos hijos

                if (vertex.Right != null)
                    S.Push(vertex.Right);

				if (vertex.Left != null)
					S.Push(vertex.Left);
            }
            return visited;
        }


        public static int LongestLeafToLeafPath(BSTNode root)
        { //Write a function that returns the length of the longest leaf-to-leaf path in a binary tree. 
		  // it is the diameter of the tree.
			Func<BSTNode, int> FarthestLeaf = v =>
			{ //BFS
				if (v is null) return 0;

				var farthest = 0;

                var Q = new Queue<BSTNode>();
               
                int nodeCountForLevel;

                Q.Enqueue(v);

                BSTNode current;

                while ((nodeCountForLevel = Q.Count) > 0)
				{

                    if (nodeCountForLevel == 0)
                        return farthest;

                    farthest++;


                    while (nodeCountForLevel > 0)
                    {
						current = Q.Dequeue();

						if (current.Left != null)
                            Q.Enqueue(current.Left);

                        if (current.Right != null)
                            Q.Enqueue(current.Right);
                        
                        nodeCountForLevel--;
                    }

				}
                return farthest;
			};


            int LeftLenght = 0;
            int RightLenght = 0;
           
            if (root == null)
                return 0;

            var cola = new Queue<BSTNode>();

            cola.Enqueue(root);

            int nodeCountPerLevel;

            while ((nodeCountPerLevel = cola.Count) > 0)
            {
                while (nodeCountPerLevel > 0)
                {
					BSTNode c = cola.Dequeue();
					int izq = FarthestLeaf(c.Left);
                    int der = FarthestLeaf(c.Right);

					if (izq > LeftLenght) 
                    {
						LeftLenght = izq;
                        
                    }
                    if (der > RightLenght) 
                    {
						RightLenght = der;

					}

                    if (c.Left != null) 
                        cola.Enqueue(c.Left);
                    if (c.Right != null)
                        cola.Enqueue(c.Right);

                    nodeCountPerLevel--;
                }
            }

            return LeftLenght+RightLenght;
        }

        public static int TreeHeightRecursive(BSTNode root)
        {
            if (root == null) return 0;
            return 1 + Math.Max(
                TreeHeightRecursive(root.Left),
                TreeHeightRecursive(root.Right));
        }

        public static int TreeHeightIterative(BSTNode root)
        {
            if (root == null) return 0;

            var Q = new Queue<BSTNode>();
			int height = 0;
            int nodeCount = 0;

            Q.Enqueue(root);

            BSTNode current;

            while (Q.Count > 0)
			{
                nodeCount = Q.Count;

                if (nodeCount == 0) 
                    return height;

                height++;

                while (nodeCount > 0)
                {
                    current = Q.Dequeue();
                    if (current.Left != null)
                        Q.Enqueue(current.Left);
                    if (current.Right != null)
                        Q.Enqueue(current.Right);
                    nodeCount--;
                }
			}
            return height;
        }
        public static bool SumTreeRecursive(BSTNode root)
        { // O(n log n)
            if (root == null) return true;

            var leftSum = SumTreeRecursiveAuxiliar(root.Left);
            var rightSum = SumTreeRecursiveAuxiliar(root.Right);

            Boolean sumtree;
            if (leftSum + rightSum != 0) sumtree = root.Value == leftSum + rightSum;
            else sumtree = true;

            if (sumtree)
                return SumTreeRecursive(root.Left) && SumTreeRecursive(root.Right);

            return false;
        }

        public static int SumTreeRecursiveAuxiliar(BSTNode root)
        {
            if (root == null) return 0;
            return root.Value + SumTreeRecursiveAuxiliar(root.Left) + SumTreeRecursiveAuxiliar(root.Right);
        }

        public static Boolean SumTreeIterative(BSTNode root)
        {
            var L = new List<int>(); //for storing level sums
            var Q = new Queue<BSTNode>();

            while (Q.Count > 0)
            {
                int levelSum = 0;
                int levelCount = Q.Count;

                while (levelCount > 0)
                {
                    BSTNode node = Q.Dequeue();
                    levelSum += node.Value;
					Q.Enqueue(node.Left);
                    Q.Enqueue(node.Right);
                    levelCount--;
                }
                L.Add(levelSum);
            }

            //aqui hay que procesar el arbol desde las hojas hacia la raiz usando un arreglo que contenga el arbol.
            // al sumar dos hojas hay que ir al padre y verificar que el padre sea igual que la suma de las hojas.
            // Si el padre es igual a la suma de las hojas, entonces reemplazar el padre con la suma de hojas+padre.
            // Si habiendo llegado a la raiz coincide, retornar true, de lo contrario false;
            // Esto es un caso que se resolveria facilmente teniendo puntero al padre en el arbol.
            //Asi que esta bueno suponer un arbol doblemente vinculado.

            return true;

        }




        public static void InOrderRecursive(BSTNode root)
        {
            if (root is null) return;

            InOrderRecursive(root.Left);
			Console.Write(root.Value+ ",");
			InOrderRecursive(root.Right);
        }

        public static void InOrderIterative(BSTNode root)
        {
            //    2
            //   1  3  
            // result: 1,2,3
            // seems infix notation 1 + 3



            
        }

		public static void PreOrderRecursive(BSTNode root)
		{
			//    2
			//   1  3  
			// result: 2,1,3 
            // seems prefix Notation + 1,3 
			if (root is null) return;

			Console.Write(root.Value+ ",");
			PreOrderRecursive(root.Left);
			PreOrderRecursive(root.Right);
		}

		public static void PosOrderRecursive(BSTNode root)
		{
			//    2
			//   1  3  
			// result: 1,3,2
            // seem posfix notation 1,3 +
			if (root is null) return;

            PosOrderRecursive(root.Left);
            PosOrderRecursive(root.Right);
			Console.Write(root.Value+",");
		}


        public static void Program()
        {
            BinarySearchTree bst = new BinarySearchTree();
            //  Object initializer syntax {
            //       Aux = 0,
            //       Value = 0,
            //       Left = null,
            //       Right = null
            //};

            bst.Insert(1);
            bst.Insert(2);
            bst.Insert(5);
            bst.Insert(7);
            bst.Insert(10);
            bst.Insert(13);
            bst.Insert(15);
            bst.Insert(16);
            bst.Insert(17);
            bst.Insert(18);
            bst.Insert(19);
            bst.Insert(20);
            Console.WriteLine(bst.IterativeTreeSearch(-5));
            Console.WriteLine(bst.IterativeTreeSearch(-53));
            bst.InOrderNoRecursion();
            bst.InorderTraversal(bst.Root);
            Console.WriteLine(bst.Minimum());
            //bst.Root.Right.Right.Value = 1000;
            Console.WriteLine(bst.CheckIfBST(bst.Root));
            Console.WriteLine(bst.LowestCommonAncestor(17, 15));

            //other problem
            BSTNode BinaryTree = new BSTNode(1);
            BinaryTree.Left = new BSTNode(2);
            BinaryTree.Right = new BSTNode(3);
            BinaryTree.Left.Left = new BSTNode(4);
            BinaryTree.Left.Right = new BSTNode(5);
            BinaryTree.Right.Left = new BSTNode(6);
            BinaryTree.Right.Right = new BSTNode(7);
            BinaryTree.Left.Left.Left = new BSTNode(8);
            BinaryTree.Left.Left.Right = new BSTNode(9);
            BinaryTree.Left.Right.Left = new BSTNode(10);
            BinaryTree.Left.Right.Right = new BSTNode(11);
            BinaryTree.Right.Left.Left = new BSTNode(12);
            BinaryTree.Right.Left.Right = new BSTNode(13);
            BinaryTree.Right.Right.Left = new BSTNode(14);
            BinaryTree.Right.Right.Right = new BSTNode(15);

            Array2Matrix(BST2Array(BinaryTree, 15));

            //other problem
            BinaryTree.Right.Right.Right.Right = new BSTNode(16);
            BinaryTree.Right.Right.Right.Right.Right = new BSTNode(17);
            BinaryTree.Right.Right.Right.Right.Right.Right = new BSTNode(18); //height 7
            BinaryTree.Right.Right.Right.Right.Right.Right.Right = new BSTNode(19); //height 8
            BinaryTree.Right.Right.Right.Right.Right.Right.Left = new BSTNode(20);
            BinaryTree.Right.Right.Right.Right.Right.Right.Left.Left = new BSTNode(21); //height 9
            Console.WriteLine("tree height recursive:" + TreeHeightRecursive(BinaryTree));
            Console.WriteLine("tree height iterative:" + TreeHeightIterative(BinaryTree));
            Console.WriteLine("longest leaf-to-leaft path size:" + LongestLeafToLeafPath(BinaryTree));
            LongestLeafToLeafPathRoute(BinaryTree).ForEach(Console.WriteLine);


            //other problem
            var BinaryTree2 = new BSTNode(1);
            BinaryTree2.Left = new BSTNode(2);
            BinaryTree2.Right = new BSTNode(3);
            BinaryTree2.Left.Left = new BSTNode(4);
            BinaryTree2.Left.Right = new BSTNode(5);
            BinaryTree2.Right.Right = new BSTNode(6);
            BinaryTree2.Left.Left.Left = new BSTNode(7);
            BinaryTree2.Left.Left.Right = new BSTNode(8);
            BinaryTree2.Left.Right.Right = new BSTNode(9);
            BinaryTree2.Left.Left.Right.Left = new BSTNode(10);
            BinaryTree2.Left.Right.Right.Right = new BSTNode(11);
            BinaryTree2.Left.Left.Right.Left.Left = new BSTNode(12);
            BinaryTree2.Left.Right.Right.Right.Right = new BSTNode(13);
            Console.WriteLine("tree height recursive:" + TreeHeightRecursive(BinaryTree2));
            Console.WriteLine("tree height iterative:" + TreeHeightIterative(BinaryTree2));
            Console.WriteLine("longest leaf-to-leaft path size:" + LongestLeafToLeafPath(BinaryTree2));
            LongestLeafToLeafPathRoute(BinaryTree2).ForEach(Console.WriteLine);



            //  sumtree other problem
            var BinaryTree3 = new BSTNode(30);
            BinaryTree3.Left = new BSTNode(10);
            BinaryTree3.Right = new BSTNode(5);
            BinaryTree3.Left.Left = new BSTNode(6);
            BinaryTree3.Left.Right = new BSTNode(4);
            BinaryTree3.Right.Left = new BSTNode(3);
            BinaryTree3.Right.Right = new BSTNode(2);
            Console.WriteLine(SumTreeRecursive(BinaryTree3));
            Console.WriteLine("Preorder:");
            PreOrderRecursive(BinaryTree3);
            Console.WriteLine();
            Console.WriteLine("Inorder:");
            InOrderRecursive(BinaryTree3);
            Console.WriteLine();
            Console.WriteLine("Posorder:");
            PosOrderRecursive(BinaryTree3);

        }
    }

}