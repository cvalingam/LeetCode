public class Solution
{
    // Stores allowed transitions: transitions[a][b] is a bitmask representing possible top blocks
    // for base blocks 'A'+a and 'A'+b
    private int[][] transitions = new int[7][];
    // Memoization cache: key is "currentLevel.nextLevelBuiltSoFar", value is whether pyramid can be completed
    private Dictionary<string, bool> memo = new Dictionary<string, bool>();

    public Solution()
    {
        for (int i = 0; i < 7; i++)
            transitions[i] = new int[7];
    }

    public bool PyramidTransition(string bottom, IList<string> allowed)
    {
        // Build transition table from allowed triplets
        // Each triplet "XYZ" means blocks X and Y can support block Z
        foreach (string triplet in allowed)
        {
            int leftBlock = triplet[0] - 'A';
            int rightBlock = triplet[1] - 'A';
            int topBlock = triplet[2] - 'A';

            // Use bitmask to store multiple possible top blocks for each pair
            transitions[leftBlock][rightBlock] |= (1 << topBlock);
        }

        // Start DFS from bottom level with empty next level
        return CanBuildPyramid(bottom, new StringBuilder());
    }

    private bool CanBuildPyramid(string currentLevel, StringBuilder nextLevel)
    {
        // Base case: reached the top of pyramid (single block)
        if (currentLevel.Length == 1)
            return true;

        // Current level is complete, move to next level up
        if (nextLevel.Length + 1 == currentLevel.Length)
            return CanBuildPyramid(nextLevel.ToString(), new StringBuilder());

        // Create memoization key
        string memoKey = currentLevel + "." + nextLevel.ToString();
        if (memo.TryGetValue(memoKey, out bool cachedResult))
            return cachedResult;

        // Get current pair of blocks to process
        int leftBlockIndex = currentLevel[nextLevel.Length] - 'A';
        int rightBlockIndex = currentLevel[nextLevel.Length + 1] - 'A';

        // Get bitmask of possible blocks that can go on top of this pair
        int possibleBlocks = transitions[leftBlockIndex][rightBlockIndex];

        // Try each possible block
        for (int blockIndex = 0; blockIndex < 7; blockIndex++)
        {
            // Check if this block is allowed on top of current pair
            if (((possibleBlocks >> blockIndex) & 1) == 1)
            {
                // Try placing this block
                nextLevel.Append((char)('A' + blockIndex));

                // Recursively check if pyramid can be completed
                if (CanBuildPyramid(currentLevel, nextLevel))
                {
                    memo[memoKey] = true;
                    return true;
                }

                // Backtrack: remove the block we just tried
                nextLevel.Length--;
            }
        }

        // No valid pyramid can be built from this state
        memo[memoKey] = false;
        return false;
    }
}