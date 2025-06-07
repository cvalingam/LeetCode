public class Solution
{
    public string ClearStars(string s)
    {
        // Create an array of Stacks to hold indices of each alphabet character
        Stack<int>[] characterIndices = new Stack<int>[26];
        // Initialize each Stack in the array
        for (int k = 0; k < 26; k++)
            characterIndices[k] = new Stack<int>();
        int length = s.Length;
        // Array to mark characters that should be removed
        bool[] remove = new bool[length];

        // Iterate over the characters in the string
        for (int i = 0; i < length; ++i)
        {
            if (s[i] == '*')
            {
                // Mark this star character for removal
                remove[i] = true;
                // Find the most recent character that is not a star and mark it for removal
                for (int j = 0; j < 26; ++j)
                {
                    if (characterIndices[j].Count > 0)
                    {
                        remove[characterIndices[j].Pop()] = true;
                        break; // Only remove one most recent character
                    }
                }
            }
            else // Push the index of this character onto the respective Stack
                characterIndices[s[i] - 'a'].Push(i);
        }

        // Construct the resulting string excluding the marked characters
        StringBuilder result = new StringBuilder();
        for (int i = 0; i < length; ++i)
        {
            if (!remove[i])
                result.Append(s[i]);
        }

        return result.ToString();
    }
}