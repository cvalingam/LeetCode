public class Solution
{
    public int LenLongestFibSubseq(int[] arr)
    {
        int n = arr.Length;
        int ans = 0;
        int[,] dp = new int[n, n];
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
                dp[i, j] = 2;
        }
        Dictionary<int, int> numToIndex = new Dictionary<int, int>();

        for (int i = 0; i < n; i++)
            numToIndex[arr[i]] = i;

        for (int j = 0; j < n; j++)
        {
            for (int k = j + 1; k < n; k++)
            {
                int ai = arr[k] - arr[j];
                if (ai < arr[j] && numToIndex.ContainsKey(ai))
                {
                    int i = numToIndex[ai];
                    dp[j, k] = dp[i, j] + 1;
                    ans = Math.Max(ans, dp[j, k]);
                }
            }
        }

        return ans;
    }
}