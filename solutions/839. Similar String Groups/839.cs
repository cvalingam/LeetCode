public class Solution
{
    public int NumSimilarGroups(string[] strs)
    {
        int groups = 0, n = strs.Length;
        int[] vis = new int[n];

        for (int i = 0; i < n; i++)
        {
            if (vis[i] == 1)
                continue;
            groups++;
            DFS(i, strs, vis);
        }

        return groups;
    }

    private void DFS(int i, string[] strs, int[] vis)
    {
        vis[i] = 1;
        for (int j = 0; j < strs.Length; j++)
        {
            if (vis[j] == 1)
                continue;
            if (IsSimiliar(strs[i], strs[j]))
                DFS(j, strs, vis);
        }
    }

    bool IsSimiliar(string a, string b)
    {
        int cnt = 0;
        for (int i = 0; i < a.Length; i++)
        {
            if (a[i] != b[i])
                cnt++;
        }

        return cnt == 2 || cnt == 0;
    }
}