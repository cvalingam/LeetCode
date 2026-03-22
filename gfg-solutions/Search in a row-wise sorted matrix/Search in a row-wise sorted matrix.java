class Solution {
    // Function to search a given number in row-column sorted matrix.
    public boolean searchRowMatrix(int[][] mat, int x) {
        int n = mat.length;
        for (int i = 0; i < n; i++) {
            if (mat[i][0] <= x && mat[i][mat[0].length - 1] >= x) {
                if (search(mat[i], x))
                    return true;
            }
        }

        return false;
    }

    boolean search(int arr[], int k) {
        int l = 0;
        int r = arr.length - 1;
        while (l <= r) {
            int mid = (l + r) >> 1;
            if (arr[mid] == k)
                return true;
            else if (arr[mid] > k)
                r = mid - 1;
            else
                l = mid + 1;
        }
        return false;
    }
}
