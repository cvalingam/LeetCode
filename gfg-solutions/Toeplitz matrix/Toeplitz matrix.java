// Approach: For each element, check if it equals the element diagonally below-right: matrix[i][j] == matrix[i+1][j+1].
// Time: O(n*m) Space: O(1)

class Solution {

    boolean isToeplitz(int mat[][]) {
        int n = mat.length;
        int m = mat[0].length;

        for (int i = 0; i < n; i++) {
            for (int j = 0; j < m; j++) {
                if (i - 1 >= 0 && j - 1 >= 0 && mat[i - 1][j - 1] != mat[i][j]) {
                    return false;
                }

                if (i + 1 < n && j + 1 < m && mat[i + 1][j + 1] != mat[i][j]) {
                    return false;
                }
            }
        }

        return true;
    }
}
