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