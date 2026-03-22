import java.util.*;

class Solution {
    public boolean isCycle(int V, int[][] edges) {
        // Code here
        List<List<Integer>> adj = new ArrayList<>();

        for (int i = 0; i < V; i++)
            adj.add(new ArrayList<>());

        for (int[] edge : edges) {
            int u = edge[0];
            int v = edge[1];
            adj.get(u).add(v);
            adj.get(v).add(u);
        }

        boolean[] vis = new boolean[V];

        for (int i = 0; i < V; i++) {
            if (!vis[i]) {
                if (bfsCheck(i, adj, vis))
                    return true;
            }
        }

        return false;
    }

    private boolean bfsCheck(int src, List<List<Integer>> adj, boolean[] vis) {
        Queue<int[]> q = new LinkedList<>();
        q.offer(new int[] { src, -1 });
        vis[src] = true;

        while (!q.isEmpty()) {
            int[] node = q.poll();
            int curr = node[0];
            int parent = node[1];

            for (int neighbor : adj.get(curr)) {
                if (!vis[neighbor]) {
                    vis[neighbor] = true;
                    q.offer(new int[] { neighbor, curr });
                } else if (neighbor != parent)
                    return true;
            }
        }

        return false;
    }
}