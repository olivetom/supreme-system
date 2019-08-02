import java.util.Iterator;

/**
 * Created by moliveto on 8/25/17.
 * Dequeue. A double-ended queue or deque (pronounced "deck") is a generalization of a
 * stack and a queue that supports adding and removing items from either the front or
 * the back of the data structure.
 */
public class Deque<Item> implements Iterable<Item>
{

    public Node<Item> getHead()
    {
        return head;
    }

    public void setHead(Node<Item> head)
    {
        this.head = head;
    }

    public Node<Item> getTail()
    {
        return tail;
    }

    public void setTail(Node<Item> tail)
    {
        this.tail = tail;
    }

    private Node<Item> head, tail;
    private int count;


    /**
     * This is for Factory pattern
     * private Deque()
     * {
     * }
     * <p>
     * public static <Item> Deque<Item> createDeque()
     * {
     * return new Deque<Item>();
     * }
     */


    public Deque()                           // construct an empty deque
    {
        count = 0;
    }

    public boolean isEmpty()                 // is the deque empty?
    {
        return count > 0;
    }

    public int size()                        // return the number of items on the deque
    {
        return count;
    }

    public void addFirst(Item item)          // add the item to the front
    {
        Node<Item> newNode = new Node<Item>(item);
        newNode.nextNode = head;
        head = newNode;
        newNode.previousNode = null;
        if (tail == null)
            tail = newNode;
        else
            tail.previousNode = newNode;

        count++;
    }

    public void addLast(Item item)           // add the item to the end
    {
        Node<Item> newNode = new Node<Item>(item);
        newNode.previousNode = tail;
        tail = newNode;
        newNode.nextNode = null;
        if (head == null)
            head = newNode;
        else
            head.nextNode = newNode;

        count++;
    }

    public Item removeFirst()                // remove and return the item from the front
    {
        if (head == null) throw new java.util.NoSuchElementException();
        Node<Item> resultNode = head;
        count--;

        if (head == tail)
        {
            head = tail = null;
            return resultNode.value;
        }

        resultNode.previousNode = null;
        head = resultNode.nextNode;
        return resultNode.value;
    }

    public Item removeLast()                 // remove and return the item from the end
    {
        if (head == null) throw new java.util.NoSuchElementException();
        Node<Item> resultNode = tail;
        count--;

        if (head == tail)
        {
            head = tail = null;
            return resultNode.value;
        }

        resultNode.nextNode = null;
        tail = resultNode.previousNode;
        return resultNode.value;
    }

    @Override
    public Iterator<Item> iterator()
    {
        return new ForwardIterator();
    }
    private class ForwardIterator implements Iterator<Item>
    {
        private Node current = head;
        public boolean hasNext()
        {
            return head != null;
        }
        public void remove()
        {
            throw new java.lang.UnsupportedOperationException();
        }

        public Item next()
        {
            if (!hasNext()) throw new java.util.NoSuchElementException();
            Node<Item> resultNode = current;
            current = current.nextNode;
            return (Item) resultNode.value;
        }
    }


    public static void main(String[] args)   // unit testing (optional)
    {
        /* TODO
        Corner cases.  Throw the specified exception for the following corner cases:

        Throw a java.lang.IllegalArgumentException if the client calls either addFirst() or addLast() with a null argument.
        Throw a java.util.NoSuchElementException if the client calls either removeFirst() or removeLast when the deque is empty.
        Throw a java.util.NoSuchElementException if the client calls the next() method in the iterator when there are no more items to return.
        Throw a java.lang.UnsupportedOperationException if the client calls the remove() method in the iterator.

         */
    }

    private class Node<Item>
    {
        Item value;
        Node<Item> nextNode;
        Node<Item> previousNode;

        public Node(Item value)
        {
            this.value = value;
        }
    }

}
