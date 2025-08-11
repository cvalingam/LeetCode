public class Solution
{
    // Define the mod constant for the problem (10^9 + 7)
    private const int MOD = (int)1e9 + 7;

    // Method to solve the product queries on a range of powers of two that compose n
    public int[] ProductQueries(int n, int[][] queries)
    {
        // Count the number of set bits in n to determine the size of the powers array
        int[] powers = new int[CountSetBits(n)];

        // Extract the powers of two which compose n
        for (int i = 0; n > 0; ++i)
        {
            int lowestOneBit = n & -n; // Get the lowest set bit (the rightmost one)
            powers[i] = lowestOneBit; // Store the power of two in the array
            n -= lowestOneBit; // Remove the extracted power of two from n
        }

        // Create an array to store the answers to the queries
        int[] ans = new int[queries.Length];

        // Process each query
        for (int i = 0; i < ans.Length; ++i)
        {
            long product = 1; // Store the product as a long to prevent overflow
            int left = queries[i][0], right = queries[i][1]; // Get the left and right indices

            // Calculate the product of the powers from left to right index inclusive
            for (int j = left; j <= right; ++j)
                product = (product * powers[j]) % MOD; // Multiply the current power and take mod

            // Store the result as an int after casting from long
            ans[i] = (int)product;
        }

        // Return the array containing the results for all the queries
        return ans;
    }

    // Helper method to count the number of set bits in an integer
    private int CountSetBits(int n)
    {
        int count = 0;
        while (n > 0)
        {
            count += n & 1;
            n >>= 1;
        }
        
        return count;
    }
}