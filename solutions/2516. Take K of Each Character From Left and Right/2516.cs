public class Solution
{
    public int TakeCharacters(string s, int k)
    {
        int n = s.Length;
        int ans = n;
        int[] count = new int[3];

        foreach (char c in s)
            count[c - 'a']++;

        if (count[0] < k || count[1] < k || count[2] < k)
            return -1;

        for (int l = 0, r = 0; r < n; r++)
        {
            count[s[r] - 'a']--;
            while (count[s[r] - 'a'] < k)
            {
                count[s[l] - 'a']++;
                l++;
            }
            ans = Math.Min(ans, n - (r - l + 1));
        }

        return ans;
    }
}