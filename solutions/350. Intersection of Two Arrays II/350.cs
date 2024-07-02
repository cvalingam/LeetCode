public class Solution
{
    public int[] Intersect(int[] nums1, int[] nums2)
    {
        List<int> result = new List<int>();
        Dictionary<int, int> map = new Dictionary<int, int>();
        for (int i = 0; i < nums1.Length; i++)
        {
            if (!map.ContainsKey(nums1[i]))
                map.Add(nums1[i], 1);
            else
                map[nums1[i]] += 1;
        }
        for (int i = 0; i < nums2.Length; i++)
        {
            if (map.ContainsKey(nums2[i]) && map[nums2[i]] > 0)
            {
                result.Add(nums2[i]);
                map[nums2[i]] -= 1;
            }
        }

        return result.ToArray();
    }
}