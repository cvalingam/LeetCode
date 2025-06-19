public class Solution
{
    public int PartitionArray(int[] nums, int k)
    {
        // Sort the input array in ascending order
        Array.Sort(nums);

        // Initialize the count of partitions needed, starting with 1
        int partitionCount = 1;

        // Store the first number as the starting point of the first partition
        int partitionStart = nums[0];

        // Iterate through all numbers in the array
        foreach (int currentNumber in nums)
        {
            // If the current number minus the partition start is greater than k,
            // a new partition is needed
            if (currentNumber - partitionStart > k)
            {
                // Update the starting point to the current number
                partitionStart = currentNumber;
                // Increment the partition count
                ++partitionCount;
            }
        }

        // Return the total number of partitions required
        return partitionCount;
    }
}