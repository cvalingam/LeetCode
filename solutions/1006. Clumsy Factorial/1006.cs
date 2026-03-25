// Approach: Closed-form formula based on n mod 4; compute offset pattern directly without simulation.
// Time: O(1) Space: O(1)

public class Solution
{
    public int Clumsy(int n)
    {
        if (n == 1)
            return 1;
        if (n == 2)
            return 2;
        if (n == 3)
            return 6;
        if (n == 4)
            return 7;
        if (n % 4 == 1)
            return n + 2;
        if (n % 4 == 2)
            return n + 2;
        if (n % 4 == 3)
            return n - 1;
        return n + 1;
    }
}