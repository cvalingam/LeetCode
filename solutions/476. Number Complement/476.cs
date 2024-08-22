public class Solution
{
    public int FindComplement(int num)
    {
        for (long i = 1; i <= num; i <<= 1)
            num ^= (int)i;

        return num;
    }
}