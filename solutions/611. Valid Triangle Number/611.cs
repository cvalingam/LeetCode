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