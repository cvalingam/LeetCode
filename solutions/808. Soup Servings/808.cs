public class Solution
{
    // Cache for storing results of subproblems
    private double[,] memo = new double[200, 200];

    // Entry method which adjusts servings (if necessary) and starts the depth-first search
    public double SoupServings(int n)
    {
        // If n is larger than 4800, we assume probability is practically 1
        return n > 4800 ? 1.0 : Dfs((n + 24) / 25, (n + 24) / 25);
    }

    // Depth-first search to compute probability
    private double Dfs(int a, int b)
    {
        // If both servings are not positive, it's a tie, return 0.5
        if (a <= 0 && b <= 0)
            return 0.5;

        // If only A is depleted, A finished serving first, return 1.0
        if (a <= 0)
            return 1.0;

        // If only B is depleted, B finished serving first, return 0
        if (b <= 0)
            return 0;

        // If result is already computed, return it from the memo cache
        if (memo[a, b] > 0)
            return memo[a, b];

        // Recursively compute the probability considering all 4 possible operations
        double probability = 0.25 * (
            Dfs(a - 4, b) +
            Dfs(a - 3, b - 1) +
            Dfs(a - 2, b - 2) +
            Dfs(a - 1, b - 3)
        );
        // Store the computed probability in the memo cache
        memo[a, b] = probability;
        // Return the computed probability
        return probability;
    }
}