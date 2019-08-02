using System;
using System.Collections.Generic;

public static class Matrices
{


    public static void Trasponer(int[,] a, out int[,] b)
    {// trasponer matriz de m x n
        int m = a.GetLength(0), n = a.GetLength(1);

		//int[,] b = new int[n, m];
		b = new int[n, m];

		for (int i = 0; i < m; i++)
        {
            for (int j = i; j < n; j++)
            {
				b[j, i] = a[i, j];

			}
        }
        //a = b;
    }

	public static void Producto(int[,] a, int[,] b, out int[,] c)
	{
        if (((a.GetLength(0) != b.GetLength(1)) || (a.GetLength(1) != b.GetLength(0)))) 
        {
            c = null;
            return;
        }

        c = new int[a.GetLength(0), b.GetLength(1)];

        for (int i = 0; i < a.GetLength(0); i++)
        {
            for (int j = 0; j < b.GetLength(1); j++)
            {
                c[i, j] = 0;
                for (int k = 0; k < a.GetLength(1); k++)
                {
                    c[i, j] += a[i, k] * b[k, i];

                }
            }
        }

    }

    public static void Rotar90( char[,] m)
    { //rotar 90 grados a la derecha una matriz cuadrada
        char[,] n = new char[3,3];

        //usando otra matriz para los resultados
        for (int i = 0; i < m.GetLength(0); i++)
        {
            for (int j = 0; j < m.GetLength(0); j++)
            {
                //int aux = m[i, j]; 
                int k = m.GetLength(0) - 1 - j;
                n[i, j] = m[k, i];
                //m[k, j] = aux;
            }
        }


        for (int i = 0; i < n.GetLength(0); i++)
        {
            for (int j = 0; j < n.GetLength(0); j++)
            {
                Console.Write(n[i,j]+" ");

            }
            Console.WriteLine();
        }

    }

    public static void Blanquear(int[,] m)
    {
        // Write an algorithm such that if an element in an MxN matrix is 0, its entire row and column are set to 0.
        // algorith doesnt consider m=0 or n=0
        int max = m.GetLength(0);

        for (int i = 0; i < max; i++)
        {
            for (int j = 0; j < max; j++)
            {
                if (m[i,j] == 0) 
                {
                    //zeroing just first cell at north and west to not mess unvisited cell
                    m[0, j] = m[i, 0] = 0;
                }
            }
        }
        for (int i = 0; i < max; i++)
        {
            if (m[i,0] == 0)
            {
                for (int j = 0; j < max; j++)
                {
                    m[i, j] = 0;
                }
            }
        }

        for (int j = 0; j < max; j++)
		{
			if (m[0, j] == 0)
			{
				for (int i = 0; i < max; i++)
				{
					m[i, j] = 0;
				}
			}
		}

        for (int i = 0; i < max; i++)
        {
            for (int j = 0; j < max; j++)
            {
                Console.Write(m[i, j] + " ");

            }
            Console.WriteLine();
        }

	}

	internal static int SumPath(int[][] m, int col, int row = 0)
    { /* There is a N*N integer matrix Arr[N][N]. From the row r and column c, we can go to any of the following three indices:

		I.                Arr[ r+1 ][ c-1 ] (valid only if c-1>=0)

		II.               Arr[ r+1 ][ c ]

		III.              Arr[ r+1 ][ c+1 ] (valid only if c+1<=N-1)

		So if we start at any column index on row 0, what is the largest sum of any of the paths till row N-1.
		*/
        int N = m.GetLength(0);
		int sumLeft = 0;

        int sumCenter = 0;

        int sumRight = 0;

        if (row == N - 1)
        {
			return m[row][col];
        }
        else
        {
            if (col - 1 >= 0) sumLeft = m[row][col] + SumPath(m, col - 1, row + 1);

            sumCenter = m[row][col] + SumPath(m, col, row + 1);

            if (col + 1 < N) sumRight = m[row][col] + SumPath(m, col + 1, row + 1);

            if (sumLeft > sumCenter && sumLeft > sumRight)
                return sumLeft;

            if (sumCenter > sumLeft && sumCenter > sumRight)
                return sumCenter;

            return sumRight;
		}
 
    }

    public static void Program()
    {
        // single-dimension jagged array
        var c = new[]
		{
		    new[]{1,2,3,4},
		    new[]{5,6,777,8},
			new[]{9,10,11,12},
			new[]{134,14,15,1666},
		};
        Console.WriteLine(SumPath(c,1));
        // jagged array of strings
        var d = new[]
		{
		    new[]{"Luca", "Mads", "Luke", "Dinesh"},
		    new[]{"Karen", "Suma", "Frances"}
		};
    }

}

