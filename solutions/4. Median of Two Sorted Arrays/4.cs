public class Solution
{
    public double FindMedianSortedArrays(int[] nums1, int[] nums2)
    {
        int n1 = nums1.Length;
        int n2 = nums2.Length;
        if (n1 > n2)
            return FindMedianSortedArrays(nums2, nums1);
        int low = 0, high = n1;
        int n = n1 + n2;
        int left = (n1 + n2 + 1) / 2;
        while (low <= high)
        {
            int mid1 = (low + high) / 2;
            int mid2 = left - mid1;
            int l1 = Int32.MinValue, l2 = Int32.MinValue;
            int r1 = Int32.MaxValue, r2 = Int32.MaxValue;
            if (mid1 < n1)
                r1 = nums1[mid1];
            if (mid2 < n2)
                r2 = nums2[mid2];

            if (mid1 - 1 >= 0)
                l1 = nums1[mid1 - 1];
            if (mid2 - 1 >= 0)
                l2 = nums2[mid2 - 1];

            if (l1 <= r2 && l2 <= r1)
            {
                if (n % 2 == 1)
                    return (double)Math.Max(l1, l2);
                else
                    return (double)(Math.Max(l1, l2) + Math.Min(r1, r2)) / (double)2.0;
            }
            else if (l1 > r2)
                high = mid1 - 1;
            else
                low = mid1 + 1;
        }

        return 0;
    }
}