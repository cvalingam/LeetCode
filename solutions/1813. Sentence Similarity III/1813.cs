public class Solution
{
    public bool AreSentencesSimilar(string sentence1, string sentence2)
    {
        if (sentence1.Length == sentence2.Length)
            return sentence1.Equals(sentence2);

        string[] words1 = sentence1.Split(' ');
        string[] words2 = sentence2.Split(' ');
        int m = words1.Length;
        int n = words2.Length;
        if (m > n)
            return AreSentencesSimilar(sentence2, sentence1);

        int i = 0; // words1's index
        while (i < m && words1[i].Equals(words2[i]))
            ++i;
        while (i < m && words1[i].Equals(words2[i + n - m]))
            ++i;

        return i == m;
    }
}