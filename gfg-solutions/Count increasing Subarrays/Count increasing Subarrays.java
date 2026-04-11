// Approach: Scan once and track the current strictly increasing streak length between
// adjacent elements. When arr[i] > arr[i-1], extend the streak and add it to answer;
// otherwise reset streak to 0.
// Time: O(n) Space: O(1)

class Solution {

    public int countIncreasing(int[] arr) {
        int n = arr.length;
        long ans = 0;
        int cnt = 0; // Represents the number of increasing elements before current

        for (int i = 1; i < n; i++) {
            if (arr[i] > arr[i - 1]) {
                cnt++;
                ans += cnt; // Each new element in a streak adds 'cnt' new subarrays
            } else {
                cnt = 0; // Reset streak
            }
        }

        return (int) ans;
    }
}
