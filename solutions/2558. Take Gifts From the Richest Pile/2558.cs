public class Solution
{
    public long PickGifts(int[] gifts, int k)
    {
        long ans = 0;
        PriorityQueue<int, int> maxHeap = new PriorityQueue<int, int>();

        foreach (int gift in gifts)
            maxHeap.Enqueue(gift, -gift); // Use negative priority for max-heap behavior

        for (int i = 0; i < k; ++i)
        {
            int maxGift = maxHeap.Dequeue();
            int squaredMax = (int)Math.Sqrt(maxGift);
            maxHeap.Enqueue(squaredMax, -squaredMax);
        }

        while (maxHeap.TryDequeue(out int result, out int _))
            ans += result;

        return ans;
    }
}