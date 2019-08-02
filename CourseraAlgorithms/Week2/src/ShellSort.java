/**
 * Created by moliveto on 8/27/17.
 * Shell sort. h values are from empirical studies. Not stable.
 */
public class ShellSort
{
    public static void sort(Comparable[] a)
    {
        int N = a.length;
        int h = 1;
        while (h < N / 3)
            h = 3 * h + 1; // 1, 4, 13, 40, 121, 364,   Donald Knuth ~ 1960

        while (h >= 1)
        { // h-sort the array.  If sorted array it takes linearithmic time
            for (int i = h; i < N; i++)
            {
                for (int j = i; j >= h; j -= h)  //to many exchanges when reverse ordered array input
                {
                    if (less(a[j], a[j - h]))  // runs linear when partially ordered input
                        exch(a, j, j - h);
                    else break;
                }
                /**
                 * another option without if
                 * for (int j = i; j >= h && less(a[j], a[j-h]); j -= h)
                 *          exch(a, j, j-h);
                 */
            }
            h /= 3;  //move down or back to the next lower value of h
        }
    }

    private static boolean less(Comparable v, Comparable w)
    {
        return v.compareTo(w) < 0;
    }

    private static void exch(Comparable[] a, int i, int j)
    {
        Comparable swap = a[i];
        a[i] = a[j];
        a[j] = swap;
    }


}
