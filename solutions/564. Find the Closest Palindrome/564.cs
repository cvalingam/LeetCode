public class Solution
{
    public string NearestPalindromic(string n)
    {
        long[] palindromes = GetPalindromes(n);
        return Math.Abs(palindromes[0] - long.Parse(n)) <=
               Math.Abs(palindromes[1] - long.Parse(n))
            ? palindromes[0].ToString()
            : palindromes[1].ToString();
    }

    // Returns the two closest palindromes to the given number.
    private long[] GetPalindromes(string s)
    {
        long num = long.Parse(s);
        int n = s.Length;
        long[] palindromes = new long[2];
        string half = s.Substring(0, (n + 1) / 2);
        string reversedHalf = new string(half.Substring(0, n / 2).ToCharArray().Reverse().ToArray());
        long candidate = long.Parse(half + reversedHalf);

        if (candidate < num)
            palindromes[0] = candidate;
        else
        {
            string prevHalf = (long.Parse(half) - 1).ToString();
            string reversedPrevHalf = new string(prevHalf.Substring(0, Math.Min(prevHalf.Length, n / 2)).ToCharArray().Reverse().ToArray());
            if (n % 2 == 0 && long.Parse(prevHalf) == 0)
                palindromes[0] = 9;
            else if (n % 2 == 0 && prevHalf.Equals("9"))
                palindromes[0] = long.Parse(prevHalf + '9' + reversedPrevHalf);
            else
                palindromes[0] = long.Parse(prevHalf + reversedPrevHalf);
        }

        if (candidate > num)
            palindromes[1] = candidate;
        else
        {
            string nextHalf = (long.Parse(half) + 1).ToString();
            string reversedNextHalf = new string(nextHalf.Substring(0, n / 2).ToCharArray().Reverse().ToArray());
            palindromes[1] = long.Parse(nextHalf + reversedNextHalf);
        }

        return palindromes;
    }
}