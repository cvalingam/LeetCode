public class Solution
{
    public int AddMinimum(string word)
    {
        char[] letters = new char[] { 'a', 'b', 'c' };
        int ans = 0;
        int i = 0, n = word.Length;

        while (i < n)
        {
            foreach (char ch in letters)
            {
                if (i < n && word[i] == ch)
                    i++;
                else
                    ans++;
            }
        }

        return ans;
    }
}