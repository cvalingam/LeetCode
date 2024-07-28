public class Solution
{
    public IList<string> FindAndReplacePattern(string[] words, string pattern)
    {
        IList<string> ans = new List<string>();

        foreach (string word in words)
        {
            if (IsIsomorphic(word, pattern))
                ans.Add(word);
        }

        return ans;
    }

    private bool IsIsomorphic(string w, string p)
    {
        int[] wordMap = new int[128];
        int[] patternMap = new int[128];

        for (int i = 0; i < w.Length; i++)
        {
            if (wordMap[w[i]] != patternMap[p[i]])
                return false;

            wordMap[w[i]] = i + 1;
            patternMap[p[i]] = i + 1;
        }

        return true;
    }
}