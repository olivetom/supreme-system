using System;
namespace CourseraAlgorithms
{
    public class QuickFindUF
    {
        private int[] id;
        private int N { get { return id.Length; } }

		public QuickFindUF(int N)
        {
            id = new int[N];
            for (int i = 0; i < N; i++)
            {
                id[i] = i;
            }
        }

        public Boolean Connected(int p, int q)
        {
            try
            {
				if (id[p] == id[q]) return true;
            } 
            catch (Exception) 
            {
                throw new ArgumentOutOfRangeException();
            }
            return false;
        }

        public void Union(int p, int q)
        {
            int pid = id[p];
            int qid = id[q];

            for (int i = 0; i < N; i++)
            {
                if (id[i] == pid)
                {
                    id[i] = qid;
                }

            }
        }
    }
}
