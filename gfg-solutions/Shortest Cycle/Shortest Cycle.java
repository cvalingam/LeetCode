import java.util.*;

class Solution {
    public int shortCycle(int V, int[][] edges) {
        List<List<Integer>> g = new ArrayList<>();
        for (int i = 0; i < V; i++)
            g.add(new ArrayList<>());

        for (int[] e : edges) {
            int u = e[0], v = e[1];
            g.get(u).add(v);
            g.get(v).add(u);
        }

        int ans = Integer.MAX_VALUE;

        for (int start = 0; start < V; start++) {
            int[] dist = new int[V];
            int[] parent = new int[V];
            Arrays.fill(dist, -1);
            Arrays.fill(parent, -1);

            Queue<Integer> queue = new LinkedList<>();
            queue.add(start);
            dist[start] = 0;

            while (!queue.isEmpty()) {
                int node = queue.poll();

                for (int nbr : g.get(node)) {
                    if (dist[nbr] == -1) {
                        dist[nbr] = dist[node] + 1;
                        parent[nbr] = node;
                        queue.add(nbr);
                    } else if (parent[node] != nbr) {
                        int cycleLen = dist[node] + dist[nbr] + 1;
                        ans = Math.min(ans, cycleLen);
                    }
                }
            }
        }
        
        return (ans == Integer.MAX_VALUE) ? -1 : ans;
    }
}