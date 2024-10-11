public class Solution
{
    public int SmallestChair(int[][] times, int targetFriend)
    {
        int nextUnsatChair = 0;
        PriorityQueue<int, int> emptyChairs = new PriorityQueue<int, int>();
        PriorityQueue<(int, int), int> occupied = new PriorityQueue<(int, int), int>(Comparer<int>.Create((a, b) => a.CompareTo(b)));

        for (int i = 0; i < times.Length; ++i)
        {
            Array.Resize(ref times[i], times[i].Length + 1);
            times[i][times[i].Length - 1] = i;
        }

        Array.Sort(times, (a, b) => a[0].CompareTo(b[0]));

        foreach (var time in times)
        {
            int arrival = time[0];
            int leaving = time[1];
            int i = time[2];
            while (occupied.Count > 0 && occupied.Peek().Item1 <= arrival)
            {
                int occupiedChair = occupied.Dequeue().Item2;
                emptyChairs.Enqueue(occupiedChair, occupiedChair);
            }
            if (i == targetFriend)
                return emptyChairs.Count == 0 ? nextUnsatChair : emptyChairs.Peek();
            if (emptyChairs.Count == 0)
            {
                occupied.Enqueue((leaving, nextUnsatChair), leaving);
                nextUnsatChair++;
            }
            else
            {
                int emptyChair = emptyChairs.Dequeue();
                occupied.Enqueue((leaving, emptyChair), leaving);
            }
        }

        throw new ArgumentException();
    }
}