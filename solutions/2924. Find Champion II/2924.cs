public class Solution
{
    public int FindChampion(int n, int[][] edges)
    {
        int ans = -1;
        int count = 0;
        int[] inDegrees = new int[n];

        foreach (var edge in edges)
        {
            int v = edge[1];
            ++inDegrees[v];
        }

        for (int i = 0; i < n; ++i)
        {
            if (inDegrees[i] == 0)
            {
                ++count;
                ans = i;
            }
        }

        return count > 1 ? -1 : ans;
    }
}