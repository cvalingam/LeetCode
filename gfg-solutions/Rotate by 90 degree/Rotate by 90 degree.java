// Clock wise
class GFG {
    static void rotate(int arr[][]) {
        int n = arr.length;
        int m = arr[0].length;

        for (int i = 0; i < n; i++) {
            for (int j = i; j < m; j++) {
                int temp = arr[i][j];
                arr[i][j] = arr[j][i];
                arr[j][i] = temp;
            }
        }

        for (int i = 0; i < n; i++) {
            int low = 0;
            int high = n - 1;
            while (low <= high) {
                int temp = arr[i][low];
                arr[i][low] = arr[i][high];
                arr[i][high] = temp;
                low++;
                high--;
            }
        }
    }
}

// Anti-clockwise
class Solution {
    // Function to rotate matrix anticlockwise by 90 degrees.
    static void rotateby90(int mat[][]) {
        int n = mat.length; // Length of the matrix (assuming square matrix)

        // Transpose the matrix
        for (int i = 0; i < n; i++) {
            for (int j = i; j < n; j++) {
                int temp = mat[i][j];
                mat[i][j] = mat[j][i];
                mat[j][i] = temp;
            }
        }

        // Reverse each column to get anticlockwise rotation
        for (int i = 0; i < n / 2; i++) {
            for (int j = 0; j < n; j++) {
                int temp = mat[i][j];
                mat[i][j] = mat[n - i - 1][j];
                mat[n - i - 1][j] = temp;
            }
        }
    }
}