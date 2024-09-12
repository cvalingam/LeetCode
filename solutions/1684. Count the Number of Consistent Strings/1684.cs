public class Solution
{
    public int CountConsistentStrings(string allowed, string[] words)
    {
        bool[] s = new bool[26];

        foreach (char c in allowed)
            s[c - 'a'] = true;

        int ans = 0;

        foreach (string w in words)
        {
            if (Check(w, s))
                ans++;
        }

        return ans;
    }

    private bool Check(string w, bool[] s)
    {
        for (int i = 0; i < w.Length; i++)
        {
            if (!s[w[i] - 'a'])
                return false;
        }

        return true;
    }
}