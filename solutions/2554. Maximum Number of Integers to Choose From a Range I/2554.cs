public class Solution
{
    public int MaxCount(int[] banned, int n, int maxSum)
    {
        int answerCount = 0;
        int currentSum = 0;
        HashSet<int> bannedNumberSet = new HashSet<int>(banned);

        for (int currentNumber = 1; currentNumber <= n; ++currentNumber)
        {
            if (!bannedNumberSet.Contains(currentNumber) && currentSum + currentNumber <= maxSum)
            {
                ++answerCount;
                currentSum += currentNumber;
            }
        }

        return answerCount;
    }
}