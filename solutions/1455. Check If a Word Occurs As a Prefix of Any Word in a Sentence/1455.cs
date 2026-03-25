// Approach: Split sentence into words; return 1-indexed position of first word that starts with searchWord.
// Time: O(n·m) Space: O(n)

public class Solution
{
    public int IsPrefixOfWord(string sentence, string searchWord)
    {
        string[] words = sentence.Split(' ');

        for (int i = 0; i < words.Length; i++)
        {
            if (words[i].StartsWith(searchWord))
                return i + 1;
        }

        return -1;
    }
}