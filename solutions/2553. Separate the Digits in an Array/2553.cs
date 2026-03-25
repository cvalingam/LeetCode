// Approach: For each number extract digits in order and append to result list.
// Time: O(n * digits) Space: O(n * digits)

public class Solution
{
    public int[] SeparateDigits(int[] nums)
    {
        List<int> ans = new List<int>();

        foreach (var num in nums)
        {
            foreach (var c in num.ToString())
                ans.Add(c - '0');
        }

        return ans.ToArray();
    }
}