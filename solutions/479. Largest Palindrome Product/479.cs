public class Solution
{
    public int LargestPalindrome(int n)
    {
        if (n == 1)
            return 9;

        const int kMod = 1337;
        int upper = (int)Math.Pow(10, n) - 1;
        int lower = (int)Math.Pow(10, n - 1) - 1;

        for (int i = upper; i > lower; --i)
        {
            long cand = GetPalindromeCandidate(i);
            for (long j = upper; j * j >= cand; --j)
            {
                if (cand % j == 0)
                    return (int)(cand % kMod);
            }
        }

        throw new ArgumentException();
    }

    private long GetPalindromeCandidate(int i)
    {
        string reversed = new string(i.ToString().ToCharArray().Reverse().ToArray());
        return long.Parse(i + reversed);
    }
}