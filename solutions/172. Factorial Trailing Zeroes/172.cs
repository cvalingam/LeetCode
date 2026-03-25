// Approach: Each trailing zero requires a factor of 5. Recursively count
// multiples of 5, 25, 125… via n/5 + TrailingZeroes(n/5).
// Time: O(log n) Space: O(log n)

public class Solution
{
    public int TrailingZeroes(int n)
    {
        return n == 0 ? 0 : n / 5 + TrailingZeroes(n / 5);
    }
}