// Approach: After n minutes the colored diamond has n² + (n-1)² cells.
// Time: O(1) Space: O(1)

public class Solution
{
    public long ColoredCells(int n)
    {
        return 1L * n * n + 1L * (n - 1) * (n - 1);
    }
}