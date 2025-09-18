public class Solution
{
    public int CanBeTypedWords(string text, string brokenLetters)
    {
        // Create a boolean array to mark which letters are broken
        // Index represents letter position (0 for 'a', 1 for 'b', etc.)
        bool[] isBrokenLetter = new bool[26];

        // Mark all broken letters as true in the array
        foreach (char letter in brokenLetters)
            isBrokenLetter[letter - 'a'] = true;

        // Counter for words that can be typed
        int typableWordCount = 0;

        // Split the text into words and check each word
        foreach (string word in text.Split(' '))
        {
            // Assume the word can be typed initially
            bool canTypeWord = true;

            // Check each character in the current word
            foreach (char character in word)
            {
                // If any character is a broken letter, the word cannot be typed
                if (isBrokenLetter[character - 'a'])
                {
                    canTypeWord = false;
                    break;
                }
            }

            // Increment count if the word can be typed
            if (canTypeWord)
                typableWordCount++;
        }

        return typableWordCount;
    }
}