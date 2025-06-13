public class Solution
{
    public int MinimizeMax(int[] nums, int p)
    {
        Array.Sort(nums);

        int n = nums.Length;

        int low = 0;
        int high = nums[n - 1] - nums[0];

        while (low < high)
        {
            int mid = (low + high) / 2;
            if (cntNumPairs(mid, nums) >= p)
                high = mid;
            else
                low = mid + 1;
        }

        return low;
    }

    private int cntNumPairs(int diff, int[] nums)
    {
        int pairs = 0;

        for (int i = 1; i < nums.Length; i++)
        {
            if (nums[i] - nums[i - 1] <= diff)
            {
                pairs++;
                i++;
            }
        }

        return pairs;
    }
}