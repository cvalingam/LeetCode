public class Solution
{
    public int MaxDotProduct(int[] nums1, int[] nums2)
    {
        int m = nums1.Length;
        int n = nums2.Length;

        // Using a 2D array in C# (multidimensional array)
        int[,] dp = new int[m + 1, n + 1];

        // Initialize the DP table with int.MinValue
        for (int i = 0; i <= m; i++)
        {
            for (int j = 0; j <= n; j++)
                dp[i, j] = int.MinValue;
        }

        for (int i = 0; i < m; ++i)
        {
            for (int j = 0; j < n; ++j)
            {
                // Calculate the dot product of the current elements
                // Math.Max(0, dp[i, j]) handles the case where we start a new subsequence
                int currentProduct = nums1[i] * nums2[j];
                int prevMax = Math.Max(0, dp[i, j]);

                dp[i + 1, j + 1] = Math.Max(
                    Math.Max(dp[i, j + 1], dp[i + 1, j]),
                    prevMax + currentProduct
                );
            }
        }

        return dp[m, n];
    }
}