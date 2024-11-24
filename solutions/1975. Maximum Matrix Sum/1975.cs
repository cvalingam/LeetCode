public class Solution
{
    public long MaxMatrixSum(int[][] matrix)
    {
        long absSum = 0;
        int minAbs = int.MaxValue;
        // 0 := even number of negatives
        // 1 := odd number of negatives
        int oddNeg = 0;

        foreach (int[] row in matrix)
        {
            foreach (int num in row)
            {
                absSum += Math.Abs(num);
                minAbs = Math.Min(minAbs, Math.Abs(num));
                if (num < 0)
                    oddNeg ^= 1;
            }
        }

        return absSum - oddNeg * minAbs * 2;
    }
}