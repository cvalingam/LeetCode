public class Solution
{
    public int PossibleStringCount(string word)
    {
        int count = 1; // Initialize the count to 1 because the first character is always counted
        // Loop through the string starting from the second character
        for (int i = 1; i < word.Length; ++i)
        {
            // Check if the current character is the same as the previous one
            if (word[i] == word[i - 1])
                ++count; // Increment the count if characters are the same
        }
        return count; // Return the total count of adjacent duplicate characters
    }
}