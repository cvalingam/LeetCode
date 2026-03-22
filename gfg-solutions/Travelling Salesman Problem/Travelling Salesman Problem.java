import java.util.*;

class Solution {
    public int tsp(int[][] cost) {
        int n = cost.length;
        int N = 1 << n;
        int INF = (int) 1e9;

        int[][] dp = new int[N][n];
        for (int i = 0; i < N; i++)
            Arrays.fill(dp[i], INF);

        dp[1][0] = 0;

        for (int mask = 0; mask < N; mask++) {
            for (int u = 0; u < n; u++) {
                if ((mask & (1 << u)) == 0)
                    continue;
                for (int v = 0; v < n; v++) {
                    if ((mask & (1 << v)) != 0)
                        continue;
                    int next = mask | (1 << v);
                    dp[next][v] = Math.min(dp[next][v], dp[mask][u] + cost[u][v]);
                }
            }
        }

        int ans = INF;
        int full = N - 1;
        for (int u = 0; u < n; u++)
            ans = Math.min(ans, dp[full][u] + cost[u][0]);

        return ans;
    }
}