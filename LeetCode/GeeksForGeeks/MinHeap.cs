using System;
using System.Collections;

namespace LeetCode.GeeksForGeeks
{
    public class MinHeap
    {
        // property of the minHeap A[i] >= A[Parent(i)]
        private readonly int[] Elements;
        private int HeapSize;
        private readonly int Capacity;

        public MinHeap()
        {
			HeapSize = 0;
            Capacity = 10;
            Elements = new int[Capacity];
        }

        public int Parent(int i)
        {
            return (int)Math.Floor((double)(i - 1) / 2);
        }

        public int Left(int i)
        {
            return 2 * i + 1;
        }

        public int Right(int i)
        {
            return 2 * i + 2;
        }

        public void Insert(int newElement)
        {
            if (++HeapSize > Capacity) return;

            int i = HeapSize - 1;

            Elements[i] = newElement;

            // Fix the min heap property if it is violated
            while (i != 0 && Elements[Parent(i)] > Elements[i])
			{
                int aux = Elements[Parent(i)];
                Elements[Parent(i)] = Elements[i];
                Elements[i] = aux;
                i = Parent(i);
			}
        }

        public int ExtractMin()
        {
            int result = Elements[0];
            Elements[0] = Elements[HeapSize - 1];
            Elements[HeapSize - 1] = 0;
            HeapSize--;
            MinHeapify(0);
            return result;
        }

        public void MinHeapify(int i)
        {
            int smallest = i;

            if (Left(i) < HeapSize && Elements[Left(i)] < Elements[smallest])
                smallest = Left(i);

            if (Right(i) < HeapSize && Elements[Right(i)] < Elements[smallest])
                smallest = Right(i);

            if (smallest != i)
            {
                int aux = Elements[smallest];
                Elements[smallest] = Elements[i];
                Elements[i] = aux;

                MinHeapify(smallest);
            }
            
        }

        public static void Program()
        {
            MinHeap minheap = new MinHeap();

			minheap.Insert(40);
			minheap.Insert(80);
			minheap.Insert(35);
			minheap.Insert(90);
			minheap.Insert(45);
			minheap.Insert(50);
			minheap.Insert(70);
            minheap.Insert(10);
            minheap.ExtractMin();
        }
    }

	
}
