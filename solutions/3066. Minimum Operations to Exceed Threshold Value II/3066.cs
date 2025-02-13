public class Solution
{
    public int MinOperations(int[] nums, int k)
    {
        int n = nums.Length;
        PriorityQueue<long, long> pq = new PriorityQueue<long, long>(new CustomComparer());
        for (int i = 0; i < nums.Length; i++)
            pq.Enqueue(nums[i], nums[i]);

        int cnt = 0;
        while (pq.Count >= 2 && pq.Peek() < k)
        {
            long val1 = pq.Dequeue();
            long val2 = pq.Dequeue();
            long newVal = Math.Min(val1, val2) * 2 + Math.Max(val1, val2);
            pq.Enqueue(newVal, newVal);
            cnt++;
        }

        return cnt;
    }
}

public class CustomComparer : IComparer<long>
{
    public int Compare(long x, long y)
    {
        return x.CompareTo(y);
    }
}