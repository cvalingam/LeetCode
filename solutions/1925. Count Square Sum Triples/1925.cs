public class Solution
{
    public int CountTriples(int n)
    {
        int tripleCount = 0;

        // Iterate through all possible values for 'a'
        for (int a = 1; a < n; a++)
        {
            // Iterate through all possible values for 'b'
            for (int b = 1; b < n; b++)
            {
                // Calculate the sum of squares: a^2 + b^2
                int sumOfSquares = a * a + b * b;

                // Calculate the potential value of 'c' using square root
                int c = (int)Math.Sqrt(sumOfSquares);

                // Check if 'c' is within bounds and forms a perfect square
                // (c^2 == sumOfSquares ensures it's a Pythagorean triple)
                if (c <= n && c * c == sumOfSquares)
                    tripleCount++;
            }
        }

        return tripleCount;
    }
}