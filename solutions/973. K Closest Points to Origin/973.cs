// Approach: Max-heap of size k; maintain the k smallest squared distances by evicting the farthest when size exceeds k.
// Time: O(n log k) Space: O(k)

public class Solution
{
    public int[][] KClosest(int[][] points, int k)
    {
        int[][] ans = new int[k][];
        var maxHeap = new PriorityQueue<int[], int[]>(Comparer<int[]>.Create((a, b) => SquareDist(b).CompareTo(SquareDist(a))));

        foreach (int[] point in points)
        {
            maxHeap.Enqueue(point, point);
            if (maxHeap.Count > k)
                maxHeap.Dequeue();
        }

        for (int i = k - 1; i >= 0; i--)
            ans[i] = maxHeap.Dequeue();

        return ans;
    }

    private int SquareDist(int[] p)
    {
        return p[0] * p[0] + p[1] * p[1];
    }
}