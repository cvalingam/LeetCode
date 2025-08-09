public class Solution
{
    public bool IsPowerOfTwo(int n)
    {
        // Check if n is greater than 0 and if n AND (n-1) is 0
        return n > 0 && (n & (n - 1)) == 0;
    }
}