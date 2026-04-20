// Approach: Greedy with two passes to independently satisfy left-neighbor and right-neighbor constraints.
// Initialise every child with 1 candy (the minimum allowed).
// Left-to-right pass: if ratings[i] > ratings[i-1], set candies[i] = candies[i-1] + 1.
// Right-to-left pass: if ratings[i] > ratings[i+1], set candies[i] = max(candies[i], candies[i+1] + 1).
// Taking the max in the right-to-left pass ensures both constraints are satisfied simultaneously.
// Summing all values gives the minimum total candy required.
// Time: O(n) Space: O(n) for the candy array.

public class Solution
{
    public int Candy(int[] ratings)
    {
        int n = ratings.Length;

        int ans = 0;
        int[] l = new int[n];
        int[] r = new int[n];
        Array.Fill(l, 1);
        Array.Fill(r, 1);

        for (int i = 1; i < n; ++i)
        {
            if (ratings[i] > ratings[i - 1])
                l[i] = l[i - 1] + 1;
        }

        for (int i = n - 2; i >= 0; --i)
        {
            if (ratings[i] > ratings[i + 1])
                r[i] = r[i + 1] + 1;
        }

        for (int i = 0; i < n; ++i)
            ans += Math.Max(l[i], r[i]);

        return ans;
    }
}