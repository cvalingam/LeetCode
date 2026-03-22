class Solution {
    public static boolean matSearch(int mat[][], int x) {
        for (int i = 0; i < mat.length; i++) {
            int low = 0, high = mat[i].length - 1;
            if (mat[i][low] <= x && mat[i][high] >= x) {

                while (low <= high) {
                    int mid = (low + high) / 2;
                    if (mat[i][mid] == x)
                        return true;
                    else if (mat[i][mid] > x)
                        high = mid - 1;
                    else
                        low = mid + 1;

                }
            }

        }
        return false;
    }
}