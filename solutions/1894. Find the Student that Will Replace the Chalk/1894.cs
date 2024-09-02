public class Solution
{
    public int ChalkReplacer(int[] chalk, int k)
    {
        long k1 = k;
        long sum = 0;
        for (int i = 0; i < chalk.Length; i++)
            sum += chalk[i];
        k1 %= sum;
        if (k1 == 0)
            return 0;

        for (int i = 0; i < chalk.Length; ++i)
        {
            k1 -= chalk[i];
            if (k1 < 0)
                return i;
        }

        throw new ArgumentException();
    }
}