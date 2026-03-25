// Approach: At least two even numbers (bit 0 = 0) must exist for their OR to have trailing zero.
// Time: O(n) Space: O(1)

public class Solution
{
    public bool HasTrailingZeros(int[] nums)
    {
        int cntEven = 0;

        foreach (int num in nums)
        {
            if (num % 2 == 0)
                cntEven++;
        }

        return cntEven >= 2;
    }
}