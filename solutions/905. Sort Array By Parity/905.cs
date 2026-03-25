// Approach: In-place two-pointer partition; move even numbers to the front by swapping with a write pointer.
// Time: O(n) Space: O(1)

public class Solution
{
    public int[] SortArrayByParity(int[] nums)
    {
        int n = nums.Length;
        int k = 0;
        for (int i = 0; i < n; i++)
        {
            if (nums[i] % 2 == 0)
            {
                int temp = nums[k];
                nums[k++] = nums[i];
                nums[i] = temp;
            }
        }

        return nums;
    }
}