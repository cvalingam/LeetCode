// Approach: Greedily track $5 and $10 bill counts; for $20 change prefer using $10+$5 before falling back to three $5s.
// Time: O(n) Space: O(1)

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