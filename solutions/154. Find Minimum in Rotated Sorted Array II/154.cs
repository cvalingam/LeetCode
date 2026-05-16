// Approach: Binary search on rotated array with duplicates.
// Compare mid with right boundary: if nums[mid] < nums[r], min is in [l..mid];
// if nums[mid] > nums[r], min is in [mid+1..r]; if equal, shrink r by one.
// Time: O(log n) average, O(n) worst case (many duplicates) Space: O(1)

public class Solution
{
    public int FindMin(int[] nums)
    {
        int n = nums.Length;
        int l = 0, r = n - 1, mid = 0;

        while (l <= r)
        {
            mid = (l + r) / 2;
            if (nums[r] == nums[mid])
            {
                r--;
                continue;
            }
            else if (nums[r] > nums[mid])
                r = mid;
            else
                l = mid + 1;
        }

        return nums[l];
    }
}