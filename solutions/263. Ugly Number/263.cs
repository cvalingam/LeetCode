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