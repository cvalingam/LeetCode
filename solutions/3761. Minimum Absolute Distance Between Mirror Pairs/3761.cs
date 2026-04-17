// Approach: For each element, check if its digit-reverse was seen at an earlier index.
// Store the reverse of each element mapped to its index as we iterate left to right.
// When nums[i]'s reverse already exists in the map, the distance i - map[reverse] is a candidate answer.
// Track the minimum candidate; return -1 if no mirror pair is found.
// Time: O(n) Space: O(n)
public class Solution
{
    public int MinMirrorPairDistance(int[] nums)
    {
        int n = nums.Length;
        Dictionary<int, int> pos = new Dictionary<int, int>(n);
        int ans = n + 1;
        for (int i = 0; i < n; ++i)
        {
            if (pos.ContainsKey(nums[i]))
                ans = Math.Min(ans, i - pos[nums[i]]);
            pos[Reverse(nums[i])] = i;
        }
        return ans > n ? -1 : ans;
    }

    private int Reverse(int x)
    {
        int y = 0;
        while (x > 0)
        {
            y = y * 10 + x % 10;
            x /= 10;
        }
        return y;
    }
}