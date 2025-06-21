public class Solution
{
    // List to store the frequencies of characters in the input word
    private List<int> characterFrequencies = new List<int>();

    public int MinimumDeletions(string word, int k)
    {
        // Array to store frequency of each character in the English alphabet
        int[] frequencyArray = new int[26];
        int wordLength = word.Length;

        // Calculate frequency of each character in the input word
        for (int i = 0; i < wordLength; ++i)
            ++frequencyArray[word[i] - 'a'];

        // Add non-zero frequencies to the characterFrequencies list
        foreach (int frequency in frequencyArray)
        {
            if (frequency > 0)
                characterFrequencies.Add(frequency);
        }

        // Initialize the answer with the length of the word
        int minimumDeletions = wordLength;

        // Find the minimum deletions possible by checking for every potential value `v` from 0 to word length
        for (int i = 0; i <= wordLength; ++i)
            // Update minimumDeletions with the smaller value between the current and the new calculation from helper function `f`
            minimumDeletions = Math.Min(minimumDeletions, CalculateDeletions(i, k));

        return minimumDeletions;
    }

    // Helper method to calculate deletions given a threshold `v` and limit `k`
    private int CalculateDeletions(int v, int k)
    {
        int deletions = 0;

        // Iterate over each frequency in the list
        foreach (int frequency in characterFrequencies)
        {
            // If the frequency is less than `v`, add the full frequency to deletions
            if (frequency < v)
                deletions += frequency;
            // If the frequency exceeds `v + k`, calculate the deletions needed to reduce it
            else if (frequency > v + k)
                deletions += frequency - v - k;
        }

        return deletions;
    }
}