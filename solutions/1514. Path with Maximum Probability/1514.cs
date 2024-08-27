public class Solution
{
    public double MaxProbability(int n, int[][] edges, double[] succProb, int start_node, int end_node)
    {
        // {a: [(b, probability_ab)]}
        List<(int, double)>[] graph = new List<(int, double)>[n];
        // (the probability to reach u, u)
        PriorityQueue<(double, int), double> maxHeap = new PriorityQueue<(double, int), double>(new MaxHeapComparer());

        maxHeap.Enqueue((1.0, start_node), 1.0);
        bool[] seen = new bool[n];

        for (int i = 0; i < n; ++i)
            graph[i] = new List<(int, double)>();

        for (int i = 0; i < edges.Length; ++i)
        {
            int u = edges[i][0];
            int v = edges[i][1];
            double prob = succProb[i];
            graph[u].Add((v, prob));
            graph[v].Add((u, prob));
        }

        while (maxHeap.Count > 0)
        {
            var (prob, u) = maxHeap.Dequeue();
            if (u == end_node)
                return prob;
            if (seen[u])
                continue;
            seen[u] = true;
            foreach (var node in graph[u])
            {
                int nextNode = node.Item1;
                double edgeProb = node.Item2;
                if (seen[nextNode])
                    continue;
                maxHeap.Enqueue((prob * edgeProb, nextNode), prob * edgeProb);
            }
        }

        return 0;
    }

    public class MaxHeapComparer : IComparer<double>
    {
        public int Compare(double a, double b)
        {
            return b.CompareTo(a);
        }
    }
}