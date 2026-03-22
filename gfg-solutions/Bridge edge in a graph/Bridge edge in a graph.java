import java.util.*;

class Solution {
    public boolean isBridge(int V, int[][] edges, int c, int d) {
        // Create adjacency list
        List<List<Integer>> adj = new ArrayList<>();
        for (int i = 0; i < V; i++) {
            adj.add(new ArrayList<>());
        }

        for (int[] edge : edges) {
            int u = edge[0], v = edge[1];
            adj.get(u).add(v);
            adj.get(v).add(u);
        }

        // Count components before removing edge
        int componentsBefore = countComponents(V, adj);

        // Remove edge (c, d)
        adj.get(c).remove((Integer) d);
        adj.get(d).remove((Integer) c);

        // Count components after removing edge
        int componentsAfter = countComponents(V, adj);

        // If components increase, it’s a bridge
        return componentsAfter > componentsBefore ? true : false;
    }

    // Count connected components
    private int countComponents(int V, List<List<Integer>> adj) {
        boolean[] visited = new boolean[V];
        int count = 0;

        for (int i = 0; i < V; i++) {
            if (!visited[i]) {
                dfs(i, visited, adj);
                count++;
            }
        }
        return count;
    }

    // Perform DFS
    private void dfs(int node, boolean[] visited, List<List<Integer>> adj) {
        visited[node] = true;
        for (int neighbor : adj.get(node)) {
            if (!visited[neighbor]) {
                dfs(neighbor, visited, adj);
            }
        }
    }
}