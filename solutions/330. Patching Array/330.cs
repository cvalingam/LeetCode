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