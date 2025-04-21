public class Solution
{
    public int NumberOfArrays(int[] differences, int lower, int upper)
    {
        long prefix = 0;
        long mn = 0; // Starts from 0.
        long mx = 0; // Starts from 0.

        foreach (var d in differences)
        {
            prefix += d;
            mn = Math.Min(mn, prefix);
            mx = Math.Max(mx, prefix);
        }

        return (int)Math.Max(0L, (upper - lower) - (mx - mn) + 1);
    }
}