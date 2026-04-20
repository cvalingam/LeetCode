// Approach: Sort the candidates array first so duplicates are adjacent.
// Use backtracking: for each position, iterate from 'start' to end, subtracting candidates from target.
// Skip duplicate candidates at the same recursion depth (i > start && candidates[i] == candidates[i-1]).
// This prevents generating duplicate combinations without using a hash set.
// Stop exploring a branch early if candidates[i] > remaining target (array is sorted, so all further are larger).
// Time: O(2^n) in the worst case. Space: O(n) for the recursion stack.

public class Solution
{
    public IList<IList<int>> CombinationSum2(int[] candidates, int target)
    {
        IList<IList<int>> ansList = new List<IList<int>>();
        Array.Sort(candidates);
        findCombinations(0, candidates, target, new List<int>(), ansList);
        return ansList;
    }

    private void findCombinations(int ind, int[] array, int target, IList<int> ds, IList<IList<int>> ansList)
    {
        if (target == 0)
        {
            ansList.Add(new List<int>(ds));
            return;
        }

        for (int j = ind; j < array.Length; j++)
        {
            if (j > ind && array[j - 1] == array[j])
                continue;

            if (array[j] > target)
                break;

            ds.Add(array[j]);
            findCombinations(j + 1, array, target - array[j], ds, ansList);
            ds.RemoveAt(ds.Count - 1);
        }
    }
}