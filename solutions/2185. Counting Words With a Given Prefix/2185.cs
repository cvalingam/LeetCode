public class Solution
{
    public int PrefixCount(string[] words, string pref)
    {
        return words.Count(w => w.StartsWith(pref));
    }
}