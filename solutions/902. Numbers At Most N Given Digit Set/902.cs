public class Solution
{
    public int AtMostNGivenDigitSet(string[] digits, int n)
    {
        int ans = 0;
        string num = n.ToString();

        for (int i = 1; i < num.Length; ++i)
            ans += (int)Math.Pow(digits.Length, i);

        for (int i = 0; i < num.Length; ++i)
        {
            bool dHasSameNum = false;
            foreach (var digit in digits)
            {
                if (digit[0] < num[i])
                    ans += (int)Math.Pow(digits.Length, num.Length - i - 1);
                else if (digit[0] == num[i])
                    dHasSameNum = true;
            }
            if (!dHasSameNum)
                return ans;
        }

        return ans + 1;
    }
}