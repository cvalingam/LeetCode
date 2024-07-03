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