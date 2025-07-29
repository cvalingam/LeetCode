public class Solution
{
    public int[] SmallestSubarrays(int[] nums)
    {
        // Number of elements in the given array.
        int length = nums.Length;
        // Array to store the answer which is the length of smallest subarrays.
        int[] answer = new int[length];
        // Frequency array for each bit position (0 to 31 for 32-bit integers).
        int[] latestOneBitIndices = new int[32];
        // Initialize with -1, it signifies that we haven't seen a bit 1 in that position so far.
        Array.Fill(latestOneBitIndices, -1);

        // Start from the end of the input array and move towards the start.
        for (int i = length - 1; i >= 0; --i)
        {
            int subarraySize = 1; // Initialize the minimum subarray size to 1 for each number.
            // Check each bit position.
            for (int j = 0; j < 32; ++j)
            {
                // If the j-th bit of the current number is set (equal to 1).
                if (((nums[i] >> j) & 1) == 1)
                    // Update the latest index where this bit was set.
                    latestOneBitIndices[j] = i;
                else if (latestOneBitIndices[j] != -1)
                    // If the bit is not set, we use the latest index where this bit was set,
                    // to calculate the size of the subarray.
                    subarraySize = Math.Max(subarraySize, latestOneBitIndices[j] - i + 1);
            }
            // Set the computed minimum subarray size.
            answer[i] = subarraySize;
        }
        // Return the array containing the minimum subarray sizes.
        return answer;
    }
}