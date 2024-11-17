public class Solution
{
    public int SumOfFlooredPairs(int[] nums)
    {
        const int kMod = 1000000007;
        int kMax = nums.Max();
        long ans = 0;
        // count[i] := the number of `nums` <= i
        int[] count = new int[kMax + 1];

        foreach (var num in nums)
            ++count[num];

        for (int i = 1; i <= kMax; ++i)
            count[i] += count[i - 1];

        for (int i = 1; i <= kMax; ++i)
        {
            if (count[i] > count[i - 1])
            {
                long sum = 0;
                for (int j = 1; i * j <= kMax; ++j)
                {
                    int lo = i * j - 1;
                    int hi = i * (j + 1) - 1;
                    sum += (count[Math.Min(hi, kMax)] - count[lo]) * (long)j;
                }
                ans += sum * (count[i] - count[i - 1]);
                ans %= kMod;
            }
        }

        return (int)ans;
    }
}