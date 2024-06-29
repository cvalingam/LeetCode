public class Solution
{
    public IList<IList<int>> GetAncestors(int n, int[][] edges)
    {
        var ans = new List<IList<int>>();

        var adjList = new List<List<int>>();

        for (int i = 0; i < n; i++)
        {
            ans.Add(new List<int>());
            adjList.Add(new List<int>());
        }

        foreach (int[] edge in edges)
        {
            int u = edge[0];
            int v = edge[1];
            adjList[u].Add(v);
        }

        for (int i = 0; i < n; i++)
            dfs(adjList, i, i, new bool[n], ans);

        return ans;
    }

    private void dfs(List<List<int>> adjList, int node, int ancestor, bool[] seen, List<IList<int>> ans)
    {
        seen[node] = true;
        foreach (int adjNode in adjList[node])
        {
            if (seen[adjNode])
                continue;

            ans[adjNode].Add(ancestor);
            dfs(adjList, adjNode, ancestor, seen, ans);
        }
    }
}