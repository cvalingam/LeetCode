public class Solution
{
    public int[] GetFinalState(int[] nums, int k, int multiplier)
    {
        int[] ans = new int[nums.Length];
        // (nums[i], i)
        var minHeap = new PriorityQueue<int[], int[]>(Comparer<int[]>.Create((a, b) => a[0] == b[0] ? a[1].CompareTo(b[1]) : a[0].CompareTo(b[0])));

        for (int i = 0; i < nums.Length; ++i)
        {
            int[] val = new int[] { nums[i], i };
            minHeap.Enqueue(val, val);
        }

        while (k-- > 0)
        {
            int[] curr = minHeap.Dequeue();
            int[] newVal = new int[] { curr[0] * multiplier, curr[1] };
            minHeap.Enqueue(newVal, newVal);
        }

        while (minHeap.Count > 0)
        {
            int[] value = minHeap.Dequeue();
            ans[value[1]] = value[0];
        }

        return ans;
    }
}