// Approach: XOR the number bit by bit with 1 up to and including its
// highest set bit to flip all relevant bits.
// Time: O(log n) Space: O(1)

public class Solution
{
    public int FindComplement(int num)
    {
        for (long i = 1; i <= num; i <<= 1)
            num ^= (int)i;

        return num;
    }
}