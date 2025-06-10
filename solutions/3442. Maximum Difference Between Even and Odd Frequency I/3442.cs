public class Solution
{
    public int MaxDifference(string s)
    {
        int[] frequency = new int[26];  // Array to hold the frequency of each character (a-z) in the string

        // Populate the frequency array with the count of each character in the string
        foreach (char c in s)
            frequency[c - 'a']++;

        int maxOddFrequency = 0;  // Variable to track the maximum frequency of characters appearing an odd number of times
        int minEvenFrequency = int.MaxValue;  // Variable to track the minimum frequency of characters appearing an even number of times

        // Iterate through the frequency array
        foreach (int count in frequency)
        {
            if (count % 2 == 1)  // Check if the frequency is odd
                maxOddFrequency = Math.Max(maxOddFrequency, count);  // Update maxOddFrequency if a larger odd frequency is found
            else if (count > 0)  // Check if the frequency is even and greater than zero
                minEvenFrequency = Math.Min(minEvenFrequency, count);  // Update minEvenFrequency if a smaller even frequency is found
        }

        // Return the difference between max odd frequency and min even frequency
        return maxOddFrequency - minEvenFrequency;
    }
}