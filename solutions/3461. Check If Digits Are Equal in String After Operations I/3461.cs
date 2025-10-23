public class Solution
{
    public bool HasSameDigits(string s)
    {
        // Convert the input string to a character array for manipulation
        char[] digitArray = s.ToCharArray();
        int arrayLength = digitArray.Length;

        // Perform triangular reduction
        // Start from the last position and work backwards to position 1
        // This ensures we end up with exactly 2 elements
        for (int currentLength = arrayLength - 1; currentLength > 1; --currentLength)
        {
            // For each iteration, compute new values for positions 0 to currentLength-1
            // Each new value is the sum of adjacent digits modulo 10
            for (int position = 0; position < currentLength; ++position)
            {
                // Calculate sum of current digit and next digit
                int currentDigit = digitArray[position] - '0';
                int nextDigit = digitArray[position + 1] - '0';
                int sumModTen = (currentDigit + nextDigit) % 10;

                // Store the result back as a character
                digitArray[position] = (char)(sumModTen + '0');
            }
        }

        // Check if the final two remaining digits are equal
        return digitArray[0] == digitArray[1];
    }
}