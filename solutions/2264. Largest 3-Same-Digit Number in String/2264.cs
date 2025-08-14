public class Solution
{
    public string LargestGoodInteger(string num)
    {
        // Loop backwards from '9' to '0'
        // This will ensure that the first good integer found is the largest
        for (int i = 9; i >= 0; i--)
        {
            // Create a string consisting of three identical digits
            string tripleDigit = new string(char.Parse(i.ToString()), 3);

            // Check if the num string contains the tripleDigit
            if (num.Contains(tripleDigit))
                // Return the found good integer (since we started from 9, it's the largest)
                return tripleDigit;
        }

        // If no good integer is found, return an empty string
        return "";
    }
}