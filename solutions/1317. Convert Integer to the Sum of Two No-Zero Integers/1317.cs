// Approach: Iterate a from 1 upward; check whether neither a nor n-a contains a '0' digit.
// Time: O(n log n) Space: O(1)

public class Solution
{
    public int[] GetNoZeroIntegers(int n)
    {
        // Iterate through possible values of the first integer starting from 1
        for (int firstInteger = 1; ; firstInteger++)
        {
            // Calculate the second integer as the difference
            int secondInteger = n - firstInteger;

            // Convert both integers to strings and concatenate them
            string concatenatedString = firstInteger.ToString() + secondInteger.ToString();

            // Check if the concatenated string contains the digit '0'
            // If it doesn't contain '0', both integers are non-zero integers
            if (!concatenatedString.Contains("0"))
                // Return the pair of non-zero integers
                return new int[] { firstInteger, secondInteger };
        }
    }
}