public class Solution
{
    public int MinOperations(int[] nums)
    {
        int n = nums.Length, ans = 0;

        for (int i = 0; i < n - 2; i++)
        {
            if (nums[i] == 1)
                continue;

            for (int j = i; j <= i + 2; j++)
                nums[j] = nums[j] ^ 1;

            ans++;
        }

        if (nums[n - 1] == 0 || nums[n - 2] == 0)
            return -1;

        return ans;
    }
}