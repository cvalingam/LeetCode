public class KthLargest
{
    private int k;
    private PriorityQueue<int, int> pq = new PriorityQueue<int, int>();
    public KthLargest(int k, int[] nums)
    {
        this.k = k;
        foreach (int num in nums)
            Heapify(num);
    }

    private void Heapify(int num)
    {
        pq.Enqueue(num, num);
        if (pq.Count > k)
            pq.Dequeue();
    }

    public int Add(int val)
    {
        Heapify(val);
        return pq.Peek();
    }
}
