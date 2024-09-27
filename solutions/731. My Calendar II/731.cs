public class MyCalendarTwo
{
    private SortedDictionary<int, int> timeline = new SortedDictionary<int, int>();

    public bool Book(int start, int end)
    {
        timeline[start] = timeline.GetValueOrDefault(start, 0) + 1;
        timeline[end] = timeline.GetValueOrDefault(end, 0) - 1;

        int activeEvents = 0;

        foreach (var count in timeline.Values)
        {
            activeEvents += count;
            if (activeEvents > 2)
            {
                timeline[start] = timeline.GetValueOrDefault(start, 0) - 1;
                if (timeline[start] == 0)
                    timeline.Remove(start);

                timeline[end] = timeline.GetValueOrDefault(end, 0) + 1;
                if (timeline[end] == 0)
                    timeline.Remove(end);

                return false;
            }
        }

        return true;
    }
}