using System;
using System.Collections.Generic;

namespace LeetCode.GeeksForGeeks
{

    /*
* Design a data structure for the following operations:
* 
* I. Enqueue
* II. Dequeue
* III. Delete a given number(if it is present in the queue, else do nothing)
* IV. isNumberPresent
* 
* All these operations should take O(1) time
*/
    public class HashQueue
    {
        private LinkedList<int> MyQueue;
        private Dictionary<int, LinkedListNode<int>> NodePointerTable;

        public HashQueue()
        {
            MyQueue = new LinkedList<int>();
            NodePointerTable = new Dictionary<int, LinkedListNode<int>>();
        }

        public void Enqueue(int data)
        {
            if (!NodePointerTable.ContainsKey(data))
            {
                MyQueue.AddLast(new LinkedListNode<int>(data));
                NodePointerTable.Add(data, MyQueue.Last);
            }
        }

        public int Dequeue()
        {
            int ret;
            if (MyQueue.Count > 0)
            {
                ret = MyQueue.First.Value;
                if (NodePointerTable.Remove(ret)) return ret;
            }
            throw new ArgumentException();
        }


        public void DeleteGivenNumber(int data)
        {
            if (NodePointerTable.ContainsKey(data))
            {
                NodePointerTable.TryGetValue(data, out LinkedListNode<int> del);
                MyQueue.Remove(del);
                //del.Previous.Next = del.Next;
                //del.Next.Previous = del.Previous;
                NodePointerTable.Remove(data);
            }
        }

        public Boolean IsNumberPresent(int data)
        {
            if (NodePointerTable.ContainsKey(data)) return true;
            return false;
        }

        public static void Program()
        {
            HashQueue hq = new HashQueue();
            hq.Enqueue(1);
			hq.Enqueue(2);
			hq.Enqueue(3);
			hq.Enqueue(4);
			hq.Enqueue(5);
            hq.DeleteGivenNumber(3);
		}
    }

}
