public class Solution
{
    public int MinimumOperations(int[] nums)
    {
        var set = new HashSet<int>();
        for (int i = nums.Length - 1; i >= 0; i--)
        {
            if (!set.Add(nums[i]))
                return (i + 1 + 2) / 3;
        }

        return 0;
    }
}