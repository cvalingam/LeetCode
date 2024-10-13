public class Solution
{
    private record T(int i, int j, int num); // num := nums[i][j]

    public int[] SmallestRange(IList<IList<int>> nums)
    {
        var minHeap = new SortedSet<T>(Comparer<T>.Create((a, b) => a.num != b.num ? a.num.CompareTo(b.num) : a.i.CompareTo(b.i)));
        int mn = int.MaxValue;
        int mx = int.MinValue;

        for (int i = 0; i < nums.Count; ++i)
        {
            int num = nums[i][0];
            minHeap.Add(new T(i, 0, num));
            mn = Math.Min(mn, num);
            mx = Math.Max(mx, num);
        }

        int minRange = mn;
        int maxRange = mx;

        while (minHeap.Count == nums.Count)
        {
            int i = minHeap.Min.i;
            int j = minHeap.Min.j;
            minHeap.Remove(minHeap.Min);
            if (j + 1 < nums[i].Count)
            {
                minHeap.Add(new T(i, j + 1, nums[i][j + 1]));
                mx = Math.Max(mx, nums[i][j + 1]);
                mn = minHeap.Min.num;
            }
            if (mx - mn < maxRange - minRange)
            {
                minRange = mn;
                maxRange = mx;
            }
        }

        return new int[] { minRange, maxRange };
    }
}