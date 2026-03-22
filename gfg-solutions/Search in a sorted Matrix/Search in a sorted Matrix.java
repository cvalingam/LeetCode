class Solution {
    // Function to search a given number in row-column sorted matrix.
    public boolean searchMatrix(int[][] mat, int x) {
        int m = mat.length; // Number of rows
        int n = mat[0].length; // Number of columns

        // Start from top-right corner
        int i = 0; // Row index
        int j = n - 1; // Column index

        while (i < m && j >= 0) {
            if (mat[i][j] == x)
                return true; // Found the element
            else if (mat[i][j] > x)
                j--; // Move left if the current element is larger
            else
                i++; // Move down if the current element is smaller
        }

        return false; // Element not found
    }
}