// Approach: Count elements satisfying the given condition, often using binary search or linear scan.
// Time: O(n log n) Space: O(1)
class Solution {
    int totalCount(int k, int[] arr) {
        int count = 0;

        for (int num : arr)
            count += (num + k - 1) / k;

        return count;
    }
}