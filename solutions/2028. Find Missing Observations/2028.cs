public class Solution
{
    public int[] MissingRolls(int[] rolls, int mean, int n)
    {
        int targetSum = (rolls.Length + n) * mean;
        int missingSum = targetSum - rolls.Sum();
        if (missingSum > n * 6 || missingSum < n)
            return new int[] { };

        int[] ans = new int[n];
        Array.Fill(ans, missingSum / n);
        missingSum %= n;
        for (int i = 0; i < missingSum; ++i)
            ++ans[i];

        return ans;
    }
}

