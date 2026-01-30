public class Solution
{
    public long MinimumCost(string source, string target, string[] original, string[] changed, int[] cost)
    {
        var subLengths = GetSubLengths(original);
        var subToId = GetSubToId(original, changed);
        int subCount = subToId.Count;

        // dist[u][v] := the minimum distance to change the substring with id u to the substring with id v
        long[,] dist = new long[subCount, subCount];
        for (int i = 0; i < subCount; i++)
        {
            for (int j = 0; j < subCount; j++)
                dist[i, j] = long.MaxValue;
        }

        // dp[i] := the minimum cost to change the first i letters of `source` into `target`, leaving the suffix untouched
        long[] dp = new long[source.Length + 1];
        for (int i = 0; i < dp.Length; i++)
            dp[i] = long.MaxValue;

        for (int i = 0; i < cost.Length; ++i)
        {
            int u = subToId[original[i]];
            int v = subToId[changed[i]];
            dist[u, v] = Math.Min(dist[u, v], (long)cost[i]);
        }

        for (int k = 0; k < subCount; ++k)
        {
            for (int i = 0; i < subCount; ++i)
            {
                if (dist[i, k] < long.MaxValue)
                {
                    for (int j = 0; j < subCount; ++j)
                    {
                        if (dist[k, j] < long.MaxValue)
                            dist[i, j] = Math.Min(dist[i, j], dist[i, k] + dist[k, j]);
                    }
                }
            }
        }

        dp[0] = 0;

        for (int i = 0; i < source.Length; ++i)
        {
            if (dp[i] == long.MaxValue)
                continue;
            if (target[i] == source[i])
                dp[i + 1] = Math.Min(dp[i + 1], dp[i]);
            foreach (int subLength in subLengths)
            {
                if (i + subLength > source.Length)
                    continue;
                string subSource = source.Substring(i, subLength);
                string subTarget = target.Substring(i, subLength);
                if (!subToId.ContainsKey(subSource) || !subToId.ContainsKey(subTarget))
                    continue;
                int u = subToId[subSource];
                int v = subToId[subTarget];
                if (dist[u, v] < long.MaxValue)
                    dp[i + subLength] = Math.Min(dp[i + subLength], dp[i] + dist[u, v]);
            }
        }

        return dp[source.Length] == long.MaxValue ? -1 : dp[source.Length];
    }

    private Dictionary<string, int> GetSubToId(string[] original, string[] changed)
    {
        var subToId = new Dictionary<string, int>();
        foreach (var s in original)
        {
            if (!subToId.ContainsKey(s))
                subToId[s] = subToId.Count;
        }

        foreach (var s in changed)
        {
            if (!subToId.ContainsKey(s))
                subToId[s] = subToId.Count;
        }

        return subToId;
    }

    private HashSet<int> GetSubLengths(string[] original)
    {
        var subLengths = new HashSet<int>();
        foreach (var s in original)
            subLengths.Add(s.Length);

        return subLengths;
    }
}