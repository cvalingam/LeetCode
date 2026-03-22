class Solution {
    public boolean searchMatrix(int[][] mat, int x) {
        int n = mat.length;
        int m = mat[0].length;
        int left = 0, right = n * m - 1;
        while (left <= right) {
            int mid = left + (right - left) / 2;
            int midVal = mat[mid / m][mid % m];
            if (midVal == x)
                return true;
            int leftVal = mat[left / m][left % m];
            int rightVal = mat[right / m][right % m];

            if (leftVal <= midVal) {
                if (x >= leftVal && x < midVal)
                    right = mid - 1;
                else
                    left = mid + 1;
            } else {
                if (x > midVal && x <= rightVal)
                    left = mid + 1;
                else
                    right = mid - 1;
            }
        }

        return false;
    }
}