public class Solution
{
    public int[][] MergeArrays(int[][] nums1, int[][] nums2)
    {
        const int kMax = 1000;
        List<int[]> ans = new List<int[]>();
        int[] count = new int[kMax + 1];

        AddCount(nums1, count);
        AddCount(nums2, count);

        for (int i = 1; i <= kMax; ++i)
        {
            if (count[i] > 0)
                ans.Add(new int[] { i, count[i] });
        }

        return ans.ToArray();
    }

    private void AddCount(int[][] nums, int[] count)
    {
        foreach (int[] idAndVal in nums)
        {
            int id = idAndVal[0];
            int val = idAndVal[1];
            count[id] += val;
        }
    }
}