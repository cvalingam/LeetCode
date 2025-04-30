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