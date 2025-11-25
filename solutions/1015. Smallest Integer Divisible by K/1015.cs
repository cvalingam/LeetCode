public class Solution
{
    public int SmallestRepunitDivByK(int k)
    {
        if (k % 10 != 1 && k % 10 != 3 && k % 10 != 7 && k % 10 != 9)
            return -1;

        HashSet<int> seen = new HashSet<int>();
        int n = 0;

        for (int length = 1; length <= k; ++length)
        {
            n = (n * 10 + 1) % k;
            if (n == 0)
                return length;
            if (seen.Contains(n))
                return -1;
            seen.Add(n);
        }

        return -1;
    }
}