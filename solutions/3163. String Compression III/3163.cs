public class Solution
{
    public string CompressedString(string word)
    {
        int n = word.Length;
        StringBuilder sb = new StringBuilder();

        for (int i = 0, j = 0; i < n; i = j)
        {
            int count = 0;
            while (j < n && word[j] == word[i] && count < 9)
            {
                ++j;
                ++count;
            }
            sb.Append(count.ToString()).Append(word[i]);
        }

        return sb.ToString();
    }
}