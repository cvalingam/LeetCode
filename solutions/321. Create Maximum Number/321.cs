public class Solution
{
    public int[] MaxNumber(int[] nums1, int[] nums2, int k)
    {
        int[] ans = new int[k];

        for (int k1 = 0; k1 <= k; ++k1)
        {
            int k2 = k - k1;
            if (k1 > nums1.Length || k2 > nums2.Length)
                continue;
            int[] candidate = Merge(MaxArray(nums1, k1), MaxArray(nums2, k2));
            if (Greater(candidate, 0, ans, 0))
                ans = candidate;
        }
        return ans;
    }

    private int[] MaxArray(int[] nums, int k)
    {
        List<int> res = new List<int>();
        int toPop = nums.Length - k;
        foreach (var num in nums)
        {
            while (res.Count > 0 && res[res.Count - 1] < num && toPop > 0)
            {
                res.RemoveAt(res.Count - 1);
                --toPop;
            }
            res.Add(num);
        }
        return res.Take(k).ToArray();
    }

    // Merges nums1 and nums2.
    private int[] Merge(int[] nums1, int[] nums2)
    {
        int[] res = new int[nums1.Length + nums2.Length];
        for (int i = 0, j = 0, k = 0; k < res.Length; ++k)
            res[k] = Greater(nums1, i, nums2, j) ? nums1[i++] : nums2[j++];
        return res;
    }

    // Returns true if nums1[i..n) > nums2[j..n).
    private bool Greater(int[] nums1, int i, int[] nums2, int j)
    {
        while (i < nums1.Length && j < nums2.Length && nums1[i] == nums2[j])
        {
            ++i;
            ++j;
        }
        return j == nums2.Length || (i < nums1.Length && nums1[i] > nums2[j]);
    }
}