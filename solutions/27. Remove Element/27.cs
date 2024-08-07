public class Solution
{
    public int RemoveElement(int[] nums, int val)
    {
        int n = nums.Length;
        int k = 0;
        for (int i = 0; i < n; i++)
        {
            if (nums[i] != val)
            {
                int temp = nums[k];
                nums[k++] = nums[i];
                nums[i] = temp;
            }
        }

        return k;
    }
}