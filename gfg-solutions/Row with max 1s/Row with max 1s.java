class Solution {
    public int rowWithMax1s(int arr[][]) {
        int res = -1;
        int n = arr.length;
        int m = arr[0].length;
        int j = m - 1;
        int i = 0;

        while (i < n && j >= 0) {
            if (arr[i][j] == 1) {
                j--;
                res = i;
            } else
                i++;
        }

        return res;
    }
}