public class Solution
{
    public int MinGroups(int[][] intervals)
    {
        // Stores `right`s.
        PriorityQueue<int, int> minHeap = new PriorityQueue<int, int>();

        Array.Sort(intervals, (a, b) => a[0].CompareTo(b[0]));

        foreach (var interval in intervals)
        {
            // There's no overlap, so we can reuse the same group.
            if (minHeap.Count > 0 && interval[0] > minHeap.Peek())
                minHeap.Dequeue();
            minHeap.Enqueue(interval[1], interval[1]);
        }

        return minHeap.Count;
    }
}