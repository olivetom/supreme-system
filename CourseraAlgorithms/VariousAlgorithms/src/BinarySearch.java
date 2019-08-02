import java.util.function.Supplier;

/**
 * Created by moliveto on 8/20/17.
 * Simple iterative binary search implementation
 */
public class BinarySearch
{

    public static void program(int element)
    {
        int[] integers = {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};
        final int numberOfElements = integers.length;

        int mid, hi, low;
        low = 0;
        hi = numberOfElements - 1;
        while (low <= hi)
        {
            mid = low + (hi - low) / 2;
            if (element < integers[mid]) hi = mid - 1;
            else if (element > integers[mid]) low = mid + 1;
            else
            {
                System.out.println(element + " element found at index: " + mid);
                return;
            }
        }
        if (low > hi) System.out.println("Not found");
    }


    //BinarySearch<String> stringContainer = new BinarySearch<>(String::new);
    //BinarySearch<String> stringContainer = new BinarySearch<>(() -> new String("lksadfdsaf"));

}
