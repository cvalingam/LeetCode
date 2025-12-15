public class Solution
{
    public long GetDescentPeriods(int[] prices)
    {
        long totalDescentPeriods = 0;
        int arrayLength = prices.Length;

        int startIndex = 0;
        while (startIndex < arrayLength)
        {
            int endIndex = startIndex + 1;

            while (endIndex < arrayLength && prices[endIndex - 1] - prices[endIndex] == 1)
                endIndex++;

            int sequenceLength = endIndex - startIndex;

            totalDescentPeriods += (1L + sequenceLength) * sequenceLength / 2;

            startIndex = endIndex;
        }

        return totalDescentPeriods;
    }
}