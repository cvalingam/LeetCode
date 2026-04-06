// Approach: For each pair of adjacent elements, their sum is a candidate (no non-adjacent sum can be better).
// Time: O(n) Space: O(1)
class Solution {
    public int maxSum(int arr[]) {
        int ans = Integer.MIN_VALUE;
        for (int i = 1; i < arr.length; i++)
            ans = Math.max(ans, arr[i] + arr[i - 1]);

        return ans;
    }
}