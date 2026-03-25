// Approach: Bit trick — a power of two has exactly one set bit, so
// n > 0 and (n & n-1) == 0.
// Time: O(1) Space: O(1)

public class Solution
{
    public bool IsPowerOfTwo(int n)
    {
        // Check if n is greater than 0 and if n AND (n-1) is 0
        return n > 0 && (n & (n - 1)) == 0;
    }
}