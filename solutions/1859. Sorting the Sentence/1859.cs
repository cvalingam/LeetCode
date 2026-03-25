// Approach: Split sentence, sort by trailing digit (word position), strip digits and rejoin.
// Time: O(n log n) Space: O(n)

public class Solution
{
    public string SortSentence(string s)
    {
        string[] words = s.Split(' ');

        Array.Sort(words, (a, b) => a[a.Length - 1] - b[b.Length - 1]);

        StringBuilder sb = new StringBuilder(Trim(words[0]));

        for (int i = 1; i < words.Length; ++i)
            sb.Append(" ").Append(Trim(words[i]));

        return sb.ToString();
    }

    private string Trim(string s)
    {
        return s.Substring(0, s.Length - 1);
    }
}