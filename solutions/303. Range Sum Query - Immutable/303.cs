// Approach: Prefix sum array for O(1) range queries after O(n) preprocessing.
// preSum[i] stores the sum of nums[0..i-1], with preSum[0] = 0 as a sentinel.
// Range sum query [left, right] = preSum[right + 1] - preSum[left].
// The sentinel avoids a boundary check for left == 0.
// This pattern extends to 2D (304), trees (307 Fenwick tree), and strings.
// Time: O(n) preprocessing, O(1) per query. Space: O(n) for the prefix array.

public class NumArray
{

    int[] preSum;
    public NumArray(int[] nums)
    {
        int m = nums.Length;
        preSum = new int[m + 1];
        int sum = 0;
        for (int i = 0; i < m; i++)
        {
            sum += nums[i];
            preSum[i + 1] = sum;
        }
    }

    public int SumRange(int left, int right)
    {
        return preSum[right + 1] - preSum[left];
    }
}

/**
 * Your NumArray object will be instantiated and called as such:
 * NumArray obj = new NumArray(nums);
 * int param_1 = obj.SumRange(left,right);
 */