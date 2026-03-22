import java.util.*;

class Solution {

    public int[] shortestPath(int[][] edges, int n, int m, int src) {
        List<List<Integer>> adjList = new ArrayList<>();

        for (int i = 0; i < n; i++)
            adjList.add(new ArrayList<>());

        for (int[] edge : edges) {
            int u = edge[0];
            int v = edge[1];
            adjList.get(u).add(v);
            adjList.get(v).add(u);
        }

        int[] dist = new int[n];
        Arrays.fill(dist, -1);
        dist[src] = 0;

        Queue<Integer> q = new LinkedList<>();
        q.add(src);

        while (!q.isEmpty()) {
            int node = q.poll();

            for (int adjNode : adjList.get(node)) {
                if (dist[adjNode] == -1) {
                    dist[adjNode] = dist[node] + 1;
                    q.add(adjNode);
                }
            }
        }

        return dist;
    }
}