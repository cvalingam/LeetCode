public class Solution
{
    public int[] SumOfDistancesInTree(int n, int[][] edges)
    {
        var ans = new int[n];
        var adjList = new List<List<int>>();
        var count = new int[n];
        Array.Fill(count, 1);

        for (int i = 0; i < n; i++)
            adjList.Add(new List<int>());

        foreach (int[] edge in edges)
        {
            int u = edge[0];
            int v = edge[1];
            adjList[u].Add(v);
            adjList[v].Add(u);
        }

        DFS(0, -1, adjList, count, ans);
        DFS2(0, -1, adjList, ans, count, n);
        return ans;
    }

    private void DFS(int node, int parent, List<List<int>> adjList, int[] count, int[] ans)
    {
        foreach (int child in adjList[node])
        {
            if (child != parent)
            {
                DFS(child, node, adjList, count, ans);
                count[node] += count[child];
                ans[node] += ans[child] + count[child];
            }
        }
    }

    private void DFS2(int node, int parent, List<List<int>> adjList, int[] ans, int[] count, int n)
    {
        foreach (int child in adjList[node])
        {
            if (child != parent)
            {
                ans[child] = ans[node] - count[child] + (n - count[child]);
                DFS2(child, node, adjList, ans, count, n);
            }
        }
    }
}