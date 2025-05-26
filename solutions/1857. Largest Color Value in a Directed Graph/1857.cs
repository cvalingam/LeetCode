public class Solution
{
    public int LargestPathValue(string colors, int[][] edges)
    {
        int n = colors.Length;
        List<int>[] adjList = new List<int>[n];
        int[] inDegrees = new int[n];
        int[,] count = new int[n, 26];

        for (int i = 0; i < n; i++)
            adjList[i] = new List<int>();

        foreach (int[] edge in edges)
        {
            int u = edge[0];
            int v = edge[1];
            adjList[u].Add(v);
            inDegrees[v]++;
        }

        Queue<int> q = new Queue<int>();
        for (int i = 0; i < n; i++)
        {
            if (inDegrees[i] == 0)
                q.Enqueue(i);
        }

        int ans = 0, processed = 0;
        while (q.Count > 0)
        {
            int item = q.Dequeue();
            ans = Math.Max(ans, ++count[item, colors[item] - 'a']);
            ++processed;

            foreach (int adjNode in adjList[item])
            {
                inDegrees[adjNode]--;
                if (inDegrees[adjNode] == 0)
                    q.Enqueue(adjNode);

                for (int i = 0; i < 26; i++)
                    count[adjNode, i] = Math.Max(count[adjNode, i], count[item, i]);
            }
        }

        return processed == n ? ans : -1;
    }
}