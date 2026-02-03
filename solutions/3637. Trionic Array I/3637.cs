public class Solution
{
    public bool IsTrionic(int[] nums)
    {
        int arrayLength = nums.Length;
        int currentIndex = 0;

        // Phase 1: Find the first strictly increasing segment
        // Move forward while elements are strictly increasing
        while (currentIndex < arrayLength - 2 && nums[currentIndex] < nums[currentIndex + 1])
            currentIndex++;

        // If no increasing segment found at the beginning, pattern is invalid
        if (currentIndex == 0)
            return false;

        // Phase 2: Find the strictly decreasing segment
        // Save the peak position where decreasing starts
        int peakIndex = currentIndex;

        // Move forward while elements are strictly decreasing
        while (currentIndex < arrayLength - 1 && nums[currentIndex] > nums[currentIndex + 1])
            currentIndex++;

        // Check if decreasing segment exists and doesn't reach the end
        // (we need room for the final increasing segment)
        if (currentIndex == peakIndex || currentIndex == arrayLength - 1)
            return false;

        // Phase 3: Find the final strictly increasing segment
        // Move forward while elements are strictly increasing
        while (currentIndex < arrayLength - 1 && nums[currentIndex] < nums[currentIndex + 1])
            currentIndex++;

        // Pattern is valid only if we've reached the end of the array
        return currentIndex == arrayLength - 1;
    }
}