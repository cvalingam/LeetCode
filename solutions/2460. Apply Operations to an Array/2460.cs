public class Solution
{
    public int[] ApplyOperations(int[] nums)
    {
        int[] ans = new int[nums.Length];

        for (int i = 0; i + 1 < nums.Length; ++i)
        {
            if (nums[i] == nums[i + 1])
            {
                nums[i] *= 2;
                nums[i + 1] = 0;
            }
        }

        int index = 0;
        foreach (int num in nums)
        {
            if (num > 0)
                ans[index++] = num;
        }

        return ans;
    }
}