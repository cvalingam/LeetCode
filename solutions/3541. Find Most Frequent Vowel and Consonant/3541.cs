public class Solution
{
    public int MaxFreqSum(string s)
    {
        // Array to store frequency count of each letter (a-z)
        int[] frequencyCount = new int[26];

        // Count the frequency of each character in the string
        foreach (char character in s)
            frequencyCount[character - 'a']++;

        // Variables to track maximum frequency among vowels and consonants
        int maxVowelFrequency = 0;
        int maxConsonantFrequency = 0;

        // Iterate through the frequency array to find max frequencies
        for (int i = 0; i < frequencyCount.Length; i++)
        {
            char currentChar = (char)(i + 'a');

            // Check if current character is a vowel
            if (currentChar == 'a' || currentChar == 'e' || currentChar == 'i' ||
                currentChar == 'o' || currentChar == 'u')
                // Update maximum vowel frequency if current is greater
                maxVowelFrequency = Math.Max(maxVowelFrequency, frequencyCount[i]);
            else
                // Update maximum consonant frequency if current is greater
                maxConsonantFrequency = Math.Max(maxConsonantFrequency, frequencyCount[i]);
        }

        // Return the sum of maximum vowel frequency and maximum consonant frequency
        return maxVowelFrequency + maxConsonantFrequency;
    }
}