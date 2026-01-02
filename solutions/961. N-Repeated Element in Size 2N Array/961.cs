public class Solution
{
    public int RepeatedNTimes(int[] nums)
    {
        // Create a HashSet to store unique elements
        // Initial capacity is set to n/2 + 1 for optimization
        HashSet<int> seenNumbers = new HashSet<int>(nums.Length / 2 + 1);

        // Iterate through the array
        for (int i = 0; ; ++i)
        {
            // Try to add current element to the set
            // Add() returns false if element already exists
            if (!seenNumbers.Add(nums[i]))
                // Found the duplicate element that appears n times
                return nums[i];
        }
    }
}