// Approach: SortedDictionary stores [start, end) pairs; find the predecessor and successor of the new interval and reject if they overlap.
// Time: O(n log n) Space: O(n)

public class MyCalendar
{
    private SortedDictionary<int, int> timeline = new SortedDictionary<int, int>();

    public bool Book(int start, int end)
    {
        if (timeline.Count == 0)
        {
            timeline.Add(start, end);
            return true;
        }

        var low = timeline.Keys.LastOrDefault(k => k < end);

        if (low == 0 && !timeline.ContainsKey(low) || timeline[low] <= start)
        {
            timeline.Add(start, end);
            return true;
        }

        return false;
    }
}