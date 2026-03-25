// Approach: For each k×k submatrix sort unique elements; find min adjacent difference.
// Time: O(mn * k² log k) Space: O(k²)

public class Solution
{
    public int[][] MinAbsDiff(int[][] grid, int k)
    {
        int rows = grid.Length;
        int cols = grid[0].Length;

        // Result array to store minimum absolute differences for each subgrid
        int[][] result = new int[rows - k + 1][];
        for (int i = 0; i < result.Length; i++)
            result[i] = new int[cols - k + 1];

        // Iterate through all possible starting positions for k x k subgrids
        for (int startRow = 0; startRow <= rows - k; startRow++)
        {
            for (int startCol = 0; startCol <= cols - k; startCol++)
            {
                // Collect all elements from the current k x k subgrid
                List<int> subgridElements = new List<int>();
                for (int row = startRow; row < startRow + k; row++)
                {
                    for (int col = startCol; col < startCol + k; col++)
                        subgridElements.Add(grid[row][col]);
                }

                // Sort elements to find minimum difference between adjacent elements
                subgridElements.Sort();

                // Find minimum absolute difference between any two distinct elements
                int minDifference = int.MaxValue;
                for (int index = 1; index < subgridElements.Count; index++)
                {
                    int previousElement = subgridElements[index - 1];
                    int currentElement = subgridElements[index];

                    // Only consider distinct elements
                    if (previousElement != currentElement)
                        minDifference = Math.Min(minDifference,
                                                 Math.Abs(previousElement - currentElement));
                }

                // If no distinct elements found (all elements are the same), set to 0
                result[startRow][startCol] = (minDifference == int.MaxValue) ? 0 : minDifference;
            }
        }

        return result;
    }
}