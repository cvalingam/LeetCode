public class Solution
{
    public int NumberOfPairs(int[][] points)
    {
        // Sort points by X coordinate in ascending order, if X coordinates are equal, then by Y in descending order
        Array.Sort(points, (point1, point2) =>
            point1[0] == point2[0] ? point2[1] - point1[1] : point1[0] - point2[0]);

        int pairCount = 0; // Initialize the count for the number of valid pairs
        int n = points.Length; // Number of points available
        const int INF = 1 << 30; // A very large number to represent the lower bound of maximum Y

        // Iterate through each point to calculate valid pairs
        for (int i = 0; i < n; ++i)
        {
            int y1 = points[i][1]; // Y coordinate of the current point
            int maxY = -INF; // Initialize maxY to track the max Y value of the valid pair seen so far

            // Iterate through the points that lie after the current point
            for (int j = i + 1; j < n; ++j)
            {
                int y2 = points[j][1]; // Y coordinate of the subsequent point

                // Check if the current Y2 is a potential candidate for forming a valid pair with Y1
                if (maxY < y2 && y2 <= y1)
                {
                    maxY = y2; // Update the maximum Y found so far
                    ++pairCount; // Increment the pair count
                }
            }
        }
        return pairCount; // Return the total number of valid pairs found
    }
}