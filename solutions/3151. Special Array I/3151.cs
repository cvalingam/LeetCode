// Approach: Check every adjacent pair has different parity.
// Time: O(n) Space: O(1)

public class Solution
{
    public bool IsArraySpecial(int[] nums)
    {
        for (int i = 1; i < nums.Length; ++i)
        {
            if (nums[i] % 2 == nums[i - 1] % 2)
                return false;
        }
        return true;
    }
}