public class Solution
{
    public int MakeTheIntegerZero(int num1, int num2)
    {
        if (num1 == 0)
            return 0;

        for (long op = 1; op < 36; op++)
        {
            long req = (long)num1 - op * num2;
            if (countSetBits(req) <= op && op <= req)
                return (int)op;
        }

        return -1;
    }

    int countSetBits(long x)
    {
        int res = 0;
        for (int i = 0; i < 64; i++)
        {
            if (((1L << i) & x) != 0)
                res++;
        }

        return res;
    }
}