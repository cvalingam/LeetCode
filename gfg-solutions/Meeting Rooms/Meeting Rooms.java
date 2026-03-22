import java.util.*;

class Solution {
    static boolean canAttend(int[][] arr) {
        Arrays.sort(arr, (a, b) -> a[0] - b[0]);
        int end = arr[0][1];
        for (int i = 1; i < arr.length; i++) {
            if (end > arr[i][0]) {
                return false;
            }
            end = arr[i][1];
        }
        return true;
    }
}