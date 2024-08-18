public class Solution
{
    public int RemoveDuplicates(int[] nums)
    {
        int i = 0;
        int j = i + 1;

        while (j < nums.Length)
        {
            if (nums[j] > nums[i])
            {
                i++;
                nums[i] = nums[j];
            }
            j++;
        }
        return i + 1;
    }
}