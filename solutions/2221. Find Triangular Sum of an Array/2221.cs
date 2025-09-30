public class Solution
{
    public int TriangularSum(int[] nums)
    {
        for (int currentLength = nums.Length - 1; currentLength > 0; currentLength--)
        {
            for (int index = 0; index < currentLength; index++)
                nums[index] = (nums[index] + nums[index + 1]) % 10;
        }
        return nums[0];
    }
}