public class Solution
{
    public int MinOperations(int[] nums)
    {
        int n = nums.Length;
        int ans = n;

        Array.Sort(nums);
        nums = nums.Distinct().ToArray();

        for (int i = 0; i < nums.Length; ++i)
        {
            int start = nums[i];
            int end = start + n - 1;
            int index = FirstGreater(nums, end);
            int uniqueLength = index - i;
            ans = Math.Min(ans, n - uniqueLength);
        }

        return ans;
    }

    private int FirstGreater(int[] A, int target)
    {
        int i = Array.BinarySearch(A, target + 1);
        return i < 0 ? ~i : i;
    }
}