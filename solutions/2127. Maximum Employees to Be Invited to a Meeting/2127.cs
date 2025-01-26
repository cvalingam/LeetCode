enum State { kInit, kVisiting, kVisited }

public class Solution
{
    public int MaximumInvitations(int[] favorite)
    {
        int n = favorite.Length;
        int sumComponentsLength = 0; // the component: a -> b -> c <-> x <- y
        List<int>[] graph = new List<int>[n];
        int[] inDegrees = new int[n];
        int[] maxChainLength = new int[n];
        Array.Fill(maxChainLength, 1);

        for (int i = 0; i < n; ++i)
            graph[i] = new List<int>();

        // Build the graph.
        for (int i = 0; i < n; ++i)
        {
            graph[i].Add(favorite[i]);
            ++inDegrees[favorite[i]];
        }

        // Perform topological sorting.
        Queue<int> q = new Queue<int>(Enumerable.Range(0, n).Where(i => inDegrees[i] == 0));

        while (q.Count > 0)
        {
            int u = q.Dequeue();
            foreach (int v in graph[u])
            {
                if (--inDegrees[v] == 0)
                    q.Enqueue(v);
                maxChainLength[v] = Math.Max(maxChainLength[v], 1 + maxChainLength[u]);
            }
        }

        for (int i = 0; i < n; ++i)
        {
            if (favorite[favorite[i]] == i)
                // i <-> favorite[i] (the cycle's length = 2)
                sumComponentsLength += maxChainLength[i] + maxChainLength[favorite[i]];
        }

        int[] parent = new int[n];
        Array.Fill(parent, -1);
        bool[] seen = new bool[n];
        State[] states = new State[n];

        for (int i = 0; i < n; ++i)
        {
            if (!seen[i])
                FindCycle(graph, i, parent, seen, states);
        }

        return Math.Max(sumComponentsLength / 2, maxCycleLength);
    }

    private int maxCycleLength = 0; // the cycle : a -> b -> c -> a

    private void FindCycle(List<int>[] graph, int u, int[] parent, bool[] seen, State[] states)
    {
        seen[u] = true;
        states[u] = State.kVisiting;

        foreach (int v in graph[u])
        {
            if (!seen[v])
            {
                parent[v] = u;
                FindCycle(graph, v, parent, seen, states);
            }
            else if (states[v] == State.kVisiting)
            {
                // Find the cycle's length.
                int curr = u;
                int cycleLength = 1;
                while (curr != v)
                {
                    curr = parent[curr];
                    ++cycleLength;
                }
                maxCycleLength = Math.Max(maxCycleLength, cycleLength);
            }
        }

        states[u] = State.kVisited;
    }
}