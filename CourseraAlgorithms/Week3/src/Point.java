/******************************************************************************
 * Created by moliveto on 9/1/17.
 * <p>
 * Compilation:  javac Point.java
 * Execution:    java Point
 * Dependencies: none
 * <p>
 * An immutable data type for points in the plane.
 * For use on Coursera, Algorithms Part I programming assignment.
 ******************************************************************************/

import java.util.Comparator;
import edu.princeton.cs.algs4.StdDraw;

public class Point implements Comparable<Point>
{
    private final int x;     // x-coordinate of this point
    private final int y;     // y-coordinate of this point

    /**
     * Initializes a new point.
     *
     * Corner cases. To avoid potential complications with integer overflow or floating-point precision,
     * you may assume that the constructor arguments x and y are each between 0 and 32,767.
     * @param  x the <em>x</em>-coordinate of the point
     * @param  y the <em>y</em>-coordinate of the point
     */
    public Point(int x, int y)
    {
        /* DO NOT MODIFY */
        this.x = x;
        this.y = y;
    }

    /**
     * Draws this point to standard draw.
     */
    public void draw()
    {
        /* DO NOT MODIFY */
        StdDraw.point(x, y);
    }

    /**
     * Draws the line segment between this point and the specified point
     * to standard draw.
     *
     * @param that the other point
     */
    public void drawTo(Point that)
    {
        /* DO NOT MODIFY */
        StdDraw.line(this.x, this.y, that.x, that.y);
    }

    /**
     * Returns the slope between this point and the specified point.
     * Formally, if the two points are (x0, y0) and (x1, y1), then the slope
     * is (y1 - y0) / (x1 - x0). For completeness, the slope is defined to be
     * +0.0 if the line segment connecting the two points is horizontal;
     * Double.POSITIVE_INFINITY if the line segment is vertical;
     * and Double.NEGATIVE_INFINITY if (x0, y0) and (x1, y1) are equal.
     *
     * @param  that the other point
     * @return the slope between this point and the specified point
     */
    public double slopeTo(Point that)
    {
        /* if (this.y - that.y == 0) {
            if (this.x - that.x == 0) {
                return Double.NEGATIVE_INFINITY;
            }
            return +0;
        } else if (this.x - that.x == 0) {
            return Double.POSITIVE_INFINITY;
        }
        return (that.y - this.y) / (double) (that.x - this.x);
        */

        if (that == null) throw new java.lang.NullPointerException();
        if (compareTo(that) == 0) return Double.NEGATIVE_INFINITY;
        if (that.x == x) return Double.POSITIVE_INFINITY;
        if (y == that.y) return +0.0;
        return (double) (that.y - y) / (that.x - x);
    }

    /**
     * Compares two points by y-coordinate, breaking ties by x-coordinate.
     * Formally, the invoking point (x0, y0) is less than the argument point
     * (x1, y1) if and only if either y0 < y1 or if y0 = y1 and x0 < x1.
     *
     * @param  that the other point
     * @return the value <tt>0</tt> if this point is equal to the argument
     *         point (x0 = x1 and y0 = y1);
     *         a negative integer if this point is less than the argument
     *         point; and a positive integer if this point is greater than the
     *         argument point
     */
    public int compareTo(Point that)
    {
        if (that == null) throw new java.lang.NullPointerException();
        return this.y < that.y ? -1 : (this.y > that.y ? 1 : (this.x < that.x ? -1 : (this.x > that.x ? 1 : 0)));
    }

    /**
     * Compares two points by the slope they make with this point.
     * The slope is defined as in the slopeTo() method.
     *
     * @return the Comparator that defines this ordering on points
     */
    public Comparator<Point> slopeOrder()
    {
        // To do this, create a private nested (non-static) class SlopeOrder that implements the
        // Comparator<Point> interface. This class has a single method compare(q1, q2) that compares the slopes
        // that q1 and q2 make with the invoking object p. the slopeOrder() method should create an instance of
        // this nested class and return it.

        // using java8 lambda
        // In both cases, the slopeTo() calls are made on the this object of the slopeOrder() call.
        return (a, b) -> {
            int result = Double.compare(this.slopeTo(a), this.slopeTo(b));
            return result;
        };
//          Using old anonymous class
        /* final Point that = this;
        return new Comparator<Point>() {
            @Override
            public int compare(Point a, Point b) {
                return Double.compare(a.slopeTo(that), b.slopeTo(that));
            }
        }; */



    }

    /**
     * Returns a string representation of this point.
     * This method is provide for debugging;
     * your program should not rely on the format of the string representation.
     *
     * @return a string representation of this point
     */
    public String toString()
    {
        /* DO NOT MODIFY */
        return "(" + x + ", " + y + ")";
    }

    /**
     * Unit tests the Point data type.
     */
    public static void main(String[] args)
    {
        /* TODO */
    }


}

