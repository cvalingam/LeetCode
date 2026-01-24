public class Solution
{
    public int MinPairSum(int[] nums)
    {
        int ans = 0;

        Array.Sort(nums);

        int i = 0, j = nums.Length - 1;
        while (i < j)
            ans = Math.Max(ans, nums[i++] + nums[j--]);

        return ans;
    }
}