// Approach: Find node with in-degree 0; if exactly one exists it is the champion, else return -1.
// Time: O(n + E) Space: O(n)

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