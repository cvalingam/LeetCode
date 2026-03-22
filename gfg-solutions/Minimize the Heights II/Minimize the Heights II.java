import java.util.*;

class Solution {
    int getMinDiff(int[] arr, int k) {
        Arrays.sort(arr);

        int n = arr.length;
        int ans = arr[n - 1] - arr[0];

        int l = arr[0] + k;
        int r = arr[n - 1] - k;
        for (int i = 0; i < n - 1; i++) {
            int mini = Math.min(l, arr[i + 1] - k);
            int maxi = Math.max(r, arr[i] + k);

            if (mini >= 0)
                ans = Math.min(ans, maxi - mini);
        }

        return ans;
    }
}