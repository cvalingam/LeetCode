// Approach: Use two pointers because both arrays are already sorted.
// If nums1[i] is smaller, move i forward; if nums2[j] is smaller, move j forward.
// The first time both values match, that value is the minimum common element.
// Time: O(m + n) Space: O(1)

public class Solution
{
    public int GetCommon(int[] nums1, int[] nums2)
    {
        int i = 0; // nums1's index
        int j = 0; // nums2's index

        while (i < nums1.Length && j < nums2.Length)
        {
            if (nums1[i] == nums2[j])
                return nums1[i];
            if (nums1[i] < nums2[j])
                ++i;
            else
                ++j;
        }

        return -1;
    }
}