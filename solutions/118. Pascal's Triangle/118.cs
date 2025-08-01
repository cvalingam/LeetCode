public class Solution
{
    public IList<IList<int>> Generate(int numRows)
    {
        // Initialize the main list that will hold all rows of Pascal's Triangle
        IList<IList<int>> triangle = new List<IList<int>>();

        // The first row of Pascal's Triangle is always [1]
        triangle.Add(new List<int> { 1 });

        // Loop through each row (starting from the second row)
        for (int rowIndex = 1; rowIndex < numRows; ++rowIndex)
        {
            // Initialize the list to hold the current row's values
            IList<int> row = new List<int>();

            // The first element in each row is always 1
            row.Add(1);

            // Compute the values within the row (excluding the first and last element)
            for (int j = 0; j < triangle[rowIndex - 1].Count - 1; ++j)
                // Calculate each element as the sum of the two elements above it
                row.Add(triangle[rowIndex - 1][j] + triangle[rowIndex - 1][j + 1]);

            // The last element in each row is always 1
            row.Add(1);

            // Add the computed row to the triangle list
            triangle.Add(row);
        }

        // Return the fully constructed list of rows of Pascal's Triangle
        return triangle;
    }
}