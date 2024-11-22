public class Solution
{
    public int FindNthDigit(int n)
    {
        int digitSize = 1;
        int startNum = 1;
        long count = 9;

        while (digitSize * count < n)
        {
            n -= digitSize * (int)count;
            ++digitSize;
            startNum *= 10;
            count *= 10;
        }

        int targetNum = startNum + (n - 1) / digitSize;
        int index = (n - 1) % digitSize;
        return (int)(targetNum.ToString()[index]) - '0';
    }
}