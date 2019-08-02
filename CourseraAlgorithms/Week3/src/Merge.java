import edu.princeton.cs.algs4.Insertion;

/**
 * Von Neumann was the inventor
 * Mergesort is an optimal sort with n log n upper bound. Is stable sort. Its used for java object sorting.
 * Compares? Mergesort is optimal with respect to number compares.
 * Space? Mergesort is not optimal with respect to space usage.
 * Created by moliveto on 8/29/17.
 */
public class Merge
{
    private static void merge(Comparable[] a, Comparable[] aux, int lo, int mid, int hi)
    {
        assert isSorted(a, lo, mid); // precondition: a[lo..mid] sorted
        assert isSorted(a, mid + 1, hi); // precondition: a[mid+1..hi] sorted

        for (int k = lo; k <= hi; k++)
            aux[k] = a[k];

        int i = lo, j = mid + 1;

        for (int k = lo; k <= hi; k++)
        {
            if (i > mid) a[k] = aux[j++]; // exhausted left subarray
            else if (j > hi) a[k] = aux[i++];  // exhausted right subarray
            else if (less(aux[j], aux[i])) a[k] = aux[j++];  // copy from right subarray
            else a[k] = aux[i++];  // copy from left subarray
        }
        assert isSorted(a, lo, hi); // postcondition: a[lo..hi] sorted
    }

    /**
     * Checks if incrementally sorted
     * @param a
     * @param lo
     * @param hi
     * @return
     */
    private static boolean isSorted(Comparable[] a, int lo, int hi)
    {
        for (int i = lo; i < hi - 1; i++)
        {
            if (less(a[i + 1], a[i])) return false;
        }
        return true;
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

    /**
     * Merge sort with insertion sort for ~ 7 size arrays
     * @param a
     * @param aux
     * @param lo
     * @param hi
     */
    private static void sort(Comparable[] a, Comparable[] aux, int lo, int hi)
    {
        if (hi <= lo) return;
        if (hi <= lo + 7 - 1)
        {
            Insertion.sort(a, lo, hi);
            return;
        }
        int mid = lo + (hi - lo) / 2;
        sort(a, aux, lo, mid);
        sort(a, aux, mid+1, hi);
        merge(a, aux, lo, mid, hi);
    }

    public static void sort(Comparable[] a)
    {
        Comparable[] aux = new Comparable[a.length];
        sort(a, aux, 0, a.length - 1);
    }

    /**
     * Non recursive bottom up mergesort. N log N
     * Pass through array, merging subarrays of size 1.
     * Repeat for subarrays of size 2, 4, 8, 16, ....
     * about 10% slower than recursive top-down mergesort on typical systems
     * @param a
     */
    public static void sortNonRecursive(Comparable[] a)
    {
        int N = a.length;
        Comparable[] aux = new Comparable[N];
        for (int sz = 1; sz < N; sz = sz+sz)
            for (int lo = 0; lo < N-sz; lo += sz+sz)
                merge(a, aux, lo, lo+sz-1, Math.min(lo+sz+sz-1, N-1));
    }

}