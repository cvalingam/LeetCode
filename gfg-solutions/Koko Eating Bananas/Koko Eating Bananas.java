import java.util.*;

class Solution {
    public int kokoEat(int[] arr, int k) {
        Arrays.sort(arr);
        int ans = -1;
        int low = 1;
        int high = (int) 1e9;
        while (low <= high) {
            int mid = low + (high - low) / 2;
            if (ispossible(arr, mid) <= k) {
                ans = mid;
                high = mid - 1;
            } else
                low = mid + 1;
        }

        return ans;
    }

    private int ispossible(int[] arr, int mid) {
        int ans = 0;
        for (int i = 0; i < arr.length; i++) {
            int cnt = arr[i] / mid;
            if (arr[i] % mid != 0)
                cnt++;

            ans += cnt;
        }
        
        return ans;
    }
}
