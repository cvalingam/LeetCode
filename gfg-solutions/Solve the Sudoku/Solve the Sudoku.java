class Solution {
    // Function to find a solved Sudoku.
    static void solveSudoku(int[][] mat) {
        solveSudoku1(mat);
    }

    static boolean valid(int ch, int r, int c, int[][] mat) {
        int n = mat.length;
        int m = mat[0].length;
        for (int i = 0; i < 9; i++) {
            if (mat[i][c] == ch)
                return false;
            if (mat[r][i] == ch)
                return false;

            if (mat[3 * (r / 3) + (i / 3)][3 * (c / 3) + (i % 3)] == ch)
                return false;

        }

        return true;
    }

    static boolean solveSudoku1(int[][] mat) {
        int n = mat.length;
        int m = mat[0].length;

        for (int i = 0; i < n; i++) {
            for (int j = 0; j < m; j++) {
                if (mat[i][j] == 0) {
                    for (int k = 1; k <= 9; k++) {
                        if (valid(k, i, j, mat) == true) {
                            mat[i][j] = k;
                            
                            if (solveSudoku1(mat) == true)
                                return true;

                            mat[i][j] = 0;
                        }
                    }

                    return false;
                }

            }
        }
        return true;
    }
}