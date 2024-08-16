public class Solution
{
    public int MaxDistance(IList<IList<int>> arrays)
    {
        int ans = 0;
        int min = 10000;
        int max = -10000;

        foreach (var array in arrays)
        {
            ans = Math.Max(ans, Math.Max(array[array.Count - 1] - min, max - array[0]));
            min = Math.Min(min, array[0]);
            max = Math.Max(max, array[array.Count - 1]);
        }

        return ans;
    }
}