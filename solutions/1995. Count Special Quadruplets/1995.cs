public class Solution
{
    public int CountQuadruplets(int[] nums)
    {
        int n = nums.Length;
        int ans = 0;
        Dictionary<int, int> count = new Dictionary<int, int>();

        // nums[a] + nums[b] + nums[c] == nums[d]
        // => nums[a] + nums[b] == nums[d] - nums[c]
        for (int b = n - 1; b > 0; --b)
        { // `b` also represents `c`.
            for (int a = b - 1; a >= 0; --a)
                ans += count.TryGetValue(nums[a] + nums[b], out int value) ? value : 0;
            for (int d = n - 1; d > b; --d)
                if (count.ContainsKey(nums[d] - nums[b]))
                {
                    count[nums[d] - nums[b]]++;
                }
                else
                {
                    count[nums[d] - nums[b]] = 1;
                } // b := c
        }

        return ans;
    }
}