// Approach: Simulate; each round trade numExchange empties for 1 full; numExchange increments each trade.
// Time: O(sqrt(n)) Space: O(1)

class Solution
{
    public int MaxBottlesDrunk(int numBottles, int numExchange)
    {
        int ans = numBottles;

        while (numBottles >= numExchange)
        {
            numBottles = (numBottles - numExchange + 1);
            ++numExchange;
            ++ans;
        }

        return ans;
    }
}