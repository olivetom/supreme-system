using System;
namespace LeetCode.GeeksForGeeks
{
	public class MaxHeap
	{
		// property of the minHeap A[i] <= A[Parent(i)]
		private readonly int[] Elements;
		private int HeapSize;
		private readonly int Capacity;

		public MaxHeap()
		{
			HeapSize = 0;
			Capacity = 10;
			Elements = new int[Capacity];
		}

		public int Parent(int i)
		{
            return (int)Math.Floor((double)(i - 1)  / 2);
		}


		public void Insert(int newElement)
		{
			if (++HeapSize > Capacity) return;

			int i = HeapSize - 1;

			Elements[i] = newElement;

			// Fix the min heap property if it is violated
			while (i != 0 && Elements[Parent(i)] < Elements[i])
			{
				int aux = Elements[Parent(i)];
				Elements[Parent(i)] = Elements[i];
				Elements[i] = aux;
				i = Parent(i);
			}
		}

        public int Left(int i)
        {
            return 2 * i + 1;
        }

        public int Right(int i)
        {
            return 2 * i + 2;
        }

		public void MaxHeapify(int i)
		{
			int l = Left(i);
			int r = Right(i);
			int largest = i;
			
            if (l < HeapSize && Elements[l] > Elements[i])
				largest = l;
			
            if (r < HeapSize && Elements[r] > Elements[largest])
				largest = r;
			
            if (largest != i)
			{
                int aux = Elements[i];
                Elements[i] = Elements[largest];
                Elements[largest] = aux;

				MaxHeapify(largest);
			}
		}



		// Method to remove maximun element (or root) from max heap
		public int ExtractMax()
		{
            if (HeapSize <= 0)
                return int.MaxValue;
            if (HeapSize == 1)
			{
                HeapSize--;
                return Elements[0];
			}

			// return the maximun value, and remove it from heap
            int root = Elements[0];
            Elements[0] = Elements[HeapSize - 1];
            Elements[HeapSize - 1] = 0;
			HeapSize--;

            //heapify tree
			MaxHeapify(0);

			return root;
		}

		public static void Program()
		{
			MaxHeap maxHeap = new MaxHeap();

			maxHeap.Insert(40);
			maxHeap.Insert(80);
			maxHeap.Insert(35);
			maxHeap.Insert(90);
			maxHeap.Insert(45);
			maxHeap.Insert(50);
			maxHeap.Insert(70);
            maxHeap.ExtractMax();
		}
	}
}
