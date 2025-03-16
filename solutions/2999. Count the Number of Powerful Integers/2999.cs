public class Solution
{
    public long NumberOfPowerfulInt(long start, long finish, int limit, string s)
    {
        string r = finish.ToString();
        string l = (start - 1).ToString();
        long[][] dp = new long[20][];
        for (int i = 0; i < 20; i++)
        {
            long[] arr = new long[2];
            Array.Fill(arr, -1);
            dp[i] = arr;
        }
        long a = topDown(r, s, 1, r.Length, limit, dp);
        // Console.WriteLine("A :" + a);
        for (int i = 0; i < 20; i++)
        {
            long[] arr = new long[2];
            Array.Fill(arr, -1);
            dp[i] = arr;
        }
        long b = topDown(l, s, 1, l.Length, limit, dp);
        // Console.WriteLine("B :" + b);
        return Math.Max(0, (a - b));
    }

    private long topDown(string num, string s, int tight, int n, int limit, long[][] dp)
    {
        if (num.Length < s.Length)
            return 0;

        if (dp[n][tight] != -1)
            return dp[n][tight];

        int ub = tight == 1 ? num[num.Length - n] - '0' : limit;

        // Console.WriteLine("Upper Bound: " + ub);

        // Console.WriteLine("Num value: " + num);
        // Console.WriteLine("s value: " + s);
        // Console.WriteLine("Tight value: " + tight);
        // Console.WriteLine("N value: " + n);

        long ans = 0;

        if (n == 1)
        {
            int a = s[s.Length - n] - '0';
            if (a > ub)
                return 0;

            return 1;
        }

        if (n <= s.Length)
        {
            if (tight == 1)
            {
                int a = s[s.Length - n] - '0';
                if (a > ub)
                    return 0;
                else if (a == ub)
                {
                    ans += topDown(num, s, 1, n - 1, limit, dp);
                    return ans;
                }
                else
                    return 1;
            }
            else
                return 1;
        }
        else
        {
            for (int i = 0; i <= ub && i <= limit; i++)
            {
                int t = tight == 1 && (i == ub) ? 1 : 0;
                ans += topDown(num, s, t, n - 1, limit, dp);
            }
        }

        return dp[n][tight] = ans;
    }
}