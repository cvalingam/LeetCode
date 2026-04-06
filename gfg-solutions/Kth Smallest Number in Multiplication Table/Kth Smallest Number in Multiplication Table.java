// Approach: Binary search on value. Count numbers in m x n table <= mid = sum of min(mid/i, n) for i in [1..m].
// Time: O(m log(m*n)) Space: O(1)
class Solution {
    public int kthSmallest(int m, int n, int k) {
        int low = 1;
        int high = m * n;

        while (low < high) {
            int mid = low + (high - low) / 2;

            int count = 0;
            for (int i = 1; i <= m; i++)
                count += Math.min(mid / i, n);

            if (count < k)
                low = mid + 1;
            else
                high = mid;
        }

        return low;
    }
}