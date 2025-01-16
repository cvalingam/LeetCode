public class Solution
{
    public int XorAllNums(int[] nums1, int[] nums2)
    {
        // If the size of nums1 is m and the size of nums2 is n, then each number in
        // nums1 is repeated n times and each number in nums2 is repeated m times.
        int xors1 = nums1.Aggregate(0, (a, b) => a ^ b);
        int xors2 = nums2.Aggregate(0, (a, b) => a ^ b);
        return (nums1.Length % 2 * xors2) ^ (nums2.Length % 2 * xors1);
    }
}