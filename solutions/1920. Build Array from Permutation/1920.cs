// Approach: Encode new and old values into same cell using modular arithmetic; decode in second pass.
// Time: O(n) Space: O(1)

public class Solution
{
    public int[] BuildArray(int[] nums)
    {
        int n = nums.Length;

        for (int i = 0; i < n; i++)
        {
            int val = nums[i];              // original value
            int nextVal = nums[val] % n;    // get nums[nums[i]], safely
            nums[i] = val + n * nextVal;    // encode both values
        }

        for (int i = 0; i < n; i++)
            nums[i] /= n;  // retrieve the final answer

        return nums;
    }
}