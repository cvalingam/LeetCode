public class Solution
{
    public int SumFourDivisors(int[] nums)
    {
        int ans = 0;

        foreach (int num in nums)
        {
            int divisor = 0;
            for (int i = 2; i * i <= num; ++i)
            {
                if (num % i == 0)
                {
                    if (divisor == 0)
                        divisor = i;
                    else
                    {
                        divisor = 0;
                        break;
                    }
                }
            }
            
            if (divisor > 0 && divisor * divisor < num)
                ans += 1 + num + divisor + num / divisor;
        }

        return ans;
    }
}