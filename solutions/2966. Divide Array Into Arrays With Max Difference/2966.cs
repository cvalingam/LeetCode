public class Solution
{
    /**
     * Divides an array into smaller sub-arrays of size 3, ensuring the difference between
     * the maximum and minimum values within each sub-array does not exceed a given value k.
     *
     * @param nums the input array of integers to be divided.
     * @param k    the maximum allowable difference between the largest 
     *             and smallest numbers in each sub-array.
     * @return a 2D array where each sub-array has 3 elements and the above condition is met,
     * or an empty 2D array if the condition cannot be met.
     */
    public int[][] DivideArray(int[] nums, int k)
    {
        // Sort the array to organize numbers and facilitate the process of division
        Array.Sort(nums);
        // Get the length of the input array
        int n = nums.Length;
        // Initialize the result array with the correct size based on the input array
        int[][] result = new int[n / 3][];
        // Iterate through the array, incrementing by 3 each time to create sub-arrays of size 3
        for (int i = 0; i < n; i += 3)
        {
            // Copy a range of the sorted array to form a sub-array of size 3
            int[] subArray = new int[3];
            Array.Copy(nums, i, subArray, 0, 3);

            // Check if the largest difference in the current sub-array exceeds the limit k
            if (subArray[2] - subArray[0] > k)
                // If it does, return an empty array as the condition can't be met
                return new int[][] { };

            // Assign the sub-array to the correct position in the result array
            result[i / 3] = subArray;
        }
        // Return the duly formed result array
        return result;
    }
}