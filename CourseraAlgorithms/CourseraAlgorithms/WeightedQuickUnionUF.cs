using System;
namespace CourseraAlgorithms
{
    public class WeightedQuickUnionUF
    {
		private int[] id;
        private int[] sz;
		private int N { get { return id.Length; } }

        public WeightedQuickUnionUF(int N)
		{
			id = new int[N];
			for (int i = 0; i < N; i++)
			{
				id[i] = i;
                sz[i] = 0;
			}
		}

		private int Root(int i)
		{ // O(depth of i)
			while (i != id[i]) i = id[i];
			return i;
		}

		public Boolean Connected(int p, int q)
		{
			return Root(p) == Root(q);
		}

        public void Union(int p, int q) // O(lg n)
		{
			var proot = Root(p);
			var qroot = Root(q);

            if (proot == qroot) return;
            if (sz[proot] < sz[qroot])
            {
				id[proot] = qroot;
                sz[proot] += sz[qroot];           
            }
            else
            {
                id[qroot] = proot;
                sz[qroot] += sz[proot];
            }
		}
    }
}
