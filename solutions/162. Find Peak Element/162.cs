// Approach: Binary search — move toward the neighbor with the higher value;
// a peak is guaranteed on that side by the monotonicity property.
// Time: O(log n) Space: O(1)

public class Solution
{
    public int FindPeakElement(int[] nums)
    {
        int n = nums.Length;
        if (n == 1)
            return 0;

        if (nums[0] > nums[1])
            return 0;

        if (nums[n - 1] > nums[n - 2])
            return n - 1;
        int l = 1, r = n - 2, mid;
        while (l <= r)
        {
            mid = (l + r) / 2;
            if (nums[mid] > nums[mid - 1] && nums[mid] > nums[mid + 1])
                return mid;
            else if (nums[mid] > nums[mid - 1] && nums[mid] < nums[mid + 1])
                l = mid + 1;
            else
                r = mid - 1;
        }

        return -1;
    }
}