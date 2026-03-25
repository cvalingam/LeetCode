// Approach: Build column histograms row by row; sort each row's histogram and compute max width * height.
// Time: O(mn log n) Space: O(n)

public class Solution
{
    public int LargestSubmatrix(int[][] matrix)
    {
        int n = matrix[0].Length;
        int ans = 0;
        int[] hist = new int[n];

        foreach (var row in matrix)
        {
            // Accumulate the histogram if possible.
            for (int i = 0; i < n; ++i)
                hist[i] = row[i] == 0 ? 0 : hist[i] + 1;

            // Get the sorted histogram.
            int[] sortedHist = (int[])hist.Clone();
            Array.Sort(sortedHist);

            // Greedily calculate the answer.
            for (int i = 0; i < n; ++i)
                ans = Math.Max(ans, sortedHist[i] * (n - i));
        }

        return ans;
    }
}