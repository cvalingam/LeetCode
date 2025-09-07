public class Solution
{
    public int[] SumZero(int n)
    {
        // Initialize result array with size n
        int[] result = new int[n];

        // Fill the array with pairs of positive and negative integers
        // We iterate from 1 to n/2 and place each number and its negative
        int index = 0;
        for (int i = 1; i <= n / 2; i++)
        {
            // Add positive number
            result[index++] = i;
            // Add corresponding negative number
            result[index++] = -i;
        }

        // If n is odd, the last element remains 0 (default value)
        // This ensures the sum is still 0

        return result;
    }
}