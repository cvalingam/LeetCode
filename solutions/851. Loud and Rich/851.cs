public class Solution
{
    public int[] LoudAndRich(int[][] richer, int[] quiet)
    {
        int n = quiet.Length;
        int[] ans = new int[n];
        Array.Fill(ans, -1);

        var graph = new List<int>[n];

        for (int i = 0; i < n; i++)
            graph[i] = new List<int>();

        foreach (int[] r in richer)
        {
            int u = r[1];
            int v = r[0];
            graph[u].Add(v);
        }

        for (int i = 0; i < n; i++)
            DFS(graph, i, quiet, ans);

        return ans;
    }

    private int DFS(List<int>[] graph, int u, int[] quiet, int[] ans)
    {
        if (ans[u] != -1)
            return ans[u];

        ans[u] = u;

        foreach (int v in graph[u])
        {
            int res = DFS(graph, v, quiet, ans);
            if (quiet[res] < quiet[ans[u]])
                ans[u] = res;
        }

        return ans[u];
    }
}