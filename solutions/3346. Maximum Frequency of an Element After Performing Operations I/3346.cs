public class Solution
{
    public int MaxFrequency(int[] nums, int k, int numOperations)
    {
        // Map to store the frequency of each number in the original array
        Dictionary<int, int> frequencyMap = new Dictionary<int, int>();

        // SortedDictionary to track intervals where we can perform operations
        // Uses difference array technique to efficiently track overlapping ranges
        SortedDictionary<int, int> differenceArray = new SortedDictionary<int, int>();

        // Process each number in the input array
        foreach (int num in nums)
        {
            // Count frequency of current number
            frequencyMap.TryGetValue(num, out int frequency);
            frequencyMap[num] = frequency + 1;

            // Mark the position of the original number (with 0 increment initially)
            if (!differenceArray.ContainsKey(num))
                differenceArray[num] = 0;

            // Mark the start of the range [num - k, num + k] where we can change values to num
            // Increment at start of range
            differenceArray.TryGetValue(num - k, out int startRangeValue);
            differenceArray[num - k] = startRangeValue + 1;

            // Mark the end of the range (exclusive) where we stop being able to change values to num
            // Decrement after end of range
            differenceArray.TryGetValue(num + k + 1, out int endRangeValue);
            differenceArray[num + k + 1] = endRangeValue - 1;
        }

        int maxResult = 0;
        int currentOverlappingRanges = 0; // Number of overlapping ranges at current position

        // Traverse through all positions in sorted order
        foreach (KeyValuePair<int, int> entry in differenceArray)
        {
            int position = entry.Key;
            int deltaValue = entry.Value;

            // Update the count of overlapping ranges at this position
            currentOverlappingRanges += deltaValue;

            // Calculate maximum frequency achievable at this position:
            // - Original frequency of this value (if it exists in nums)
            // - Plus up to numOperations changes from other values within range
            // - Limited by the number of values that can be changed to this position
            int achievableFrequency = Math.Min(
                currentOverlappingRanges,
                frequencyMap.GetValueOrDefault(position, 0) + numOperations
            );

            // Update the maximum frequency found so far
            maxResult = Math.Max(maxResult, achievableFrequency);
        }

        return maxResult;
    }
}