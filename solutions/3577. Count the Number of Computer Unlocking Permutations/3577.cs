// Approach: Count permutations where complexity[0] is the minimum; multiply (n-1)! if complexity[0] is min.
// Time: O(n) Space: O(1)

public class Solution
{
    public int CountPermutations(int[] complexity)
    {
        const int MOD = 1_000_000_007;
        long result = 1;

        for (int i = 1; i < complexity.Length; i++)
        {
            // If any subsequent element is not greater than the first,
            // there is no valid permutation because the first element must be the smallest.
            if (complexity[i] <= complexity[0])
                return 0;

            // Multiply by the current index (factorial‑like product) and apply modulo.
            result = (result * i) % MOD;
        }

        // Cast back to int for the final result.
        return (int)result;
    }
}