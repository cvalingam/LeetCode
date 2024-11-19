public class Solution
{
    public int GetLastMoment(int n, int[] left, int[] right)
    {
        int maxLeft = left.Length == 0 ? 0 : left.Max();
        int minRight = right.Length == 0 ? n : right.Min();
        return Math.Max(maxLeft, n - minRight);
    }
}