public class Solution
{
    public IList<int> FallingSquares(IList<IList<int>> positions)
    {
        List<int> ans = new List<int>();
        SortedDictionary<(int, int), int> xsToHeight = new SortedDictionary<(int, int), int>();  // {(xStart, xEnd), height}
        int maxHeight = int.MinValue;

        foreach (var p in positions)
        {
            int left = p[0];
            int sideLength = p[1];
            int right = left + sideLength;
            // Find the first range that intersects with [left, right).
            var it = xsToHeight.Keys.ToList().FindLast(k => k.Item1 < right);
            if (it != default && it.Item2 <= left)
                it = default;

            int maxHeightInRange = 0;
            List<(int, int, int)> ranges = new List<(int, int, int)>();
            while (it != default && it.Item1 < right)
            {
                int l = it.Item1;
                int r = it.Item2;
                int h = xsToHeight[it];
                if (l < left)
                    ranges.Add((l, left, h));
                if (right < r)
                    ranges.Add((right, r, h));
                maxHeightInRange = Math.Max(maxHeightInRange, h);
                xsToHeight.Remove(it);
                it = xsToHeight.Keys.ToList().FindLast(k => k.Item1 < right);
            }
            int newHeight = maxHeightInRange + sideLength;
            xsToHeight[(left, right)] = newHeight;
            foreach (var (l, r, h) in ranges)
                xsToHeight[(l, r)] = h;
            maxHeight = Math.Max(maxHeight, newHeight);
            ans.Add(maxHeight);
        }

        return ans;
    }
}