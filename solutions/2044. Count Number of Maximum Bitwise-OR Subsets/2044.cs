public class Solution
{
    private int ans = 0;

    public int CountMaxOrSubsets(int[] nums)
    {
        int ors = nums.Aggregate((a, b) => a | b);
        Dfs(nums, 0, 0, ors);
        return ans;
    }

    private void Dfs(int[] nums, int i, int path, int ors)
    {
        if (i == nums.Length)
        {
            if (path == ors)
                ++ans;
            return;
        }

        Dfs(nums, i + 1, path, ors);
        Dfs(nums, i + 1, path | nums[i], ors);
    }
}