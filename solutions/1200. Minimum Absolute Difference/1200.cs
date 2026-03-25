// Approach: Sort the array; scan adjacent pairs to find the minimum difference, then collect all pairs with that difference.
// Time: O(n log n) Space: O(n)

public class Solution
{
    public IList<IList<int>> MinimumAbsDifference(int[] arr)
    {
        IList<IList<int>> result = new List<IList<int>>();
        Array.Sort(arr);
        long minDifference = Int64.MaxValue;
        for (int i = 0; i < arr.Length - 1; i++)
        {
            var difference = Math.Abs(arr[i] - arr[i + 1]);
            if (difference < minDifference)
                minDifference = difference;
        }

        for (int j = 0; j < arr.Length - 1; j++)
        {
            var difference = Math.Abs(arr[j] - arr[j + 1]);
            if (minDifference == difference)
            {
                var minDifflist = new List<int> { arr[j], arr[j + 1] };
                result.Add(minDifflist);
            }
        }

        return result;
    }
}