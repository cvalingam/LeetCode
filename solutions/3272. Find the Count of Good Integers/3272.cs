public class Solution
{
    public long CountGoodIntegers(int n, int k)
    {
        int halfLength = (n + 1) / 2;
        int minHalf = (int)Math.Pow(10, halfLength - 1);
        int maxHalf = (int)Math.Pow(10, halfLength);
        long ans = 0;
        HashSet<string> seen = new HashSet<string>();

        for (int num = minHalf; num < maxHalf; ++num)
        {
            string firstHalf = num.ToString();
            string secondHalf = new string(firstHalf.ToCharArray().Reverse().ToArray());
            string palindrome = firstHalf + secondHalf.Substring(n % 2);
            if (long.Parse(palindrome) % k != 0)
                continue;

            char[] sortedDigits = palindrome.ToCharArray();
            Array.Sort(sortedDigits);
            string sortedDigitsStr = new string(sortedDigits);
            if (seen.Contains(sortedDigitsStr))
                continue;

            seen.Add(sortedDigitsStr);
            int[] digitCount = new int[10];
            foreach (char c in palindrome)
                ++digitCount[c - '0'];
            // Leading zeros are not allowed, so the first digit is special.
            int firstDigitChoices = n - digitCount[0];
            long permutations = firstDigitChoices * Factorial(n - 1);
            // For each repeated digit, divide by the factorial of the frequency since
            // permutations that swap identical digits don't create a new number.
            foreach (int freq in digitCount)
            {
                if (freq > 1)
                    permutations /= Factorial(freq);
            }

            ans += permutations;
        }

        return ans;
    }

    private long Factorial(int n)
    {
        long res = 1;
        for (int i = 2; i <= n; ++i)
            res *= i;

        return res;
    }
}