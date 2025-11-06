public class Solution
{
    public int[] ProcessQueries(int c, int[][] connections, int[][] queries)
    {
        var adj = new List<List<int>>(c);
        for (int i = 0; i < c; i++) adj.Add(new List<int>());
        foreach (var con in connections)
        {
            adj[con[0] - 1].Add(con[1] - 1);
            adj[con[1] - 1].Add(con[0] - 1);
        }

        var lookup = new int[c];
        for (int i = 0; i < c; i++) lookup[i] = -1;

        Action<int> iter_dfs = null;
        iter_dfs = (int i) =>
        {
            var stk = new Stack<int>();
            stk.Push(i);
            while (stk.Count > 0)
            {
                var u = stk.Pop();
                if (lookup[u] != -1) continue;
                lookup[u] = i;
                foreach (var v in adj[u])
                    stk.Push(v);
            }
        };

        for (int i = 0; i < c; i++)
            iter_dfs(i);

        var groups = new List<List<int>>(c);
        for (int i = 0; i < c; i++) groups.Add(new List<int>());
        for (int i = c - 1; i >= 0; i--)
            groups[lookup[i]].Add(i);

        var result = new List<int>();
        var online = new bool[c];
        for (int i = 0; i < c; i++) online[i] = true;

        foreach (var q in queries)
        {
            int t = q[0], x = q[1] - 1;
            if (t == 1)
            {
                if (online[x])
                {
                    result.Add(x + 1);
                    continue;
                }
                while (groups[lookup[x]].Count > 0 && !online[groups[lookup[x]][groups[lookup[x]].Count - 1]])
                    groups[lookup[x]].RemoveAt(groups[lookup[x]].Count - 1);
                result.Add(groups[lookup[x]].Count > 0 ? groups[lookup[x]][groups[lookup[x]].Count - 1] + 1 : -1);
            }
            else
                online[x] = false;
        }

        return result.ToArray();
    }
}