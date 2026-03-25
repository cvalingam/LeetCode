// Approach: Add base satisfied customers, then find the sliding window of length 'minutes' that maximises extra customers recovered from grumpy minutes.
// Time: O(n) Space: O(1)

public class Solution
{
    public int MaxSatisfied(int[] customers, int[] grumpy, int minutes)
    {
        int satisfied = 0, windowSatisfied = 0;
        int madeSatisfied = 0;

        for (int i = 0; i < customers.Length; i++)
        {
            if (grumpy[i] == 0)
                satisfied += customers[i];
            else
                windowSatisfied += customers[i];

            if (i >= minutes && grumpy[i - minutes] == 1)
                windowSatisfied -= customers[i - minutes];
            madeSatisfied = Math.Max(madeSatisfied, windowSatisfied);
        }

        return satisfied + madeSatisfied;
    }
}