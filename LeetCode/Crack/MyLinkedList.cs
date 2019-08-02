using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Crack
{
    class MyLinkedList<T>
    {
        LinkedListNode<T> Head { get; set; }
        int Count { get; set; } = 0;


        void DeleteElementByShifting(LinkedListNode<T> element)
        { //doesnt work if element is last element. Or it should be blanked and considered dummy
            var curr = element;
            var next = element.Next;

            while (curr != null && next != null)
            {
                //shift next node value to the previous node
                curr.Value = next.Value;
                //curr.Next = next.Next;
                curr = next;
            }
        }


        //void Partition(T x, out LinkedListNode<T> l1, out LinkedListNode<T> l2)
        //{/*  Write code to partition a linked list around a value x, such that all nodes less than x come before 
        // all nodes greater than or equal to x. */
		 //insert all nodes to a min heap if you want ordered results
		 // then extract all element smaller than x to one list and all elements >= x to another list.
		 //return both lists.

			//if you dont want ordered results, you should iterate over the list comparing for >= x
			// then extract all element smaller than x to one list and all elements >= x to another list.
			//return both lists or a concatenation of both lists.


		//}

        public static List<int> TwoSum(LinkedList<int> num1, LinkedList<int> num2)
        {
            //You have two numbers represented by a linked list, where each node contains a singledigit.
            //The digits are stored in reverse order,such that the 1's digit is at the head of the list. 
            //Write a function that adds the two numbers and returns the sum as a linked list.

            //Assumptions: both lists have at least one element 

            //result will be as larger as the largest num, at least.

            var result = new LinkedList<int>();

            var largestList = num1.Count >= num2.Count ? num1 : num2;
			var largestListEnumerator = num1.Count >= num2.Count ? num1.GetEnumerator() : num2.GetEnumerator();
			var shortestListEnumerator = num1.Count < num2.Count ? num1.GetEnumerator() : num2.GetEnumerator();


            int carry = 0;

            while (shortestListEnumerator.MoveNext() && largestListEnumerator.MoveNext())
            {
                var sum = shortestListEnumerator.Current + largestListEnumerator.Current + carry;

                var resultDigit = sum >= 10 ? sum - 10 : sum;

                result.AddLast(resultDigit);

                carry = sum >= 10 ? 1 : 0;

            } 

            while (largestListEnumerator.MoveNext())
            {
				var sum = largestListEnumerator.Current + carry;

				var resultDigit = sum >= 10 ? sum - 10 : sum;

				result.AddLast(resultDigit);

				carry = sum >= 10 ? 1 : 0;

			}

            if (carry > 0)
            {
                result.AddLast(carry);
            }

            return result.ToList();

        }

		public static List<int> TwoSum(int num1, int num2)
        {
            var res = TwoSum(new LinkedList<int>(num1.ToString().Reverse().Select(x => Convert.ToInt32(x.ToString())).ToList()),
                          new LinkedList<int>(num2.ToString().Reverse().Select(x => Convert.ToInt32(x.ToString())).ToList()));
            return res;
        }

        public static Boolean DetectLoop(LinkedList<MyNode> list)
        {
			//to detect a loop object references must be compared using a hash table 
			// two passes should be enough. First pass to hash all elements. Second pass to compare hashed elements to 
			var visited = new HashSet<MyNode>();
			var current = list;
			foreach (var item in list)
			{
				visited.Add(item);
				if (visited.Contains(item.Next))
					return true;
			}
            return false;
        }

        public static MyNode DetectLoopBis(MyNode head)
		{
			//to detect a loop object references without using auxiliary hash
            MyNode slow = head;
            MyNode fast = head;


            while (true)
            {
                slow = slow.Next;
                fast = fast.Next.Next;
                if (slow == fast)
                    break;
            }
            //fast = slow;
            slow = head;
            while (slow != fast)
			{
				slow = slow.Next;
				fast = fast.Next;
			}

            return slow;
		}

        //internal Boolean CheckPalindrome(MyNode head)
        //{
            
        //}

        internal class MyNode
        {
            internal int Value { get; set; }
            internal MyNode Next { get; set; }

            internal MyNode(int e)
            {
                Value = e;
            }
        }

		public static void Program()
        {
            var result = TwoSum(1999, 2888);
            result.ForEach(e => Console.Write(e));

            MyNode n1 = new MyNode(1);
			MyNode n2 = new MyNode(2);
			MyNode n3 = new MyNode(3);
			MyNode n4 = new MyNode(4);
			MyNode n5 = new MyNode(5);
			MyNode n6 = new MyNode(6);
			MyNode n7 = new MyNode(7);
			MyNode n8 = new MyNode(8);
			MyNode n9 = new MyNode(9);
			MyNode n10 = new MyNode(10);
			MyNode n11 = new MyNode(11);
			n1.Next = n2;
			n2.Next = n3;
			n3.Next = n4;
			n4.Next = n5;
			n5.Next = n6;
			n6.Next = n7;
			n7.Next = n8;
			n8.Next = n9;
			n9.Next = n10;
			n10.Next = n11;
			n11.Next = n1;
			
			Console.WriteLine();
            Console.WriteLine("Loop:{0}", DetectLoopBis(n1).Value);

        }
    }

	

}
