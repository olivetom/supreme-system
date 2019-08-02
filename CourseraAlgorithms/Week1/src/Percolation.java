/**
 * Created by moliveto on 8/16/17.
 *  Implements Percolation assignment from coursera Algorithms
 *
 *  It has no driver main program
 */

import edu.princeton.cs.algs4.WeightedQuickUnionUF;

public class Percolation {

    private final WeightedQuickUnionUF lattice;     // union-find ADT
    private final boolean[] openness;               // Bit array to represent open/closed sites
    private final int numberOfSites;                // 0 to N - 1 sites. Equivalent to n^2 - 1 sites
    private final int numberOfRows;                 // n numberOfRows
    private final int numberOfCols;                 // n numberOfCols
    private final int virtualTop;                   // points to virtualTop site in the union-find ADT
    private final int virtualBottom;                // points to virtualBottom site in the union-find ADT


    /**
     * Create n-by-n grid, with all sites blocked.
     * N instance variable holds n*n
     * Assign 2 virtual sites and connect them to top and bottom rows.
     *
     * @param n     the number of sites
     */
    public Percolation(int n)
    {
        if (n <= 0)
            throw new java.lang.IllegalArgumentException();

        numberOfRows = n;
        numberOfCols = n;
        numberOfSites = n * n;

        lattice = new WeightedQuickUnionUF(numberOfSites + 2);

        openness = new boolean[numberOfSites + 2];  // to hold virtual top and virtual bottom

        virtualTop = numberOfSites;
        virtualBottom = numberOfSites + 1;

        openness[virtualTop] = true;
        openness[virtualBottom] = true;
    }


    /**
     * Map between 1..n and 0..N-1
     * Virtual top and bottom are not considered here
     * @param row   the row
     * @param col   the column
     * @return      the value in the range 0..N-1
     */
    private int indexOf(int row, int col)
    {
        return (row - 1) * numberOfRows + col - 1;
    }

    /**
     * Open site (row, col) if it is not already open
     *
     * @param row       the row
     * @param col       the col
     */
    public void open(int row, int col)
    {
        if (row <= 0 || row > numberOfSites || col <= 0 || col > numberOfSites)
            throw new java.lang.IllegalArgumentException();

        int siteIndex = indexOf(row, col);
        
        if (openness[siteIndex]) return;

        int northSiteIndex;
        int southSiteIndex;
        int westSiteIndex = indexOf(row, col - 1);
        int eastSiteIndex = indexOf(row, col + 1);

        openness[siteIndex] = true;

        // connect to the four adjacent nodes iif they are already opened
        if (row == 1)
            northSiteIndex = virtualTop;
        else northSiteIndex = indexOf(row - 1, col);

        if (row == numberOfRows)
            southSiteIndex  = virtualBottom;
        else southSiteIndex = indexOf(row + 1, col);

        if (openness[northSiteIndex])
            lattice.union(siteIndex, northSiteIndex);

        if (openness[southSiteIndex])
            lattice.union(siteIndex, southSiteIndex);

        if (col > 1 && col < numberOfCols)
        {
            if (openness[westSiteIndex])
                lattice.union(siteIndex, westSiteIndex);
            if (openness[eastSiteIndex])
                lattice.union(siteIndex, eastSiteIndex);
        }
        else
        if (col == 1 && openness[eastSiteIndex])
            lattice.union(siteIndex, eastSiteIndex);
        else
            if (col == numberOfCols && openness[westSiteIndex])
                lattice.union(siteIndex, westSiteIndex);
    }

    /**
     *
     * @param row   row
     * @param col   column
     * @return      returns true if site is open or false if it is closed
     *
     */
    public boolean isOpen(int row, int col)
    {
        if (row <= 0 || row > numberOfSites || col <= 0 || col > numberOfSites)
            throw new java.lang.IllegalArgumentException();

        return openness[indexOf(row, col)];
    }

    /**
     *
     * @param row   row number
     * @param col   column number
     * @return      true if site is in the same component that virtual top. False otherwise
     */
    public boolean isFull(int row, int col)
    {
        if (row <= 0 || row > numberOfSites || col <= 0 || col > numberOfSites)
            throw new java.lang.IllegalArgumentException();

        int siteIndex = indexOf(row, col);
        return lattice.connected(siteIndex, virtualTop);
    }

    /**
     *
     * @return   number of open sites
     */
    public int numberOfOpenSites()
    {
        int result = 0;
        for (int i = 0; i < numberOfSites; i++) {
            if (openness[i]) result++;
        }
        return result;
    }

    /**
     *
     * @return  true if system percolates
     */
    public boolean percolates()
    {
        return lattice.connected(virtualBottom, virtualTop);
    }
}
