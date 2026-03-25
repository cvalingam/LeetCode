// Approach: Repeatedly divide by 3; if any remainder is 2 return false (base-3 representation can only use 0/1).
// Time: O(log n) Space: O(1)

public class Solution
{
    public bool CheckPowersOfThree(int n)
    {
        while (n > 1)
        {
            int r = n % 3;
            if (r == 2)
                return false;
            n /= 3;
        }

        return true;
    }
}