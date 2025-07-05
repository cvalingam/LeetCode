public class Solution
{
    public int FindLucky(int[] arr)
    {
        // Create an array to store the frequency of each number. Assuming the maximum
        // number value is 500, thus the length is 510 to include zero-indexing padding.
        int[] frequency = new int[510];

        // Iterate through the input array and increment the frequency count for each number.
        foreach (int num in arr)
            // Increment the frequency for the number found in the array.
            ++frequency[num]; // Correct the loop to iterate over the 'arr' elements.

        // Initialize the lucky number to -1, as a default value if there's no lucky number.
        int luckyNumber = -1;

        // Iterate through the frequency array to find a lucky number starting from 1
        // since the problem statement implies lucky numbers are positive.
        for (int i = 1; i < frequency.Length; ++i)
        {
            // If the frequency of a number is the same as its value, update the luckyNumber.
            if (frequency[i] == i)
                luckyNumber = i; // A bigger number will always override previous one, if found.
        }

        // Return the lucky number, which will be -1 if none was found.
        return luckyNumber;
    }
}