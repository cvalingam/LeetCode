// Approach: Sort, fix the largest side, then apply two pointers: when the
// two smaller sides sum exceeds the largest, all left-to-right pairs count.
// Time: O(n²) Space: O(1)

public class Solution
{
    public int TriangleNumber(int[] nums)
    {
        Array.Sort(nums);

        int arrayLength = nums.Length;
        int triangleCount = 0;

        for (int largestIndex = arrayLength - 1; largestIndex >= 2; largestIndex--)
        {
            int left = 0;
            int right = largestIndex - 1;

            while (left < right)
            {
                if (nums[left] + nums[right] > nums[largestIndex])
                {
                    triangleCount += right - left;
                    right--;
                }
                else
                {
                    left++;
                }
            }
        }

        return triangleCount;
    }
}