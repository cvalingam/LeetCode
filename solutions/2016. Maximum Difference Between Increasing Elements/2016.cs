public class Solution
{
    public int MaximumDifference(int[] nums)
    {
        // Initialize the minimum value to a very large value
        int minVal = int.MaxValue;
        // Initialize the answer to -1, assuming there is no positive difference found
        int maxDiff = -1;

        // Loop through each number in the input array
        foreach (int num in nums)
        {
            // If the current number is greater than the minimum value found so far
            if (num > minVal)
            {
                // Update the maximum difference with the greater value between the current maximum difference
                // and the difference between the current number and the minimum value found so far
                maxDiff = Math.Max(maxDiff, num - minVal);
            }
            else
            {
                // If the current number is not greater than the minimum value found so far,
                // then update the minimum value to the current number
                minVal = num;
            }
        }

        // Return the maximum difference found, or -1 if no positive difference exists
        return maxDiff;
    }
}