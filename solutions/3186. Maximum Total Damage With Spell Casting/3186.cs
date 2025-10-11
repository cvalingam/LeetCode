public class Solution
{
    // Memoization array to store computed results for each index
    private long?[] memo;

    // Input array of power values
    private int[] power;

    // Dictionary to store frequency count of each power value
    private Dictionary<int, int> frequencyMap;

    // Array to store the next valid index after skipping conflicting elements
    private int[] nextValidIndex;

    // Length of the power array
    private int n;


    public long MaximumTotalDamage(int[] power)
    {
        // Sort the power array to group same values and enable binary search
        Array.Sort(power);

        // Initialize instance variables
        this.power = power;
        this.n = power.Length;
        this.memo = new long?[n];
        this.frequencyMap = new Dictionary<int, int>(n);
        this.nextValidIndex = new int[n];

        // Preprocess the array
        for (int i = 0; i < n; i++)
        {
            // Count frequency of each power value
            if (frequencyMap.ContainsKey(power[i]))
                frequencyMap[power[i]]++;
            else
                frequencyMap[power[i]] = 1;

            // Find the first index where power[index] >= power[i] + 3
            // This represents the next valid position after skipping conflicting elements
            int searchTarget = power[i] + 3;
            int nextIndex = Array.BinarySearch(power, searchTarget);

            // If exact match not found, BinarySearch returns a negative number:
            // bitwise complement of the index of the next element that is larger than searchTarget
            if (nextIndex < 0)
                nextIndex = ~nextIndex;

            nextValidIndex[i] = nextIndex;
        }

        // Start dynamic programming from index 0
        return Dfs(0);
    }

    /// <summary>
    /// Dynamic programming function to find maximum damage starting from index i
    /// </summary>
    /// <param name="i">current index in the power array</param>
    /// <returns>maximum total damage achievable from index i to end</returns>
    private long Dfs(int i)
    {
        // Base case: reached end of array
        if (i >= n)
            return 0;

        // Return memoized result if already computed
        if (memo[i].HasValue)
            return memo[i].Value;

        // Option 1: Skip current power value group
        // Move to the next different power value
        long skipCurrent = Dfs(i + frequencyMap[power[i]]);

        // Option 2: Take current power value group
        // Calculate damage from all occurrences of current power value
        // Then continue from the next valid index (skipping conflicting values)
        long takeCurrent = (long)power[i] * frequencyMap[power[i]] + Dfs(nextValidIndex[i]);

        // Store and return the maximum of both options
        memo[i] = Math.Max(skipCurrent, takeCurrent);
        return memo[i].Value;
    }
}