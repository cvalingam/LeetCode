// Approach: Compute position via modular arithmetic on zigzag period of 2*(n-1).
// Time: O(1) Space: O(1)

public class Solution
{
    public int PassThePillow(int n, int time)
    {
        time %= (n - 1) * 2;

        if (time < n)
            return time + 1;

        return n - (time - (n - 1));
    }
}