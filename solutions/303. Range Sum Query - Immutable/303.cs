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