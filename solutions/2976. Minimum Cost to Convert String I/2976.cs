// Approach: Floyd-Warshall on 26 chars to find min cost transitions; sum min costs per source-target pair.
// Time: O(26³ + n) Space: O(26²)

public class Solution
{
    public long MinimumCost(string source, string target, char[] original, char[] changed, int[] cost)
    {
        long ans = 0;

        long[][] dist = new long[26][];

        for (int i = 0; i < 26; i++)
        {
            dist[i] = new long[26];
            Array.Fill(dist[i], long.MaxValue);
        }

        for (int i = 0; i < cost.Length; i++)
        {
            int u = original[i] - 'a';
            int v = changed[i] - 'a';
            dist[u][v] = Math.Min(dist[u][v], cost[i]);
        }

        for (int k = 0; k < 26; k++)
        {
            for (int i = 0; i < 26; i++)
            {
                if (dist[i][k] < long.MaxValue)
                {
                    for (int j = 0; j < 26; j++)
                    {
                        if (dist[k][j] < long.MaxValue)
                            dist[i][j] = Math.Min(dist[i][j], dist[i][k] + dist[k][j]);
                    }
                }
            }
        }

        for (int i = 0; i < source.Length; i++)
        {
            if (source[i] == target[i])
                continue;

            int u = source[i] - 'a';
            int v = target[i] - 'a';

            if (dist[u][v] == long.MaxValue)
                return -1;

            ans += dist[u][v];
        }

        return ans;
    }
}