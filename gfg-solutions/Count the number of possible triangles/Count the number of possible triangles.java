// Approach: Sort array. For each pair (i,j) with j>i, binary search for the largest k where arr[k] < arr[i]+arr[j].
// Time: O(n^2 log n) Space: O(1)
import java.util.*;

class Solution {
    // Function to count the number of possible triangles.
    static int countTriangles(int arr[]) {
        Arrays.sort(arr);
        int n = arr.length;
        int cnt = 0;
        for (int i = 2; i < n; i++) {
            int j = 0;
            int k = i - 1;
            while (j < k) {
                int sum = arr[j] + arr[k];
                if (sum > arr[i]) {
                    cnt += k - j;
                    k--;
                } else
                    j++;
            }
        }

        return cnt;
    }
}