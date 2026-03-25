// Approach: Count numbers that fall in the even-digit ranges (10-99, 1000-9999, 100000).
// Time: O(n) Space: O(1)

public class Solution
{
    public int FindNumbers(int[] nums)
    {
        int ans = 0;

        foreach (int num in nums)
        {
            if ((num > 9 && num < 100) || (num > 999 && num < 10000) || num == 100000)
                ans++;
        }

        return ans;
    }
}