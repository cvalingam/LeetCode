public class Solution
{
    // Parent array for Union-Find data structure
    private int[] parent;
    public int SwimInWater(int[][] grid)
    {
        int n = grid.Length;

        // Initialize Union-Find parent array
        // Each cell initially points to itself as parent
        parent = new int[n * n];
        for (int i = 0; i < parent.Length; i++)
            parent[i] = i;

        // Create a mapping from elevation value to its position in grid
        // heightToIndex[h] stores the flattened index of cell with height h
        int[] heightToIndex = new int[n * n];
        for (int row = 0; row < n; row++)
        {
            for (int col = 0; col < n; col++)
            {
                int height = grid[row][col];
                int flattenedIndex = row * n + col;
                heightToIndex[height] = flattenedIndex;
            }
        }

        // Direction vectors for exploring 4 adjacent cells (up, right, down, left)
        int[] directions = { -1, 0, 1, 0, -1 };

        // Process cells in order of increasing elevation (time)
        for (int time = 0; time < n * n; time++)
        {
            // Get the position of cell with current elevation
            int currentIndex = heightToIndex[time];
            int currentRow = currentIndex / n;
            int currentCol = currentIndex % n;

            // Connect current cell with all adjacent cells that have been processed
            // (cells with elevation <= current time)
            for (int dir = 0; dir < 4; dir++)
            {
                int nextRow = currentRow + directions[dir];
                int nextCol = currentCol + directions[dir + 1];

                // Check if adjacent cell is within bounds and already accessible
                if (nextRow >= 0 && nextRow < n && nextCol >= 0 && nextCol < n
                    && grid[nextRow][nextCol] <= time)
                {
                    // Union the two cells in the disjoint set
                    int nextIndex = nextRow * n + nextCol;
                    parent[Find(nextIndex)] = Find(currentIndex);
                }
            }

            // Check if start (0,0) and end (n-1,n-1) are connected
            if (Find(0) == Find(n * n - 1))
                return time;
        }

        // This should never be reached given problem constraints
        return -1;
    }

    // Find operation with path compression for Union-Find
    private int Find(int x)
    {
        if (parent[x] != x)
            // Path compression: make x point directly to root
            parent[x] = Find(parent[x]);
            
        return parent[x];
    }
}