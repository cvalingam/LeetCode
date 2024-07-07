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