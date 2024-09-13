public class Solution
{
    public int[] XorQueries(int[] arr, int[][] queries)
    {
        int n = arr.Length;
        int[] prefix = new int[n + 1];

        for (int i = 0; i < n; i++)
            prefix[i + 1] = prefix[i] ^ arr[i];

        int j = 0;
        int[] ans = new int[queries.Length];
        foreach (int[] query in queries)
        {
            int left = query[0];
            int right = query[1];
            ans[j++] = prefix[left] ^ prefix[right + 1];
        }

        return ans;
    }
}