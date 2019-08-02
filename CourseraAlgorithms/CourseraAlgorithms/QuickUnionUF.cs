using System;
namespace CourseraAlgorithms
{
    public class QuickUnionUF
    {
		private int[] id;
        private int N { get { return id.Length; } }

		public QuickUnionUF(int N)
        {
			id = new int[N];
			for (int i = 0; i < N; i++)
			{
				id[i] = i;
			}
        }

        private int Root(int i)
        { // O(depth of i)
            while (i != id[i]) 
            {
                id[i] = id[id[i]];
				i = id[i];
            }
            return i;
        }

        public Boolean Connected(int p, int q)
        {
            return Root(p) == Root(q);
        }

        public void Union(int p, int q) //O(n)
        {
			var proot = Root(p);
			var qroot = Root(q);

            id[proot] = qroot;
        }
    }
}
