/**
 * Created by moliveto on 8/29/17.
 * Mergesort Improvement
 * Stop if already sorted.
 * Is biggest item in first half &le; smallest item in second half?
 * Helps for partially-ordered arrays.
 */
public class MergingSmaller
{
    private static void sort(Comparable[] a, Comparable[] aux, int lo, int hi)
    {
        if (hi <= lo) return;
        int mid = lo + (hi - lo) / 2;
        sort (a, aux, lo, mid);
        sort (a, aux, mid+1, hi);
        if (!less(a[mid+1], a[mid])) return; // Stop if already sorted.
        merge(a, aux, lo, mid, hi);
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
}