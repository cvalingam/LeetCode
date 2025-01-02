public class Solution
{
    public int[] VowelStrings(string[] words, int[][] queries)
    {
        int[] ans = new int[queries.Length];
        // prefix[i] := the number of the first i words that start with and end in a vowel
        int[] prefix = new int[words.Length + 1];

        for (int i = 0; i < words.Length; ++i)
            prefix[i + 1] += prefix[i] + (StartsAndEndsWithVowel(words[i]) ? 1 : 0);

        for (int i = 0; i < queries.Length; ++i)
        {
            int l = queries[i][0];
            int r = queries[i][1];
            ans[i] = prefix[r + 1] - prefix[l];
        }

        return ans;
    }

    private bool StartsAndEndsWithVowel(string word)
    {
        return IsVowel(word[0]) && IsVowel(word[word.Length - 1]);
    }

    private bool IsVowel(char c)
    {
        return "aeiou".IndexOf(c) != -1;
    }
}