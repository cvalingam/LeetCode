public class Solution
{
    public int FindLHS(int[] nums)
    {
        // Create a Dictionary to keep track of the frequency of each number
        Dictionary<int, int> frequencyMap = new Dictionary<int, int>();

        // Count the occurrences of each number in the array.
        foreach (int num in nums)
        {
            if (frequencyMap.ContainsKey(num))
                frequencyMap[num]++;
            else
                frequencyMap[num] = 1;
        }

        // Initialize variable to keep track of the longest harmonious subsequence
        int longestHarmoniousSubsequence = 0;

        // Iterate through the numbers in the array
        foreach (int num in nums)
        {
            // Check if the number that is one more than the current number exists in the map
            if (frequencyMap.ContainsKey(num + 1))
            {
                // If it exists, calculate the sum of the frequencies of the current number
                // and the number that is one more than the current number
                int currentLength = frequencyMap[num] + frequencyMap[num + 1];

                // Update the longest harmonious subsequence if the current sum is greater
                longestHarmoniousSubsequence = Math.Max(longestHarmoniousSubsequence, currentLength);
            }
        }

        // Return the length of the longest harmonious subsequence found
        return longestHarmoniousSubsequence;
    }
}