// Approach: Greedy — maintain the maximum sum [1, maxNum] representable by
// current numbers; if next number is too large, patch by adding maxNum+1.
// Time: O(log n) Space: O(1)

public class Solution {
    public int MinPatches(int[] nums, int n) {
        long minPatch = 0, maxNum = 0;
        int i = 0, sz = nums.Length;

        while(maxNum < n)
        {
            if(i < sz && maxNum + 1 >= nums[i])
            {
                maxNum += nums[i];
                i++;
            }
            else
            {
                minPatch++;
                maxNum += (maxNum + 1);
            }
        }

        return (int)minPatch;
    }
}