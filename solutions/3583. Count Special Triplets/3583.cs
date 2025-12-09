public class Solution
{
    public int SpecialTriplets(int[] nums)
    {
        // Dictionary to count occurrences of elements to the left of current position
        Dictionary<int, int> leftCounts = new Dictionary<int, int>();

        // Dictionary to count occurrences of elements to the right of current position
        // Initially contains all elements
        Dictionary<int, int> rightCounts = new Dictionary<int, int>();

        // Initialize rightCounts with all elements from the array
        foreach (int num in nums)
        {
            if (rightCounts.ContainsKey(num))
                rightCounts[num]++;
            else
                rightCounts[num] = 1;
        }

        // Variable to store the total count of special triplets
        long totalCount = 0;

        // Modulo value for preventing integer overflow
        const int MOD = (int)1e9 + 7;

        // Iterate through each element as the potential middle element of a triplet
        foreach (int currentNum in nums)
        {
            // Remove current element from right counts (moving it from right to current position)
            if (rightCounts.ContainsKey(currentNum))
            {
                rightCounts[currentNum]--;
                if (rightCounts[currentNum] == 0)
                    rightCounts.Remove(currentNum);
            }

            // Calculate the target value that should appear on both sides
            // For this to be a special triplet, we need elements equal to 2 * currentNum
            int targetValue = currentNum * 2;

            // Count triplets where left and right elements both equal targetValue
            // and current element is in the middle
            long leftCount = leftCounts.ContainsKey(targetValue) ? leftCounts[targetValue] : 0;
            long rightCount = rightCounts.ContainsKey(targetValue) ? rightCounts[targetValue] : 0;
            long tripletCount = (leftCount * rightCount) % MOD;

            // Add the count of triplets with current element as middle
            totalCount = (totalCount + tripletCount) % MOD;

            // Add current element to left counts (moving it from current position to left)
            if (leftCounts.ContainsKey(currentNum))
                leftCounts[currentNum]++;
            else
                leftCounts[currentNum] = 1;
        }

        // Return the final count as an integer
        return (int)totalCount;
    }
}