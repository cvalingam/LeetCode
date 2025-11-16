public class Solution
{
    public int NumSub(string s)
    {
        // Define modulo constant to prevent integer overflow
        const int MODULO = (int)1e9 + 7;

        // Total count of valid substrings
        int totalCount = 0;

        // Current consecutive '1's count ending at current position
        int consecutiveOnes = 0;

        // Iterate through each character in the string
        for (int i = 0; i < s.Length; i++)
        {
            // If current character is '1', increment consecutive count
            // Otherwise, reset consecutive count to 0
            if (s[i] == '1')
                consecutiveOnes++;
            else
                consecutiveOnes = 0;

            // Add current consecutive count to total
            // This represents all substrings of '1's ending at position i
            totalCount = (totalCount + consecutiveOnes) % MODULO;
        }

        return totalCount;
    }
}