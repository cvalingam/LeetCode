// Approach: Trailing zeros come from factors of 10 = 2 x 5, and factors of 2 are always more plentiful.
// So count how many times 5 divides n! by summing n/5 + n/25 + n/125 + ...
// Each term counts multiples of 5, 25, 125, ... contributing extra 5s beyond what was already counted.
// The recursion n/5 + TrailingZeroes(n/5) achieves this cleanly in O(log n) steps.
// Time: O(log n) Space: O(log n) for recursion stack; easily made iterative for O(1) space.

public class Solution
{
    public int TrailingZeroes(int n)
    {
        return n == 0 ? 0 : n / 5 + TrailingZeroes(n / 5);
    }
}