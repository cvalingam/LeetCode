import java.util.*;

class Solution {
    public boolean isCyclic(int V, int[][] edges) {
        List<List<Integer>> graph = new ArrayList<>();
        int[] indegree = new int[V];

        for (int i = 0; i < V; i++)
            graph.add(new ArrayList<>());

        for (int[] edge : edges) {
            int u = edge[0];
            int v = edge[1];
            graph.get(u).add(v);
            indegree[v]++;
        }

        Queue<Integer> q = new LinkedList<>();

        for (int i = 0; i < V; i++) {
            if (indegree[i] == 0)
                q.offer(i);
        }

        List<Integer> result = new ArrayList<>();

        while (!q.isEmpty()) {
            int node = q.poll();
            result.add(node);
            for (int adj : graph.get(node)) {
                indegree[adj]--;
                if (indegree[adj] == 0)
                    q.offer(adj);
            }
        }

        return result.size() != V;
    }
}