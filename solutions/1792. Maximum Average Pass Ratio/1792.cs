public class Solution
{
    public double MaxAverageRatio(int[][] classes, int extraStudents)
    {
        // (extra pass ratio, pass, total)
        PriorityQueue<T, double> maxHeap = new PriorityQueue<T, double>();

        foreach (var c in classes)
        {
            int pass = c[0];
            int total = c[1];
            maxHeap.Enqueue(new T(GetExtraPassRatio(pass, total), pass, total),
                             -GetExtraPassRatio(pass, total));
        }

        for (int i = 0; i < extraStudents; ++i)
        {
            int pass = maxHeap.Peek().Pass;
            int total = maxHeap.Dequeue().Total;
            maxHeap.Enqueue(new T(GetExtraPassRatio(pass + 1, total + 1), pass + 1, total + 1),
                               -GetExtraPassRatio(pass + 1, total + 1));
        }

        double ratioSum = 0;

        while (maxHeap.Count > 0)
            ratioSum += (double)maxHeap.Peek().Pass / maxHeap.Dequeue().Total;

        return ratioSum / classes.Length;
    }

    // Returns the extra pass ratio if a brilliant student joins.
    private double GetExtraPassRatio(int pass, int total)
    {
        return (pass + 1) / (double)(total + 1) - pass / (double)total;
    }

    private record T(double ExtraPassRatio, int Pass, int Total);
}