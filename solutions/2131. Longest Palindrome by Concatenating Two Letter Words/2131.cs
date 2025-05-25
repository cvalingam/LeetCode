public class Solution
{
    public int LongestPalindrome(string[] words)
    {
        int ans = 0;

        int[,] count = new int[26, 26];

        foreach (string word in words)
        {
            int i = word[0] - 'a';
            int j = word[1] - 'a';
            if (count[j, i] > 0)
            {
                ans += 4;
                --count[j, i];
            }
            else
                ++count[i, j];
        }

        for (int i = 0; i < 26; i++)
        {
            if (count[i, i] > 0)
                return ans + 2;
        }

        return ans;
    }
}