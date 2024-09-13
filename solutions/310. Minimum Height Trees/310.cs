public class Solution
{
    public IList<int> FindMinHeightTrees(int n, int[][] edges)
    {
        var ans = new List<int>();
        var adjList = new List<List<int>>();
        int[] indegree = new int[n];

        for (int i = 0; i < n; i++)
            adjList.Add(new List<int>());

        foreach (int[] edge in edges)
        {
            int u = edge[0];
            int v = edge[1];
            indegree[v]++;
            indegree[u]++;
            adjList[u].Add(v);
            adjList[v].Add(u);
        }

        var q = new Queue<int>();
        for (int i = 0; i < n; i++)
        {
            if (indegree[i] == 1)
            {
                q.Enqueue(i);
                indegree[i]--;
            }
        }

        while (q.Count > 0)
        {
            int sz = q.Count;
            //Console.WriteLine("value: " + string.Join( ",", ans.ToArray()));
            ans.Clear();
            for (int i = 0; i < sz; i++)
            {
                int node = q.Dequeue();
                ans.Add(node);
                foreach (var adjNode in adjList[node])
                {
                    indegree[adjNode]--;
                    if (indegree[adjNode] == 1)
                        q.Enqueue(adjNode);
                }
            }
        }

        if (n == 1)
            ans.Add(0);

        return ans;
    }
}