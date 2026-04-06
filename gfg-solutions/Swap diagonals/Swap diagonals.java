// Approach: Swap elements at (i, i) and (i, n-1-i) for each i in [0, n/2) to exchange the two diagonals.
// Time: O(n) Space: O(1)
class Solution {
    public void swapDiagonal(int[][] mat) {
        int n = mat.length - 1;
        for (int i = 0; i <= n; i++) {

            int temp = mat[i][i];
            mat[i][i] = mat[i][n - i];
            mat[i][n - i] = temp;
        }
    }
}