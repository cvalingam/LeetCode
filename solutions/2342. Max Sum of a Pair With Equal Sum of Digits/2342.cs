public class Solution
{
    public int MaximumSum(int[] nums)
    {
        const int kMax = 9 * 9;  // 999,999,999
        int ans = -1;
        List<List<int>> count = new List<List<int>>(new List<int>[kMax + 1]);

        for (int i = 0; i <= kMax; i++)
            count[i] = new List<int>();

        foreach (int num in nums)
            count[GetDigitSum(num)].Add(num);

        foreach (List<int> groupNums in count)
        {
            if (groupNums.Count < 2)
                continue;
            groupNums.Sort((a, b) => b.CompareTo(a));
            ans = Math.Max(ans, groupNums[0] + groupNums[1]);
        }

        return ans;
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