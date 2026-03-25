// Approach: Simulate; repeatedly exchange full bottles for new ones, tracking the total drunk.
// Time: O(log n) Space: O(1)

public class Solution
{
    public int NumWaterBottles(int numBottles, int numExchange)
    {
        int ans = numBottles;

        while (numBottles >= numExchange)
        {
            numBottles -= numExchange;
            ans++;
            numBottles += 1;
        }

        return ans;
    }
}