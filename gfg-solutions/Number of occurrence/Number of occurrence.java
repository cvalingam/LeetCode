// Approach: Binary search for first and last occurrence of target. Count = last - first + 1.
// Time: O(log n) Space: O(1)
class Solution {
    int countFreq(int[] arr, int target) {
        int ans = 0;
        for (int num : arr) {
            if (num == target)
                ans++;
        }
        return ans;
    }
}