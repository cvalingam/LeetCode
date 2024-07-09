public class Solution
{
    public int ThreeSumClosest(int[] nums, int target)
    {
        int j = 0, n = nums.Length;
        int k = 0;
        int result = 0;
        int minDiff = Int32.MaxValue;
        Array.Sort(nums);
        for (int i = 0; i < n - 2; i++)
        {
            j = i + 1;
            k = n - 1;
            while (j < k)
            {
                int sum = nums[i] + nums[j] + nums[k];
                if (sum < target)
                    j++;
                else if (sum > target)
                    k--;
                else if (sum == target)
                {
                    return sum;
                }
                int diff = Math.Abs(sum - target);
                if (diff < minDiff)
                {
                    minDiff = diff;
                    result = sum;
                }
            }
        }

        return result;
    }
}