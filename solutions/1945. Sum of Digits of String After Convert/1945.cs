public class Solution
{
    public int GetLucky(string s, int k)
    {
        int ans = Convert(s);
        for (int i = 1; i < k; ++i)
            ans = GetDigitSum(ans);
        return ans;
    }

    private int Convert(string s)
    {
        int sum = 0;
        foreach (char c in s)
        {
            int val = c - 'a' + 1;
            // Do one transform to prevent integer overflow.
            sum += val < 10 ? val : (val % 10 + val / 10);
        }
        return sum;
    }

    private int GetDigitSum(int num)
    {
        int digitSum = 0;
        while (num > 0)
        {
            digitSum += num % 10;
            num /= 10;
        }
        return digitSum;
    }
}