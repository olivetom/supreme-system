import java.util.Iterator;

/**
 * Created by moliveto on 8/23/17.
 * Generic Iterable Stack using arrays and amortized constant time access
 */


public class Stack<E> implements Iterable<E>
{
    Node first;

    private class Node
    {
        E item;
        Node next;

    }

    public Iterator<E> iterator()
    {
        return new MyListIterator();
    }

    private class MyListIterator implements Iterator<E>
    {
        private Node current = first;

        public boolean hasNext()
        {
            return current != null;
        }

        public E next() // falta exception para vacio
        {
            E item = current.item;
            current = current.next;
            return item;
        }
    }

    /* FOR ARRAY IMPLEMENTATION OF STACK

    public Iterator<E> iterator()
    {
        return new ReverseArrayIterator();
    }

    public class ReverseArrayIterator implements Iterator<E>
    {
        private int i = N;

        public boolean hastNext()
        {
            return i > 0;
        }

        public E next()
        {
            return a[--i];
        }
    }     */

}
