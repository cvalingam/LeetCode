// Approach: For each prime p find largest x < p where x | (x+1) = p by checking bit patterns.
// Time: O(n * log max) Space: O(1)

public class Solution
{
    public int[] MinBitwiseArray(IList<int> nums)
    {
        int[] ans = new int[nums.Count];

        for (int i = 0; i < nums.Count; ++i)
            ans[i] = nums[i] == 2 ? -1 : nums[i] - GetLeadingOneOfLastGroupOfOnes(nums[i]);

        return ans;
    }

    // Returns the leading one of the last group of 1s in the binary
    // representation of num. For example, if num = 0b10111, the leading one of
    // the last group of 1s is 0b100.
    private int GetLeadingOneOfLastGroupOfOnes(int num)
    {
        int leadingOne = 1;
        while ((num & leadingOne) > 0)
            leadingOne <<= 1;
            
        return leadingOne >> 1;
    }
}