import edu.princeton.cs.algs4.In;
import edu.princeton.cs.algs4.StdDraw;
import edu.princeton.cs.algs4.StdOut;

import java.util.ArrayList;
import java.util.Arrays;

/**
 * Created by moliveto on 9/5/17.
 * A faster, sorting-based solution. Remarkably, it is possible to solve the problem much faster than the
 * brute-force solution described above. Given a point p, the following method determines whether p participates
 * in a set of 4 or more collinear points.
 * Think of p as the origin.
 * For each other point q, determine the slope it makes with p.
 * Sort the points according to the slopes they makes with p.
 * Check if any 3 (or more) adjacent points in the sorted order have equal slopes with respect to p.
 * If so, these points, together with p, are collinear.
 * Applying this method for each of the n points in turn yields an efficient algorithm to the problem.
 * The algorithm solves the problem because points that have equal slopes with respect to p are collinear,
 * and sorting brings such points together. The algorithm is fast because the bottleneck operation is sorting.

 */
public class FastCollinearPoints
{
  private static final int POINTS_PER_SEGMENT = 4;
  private final ArrayList<Segment> segmentArrayList = new ArrayList<>();
  private final ArrayList<LineSegment> lineSegmentArrayList = new ArrayList<>();

  /**
   * @param points arreglo de puntos
   */
  public FastCollinearPoints(Point[] points)     // finds all line segments containing 4 or more points
  {
    Point[] points1;
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

    double[] slopes = new double[points.length];
    for (Point p: points)
    {
      // Note that p is an element from points. Not from _points.
      // Sort by slope. For points that participate in many segments collinear points
      // can be found all over the array
      Arrays.sort(points1, p.slopeOrder());
      // this sorting could move p from 0 position
      for (int i = 1; i < points.length; i++)
        slopes[i] = p.slopeTo(points1[i]);
      findSegmentEndpointsBySlope(points1, slopes, p);
    }
  }

  /**
   * Searches for 4+ collinear points to points[0] based on slope ordering
   * @param points array of points sorted by slope ordering
   * @param slopes array of slopes relative to points[0]
   */
  private void findSegmentEndpointsBySlope(Point[] points, double[] slopes, Point currentPoint)
  {
    ArrayList<Point> tempSegmentPoints = new ArrayList<>();
    double currentSlope;

    tempSegmentPoints.add(currentPoint);
    int collinearPointsCount = 1;
    boolean slopeFound = false;

    for (int i = 1; i < points.length - 1; i++)
    {
      currentSlope = slopes[i];
      // do not compare a point to itself
      if (currentPoint.compareTo(points[i]) != 0 && Double.compare(currentSlope, slopes[i + 1]) == 0)
      {
        ++collinearPointsCount;
        if (collinearPointsCount >= (POINTS_PER_SEGMENT - 1))
          slopeFound = true;
        tempSegmentPoints.add(points[i]);
      }
      else // not at the end of the array and slope found and finished or slope not found
      {
        if (slopeFound && (collinearPointsCount >= (POINTS_PER_SEGMENT - 1)))
        {
          tempSegmentPoints.add(points[i]);
          collinearPointsCount++;
          tempSegmentPoints.sort(Point::compareTo);
          Segment tempLs = new Segment(tempSegmentPoints.get(0), tempSegmentPoints.get(tempSegmentPoints.size() - 1));
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
        // clean slope tracing variables
        collinearPointsCount = 1;
        tempSegmentPoints.clear();
        tempSegmentPoints.add(currentPoint);
        slopeFound = false;
      }
    }
    // array finished.
    if (slopeFound && (collinearPointsCount >= (POINTS_PER_SEGMENT - 1)))
    {
      tempSegmentPoints.add(points[points.length - 1]);
      tempSegmentPoints.sort(Point::compareTo);
      Segment tempLs = new Segment(tempSegmentPoints.get(0), tempSegmentPoints.get(tempSegmentPoints.size() - 1));
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

  public int numberOfSegments()        // the number of line segments
  {
    return lineSegmentArrayList.size();
  }

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
    FastCollinearPoints collinear = new FastCollinearPoints(points);
    System.out.println("starting drawing segments...");
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
