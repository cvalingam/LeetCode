public class Solution
{
    /// <summary>
    /// Removes consecutive anagrams from the array, keeping only the first occurrence
    /// </summary>
    /// <param name="words">Array of strings to process</param>
    /// <returns>List of strings with consecutive anagrams removed</returns>
    public List<string> RemoveAnagrams(string[] words)
    {
        var result = new List<string>();

        // Always add the first word
        result.Add(words[0]);

        // Check each word against its predecessor
        for (int i = 1; i < words.Length; i++)
        {
            // If current word is NOT an anagram of the previous word, add it
            if (IsNotAnagram(words[i - 1], words[i]))
                result.Add(words[i]);
        }

        return result;
    }

    /// <summary>
    /// Checks if two strings are NOT anagrams of each other
    /// </summary>
    /// <param name="firstWord">First string to compare</param>
    /// <param name="secondWord">Second string to compare</param>
    /// <returns>true if strings are NOT anagrams, false if they are anagrams</returns>
    private bool IsNotAnagram(string firstWord, string secondWord)
    {
        // Different lengths mean they cannot be anagrams
        if (firstWord.Length != secondWord.Length)
            return true;

        // Count frequency of each character in the first word
        int[] characterCount = new int[26];
        for (int i = 0; i < firstWord.Length; i++)
            characterCount[firstWord[i] - 'a']++;

        // Decrement count for each character in the second word
        for (int i = 0; i < secondWord.Length; i++)
        {
            // If count goes negative, words have different character frequencies
            if (--characterCount[secondWord[i] - 'a'] < 0)
                return true;
        }

        // All character counts matched - words are anagrams
        return false;
    }
}