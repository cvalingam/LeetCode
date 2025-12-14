public class Solution
{
    private int _corridorLength;
    private char[] _corridorArray;
    private int?[,] _memoization;          // memoization[position, seatsInCurrentSection]
    private const int MOD = 1_000_000_007;

    public int NumberOfWays(string corridor)
    {
        // Convert string to char array for faster access
        _corridorArray = corridor.ToCharArray();
        _corridorLength = _corridorArray.Length;

        // Initialize memoization table
        // memoization[i, j] represents the number of ways starting from position i 
        // with j seats already in the current section
        _memoization = new int?[_corridorLength, 3];

        // Start DFS from position 0 with 0 seats in the current section
        return Dfs(0, 0);
    }

    /// <summary>
    /// Recursively calculates the number of ways to divide the corridor.
    /// </summary>
    /// <param name="currentPosition">Current index in the corridor.</param>
    /// <param name="seatsInSection">Number of seats in the current section (0, 1, or 2).</param>
    /// <returns>Number of valid ways to divide from the current position.</returns>
    private int Dfs(int currentPosition, int seatsInSection)
    {
        // Base case: reached end of corridor
        if (currentPosition >= _corridorLength)
            // Valid only if the last section has exactly 2 seats
            return seatsInSection == 2 ? 1 : 0;

        // Check memoization cache
        if (_memoization[currentPosition, seatsInSection].HasValue)
            return _memoization[currentPosition, seatsInSection].Value;

        // Update seat count if current position has a seat
        int updatedSeatCount = seatsInSection;
        if (_corridorArray[currentPosition] == 'S')
            updatedSeatCount++;

        // Invalid case: more than 2 seats in a section
        if (updatedSeatCount > 2)
            return 0;

        // Option 1: Don't place a divider, continue with current section
        int totalWays = Dfs(currentPosition + 1, updatedSeatCount);

        // Option 2: Place a divider (only valid if current section has exactly 2 seats)
        if (updatedSeatCount == 2)
            // Place divider and start new section with 0 seats
            totalWays = (totalWays + Dfs(currentPosition + 1, 0)) % MOD;

        // Store result in memoization table and return
        _memoization[currentPosition, seatsInSection] = totalWays;
        return totalWays;
    }
}