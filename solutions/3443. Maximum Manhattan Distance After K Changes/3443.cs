public class Solution
{
    // Class level variables to store the character array and the integer k
    private char[] directionArray;
    private int k;

    // Main method to find the maximum distance based on the given conditions
    public int MaxDistance(string s, int k)
    {
        // Initialize the class variables
        this.directionArray = s.ToCharArray();
        this.k = k;

        // Calculate maximum distances for each pair of directions
        int max_SE = CalculateDistance('S', 'E');
        int max_SW = CalculateDistance('S', 'W');
        int max_NE = CalculateDistance('N', 'E');
        int max_NW = CalculateDistance('N', 'W');

        // Return the maximum distance among all calculated distances
        return Math.Max(Math.Max(max_SE, max_SW), Math.Max(max_NE, max_NW));
    }

    // Helper method to calculate the distance for a given pair of directions
    private int CalculateDistance(char direction1, char direction2)
    {
        int currentMax = 0; // Current running max distance
        int maxDistance = 0; // Overall max distance found
        int replacementCount = 0; // Count of non-direction characters replaced

        // Iterate over each character in the direction array
        foreach (char currentDirection in directionArray)
        {
            // Increment the current max if the character matches one of the interested directions
            if (currentDirection == direction1 || currentDirection == direction2)
                ++currentMax;
            else if (replacementCount < k) // Replace non-direction chars if replacements are available
            {
                ++currentMax;
                ++replacementCount;
            }
            else
                --currentMax; // Decrement the current max if no more replacements can be made
            // Update the max distance if the current calculated distance is greater
            maxDistance = Math.Max(maxDistance, currentMax);
        }

        return maxDistance; // Return the calculated max distance
    }
}