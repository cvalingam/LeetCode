public class Solution
{
    public int LengthAfterTransformations(string s, int t)
    {
        const int MOD = 1_000_000_007;
        int[] count = new int[26];

        foreach (char c in s)
            count[c - 'a']++;

        while (t-- > 0)
        {
            int[] newCount = new int[26];
            // 'a' -> 'b', 'b' -> 'c', ..., 'y' -> 'z'
            for (int i = 0; i < 25; i++)
                newCount[i + 1] = count[i];
            // 'z' -> 'ab'
            newCount[0] = count[25];
            newCount[1] = (newCount[1] + count[25]) % MOD;
            count = newCount;
        }

        return count.Aggregate(0, (a, b) => (a + b) % MOD);
    }
}