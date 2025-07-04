public class Solution
{
    public char KthCharacter(long k, int[] operations)
    {
        int operationsCount = (int)Math.Ceiling(Math.Log(k) / Math.Log(2));
        int increases = 0;

        for (int i = operationsCount - 1; i >= 0; --i)
        {
            long halfSize = 1L << i;
            if (k > halfSize)
            {
                k -= halfSize; // Move k from the right half to the left half.
                increases += operations[i];
            }
        }

        return (char)('a' + increases % 26);
    }
}