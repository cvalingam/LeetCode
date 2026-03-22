import java.util.*;

class Solution {
    // Directions for moving in the grid
    private int[] dRow = { -1, 1, 0, 0 };
    private int[] dCol = { 0, 0, -1, 1 };

    // Function to return the minimum cost to react at bottom
    // right cell from top left cell.
    public int minimumCostPath(int[][] grid) {
        int N = grid.length;
        int[][] dist = new int[N][N];

        // Initialize the distance array with a large value
        for (int i = 0; i < N; i++)
            Arrays.fill(dist[i], Integer.MAX_VALUE);

        // Min-Heap priority queue to store cells and their current path cost
        PriorityQueue<int[]> pq = new PriorityQueue<>((a, b) -> a[2] - b[2]);

        // Start from the top-left corner
        pq.add(new int[] { 0, 0, grid[0][0] });
        dist[0][0] = grid[0][0];

        while (!pq.isEmpty()) {
            int[] current = pq.poll();
            int row = current[0];
            int col = current[1];
            int currentCost = current[2];

            // If we reached the bottom-right corner, return the cost
            if (row == N - 1 && col == N - 1)
                return currentCost;

            // Explore the 4 possible directions
            for (int i = 0; i < 4; i++) {
                int newRow = row + dRow[i];
                int newCol = col + dCol[i];

                // Check if the new position is within the grid bounds
                if (newRow >= 0 && newRow < N && newCol >= 0 && newCol < N) {
                    int newCost = currentCost + grid[newRow][newCol];

                    // If a cheaper cost path is found
                    if (newCost < dist[newRow][newCol]) {
                        dist[newRow][newCol] = newCost;
                        pq.add(new int[] { newRow, newCol, newCost });
                    }
                }
            }
        }

        return dist[N - 1][N - 1];
    }
}