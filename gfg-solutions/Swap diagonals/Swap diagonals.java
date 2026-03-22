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