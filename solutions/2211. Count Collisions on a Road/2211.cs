public class Solution
{
    public int CountCollisions(string directions)
    {
        // Convert string to char array for easier manipulation
        char[] directionArray = directions.ToCharArray();
        int length = directionArray.Length;

        // Find the leftmost non-'L' car
        // Cars moving left at the beginning won't collide with anything
        int leftBoundary = 0;
        while (leftBoundary < length && directionArray[leftBoundary] == 'L')
            leftBoundary++;

        // Find the rightmost non-'R' car
        // Cars moving right at the end won't collide with anything
        int rightBoundary = length - 1;
        while (rightBoundary >= 0 && directionArray[rightBoundary] == 'R')
            rightBoundary--;

        // Calculate total collisions
        // All cars between boundaries will eventually stop (collision count = 2 per moving car)
        // This counts all cars in the collision zone
        int totalCollisions = rightBoundary - leftBoundary + 1;

        // Subtract stationary cars as they don't contribute to collision count
        // Stationary cars ('S') are already stopped and won't generate collisions
        for (int i = leftBoundary; i <= rightBoundary; i++)
        {
            if (directionArray[i] == 'S')
                totalCollisions--;
        }

        return totalCollisions;
    }
}