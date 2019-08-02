using System;
using System.Collections.Generic;

namespace LeetCode.Cormen
{
    public static class SortingAlgorithms
    {
        public static string InsertionSort(char[] a)
        {
            int max = a.Length;
            for (int j = 1; j < max; j++)
            {
                //insert a[j] into sorted sequence a[1]..a[j-1]
                int i = j - 1;
                while ((i >= 0) && (a[i] > a[i + 1]))
                {
                    char aux = a[i + 1];
                    a[i + 1] = a[i];
                    a[i] = aux;
                    i--;
                }
            }
            return new string(a);
        }

        public static string MergeSort(char[] a, int inicio, int fin)
        { // call MergeSort(a, 0, length(a))
            if (inicio < (fin - 1))
            {
                int mitad = (int)Math.Floor((float)(inicio + fin + 1) / 2);
                MergeSort(a, inicio, mitad);
                MergeSort(a, mitad + 1, fin - 1);
                Merge2(a, inicio, mitad, fin - 1);
            }

            return new string(a);
        }

        private static void Merge(char[] a, int inicio, int mitad, int fin)
        {
            char[] b = new char[a.Length];

            //firtst half from 0...mitad and second half from mitad+1...fin

            //int h = inicio, i = inicio, j = mitad + 1, k;
            int h = inicio, i = inicio, j = mitad + 1, k;

            while ((h < mitad) && (j < fin))
            {
                if (a[h] <= a[j])
                {
                    b[i] = a[h];
                    h++;
                }
                else
                {
                    b[i] = a[j];
                    j++;
                }
                i++;
            }

            if (h > mitad)
                for (k = j; k <= fin; k++)
                {
                    b[i] = a[k];
                    i++;
                }
            else
                for (k = h; k < mitad; k++)
                {
                    b[i] = a[k];
                    i++;
                }

            for (k = inicio; k < fin; k++)
                a[k] = b[k];
        }


        //        Rewrite the MERGE procedure so that it does not use sentinels, instead
        //stopping once either array L or R has had all its elements copied back to
        //A and then copying the remainder of the other array back into A.

        public static void Merge2(char[] a, int p, int q, int r)
        {
            int n1 = q - p + 1;
            int n2 = r - q;
            char[] L = new char[n1];
            char[] R = new char[n2];
            int i, j, k;
            for (i = 0; i < n1; i++)
                L[i] = a[p + i];
            //original L[i] = a[p + i - 1];
            for (j = 0; j < n2; j++)
            {
                R[j] = a[q + j];
            }
            i = 0;
            j = 0;
            //original i = 1;
            //original j = 1;
            for (k = p; k < r; k++)
            {
                if ((i < L.Length) && (j < R.Length))

                    if (L[i] <= R[j])
                    {
                        a[k] = L[i];
                        i++;
                    }
                    else
                    {
                        a[k] = R[j];
                        j++;
                    }
                else
                if (i < L.Length)
                {
                    a[k] = L[i];
                    i++;
                }
                else
                {
                    a[k] = R[j];
                    j++;

                }
            }
        }

      

        public static void SelectionSort(int[] arr)
        {
            //pos_min is short for position of min
            int pos_min, temp;

            for (int i = 0; i < arr.Length - 1; i++)
            {
                pos_min = i;//set pos_min to the current index of array

                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[j] < arr[pos_min])
                    {
                        //pos_min will keep track of the index that min is in, this is needed when a swap happens
                        pos_min = j;
                    }
                }

                //if pos_min no longer equals i then a smaller value must have been found, so a swap must occur
                if (pos_min != i)
                {
                    temp = arr[i];
                    arr[i] = arr[pos_min];
                    arr[pos_min] = temp;
                }
            }
        }

        public static int[] BubleSort(int[] input)
        {
            for (int i = 0; i < input.Length; i++)
            {
                for (int j = 0; j < input.Length - i - 1; j++)
                {
                    if (input[j] > input[j+1])
                    {
                        Swap(ref input[j], ref input[j+1]);
                    }
                }
            }
            return input;
        }

        private static void Swap(ref int a, ref int b)
        {
            int aux = a;
            a = b;
            b = aux;
        }

        public static void HeapSort()
        {}

         
    }
}
