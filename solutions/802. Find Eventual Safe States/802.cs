enum State { kInit, kVisiting, kVisited }

public class Solution
{
    public IList<int> EventualSafeNodes(int[][] graph)
    {
        List<int> ans = new List<int>();
        State[] states = new State[graph.Length];

        for (int i = 0; i < graph.Length; ++i)
        {
            if (!HasCycle(graph, i, states))
                ans.Add(i);
        }

        return ans;
    }

    private bool HasCycle(int[][] graph, int u, State[] states)
    {
        if (states[u] == State.kVisiting)
            return true;
        if (states[u] == State.kVisited)
            return false;

        states[u] = State.kVisiting;
        foreach (var v in graph[u])
        {
            if (HasCycle(graph, v, states))
                return true;
        }
        states[u] = State.kVisited;

        return false;
    }
}