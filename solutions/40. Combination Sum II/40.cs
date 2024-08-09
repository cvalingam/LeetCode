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