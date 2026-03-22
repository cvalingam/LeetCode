import java.util.*;

class Solution {
    public int isCircle(String arr[]) {
        int n = arr.length;

        if (n == 0)
            return 0;

        int[] inDegree = new int[26];
        int[] outDegree = new int[26];

        ArrayList<Integer>[] adj = new ArrayList[26];

        for (int i = 0; i < 26; i++)
            adj[i] = new ArrayList<>();

        for (String str : arr) {
            int first = str.charAt(0) - 'a';
            int last = str.charAt(str.length() - 1) - 'a';

            outDegree[first]++;
            inDegree[last]++;

            adj[first].add(last);
        }

        for (int i = 0; i < 26; i++) {
            if (inDegree[i] != outDegree[i])
                return 0;
        }

        int start = -1;
        for (int i = 0; i < 26; i++) {
            if (outDegree[i] > 0) {
                start = i;
                break;
            }
        }

        boolean[] visited = new boolean[26];
        dfs(start, adj, visited);

        for (int i = 0; i < 26; i++) {
            if (outDegree[i] > 0 && !visited[i])
                return 0;
        }

        return 1;
    }

    private void dfs(int node, ArrayList<Integer>[] adj, boolean[] visited) {
        visited[node] = true;

        for (int adjNode : adj[node]) {
            if (!visited[adjNode])
                dfs(adjNode, adj, visited);
        }
    }
}