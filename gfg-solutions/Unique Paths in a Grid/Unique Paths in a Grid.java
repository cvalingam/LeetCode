class Solution {
    public int uniquePaths(int[][] grid) {
        int rw = grid.length;
        int column = grid[0].length;

        int[][] temp = new int[rw + 1][column + 1];
        for (int i = 0; i <= rw; i++) {
            for (int j = 0; j <= column; j++)
                temp[i][j] = -1;
        }

        if (grid[0][0] == 1 || grid[rw - 1][column - 1] == 1)
            return 0;

        return possiblePath(0, 0, grid, temp);
    }

    static int possiblePath(int row, int col, int[][] grid, int[][] temp) {
        // base case
        if (row == grid.length - 1 && col == grid[0].length - 1)
            return 1;

        if (temp[row][col] != -1)
            return temp[row][col];

        // subproblems
        int goRight = 0;
        if (row < grid.length && col < grid[0].length - 1 && grid[row][col + 1] == 0)
            goRight = possiblePath(row, col + 1, grid, temp);

        int goDown = 0;
        if (row < grid.length - 1 && col < grid[0].length && grid[row + 1][col] == 0)
            goDown = possiblePath(row + 1, col, grid, temp);

        return temp[row][col] = goRight + goDown;
    }
};