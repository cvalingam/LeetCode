public class Solution
{
    public long MinCost(int[] basket1, int[] basket2)
    {
        int n = basket1.Length; // Length of the baskets
        Dictionary<int, int> fruitCountMap = new Dictionary<int, int>(); // A map to store the count difference of fruits between baskets

        // Count the difference between the two baskets
        for (int i = 0; i < n; ++i)
        {
            if (fruitCountMap.ContainsKey(basket1[i]))
                fruitCountMap[basket1[i]]++;
            else
                fruitCountMap[basket1[i]] = 1;

            if (fruitCountMap.ContainsKey(basket2[i]))
                fruitCountMap[basket2[i]]--;
            else
                fruitCountMap[basket2[i]] = -1;
        }

        int minFruitValue = int.MaxValue; // Initialize the minimum fruit value
        List<int> fruitDifferences = new List<int>(); // List to store absolute differences

        // Analyze the map to find out the absolute difference and minimum fruit value
        foreach (var entry in fruitCountMap)
        {
            int fruit = entry.Key, count = entry.Value;
            if (count % 2 != 0) // If count is odd, there's no way to balance, return -1
                return -1;

            for (int i = Math.Abs(count) / 2; i > 0; --i)
                fruitDifferences.Add(fruit);  // Add the fruit differences

            minFruitValue = Math.Min(minFruitValue, fruit); // Update the minimum fruit value if necessary
        }

        fruitDifferences.Sort(); // Sort the list of differences

        int m = fruitDifferences.Count; // Size of the list of differences
        long totalCost = 0; // Initialize the total cost

        // Calculate the minimum cost of balancing the baskets
        for (int i = 0; i < m / 2; ++i)
            totalCost += Math.Min(fruitDifferences[i], minFruitValue * 2); // Take the minimum of the current fruit difference and double of min fruit value

        return totalCost; // Return the total minimum cost
    }
}