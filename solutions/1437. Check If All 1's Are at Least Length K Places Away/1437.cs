public class Solution
{
    public bool KLengthApart(int[] nums, int k)
    {
        // Initialize the position of the previous 1
        // Set to -(k+1) to handle the case when the first element is 1
        // This ensures the distance check passes for the first 1
        int previousOneIndex = -(k + 1);

        // Iterate through the array to find all 1s
        for (int currentIndex = 0; currentIndex < nums.Length; currentIndex++)
        {
            // Check if current element is 1
            if (nums[currentIndex] == 1)
            {
                // Calculate distance between current 1 and previous 1
                // Distance = currentIndex - previousOneIndex - 1 (excluding both endpoints)
                if (currentIndex - previousOneIndex - 1 < k)
                    // Distance is less than k, so return false
                    return false;

                // Update the position of the previous 1
                previousOneIndex = currentIndex;
            }
        }

        // All 1s are at least k distance apart
        return true;
    }
}