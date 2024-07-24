public class Solution
{
    public int[] SortJumbled(int[] mapping, int[] nums)
    {
        int n = nums.Length;
        int[] ans = new int[n];
        List<int[]> pair = new List<int[]>();

        for (int i = 0; i < n; i++)
            pair.Add(new int[] { GetMapped(nums[i], mapping), i, nums[i] });

        pair.Sort((a, b) => a[0] == b[0] ? a[1] - b[1] : a[0] - b[0]);

        return pair.Select(x => x[2]).ToArray();
    }

    private int GetMapped(int val, int[] mapping)
    {
        var sb = new StringBuilder();

        foreach (char c in val.ToString())
            sb.Append(mapping[c - '0']);

        return int.Parse(sb.ToString());
    }
}