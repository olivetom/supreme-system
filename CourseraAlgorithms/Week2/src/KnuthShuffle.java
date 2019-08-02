/**
 * Created by moliveto on 8/28/17.
 * Week 3 Shuffling in linear time
 * Max shuffles is given by N!  (N factorial)
 * So it depends on the size in bits of the seed
 * e.g. if seed is 32 bits => 2^32 shuffles. Which is not enough if you have more than 32 cards.
 */

import edu.princeton.cs.algs4.StdRandom;

public class KnuthShuffle
{

    public static void shuffle(Object[] a)
    {
        int N = a.length;

        for (int i = 0; i < N; i++)
        {
            exch(a, i, StdRandom.uniform(i + 1));  // random integer between [0, i + 1)
        }
    }

    private static boolean less(Comparable v, Comparable w)
    {
        return v.compareTo(w) < 0;
    }

    private static void exch(Object[] a, int i, int j)
    {
        Object swap = a[i];
        a[i] = a[j];
        a[j] = swap;
    }

}
