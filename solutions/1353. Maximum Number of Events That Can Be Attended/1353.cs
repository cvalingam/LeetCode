public class Solution
{
    public int MaxEvents(int[][] events)
    {
        int ans = 0;
        int d = 0; // the current day
        int i = 0; // events' index
        PriorityQueue<int, int> minHeap = new PriorityQueue<int, int>();

        Array.Sort(events, (a, b) => a[0].CompareTo(b[0]));

        while (minHeap.Count > 0 || i < events.Length)
        {
            // If no events are available to attend today, let time flies to the next
            // available event.
            if (minHeap.Count == 0)
                d = events[i][0];
            // All the events starting from today are newly available.
            while (i < events.Length && events[i][0] == d)
            {
                var val = events[i++][1];
                minHeap.Enqueue(val, val);
            }
            // Greedily attend the event that'll end the earliest since it has higher
            // chance can't be attended in the future.
            minHeap.Dequeue();
            ++ans;
            ++d;
            // Pop the events that can't be attended.
            while (minHeap.Count > 0 && minHeap.Peek() < d)
                minHeap.Dequeue();
        }

        return ans;
    }
}