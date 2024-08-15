public class Solution
{
    public bool LemonadeChange(int[] bills)
    {
        int cnt5 = 0, cnt10 = 0;

        foreach (int bill in bills)
        {
            if (bill == 5)
                cnt5++;
            else if (bill == 10)
            {
                cnt10++;
                cnt5--;
            }
            else
            {
                if (cnt10 > 0)
                {
                    cnt10--;
                    cnt5--;
                }
                else
                    cnt5 -= 3;
            }

            if (cnt5 < 0)
                return false;
        }

        return true;
    }
}