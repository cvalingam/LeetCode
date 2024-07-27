public class Solution
{
    public double MincostToHireWorkers(int[] quality, int[] wage, int k)
    {
        double ans = double.MaxValue;
        int qualitySum = 0;

        Tuple<double, int>[] workers = new Tuple<double, int>[quality.Length];

        var pq = new PriorityQueue<int, int>(new CustomComparer());

        for (int i = 0; i < quality.Length; i++)
            workers[i] = Tuple.Create((double)wage[i] / quality[i], quality[i]);

        Array.Sort(workers, (a, b) => a.Item1.CompareTo(b.Item1));

        foreach (Tuple<double, int> worker in workers)
        {
            double wageperQuality = worker.Item1;
            int q = worker.Item2;
            pq.Enqueue(q, q);
            qualitySum += q;

            if (pq.Count > k)
                qualitySum -= pq.Dequeue();
            if (pq.Count == k)
                ans = Math.Min(ans, qualitySum * wageperQuality);
        }

        return ans;
    }
}

public class CustomComparer : IComparer<int>
{
    public int Compare(int x, int y)
    {
        // Custom comparison logic
        // For example, descending order
        return y.CompareTo(x);
    }
}