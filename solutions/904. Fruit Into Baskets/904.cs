public class Solution
{
    public int TotalFruit(int[] tree)
    {
        // Create a Dictionary to keep track of the count of each type of fruit
        Dictionary<int, int> fruitCount = new Dictionary<int, int>();
        int start = 0; // Start of the sliding window
        int maxFruits = 0; // Maximum number of fruits collected

        // Iterate through the array of fruits using the end of the sliding window
        for (int end = 0; end < tree.Length; end++)
        {
            // Add the current fruit to the fruitCount dictionary or update its count
            if (fruitCount.ContainsKey(tree[end]))
                fruitCount[tree[end]]++;
            else
                fruitCount[tree[end]] = 1;

            // If the dictionary contains more than 2 types of fruit, shrink the window from the start
            while (fruitCount.Count > 2)
            {
                fruitCount[tree[start]]--;
                // If the count of a fruit at the start of the window becomes 0, remove it
                if (fruitCount[tree[start]] == 0)
                    fruitCount.Remove(tree[start]);
                start++; // Move the start of the window forward
            }

            // Calculate the maximum number of fruits in the current window
            maxFruits = Math.Max(maxFruits, end - start + 1);
        }
        // Return the size of the largest contiguous subarray with 2 types of fruits
        return maxFruits;
    }
}