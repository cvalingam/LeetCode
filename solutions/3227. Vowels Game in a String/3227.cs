public class Solution
{
    public bool DoesAliceWin(string s)
    {
        // Define vowels as a constant string
        string vowels = "aeiou";

        // Iterate through each character in the input string
        for (int i = 0; i < s.Length; i++)
        {
            char currentChar = s[i];

            // Check if the current character is a vowel
            if (vowels.IndexOf(currentChar) != -1)
                // If a vowel is found, Alice wins
                return true;
        }

        // No vowels found, Alice does not win
        return false;
    }
}