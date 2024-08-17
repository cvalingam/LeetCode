public class Solution
{
    public int SingleNumber(int[] nums)
    {
        int ones = 0, twos = 0;

        for (int i = 0; i < nums.Length; i++)
        {
            ones ^= nums[i] & ~twos;
            twos ^= nums[i] & ~ones;
        }

        return ones;
    }
}