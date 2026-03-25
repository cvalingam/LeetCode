// Approach: Count words where w.StartsWith(pref) is true.
// Time: O(n * p) Space: O(1)

public class Solution
{
    public int PrefixCount(string[] words, string pref)
    {
        return words.Count(w => w.StartsWith(pref));
    }
}