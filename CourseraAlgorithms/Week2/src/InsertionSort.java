import java.util.Comparator;

/**
 * Created by moliveto on 8/25/17.
 * Insertion Sort. Is stable
 */
public class InsertionSort
{
    public static void sort(Comparable[] a)
    {
        int N = a.length;
        for (int i = 0; i < N; i++)
        {
            for (int j = i; j > 0; j--)  //to many exchanges when reverse ordered array input
            {
                if (less(a[j], a[j - 1]))  // runs linear when partially ordered input
                    exch(a, j, j - 1);
                else break;
            }
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

    /**
     * Overloaded methods to use with to support Princenton comparators
     * @param a
     * @param comparator
     */
    public static void sort(Object[] a, Comparator comparator)
    {
        int N = a.length;
        for (int i = 0; i < N; i++)
            for (int j = i; j > 0 && less(comparator, a[j], a[j-1]); j--)
                exch(a, j, j-1);
    }
    private static boolean less(Comparator c, Object v, Object w)
    {
        return c.compare(v, w) < 0;
    }

    private static void exch(Object[] a, int i, int j)
    {
        Object swap = a[i];
        a[i] = a[j];
        a[j] = swap;
    }
}
