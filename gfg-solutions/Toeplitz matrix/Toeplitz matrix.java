class Solution {
    boolean isToeplitz(int mat[][]) {
        int n = mat.length;
        int m = mat[0].length;

        for (int i = 0; i < n; i++) {
            for (int j = 0; j < m; j++) {
                if (i - 1 >= 0 && j - 1 >= 0 && mat[i - 1][j - 1] != mat[i][j])
                    return false;

                if (i + 1 < n && j + 1 < m && mat[i + 1][j + 1] != mat[i][j])
                    return false;
            }
        }

        return true;
    }
}