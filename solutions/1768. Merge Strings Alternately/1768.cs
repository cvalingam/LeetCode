public class Solution
{
    public string MergeAlternately(string word1, string word2)
    {
        int l1 = 0, l2 = 0;
        int r1 = word1.Length;
        int r2 = word2.Length;

        StringBuilder res = new StringBuilder();
        while (l1 < r1 && l2 < r2)
        {
            res.Append(word1[l1++]);
            res.Append(word2[l2++]);
        }

        while (l1 < r1)
            res.Append(word1[l1++]);

        while (l2 < r2)
            res.Append(word2[l2++]);

        return res.ToString();
    }
}