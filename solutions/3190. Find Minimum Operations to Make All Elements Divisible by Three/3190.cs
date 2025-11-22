public class Solution
{
    public int MinimumOperations(int[] nums)
    {
        int totalOperations = 0;

        // Iterate through each number in the array
        foreach (int number in nums)
        {
            // Calculate the remainder when divided by 3
            int remainder = number % 3;

            // If the number is not divisible by 3, we need operations
            if (remainder != 0)
                // We can either subtract the remainder to reach a multiple of 3
                // or add (3 - remainder) to reach the next multiple of 3
                // Choose the minimum of these two options
                totalOperations += Math.Min(remainder, 3 - remainder);
        }

        return totalOperations;
    }
}