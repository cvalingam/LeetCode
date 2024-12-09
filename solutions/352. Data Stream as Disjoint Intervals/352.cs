public class SummaryRanges
{
    private SortedDictionary<int, int[]> intervals = new SortedDictionary<int, int[]>();
    public SummaryRanges()
    {

    }

    public void AddNum(int val)
    {
        if (intervals.ContainsKey(val))
            return;

        // the maximum key in `intervals` < `key`
        intervals.TryGetValue(val - 1, out int[] lo);
        // the minimum key in `intervals` > `key`
        intervals.TryGetValue(val + 1, out int[] hi);

        // {lo, intervals[lo][1]} + val + {hi, intervals[hi][1]} = {lo, intervals[hi][1]}
        if (lo != null && hi != null && lo[1] + 1 == val && val + 1 == hi[0])
        {
            lo[1] = hi[1];
            intervals.Remove(hi[0]);
        }
        else if (lo != null && lo[1] + 1 >= val)
            lo[1] = Math.Max(lo[1], val);
        else if (hi != null && val + 1 == hi[0])
        {
            intervals[val] = new int[] { val, hi[1] };
            intervals.Remove(hi[0]);
        }
        else
            intervals[val] = new int[] { val, val };
    }

    public int[][] GetIntervals()
    {
        return intervals.Values.ToArray();
    }
}

/**
 * Your SummaryRanges object will be instantiated and called as such:
 * SummaryRanges obj = new SummaryRanges();
 * obj.AddNum(value);
 * int[][] param_2 = obj.GetIntervals();
 */