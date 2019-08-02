import edu.princeton.cs.algs4.In;
import edu.princeton.cs.algs4.StdDraw;
import edu.princeton.cs.algs4.StdOut;

import java.util.ArrayList;
import java.util.Arrays;

/**
 * Created by moliveto on 9/4/17.
 * Write a program BruteCollinearPoints.java that examines 4 points at a time and checks whether they all lie
 * on the same line segment, returning all such line segments. To check whether the 4 points p, q, r, and s
 * are collinear, check whether the three slopes between p and q, between p and r, and between p and s are all equal.
 */
public class BruteCollinearPoints
{
    private static final int POINTS_PER_SEGMENT = 4;
    private final ArrayList<LineSegment> lineSegmentArrayList = new ArrayList<>();
    /**
     * Corner cases. Throw a java.lang.IllegalArgumentException if the argument to the constructor is null,
     * if any point in the array is null, or if the argument to the constructor contains a repeated point.
     *
     * Performance requirement. The order of growth of the running time of your program should be n^4 in the worst case
     * and it should use space proportional to n plus the number of line segments returned.
     * @param points Array of points
     *
     */
    public BruteCollinearPoints(Point[] points)    // finds all line segments containing 4 points
    {
        Point[] points1;
        ArrayList<Segment> segmentArrayList = new ArrayList<>();

        points1 = points.clone();
        if (points1 == null) throw new java.lang.IllegalArgumentException();
        if (points1.length < POINTS_PER_SEGMENT) return;

        Arrays.sort(points1);
        Point previousPoint = points1[0];
        boolean firstPoint = true;
        for (Point point : points1)
        {
            if (point == null) throw new java.lang.IllegalArgumentException();
            if (!firstPoint && (point.compareTo(previousPoint) == 0)) throw new java.lang.IllegalArgumentException();
            firstPoint = false;
            previousPoint = point;
        }

        for (int i = 0; i < points1.length - POINTS_PER_SEGMENT + 1; i++)
        {
            if ((points1[i] == null) || (points1[i + 1] == null) || (points1[i] == points1[i + 1]))
                throw new java.lang.IllegalArgumentException("puntos nulos o repetidos son invalidos");

            for (int j = i + 1; j < points1.length - POINTS_PER_SEGMENT + 2; j++)
            {
                for (int k = j + 1; k < points1.length - POINTS_PER_SEGMENT + 3; k++)
                {
                    for (int m = k + 1; m < points1.length - POINTS_PER_SEGMENT + 4; m++)
                    {
                        Point p = points1[i], q = points1[j], r = points1[k], s = points1[m];

                        double pqSlope = p.slopeTo(q), qrSlope = q.slopeTo(r), rsSlope = r.slopeTo(s);

                        if (Double.compare(pqSlope, qrSlope) == 0
                                && Double.compare(qrSlope, rsSlope) == 0
                                && Double.compare(pqSlope, rsSlope) == 0)
                        {
                            // collinear points found
                            Segment tempLs = new Segment(p, s);
                            boolean existentSegment = false;

                            for (Segment segment : segmentArrayList)
                            {
                                if ((segment.endpointA.compareTo(tempLs.endpointA) == 0) && (segment.endpointB.compareTo(tempLs.endpointB) == 0))
                                    existentSegment = true;
                            }
                            if (!existentSegment)
                            {
                                segmentArrayList.add(new Segment(tempLs.endpointA, tempLs.endpointB));
                                lineSegmentArrayList.add(new LineSegment(tempLs.endpointA, tempLs.endpointB));
                            }
                        }
                    }
                }
            }
        }
    }

    public int numberOfSegments()        // the number of line segments
    {
        return lineSegmentArrayList.size();
    }

    /**
     * The method segments() should include each line segment containing 4 points exactly once.
     * If 4 points appear on a line segment in the order p→q→r→s, then you should include either
     * the line segment p→s or s→p (but not both) and you should not include subsegments such as p→r or q→r.
     * For simplicity, we will not supply any input to BruteCollinearPoints that has 5 or more collinear points.
     * @return  an array containing segments
     */
    public LineSegment[] segments()                // the line segments
    {
        return lineSegmentArrayList.toArray(new LineSegment[lineSegmentArrayList.size()]);
    }

    public static void main(String[] args)
    {
        // read the n points from a file
        In in = new In(args[0]);
        int n = in.readInt();
        Point[] points = new Point[n];
        for (int i = 0; i < n; i++) {
            int x = in.readInt();
            int y = in.readInt();
            points[i] = new Point(x, y);
        }

        // draw the points
        StdDraw.enableDoubleBuffering();
        StdDraw.setXscale(0, 32768);
        StdDraw.setYscale(0, 32768);
        for (Point p : points) {
            p.draw();
        }
        StdDraw.show();
        System.out.println("finished drawing points...");

        // print and draw the line segments
        BruteCollinearPoints collinear = new BruteCollinearPoints(points);
        for (LineSegment segment : collinear.segments()) {
            StdOut.println(segment);
            segment.draw();
        }
        StdDraw.show();
        System.out.println("finished drawing segments...");
    }

    private final class Segment
    {
        Point endpointA, endpointB;

        public Segment(Point endpointA, Point endpointB)
        {
            this.endpointA = endpointA;
            this.endpointB = endpointB;
        }
    }
}
