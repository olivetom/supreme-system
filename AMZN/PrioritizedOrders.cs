using System;
using System.Collections.Generic;

// IMPORT LIBRARY PACKAGES NEEDED BY YOUR PROGRAM
// SOME CLASSES WITHIN A PACKAGE MAY BE RESTRICTED
// DEFINE ANY CLASS AND METHOD NEEDED
// CLASS BEGINS, THIS CLASS IS REQUIRED
public class Main
{
    // METHOD SIGNATURE BEGINS, THIS METHOD IS REQUIRED
    public List<String> prioritizedOrders(int numOrders, List<String> orderList)
    {
        // WRITE YOUR CODE HERE
        orderList.sort((o1, o2)->

                (o1.split(" ", 1)[1] + o1.split(" ", 1)[0]).compareTo(o2.split(" ", 1)[1] + o2.split(" ", 1)[0]));

        // another option could be
        //
        orderList.sort(
                Comparator.comparing(String::getPrimeId).thenComparing(String::getCommonId)
        );
        return orderList;
    }
    // METHOD SIGNATURE ENDS
}


public static void main(String[] args)
{
    // write your code here
    //int[] states = {1,0,0,0,0,1,0,0};
    int[] states = { 1, 1, 1, 0, 1, 1, 1, 1 };
    Main m = new Main();
    System.out.println(Arrays.stream(states).boxed().collect(Collectors.toList()));
    System.out.println(m.cellCompete(states, 2));
}
