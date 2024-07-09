public class Solution
{
    public double AverageWaitingTime(int[][] customers)
    {
        double wait = 0, curr = 0;

        foreach (int[] c in customers)
        {
            curr = Math.Max(curr, 1.0 * c[0]) + c[1];
            wait += curr - c[0];
        }

        return 1.0 * wait / customers.Length;
    }
}