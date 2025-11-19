public class Solution
{
    public int FindFinalValue(int[] nums, int original)
    {
        // Create a HashSet to store all unique values from the array for O(1) lookup
        HashSet<int> numSet = new HashSet<int>(nums);

        // Keep doubling the original value while it exists in the set
        while (numSet.Contains(original))
            // Double the original value using left shift operation (equivalent to multiplying by 2)
            original <<= 1;

        // Return the final value that is not present in the set
        return original;
    }
}