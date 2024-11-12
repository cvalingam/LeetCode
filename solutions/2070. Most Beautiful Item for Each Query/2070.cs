public class Solution
{
    public int[] MaximumBeauty(int[][] items, int[] queries)
    {
        int[] ans = new int[queries.Length];
        int[] maxBeautySoFar = new int[items.Length + 1];

        Array.Sort(items, (a, b) => a[0].CompareTo(b[0]));

        for (int i = 0; i < items.Length; ++i)
            maxBeautySoFar[i + 1] = Math.Max(maxBeautySoFar[i], items[i][1]);

        for (int i = 0; i < queries.Length; ++i)
        {
            int index = FirstGreater(items, queries[i]);
            ans[i] = maxBeautySoFar[index];
        }

        return ans;
    }

    private int FirstGreater(int[][] items, int q)
    {
        int l = 0;
        int r = items.Length;
        while (l < r)
        {
            int m = (l + r) / 2;
            if (items[m][0] > q)
                r = m;
            else
                l = m + 1;
        }
        return l;
    }
}