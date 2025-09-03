public class Solution
{
    public int NumberOfPairs(int[][] points)
    {
        // Sort the array of points in ascending order by x-coordinates,
        // and in descending order by y-coordinates if x-coordinates are the same
        Array.Sort(points, (point1, point2) =>
            point1[0] == point2[0] ? point2[1].CompareTo(point1[1]) : point1[0].CompareTo(point2[0]));

        int count = 0; // Initialize the count of valid pairs
        int numberOfPoints = points.Length; // Total number of points
        const int INFINITY = 1 << 30; // Representation of negative infinity

        // Iterate over each point to check for valid pairs
        for (int i = 0; i < numberOfPoints; ++i)
        {
            int y1 = points[i][1]; // Get the y-coordinate of the current point

            int maxY = -INFINITY; // Set maxY as negative infinity initially

            // Iterate over the points that come after the current point
            for (int j = i + 1; j < numberOfPoints; ++j)
            {
                int y2 = points[j][1]; // Get the y-coordinate of the next point

                // Check if the current maxY is less than y2 and y2 is less than or equal to y1
                // If so, this forms a valid pair and update maxY and increment count
                if (maxY < y2 && y2 <= y1)
                {
                    maxY = y2; // Update maxY
                    ++count; // Increment the number of valid pairs
                }
            }
        }

        return count; // Return the total number of valid pairs
    }
}