import java.util.*;

class Solution {
    public int[] dijkstra(int V, int[][] edges, int src) {
        // Create adjacency list: node -> list of (neighbor, weight)
        List<List<int[]>> adj = new ArrayList<>();
        for (int i = 0; i < V; i++) {
            adj.add(new ArrayList<>());
        }

        // Since it's an undirected graph, add both directions
        for (int[] edge : edges) {
            int u = edge[0];
            int v = edge[1];
            int w = edge[2];
            adj.get(u).add(new int[] { v, w });
            adj.get(v).add(new int[] { u, w });
        }

        // Distance array, initialized with "infinity"
        int[] dist = new int[V];
        Arrays.fill(dist, Integer.MAX_VALUE);
        dist[src] = 0;

        // Min-heap priority queue: stores (distance, node)
        PriorityQueue<int[]> pq = new PriorityQueue<>((a, b) -> a[0] - b[0]);
        pq.add(new int[] { 0, src });

        while (!pq.isEmpty()) {
            int[] current = pq.poll();
            int currDist = current[0];
            int u = current[1];

            // Traverse all adjacent vertices
            for (int[] neighbor : adj.get(u)) {
                int v = neighbor[0];
                int weight = neighbor[1];

                if (currDist + weight < dist[v]) {
                    dist[v] = currDist + weight;
                    pq.add(new int[] { dist[v], v });
                }
            }
        }

        return dist;
    }
}