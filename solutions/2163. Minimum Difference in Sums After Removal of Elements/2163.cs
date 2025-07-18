public class Solution
{
    public long MinimumDifference(int[] nums)
    {
        int totalLength = nums.Length; // Total number of elements in nums.
        int subsetSize = totalLength / 3; // Size of the subsets to be created.
        long sum = 0; // Used to store the running sum.

        // Array to store the prefix sum for the first 2/3 of the array.
        long[] prefixSums = new long[totalLength + 1];
        // Initialize a max heap to find the largest elements in reverse order.
        PriorityQueue<int, int> maxHeap = new PriorityQueue<int, int>(Comparer<int>.Create((a, b) => b.CompareTo(a)));
        for (int i = 1; i <= subsetSize * 2; ++i)
        {
            int element = nums[i - 1];
            sum += element;
            maxHeap.Enqueue(element, element);
            // If the max heap size exceeds the subset size, remove the largest element.
            if (maxHeap.Count > subsetSize)
                sum -= maxHeap.Dequeue();
            // Store the running sum in prefixSums for the first 2/3 of the array.
            prefixSums[i] = sum;
        }

        sum = 0;
        // Array to store the suffix sum for the last 2/3 of the array.
        long[] suffixSums = new long[totalLength + 1];
        // Initialize a min heap to find the smallest elements in order.
        PriorityQueue<int, int> minHeap = new PriorityQueue<int, int>();
        for (int i = totalLength; i > subsetSize; --i)
        {
            int element = nums[i - 1];
            sum += element;
            minHeap.Enqueue(element, element);
            // If the min heap size exceeds the subset size, remove the smallest element.
            if (minHeap.Count > subsetSize)
                sum -= minHeap.Dequeue();
            // Store the running sum in suffixSums for the last 2/3 of the array.
            suffixSums[i] = sum;
        }

        // Initialize answer with a very large value.
        long answer = long.MaxValue;
        // Go through the middle 1/3 of the array to find the minimum sum difference.
        for (int i = subsetSize; i <= subsetSize * 2; ++i)
            answer = Math.Min(answer, prefixSums[i] - suffixSums[i + 1]);
        // Return the minimum sum difference.
        return answer;
    }
}