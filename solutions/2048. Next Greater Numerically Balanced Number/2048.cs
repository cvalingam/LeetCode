public class Solution
{
    public int NextBeautifulNumber(int n)
    {
        for (int candidate = n + 1; ; candidate++)
        {
            int[] digitCount = new int[10];

            for (int temp = candidate; temp > 0; temp /= 10)
                digitCount[temp % 10]++;

            bool isBeautiful = true;

            for (int temp = candidate; temp > 0; temp /= 10)
            {
                int digit = temp % 10;
                if (digit != digitCount[digit])
                {
                    isBeautiful = false;
                    break;
                }
            }

            if (isBeautiful)
                return candidate;
        }
    }
}