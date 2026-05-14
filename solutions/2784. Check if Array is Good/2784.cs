// Approach: Count the frequency of each element. A "good" array has exactly [1, n-1] appearing once each, and n appearing twice.
// Check frequency counts against these constraints.
// Time: O(n) Space: O(n)

public class Solution
{
    public bool IsGood(int[] nums)
    {
        int n = nums.Length - 1;
        var count = new Dictionary<int, int>();
        foreach (var num in nums)
        {
            if (count.ContainsKey(num))
                count[num]++;
            else
                count[num] = 1;
        }
        for (int i = 1; i < n; i++)
        {
            if (!count.ContainsKey(i) || count[i] != 1)
                return false;
        }

        return count.ContainsKey(n) && count[n] == 2;
    }
}