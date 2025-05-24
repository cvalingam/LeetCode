public class Solution
{
    public IList<int> FindWordsContaining(string[] words, char x)
    {
        IList<int> result = new List<int>();
        for (int i = 0; i < words.Length; i++)
        {
            string word = words[i];
            foreach (char c in word)
            {
                if (c == x)
                {
                    result.Add(i);
                    break;
                }
            }
        }

        return result;
    }
}