import java.util.*;

class Solution {
    public static ArrayList<Integer> topoSort(int V, int[][] edges) {
        ArrayList<Integer> ans = new ArrayList<>();
        ArrayList<ArrayList<Integer>> adj = new ArrayList<>();

        for (int i = 0; i < V; i++)
            adj.add(new ArrayList<>());

        for (int[] edge : edges) {
            int u = edge[0];
            int v = edge[1];
            adj.get(v).add(u);
        }

        int[] vis = new int[V];

        for (int i = 0; i < V; i++) {
            if (vis[i] == 0)
                dfs(vis, adj, i, ans);
        }

        return ans;
    }

    public static void dfs(int[] vis, ArrayList<ArrayList<Integer>> adj, int u, ArrayList<Integer> ans) {
        vis[u] = 1;
        for (int v : adj.get(u)) {
            if (vis[v] == 0)
                dfs(vis, adj, v, ans);
        }

        ans.add(u);
    }
}