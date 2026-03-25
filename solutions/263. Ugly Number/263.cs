// Approach: Repeatedly divide by 2, 3, and 5; the number is ugly
// if and only if the final result equals 1.
// Time: O(log n) Space: O(1)

public class Solution
{
    public bool IsUgly(int n)
    {
        if (n == 0)
            return false;

        foreach (int prime in new int[] { 2, 3, 5 })
        {
            while (n % prime == 0)
                n /= prime;
        }

        return n == 1;
    }
}