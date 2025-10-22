public class Solution
{
    public int MaxFrequency(int[] nums, int k, int numOperations)
    {
        // Map to store the frequency of each number in the array
        Dictionary<int, int> frequencyMap = new Dictionary<int, int>();

        // SortedDictionary to track range boundaries and their contributions
        // Used for sweep line algorithm to count overlapping ranges
        SortedDictionary<int, int> rangeBoundaries = new SortedDictionary<int, int>();

        // Process each number in the input array
        foreach (int num in nums)
        {
            // Count frequency of current number
            frequencyMap.TryGetValue(num, out int frequency);
            frequencyMap[num] = frequency + 1;

            // Initialize the number itself as a potential target
            if (!rangeBoundaries.ContainsKey(num))
                rangeBoundaries[num] = 0;

            // Mark the start of range [num - k, num + k] where elements can be changed to num
            // Increment at start of range (num - k)
            rangeBoundaries.TryGetValue(num - k, out int startCount);
            rangeBoundaries[num - k] = startCount + 1;

            // Mark the end of range (exclusive) at num + k + 1
            // Decrement after end of range
            rangeBoundaries.TryGetValue(num + k + 1, out int endCount);
            rangeBoundaries[num + k + 1] = endCount - 1;
        }

        int maxResult = 0;
        int currentOverlap = 0;  // Running sum of overlapping ranges

        // Sweep through all boundary points in sorted order
        foreach (KeyValuePair<int, int> entry in rangeBoundaries)
        {
            int position = entry.Key;
            int delta = entry.Value;

            // Update the current overlap count
            currentOverlap += delta;

            // Calculate maximum frequency achievable at this position
            // It's the minimum of:
            // 1. Total elements that can be changed to this position (currentOverlap)
            // 2. Original frequency + allowed operations
            frequencyMap.TryGetValue(position, out int originalFrequency);
            int achievableFrequency = Math.Min(currentOverlap, originalFrequency + numOperations);

            // Update the maximum frequency found so far
            maxResult = Math.Max(maxResult, achievableFrequency);
        }

        return maxResult;
    }
}