import java.util.*;

class Solution {
    // Function to return a list containing the DFS traversal of the graph.
    public ArrayList<Integer> dfs(ArrayList<ArrayList<Integer>> adj) {
        ArrayList<Integer> list = new ArrayList<>();
        boolean[] visit = new boolean[adj.size()];
        for (int i = 0; i < adj.size(); i++) {
            if (!visit[i])
                dfsUtil(adj, list, visit, i);
        }

        return list;
    }

    private void dfsUtil(ArrayList<ArrayList<Integer>> adj, ArrayList<Integer> list, boolean[] visit, int idx) {
        visit[idx] = true;
        list.add(idx);
        for (int i = 0; i < adj.get(idx).size(); i++) {
            int neighbour = adj.get(idx).get(i);
            if (visit[neighbour])
                continue;
            dfsUtil(adj, list, visit, neighbour);
        }
    }
}