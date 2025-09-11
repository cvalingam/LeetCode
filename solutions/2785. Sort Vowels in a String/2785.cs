public class Solution
{
    public string SortVowels(string s)
    {
        // List to store all vowels found in the string
        List<char> vowelsList = new List<char>();

        // Convert string to character array for easier manipulation
        char[] charArray = s.ToCharArray();

        // First pass: Extract all vowels from the string
        foreach (char currentChar in charArray)
        {
            // Convert to lowercase for vowel checking
            char lowerCaseChar = char.ToLower(currentChar);

            // Check if the character is a vowel
            if (lowerCaseChar == 'a' || lowerCaseChar == 'e' ||
                lowerCaseChar == 'i' || lowerCaseChar == 'o' ||
                lowerCaseChar == 'u')
                // Add the original character (preserving case) to vowels list
                vowelsList.Add(currentChar);
        }

        // Sort the vowels in ascending order (based on ASCII values)
        vowelsList.Sort();

        // Second pass: Replace vowels in original positions with sorted vowels
        int vowelIndex = 0; // Index to track position in sorted vowels list

        for (int i = 0; i < charArray.Length; i++)
        {
            // Convert to lowercase for vowel checking
            char lowerCaseChar = char.ToLower(charArray[i]);

            // If current position contains a vowel, replace with sorted vowel
            if (lowerCaseChar == 'a' || lowerCaseChar == 'e' ||
                lowerCaseChar == 'i' || lowerCaseChar == 'o' ||
                lowerCaseChar == 'u')
            {
                // Replace with the next sorted vowel
                charArray[i] = vowelsList[vowelIndex];
                vowelIndex++;
            }
        }

        // Convert character array back to string and return
        return new string(charArray);
    }
}