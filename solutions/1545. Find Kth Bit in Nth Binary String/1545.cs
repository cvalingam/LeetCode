public class Solution
{
    public char FindKthBit(int n, int k)
    {
        if (n == 1)
            return '0';
        int midIndex = (int)Math.Pow(2, n - 1); // 1-indexed
        if (k == midIndex)
            return '1';
        if (k < midIndex)
            return FindKthBit(n - 1, k);
        return FindKthBit(n - 1, midIndex * 2 - k) == '0' ? '1' : '0';
    }
}