public class Solution
{
    public int SmallestNumber(int n)
    {
        // Initialize power of 2 starting from 2^0 = 1
        int powerOfTwo = 1;

        // Keep doubling the power of 2 until (powerOfTwo - 1) is at least n
        // This finds the smallest k such that 2^k - 1 >= n
        while (powerOfTwo - 1 < n)
            // Left shift by 1 is equivalent to multiplying by 2
            // powerOfTwo becomes 2, 4, 8, 16, 32, ...
            powerOfTwo <<= 1;

        // Return 2^k - 1, which is a number with all k bits set to 1
        // Examples: 1 (2^1-1), 3 (2^2-1), 7 (2^3-1), 15 (2^4-1), ...
        return powerOfTwo - 1;
    }
}