public class Solution
{
    public int PunishmentNumber(int n)
    {
        int ans = 0;

        for (int i = 1; i <= n; i++)
        {
            int square = i * i;
            if (isPossible(0, 0, square.ToString(), 0, i))
                ans += square;
        }

        return ans;
    }

    // Returns true if the sum of any split of `numChars` equals to the target.
    private bool isPossible(int accumulate, int running, string numChars, int s, int target)
    {
        if (s == numChars.Length)
            return target == accumulate + running;
        int d = numChars[s] - '0';
        return isPossible(accumulate, running * 10 + d, numChars, s + 1, target) ||
            isPossible(accumulate + running, d, numChars, s + 1, target);
    }
}