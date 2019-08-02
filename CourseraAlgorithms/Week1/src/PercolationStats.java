/**
 * Created by moliveto on 8/16/17.
 * COURSERA ALGORITHMS
 */
import edu.princeton.cs.algs4.StdRandom;
import edu.princeton.cs.algs4.StdStats;

public class PercolationStats
{

    private final double mean, stddev, confidenceLo, confidenceHi;

    /**
     *  perform trials independent experiments on an n-by-n grid
     * @param n n-by-n grid dimension
     * @param trials  trials simulations
     */
    public PercolationStats(int n, int trials)
    {
        double[] percolationThresholdArray;

        if (n <= 0 || trials <= 0)
            throw new java.lang.IllegalArgumentException();

        percolationThresholdArray = new double[trials];

        for (int i = 0; i < trials; i++)
        {
            Percolation p = new Percolation(n);
            while (!p.percolates())
                p.open(StdRandom.uniform(n)+1, StdRandom.uniform(n)+1);
            percolationThresholdArray[i] = (double) (p.numberOfOpenSites()) / (n * n);
        }

        mean = StdStats.mean(percolationThresholdArray);
        stddev = Math.sqrt(StdStats.stddev(percolationThresholdArray));
        confidenceLo = mean - (1.96 * stddev / Math.sqrt(trials));
        confidenceHi = mean + (1.96 * stddev / Math.sqrt(trials));
    }

    /**
     *  sample mean of percolation threshold
     * @return  sample mean of percolation threshold
     */
    public double mean()
    {
        return mean;
    }

    /**
     *
     * @return  sample standard deviation of percolation threshold
     */
    public double stddev()
    {
        return stddev;
    }

    /**
     *
     * @return  // low  endpoint of 95% confidence interval
     */
    public double confidenceLo()
    {
        return confidenceLo;
    }

    /**
     *
     * @return  high endpoint of 95% confidence interval
     */

    public double confidenceHi()
    {
        return confidenceHi;
    }

    /**
     * // test client (described below)
     * @param args   n is for matrix dimensions. T is for trials
     */
    public static void main(String[] args)
    {
        int nDimension = Integer.parseInt(args[0]);
        int tTrials = Integer.parseInt(args[1]);

        PercolationStats ps = new PercolationStats(nDimension, tTrials);

        System.out.format("mean                    = %f\n", ps.mean);
        System.out.format("stddev                  = %f\n", ps.stddev);
        System.out.format("95%% confidence interval = [%f, %f]", ps.confidenceLo, ps.confidenceHi);

    }
}
