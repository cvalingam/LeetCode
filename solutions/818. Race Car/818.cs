public class Solution
{
    public int Racecar(int target)
    {
        int[] mem = new int[target + 1];
        Array.Fill(mem, -1);
        return Racecar(target, mem);
    }

    private int Racecar(int i, int[] mem)
    {
        if (mem[i] >= 0)
            return mem[i];

        int res = int.MaxValue;
        int x = 1;            // xA := (2^x - 1) unit distance
        int j = (1 << x) - 1; // j = 2^x - 1, k = 2^y - 1

        // (xA + 1R) + (yA + 1R) + racecar(i - (j - k))
        for (; j < i; j = (1 << ++x) - 1)
        {
            for (int y = 0, k = 0; k < j; k = (1 << ++y) - 1)
                res = Math.Min(res, (x + 1) + (y + 1) + Racecar(i - (j - k), mem));
        }

        // xA || (xA + 1R) + racecar(j - i)
        return mem[i] = Math.Min(res, i == j ? x : x + 1 + Racecar(j - i, mem));
    }
}