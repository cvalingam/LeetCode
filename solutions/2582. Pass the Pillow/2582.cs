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