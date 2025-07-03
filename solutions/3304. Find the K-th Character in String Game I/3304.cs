public class Solution
{
    public char KthCharacter(int k)
    {
        // Initialize a list to store encodings of characters. 
        // Start with encoding for 'a', which is 0.
        List<int> word = new List<int>();
        word.Add(0);

        // Continue adding characters to the list until we reach the k-th character.
        while (word.Count < k)
        {
            int currentSize = word.Count; // Store current size of 'word' list.

            // Iterate over the current list to determine the next sequence of characters.
            for (int i = 0; i < currentSize; ++i)
                // Add the next character in sequence, wrapping around using modulo 26
                // to ensure it stays within the range 'a' to 'z'.
                word.Add((word[i] + 1) % 26);
        }

        // Convert the k-th character from its integer encoding to a character
        // by adding 'a' to it and cast to 'char'.
        return (char)('a' + word[k - 1]);
    }
}