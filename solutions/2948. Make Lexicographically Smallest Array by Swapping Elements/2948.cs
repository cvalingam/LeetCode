public class Solution
{
    public int[] LexicographicallySmallestArray(int[] nums, int limit)
    {
        int[] ans = new int[nums.Length];
        List<List<KeyValuePair<int, int>>> numAndIndexesGroups = new List<List<KeyValuePair<int, int>>>();

        foreach (var numAndIndex in GetNumAndIndexes(nums))
        {
            if (numAndIndexesGroups.Count == 0 ||
                numAndIndex.Key - numAndIndexesGroups.Last().Last().Key > limit)
                // Start a new group.
                numAndIndexesGroups.Add(new List<KeyValuePair<int, int>> { numAndIndex });
            else
                // Append to the existing group.
                numAndIndexesGroups.Last().Add(numAndIndex);
        }

        foreach (var numAndIndexesGroup in numAndIndexesGroups)
        {
            List<int> sortedNums = new List<int>();
            List<int> sortedIndices = new List<int>();
            foreach (var pair in numAndIndexesGroup)
            {
                sortedNums.Add(pair.Key);
                sortedIndices.Add(pair.Value);
            }
            sortedIndices.Sort();
            for (int i = 0; i < sortedNums.Count; ++i)
                ans[sortedIndices[i]] = sortedNums[i];
        }

        return ans;
    }

    private KeyValuePair<int, int>[] GetNumAndIndexes(int[] nums)
    {
        KeyValuePair<int, int>[] numAndIndexes = new KeyValuePair<int, int>[nums.Length];
        for (int i = 0; i < nums.Length; ++i)
            numAndIndexes[i] = new KeyValuePair<int, int>(nums[i], i);

        Array.Sort(numAndIndexes, (a, b) => a.Key.CompareTo(b.Key));
        return numAndIndexes;
    }
}