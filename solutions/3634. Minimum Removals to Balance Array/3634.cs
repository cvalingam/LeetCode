public class Solution
{
    public int MinRemoval(int[] nums, int k)
    {
        Array.Sort(nums);
        int cnt = 0;
        int n = nums.Length;
        for (int i = 0; i < n; ++i)
        {
            int j = n;
            if ((long)nums[i] * k <= nums[n - 1])
            {
                j = Array.BinarySearch(nums, nums[i] * k + 1);
                j = j < 0 ? ~j : j;
            }
            cnt = Math.Max(cnt, j - i);
        }

        return n - cnt;
    }
}