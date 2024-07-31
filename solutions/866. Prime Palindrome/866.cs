public class Solution
{
    public int PrimePalindrome(int n)
    {
        if (n <= 2)
            return 2;
        if (n == 3)
            return 3;
        if (n <= 5)
            return 5;
        if (n <= 7)
            return 7;
        if (n <= 11)
            return 11;

        int nLength = n.ToString().Length;

        while (true)
        {
            foreach (int num in GetPalindromes(nLength))
                if (num >= n && IsPrime(num))
                    return num;
            ++nLength;
        }
    }

    private List<int> GetPalindromes(int n)
    {
        List<int> palindromes = new List<int>();
        int length = n / 2;

        for (int i = (int)Math.Pow(10, length - 1); i < (int)Math.Pow(10, length); ++i)
        {
            string s = i.ToString();
            string reversedS = new string(s.ToCharArray().Reverse().ToArray());
            for (int j = 0; j < 10; ++j)
                palindromes.Add(int.Parse(s + j.ToString() + reversedS));
        }

        return palindromes;
    }

    private bool IsPrime(int num)
    {
        for (int i = 2; i <= (int)Math.Sqrt(num); ++i)
            if (num % i == 0)
                return false;
        return true;
    }
}