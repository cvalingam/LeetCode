public class Solution
{
    public int MinimumLength(string s)
    {
        int ans = 0;
        int[] count = new int[26];

        foreach (char c in s)
        {
            count[c - 'a']++;
        }

        for (int i = 0; i < 26; i++)
        {
            if (count[i] > 0)
                ans += count[i] % 2 == 0 ? 2 : 1;
        }

        return ans;
    }
}