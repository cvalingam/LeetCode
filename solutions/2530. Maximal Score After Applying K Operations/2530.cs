// Approach: Max-heap; k times take max element, add to score, push ceil(max/3) back.
// Time: O(n + k log n) Space: O(n)

public class Solution
{
    public long MaxKelements(int[] nums, int k)
    {
        long ans = 0;
        PriorityQueue<int, int> maxHeap = new PriorityQueue<int, int>();

        foreach (var num in nums)
            maxHeap.Enqueue(num, -num);

        for (int i = 0; i < k; ++i)
        {
            int num = maxHeap.Dequeue();
            ans += num;
            maxHeap.Enqueue((num + 2) / 3, -(num + 2) / 3);
        }

        return ans;
    }
}