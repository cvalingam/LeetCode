public class Solution
{
    public int[] FindOrder(int numCourses, int[][] prerequisites)
    {
        List<List<int>> adj = new List<List<int>>();

        for (int i = 0; i < numCourses; i++)
            adj.Add(new List<int>());

        for (int i = 0; i < prerequisites.Length; i++)
        {
            int node1 = prerequisites[i][0];
            int node2 = prerequisites[i][1];
            adj[node2].Add(node1);
        }

        return BFSFindOrder(adj, numCourses);
    }

    private int[] BFSFindOrder(List<List<int>> adj, int v)
    {
        int[] inDegree = new int[v];

        for (int i = 0; i < v; i++)
        {
            foreach (int adjNode in adj[i])
                inDegree[adjNode]++;
        }

        Queue<int> q = new Queue<int>();
        for (int i = 0; i < v; i++)
        {
            if (inDegree[i] == 0)
                q.Enqueue(i);
        }

        List<int> ans = new List<int>();
        while (q.Count > 0)
        {
            int node = q.Dequeue();
            ans.Add(node);

            foreach (int adjNode in adj[node])
            {
                inDegree[adjNode]--;
                if (inDegree[adjNode] == 0)
                    q.Enqueue(adjNode);
            }
        }

        if (ans.Count == v)
            return ans.ToArray();
        return new int[] { };
    }
}