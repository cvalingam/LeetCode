public class Solution
{
    public int MinNumberOperations(int[] target)
    {
        // Initialize the result with the first element's value
        // This represents the initial operations needed to build the first position
        int totalOperations = target[0];

        // Iterate through the array starting from the second element
        for (int i = 1; i < target.Length; ++i)
        {
            // If current element is greater than the previous element,
            // we need additional operations equal to the difference
            if (target[i] > target[i - 1])
                totalOperations += target[i] - target[i - 1];
            // Note: If target[i] <= target[i-1], no additional operations needed
            // as we can reuse operations from building the previous element
        }

        // Return the total minimum number of operations required
        return totalOperations;
    }
}