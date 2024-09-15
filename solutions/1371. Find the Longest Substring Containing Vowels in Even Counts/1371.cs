public class Solution
{
    public int FindTheLongestSubstring(string s)
    {
        const string kVowels = "aeiou";
        int ans = 0;
        int prefix = 0; // the binary prefix
        Dictionary<int, int> prefixToIndex = new Dictionary<int, int>();
        prefixToIndex[0] = -1;

        for (int i = 0; i < s.Length; ++i)
        {
            int index = kVowels.IndexOf(s[i]);
            if (index != -1)
                prefix ^= 1 << index;
            if (!prefixToIndex.ContainsKey(prefix))
                prefixToIndex[prefix] = i;
            ans = Math.Max(ans, i - prefixToIndex[prefix]);
        }

        return ans;
    }
}