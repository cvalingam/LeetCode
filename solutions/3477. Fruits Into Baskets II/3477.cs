public class Solution
{
    public int NumOfUnplacedFruits(int[] fruits, int[] baskets)
    {
        int n = fruits.Length; // Number of fruits
        bool[] visited = new bool[n]; // Array to track used baskets
        int unplacedFruits = n; // Initialize all fruits as unplaced

        // Loop through each fruit
        foreach (int fruit in fruits)
        {
            // Try to place each fruit in an available basket
            for (int i = 0; i < n; ++i)
            {
                // Check if the current basket can hold the fruit
                // and if it hasn't been used yet
                if (baskets[i] >= fruit && !visited[i])
                {
                    visited[i] = true; // Mark the basket as used
                    --unplacedFruits; // Decrease count of unplaced fruits
                    break; // Move to the next fruit
                }
            }
        }
        return unplacedFruits; // Return the count of unplaced fruits
    }
}