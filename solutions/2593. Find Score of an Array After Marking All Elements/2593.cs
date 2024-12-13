public class Solution
{
    public long FindScore(int[] nums)
    {
        long ans = 0;
        SortedSet<int[]> numAndIndices = new SortedSet<int[]>(Comparer<int[]>.Create((a, b) =>
            a[0] == b[0] ? a[1].CompareTo(b[1]) : a[0].CompareTo(b[0])));
        bool[] seen = new bool[nums.Length];

        for (int i = 0; i < nums.Length; ++i)
            numAndIndices.Add(new int[] { nums[i], i });

        foreach (var pair in numAndIndices)
        {
            int num = pair[0];
            int i = pair[1];
            if (seen[i])
                continue;
            if (i > 0)
                seen[i - 1] = true;
            if (i + 1 < nums.Length)
                seen[i + 1] = true;
            seen[i] = true;
            ans += num;
        }

        return ans;
    }
}