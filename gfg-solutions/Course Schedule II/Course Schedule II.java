import java.util.*;

class Solution {
    public ArrayList<Integer> findOrder(int n, int[][] prerequisites) {
        List<List<Integer>> graph = new ArrayList<>();
        boolean[] visited = new boolean[n];
        Stack<Integer> stack = new Stack<>();
        ArrayList<Integer> ansList = new ArrayList<>();

        for (int i = 0; i < n; i++)
            graph.add(new ArrayList<>());

        for (int[] prerequisite : prerequisites) {
            int u = prerequisite[1];
            int v = prerequisite[0];
            graph.get(u).add(v);
        }

        for (int i = 0; i < n; i++) {
            if (!visited[i])
                topoSort(graph, i, visited, stack);
        }
        
        while (!stack.isEmpty())
            ansList.add(stack.pop());

        return ansList;
    }

    public void topoSort(List<List<Integer>> graph, int i, boolean[] visited, Stack<Integer> stack) {
        visited[i] = true;

        for (int nei : graph.get(i)) {
            if (!visited[nei])
                topoSort(graph, nei, visited, stack);
        }
        stack.push(i);
    }
}