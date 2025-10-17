public class Solution
{
    // Memoization dictionary: key is Tuple<int, int, int> representing (position, bitmask, canChange)
    private Dictionary<(int, int, int), int> memo = new Dictionary<(int, int, int), int>();
    private string inputString;
    private int maxDistinctChars;

    public int MaxPartitionsAfterOperations(string s, int k)
    {
        this.inputString = s;
        this.maxDistinctChars = k;
        // Start DFS from position 0, empty bitmask, with 1 change allowed
        return Dfs(0, 0, 1);
    }

    /// <summary>
    /// Dynamic programming with memoization to find maximum partitions
    /// </summary>
    /// <param name="index">current position in string</param>
    /// <param name="currentMask">bitmask representing distinct characters in current partition</param>
    /// <param name="canChange">flag indicating if we can still change a character (1 = yes, 0 = no)</param>
    /// <returns>maximum number of partitions from current state</returns>
    private int Dfs(int index, int currentMask, int canChange)
    {
        // Base case: reached end of string
        if (index >= inputString.Length)
            return 1;

        var memoKey = (index, currentMask, canChange);
        if (memo.TryGetValue(memoKey, out int cachedResult))
            return cachedResult;

        int charBit = 1 << (inputString[index] - 'a');

        int newMask = currentMask | charBit;
        int maxPartitions;

        if (CountBits(newMask) > maxDistinctChars)
            // Adding current char exceeds k distinct chars, start new partition
            maxPartitions = Dfs(index + 1, charBit, canChange) + 1;
        else
            // Continue with current partition
            maxPartitions = Dfs(index + 1, newMask, canChange);

        // Try changing current character (if we haven't used our change yet)
        if (canChange > 0)
        {
            for (int charIndex = 0; charIndex < 26; ++charIndex)
            {
                newMask = currentMask | (1 << charIndex);

                if (CountBits(newMask) > maxDistinctChars)
                    maxPartitions = Math.Max(maxPartitions, Dfs(index + 1, 1 << charIndex, 0) + 1);
                else
                    maxPartitions = Math.Max(maxPartitions, Dfs(index + 1, newMask, 0));
            }
        }

        memo[memoKey] = maxPartitions;
        return maxPartitions;
    }

    // Helper method to count set bits in an integer
    private int CountBits(int n)
    {
        int count = 0;
        while (n != 0)
        {
            count += n & 1;
            n >>= 1;
        }
        
        return count;
    }
}