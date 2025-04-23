public class Solution
{
    public int CountLargestGroup(int n)
    {
        int[] count = new int[9 * 4 + 1];
        for (int i = 1; i <= n; ++i)
            ++count[GetDigitSum(i)];
        int mx = count.Max();
        return count.Count(c => c == mx);
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