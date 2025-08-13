public class Solution
{
    public int NumberOfWays(int n, int x)
    {
        // Define the modulo constant to prevent overflow issues
        const int MOD = (int)1e9 + 7;

        // Initialize a 2D array to store intermediate results
        // f[i][j] will store the number of ways to reach the sum `j`
        // using powers of numbers from 1 to `i`
        int[,] dp = new int[n + 1, n + 1];

        // There is exactly one way to reach the sum 0, which is by using no numbers
        dp[0, 0] = 1;
        

        // Loop over every number up to `n` to compute the powers and the ways to reach each sum `j`
        for (int i = 1; i <= n; ++i)
        {
            // Calculate the power of the current number `i`
            long power = (long)Math.Pow(i, x);

            // Loop over all sums from 0 to `n`
            for (int j = 0; j <= n; ++j)
            {
                // Initialize dp[i][j] with the number of ways to reach the sum `j` without using the current number
                dp[i, j] = dp[i - 1, j];

                // If adding the current power does not exceed the sum `j` (it's a valid choice to reach the sum `j`)
                if (power <= j)
                    // Update the number of ways by adding the ways to reach the reduced sum `j - power`
                    // and take modulo to handle large numbers
                    dp[i, j] = (dp[i, j] + dp[i - 1, j - (int)power]) % MOD;
            }
        }

        // Return the number of ways to reach the sum `n` using all numbers from 1 to `n` raised to the power `x`
        return dp[n, n];
    }
}