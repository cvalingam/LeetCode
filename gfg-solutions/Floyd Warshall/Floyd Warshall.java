// Approach: All-pairs shortest path DP. dist[i][j] = min over intermediate vertices k of (dist[i][k] + dist[k][j]).
// Time: O(V^3) Space: O(V^2)
class Solution {
    public void floydWarshall(int[][] dist) {
        int n = dist.length;

        for (int k = 0; k < n; k++) {
            for (int i = 0; i < n; i++) {
                for (int j = 0; j < n; j++) {
                    if (dist[i][k] + dist[k][j] < dist[i][j])
                        dist[i][j] = dist[i][k] + dist[k][j];
                }
            }
        }
    }
}