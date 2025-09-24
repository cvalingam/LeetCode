public class Solution
{
    public string FractionToDecimal(int numerator, int denominator)
    {
        // Handle zero numerator case
        if (numerator == 0)
            return "0";

        StringBuilder result = new StringBuilder();

        // Determine if result should be negative
        // XOR returns true only when signs are different
        bool isNegative = (numerator > 0) ^ (denominator > 0);
        if (isNegative)
            result.Append("-");

        // Convert to long to avoid integer overflow
        long dividend = Math.Abs((long)numerator);
        long divisor = Math.Abs((long)denominator);

        // Append integer part
        result.Append(dividend / divisor);

        // Calculate remainder
        dividend %= divisor;

        // If remainder is 0, there's no fractional part
        if (dividend == 0)
            return result.ToString();

        // Append decimal point for fractional part
        result.Append(".");

        // Dictionary to store remainder and its corresponding position in result
        // Used to detect repeating patterns
        Dictionary<long, int> remainderToPosition = new Dictionary<long, int>();

        // Process fractional part
        while (dividend != 0)
        {
            // Check if this remainder has appeared before (repeating pattern found)
            if (remainderToPosition.ContainsKey(dividend))
            {
                // Insert opening parenthesis at the start of repeating sequence
                int repeatStartPosition = remainderToPosition[dividend];
                result.Insert(repeatStartPosition, "(");
                // Append closing parenthesis at the end
                result.Append(")");
                break;
            }

            // Store current remainder and its position
            remainderToPosition[dividend] = result.Length;

            // Multiply remainder by 10 for next digit calculation
            dividend *= 10;

            // Append next digit of fractional part
            result.Append(dividend / divisor);

            // Calculate new remainder
            dividend %= divisor;
        }

        return result.ToString();
    }
}