import edu.princeton.cs.algs4.Insertion;
import edu.princeton.cs.algs4.StdRandom;
import edu.princeton.cs.algs4.StdStats;

/**
 * Created by moliveto on 8/30/17.
 * Not stable. In place
 * Worst case: Number of compares is quadratic. 1/2 N^2.
 * More likely that your computer is struck by lightning bolt.
 *
 * Average case: Number of compares is ~ 1.39 N lg N.
 * 39% more compares than mergesort.
 * But faster than mergesort in practice because of less data movement.
 *
 * Random shuffle:
 * Probabilistic guarantee against worst case.
 * Basis for math model that can be validated with experiments.
 * Java uses quicksort for primitive data types sorting.
 * */
public class Quick
{

    public static void sort(Comparable[] a)
    {
        StdRandom.shuffle(a);  // shuffle needed for performance guarantee
        sort(a, 0, a.length - 1);
    }

    public static void sort(Comparable[] a, int lo, int hi)
    {
        if (hi <= lo) return;
        int j = partition(a, lo, hi);
        sort(a, lo, j - 1);
        sort(a, j + 1, hi);
    }

    /**
     * Median of sample.
     * Best choice of pivot item = median.
     * Estimate true median by taking median of sample.
     * Median-of-3 (random) items.
     * @param a
     * @param lo
     * @param hi
     */
    private static void sortWithMedian(Comparable[] a, int lo, int hi)
    {
        if (hi <= lo + 10 - 1)
        {
            Insertion.sort(a, lo, hi);
            return;
        }

        //int m = StdStats.medianOf3(a, lo, lo + (hi - lo)/2, hi);
        //exch(a, lo, m);

        int j = partition(a, lo, hi);
        sort(a, lo, j - 1);
        sort(a, j + 1, hi);
    }

    private static int partition(Comparable[] a, int lo, int hi)
    {
        int i = lo;
        int j = hi + 1;
        while (true)
        {
            for (Comparable comparable : a)
            {
                System.out.print(comparable + ",");
            }
            System.out.println();
            while (less(a[++i], a[lo]))
                if (i == hi) break;
            while (less(a[lo], a[--j]))
                if (j == lo) break;
            if (i >= j) break; // check if pointers cross
            exch(a, i, j);

        }
        exch(a, lo, j);
        for (Comparable comparable : a)
        {
            System.out.print(comparable + ",");
        }
        System.out.println();
        return j;
    }

    /**
     * Returns true if v < w else false
     * Because compareTo returns -1 if v < w, 0 if v=w, 1 if w > v
     * @param v
     * @param w
     * @return
     */
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
     *  Goal. Given an array of N items, find a kth smallest item.
     *  Ex. Min (k = 0), max (k = N - 1), median (k = N / 2).
     *  Applications.
     *  Order statistics.
     *  Find the "top k."
     *
     *  Quick-select takes linear time on average.
     *  Remark. Quick-select uses ~ ½ N 2 compares in the worst case, but
     *  (as with quicksort) the random shuffle provides a probabilistic guarantee.
     *
     */
    public static Comparable select(Comparable[] a, int k)
    {
        StdRandom.shuffle(a);
        int lo = 0, hi = a.length - 1;
        while (hi > lo)
        {
            int j = partition(a, lo, hi);
            if (j < k) lo = j + 1;
            else if (j > k) hi = j - 1;
            else return a[k];
        }
        return a[k];
    }



    private static void sort3way(Comparable[] a, int lo, int hi)
    {
        if (hi <= lo) return;
        int lt = lo, gt = hi;
        Comparable v = a[lo];
        int i = lo;
        while (i <= gt)
        {
            int cmp = a[i].compareTo(v);
            if (cmp < 0) exch(a, lt++, i++);
            else if (cmp > 0) exch(a, i, gt--);
            else i++;
        }
        sort(a, lo, lt - 1);
        sort(a, gt + 1, hi);
        for (Comparable comparable : a)
        {
            System.out.print(comparable + ",");
        }
        System.out.println();
    }

    public static void main(String[] args)
    {
//        System.out.println(select(new Comparable[]{7, 6, 5, 12, 4, 7, 10, 3, 7, 11, 2}, 0));
        sort3way(new Comparable[]{7, 6, 5, 12, 4, 7, 10, 3, 7, 11, 2}, 0, 10);

    }
}
