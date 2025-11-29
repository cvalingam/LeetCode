public class Solution
{
    public int MinOperations(int[] nums, int k)
    {
        // Calculate the sum of all elements in the array using LINQ
        int totalSum = nums.Sum();

        // Return the remainder when the sum is divided by k
        // This represents the minimum value needed to make the sum divisible by k
        return totalSum % k;
    }
}