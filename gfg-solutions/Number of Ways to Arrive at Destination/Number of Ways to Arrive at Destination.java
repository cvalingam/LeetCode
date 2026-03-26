// Approach: Run Dijkstra's algorithm tracking both shortest distances and count of shortest paths.
// When a shorter path is found, update dist and reset ways to the source node's count.
// When an equal-length path is found, accumulate source's ways into the destination (mod 1e9+7).
// Time: O((V+E)logV) Space: O(V+E)
import java.util.*;

class Solution {

    public int countPaths(int V, int[][] edges) {
        final long MOD = (long) 1e9 + 7;
        List<List<int[]>> adj = new ArrayList<>();
        for (int i = 0; i < V; i++) {
            adj.add(new ArrayList<>());
        }

        for (int[] e : edges) {
            int u = e[0], v = e[1], w = e[2];
            adj.get(u).add(new int[]{v, w});
            adj.get(v).add(new int[]{u, w});
        }
        long[] dist = new long[V];
        long[] ways = new long[V];
        Arrays.fill(dist, Long.MAX_VALUE);
        PriorityQueue<long[]> pq = new PriorityQueue<>((a, b) -> Long.compare(a[0], b[0]));
        dist[0] = 0;
        ways[0] = 1;
        pq.add(new long[]{0, 0});
        while (!pq.isEmpty()) {
            long[] top = pq.poll();
            long d = top[0];
            int u = (int) top[1];

            if (d > dist[u]) {
                continue;
            }

            for (int[] nxt : adj.get(u)) {
                int v = nxt[0];
                long w = nxt[1];
                if (dist[v] > dist[u] + w) {
                    dist[v] = dist[u] + w;
                    ways[v] = ways[u];
                    pq.add(new long[]{dist[v], v});
                } else if (dist[v] == dist[u] + w) {
                    ways[v] = (ways[v] + ways[u]) % MOD;
                }
            }
        }

        return (int) (ways[V - 1] % MOD);
    }
}
