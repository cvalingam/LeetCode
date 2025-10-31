public class Solution
{
    public int[] GetSneakyNumbers(int[] nums)
    {
        // Array to store the result (two duplicate numbers)
        int[] result = new int[2];

        // Frequency counter array (assuming numbers range from 0 to 99)
        int[] frequencyCounter = new int[100];

        // Index to track position in result array
        int resultIndex = 0;

        // Iterate through each number in the input array
        foreach (int currentNumber in nums)
        {
            // Increment the frequency count for current number
            frequencyCounter[currentNumber]++;

            // If this number appears for the second time, add it to result
            if (frequencyCounter[currentNumber] == 2)
            {
                result[resultIndex] = currentNumber;
                resultIndex++;
            }
        }

        return result;
    }
}