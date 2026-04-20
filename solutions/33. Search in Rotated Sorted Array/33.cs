// Approach: Modified binary search that handles the single rotation break in sorted order.
// At each step, at least one of [lo, mid] or [mid, hi] is guaranteed to be sorted.
// If nums[lo] <= nums[mid], the left half is sorted: check if target is in [nums[lo], nums[mid]].
// If yes, search left; otherwise search right. Apply symmetric logic when the right half is sorted.
// This elegantly handles all rotation offsets, including 0 (no rotation at all).
// Avoid the pitfall of using strict equality for boundary checks to handle duplicate edge cases.
// Time: O(log n) Space: O(1)

public class Solution
{
    public int Search(int[] nums, int target)
    {
        int n = nums.Length;
        int low = 0, high = n - 1, mid = 0;
        while (low <= high)
        {
            mid = (low + high) / 2;
            if (nums[mid] == target)
                return mid;
            if (nums[low] <= nums[mid])
            {
                if (nums[low] <= target && target <= nums[mid])
                    high = mid - 1;
                else
                    low = mid + 1;
            }
            else
            {
                if (nums[mid] <= target && target <= nums[high])
                    low = mid + 1;
                else
                    high = mid - 1;
            }
        }

        return -1;
    }
}