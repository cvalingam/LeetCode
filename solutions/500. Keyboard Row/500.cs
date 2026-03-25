// Approach: Map each letter to its keyboard row (1/2/3); a word is valid
// if every character shares the same row as the first character.
// Time: O(n*k) Space: O(1)

public class Solution
{
    public string[] FindWords(string[] words)
    {
        List<string> ans = new List<string>();
        int[] rows = {2, 3, 3, 2, 1, 2, 2, 2, 1, 2, 2, 2, 3,
                      3, 1, 1, 1, 1, 2, 1, 1, 3, 1, 3, 1, 3};

        foreach (var word in words)
        {
            string lowerWord = word.ToLower();
            int row = rows[lowerWord[0] - 'a'];
            bool isValid = lowerWord.All(c => rows[c - 'a'] == row);
            if (isValid)
                ans.Add(word);
        }

        return ans.ToArray();
    }
}