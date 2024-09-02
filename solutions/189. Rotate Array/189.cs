public class Solution
{
    public void Rotate(int[] nums, int k)
    {
        int n = nums.Length;
        k = k % n;

        Reverse(nums, (n - k), n - 1);
        Reverse(nums, 0, n - k - 1);
        Reverse(nums, 0, n - 1);
    }

    private void Reverse(int[] nums, int start, int end)
    {
        while (start < end)
        {
            int temp = nums[start];
            nums[start] = nums[end];
            nums[end] = temp;
            start++;
            end--;
        }
    }
}