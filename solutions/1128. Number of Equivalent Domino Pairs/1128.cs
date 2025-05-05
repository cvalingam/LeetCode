public class Solution
{
    public int NumEquivDominoPairs(int[][] dominoes)
    {
        Dictionary<string, int> dominoCounts = new Dictionary<string, int>();
        int count = 0;

        foreach (var domino in dominoes)
        {
            int a = domino[0];
            int b = domino[1];
            string key = $"{Math.Min(a, b)},{Math.Max(a, b)}";

            if (dominoCounts.ContainsKey(key))
                dominoCounts[key]++;
            else
                dominoCounts[key] = 1;
        }

        foreach (var kvp in dominoCounts)
        {
            int n = kvp.Value;
            if (n >= 2)
                count += n * (n - 1) / 2;
        }

        return count;
    }
}