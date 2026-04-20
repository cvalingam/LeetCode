// Approach: Binary search exploiting the virtual boundary rule: nums[-1] = nums[n] = -infinity.
// At index mid, compare nums[mid] with nums[mid+1].
// If nums[mid] < nums[mid+1], the right half must contain a peak (it is rising at mid).
// If nums[mid] > nums[mid+1], the left half (including mid) must contain a peak.
// At convergence lo == hi, and that index is a valid peak element.
// Unlike classical binary search, the array does not need to be globally sorted.
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