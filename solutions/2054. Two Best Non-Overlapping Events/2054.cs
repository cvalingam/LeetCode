public class Solution
{
    public int MaxTwoEvents(int[][] events)
    {
        int ans = 0;
        int maxValue = 0;
        Event[] evts = new Event[events.Length * 2];

        for (int i = 0; i < events.Length; ++i)
        {
            int start = events[i][0];
            int end = events[i][1];
            int value = events[i][2];
            evts[i * 2] = new Event(start, value, 1);
            evts[i * 2 + 1] = new Event(end + 1, value, 0);
        }

        Array.Sort(evts, (a, b) =>
            a.time == b.time ? a.isStart.CompareTo(b.isStart) : a.time.CompareTo(b.time));

        foreach (Event evt in evts)
        {
            if (evt.isStart == 1)
                ans = Math.Max(ans, evt.value + maxValue);
            else
                maxValue = Math.Max(maxValue, evt.value);
        }

        return ans;
    }
}

public class Event
{
    public int time;
    public int value;
    public int isStart;

    public Event(int time, int value, int isStart)
    {
        this.time = time;
        this.value = value;
        this.isStart = isStart;
    }
}
