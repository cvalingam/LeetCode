public class Solution
{
    public int AreaOfMaxDiagonal(int[][] dimensions)
    {
        int maxArea = 0; // Holds the area of rectangle with largest diagonal so far
        int maxDiagonalSquare = 0; // Square of the largest diagonal seen so far

        // Loop through each dimensions array, where 'dimension' represents [length, width]
        foreach (var dimension in dimensions)
        {
            int length = dimension[0]; // Length of current rectangle
            int width = dimension[1];  // Width of current rectangle

            // Calculate the square of the diagonal for current rectangle
            int diagonalSquare = length * length + width * width;

            // If a larger diagonal is found, update maxDiagonalSquare and maxArea
            if (maxDiagonalSquare < diagonalSquare)
            {
                maxDiagonalSquare = diagonalSquare;
                maxArea = length * width; // Update area to the area of the current rectangle
            }
            else if (maxDiagonalSquare == diagonalSquare)
                // If the same diagonal is found, update maxArea if current area is larger
                maxArea = Math.Max(maxArea, length * width);
        }

        // Return the area of the rectangle with the largest diagonal encountered
        return maxArea;
    }
}