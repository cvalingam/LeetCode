public class Solution
{
    public int MinMaxDifference(int num)
    {
        string numStr = num.ToString(); // Convert the integer to a string for manipulation
        int minVal = int.Parse(numStr.Replace(numStr[0], '0')); // Replace first digit with '0' to get the minimum value
        // Iterate over the characters in the string
        foreach (char digit in numStr)
        {
            if (digit != '9')
                // Replace the current digit with '9' to get the maximum value and return the difference
                return int.Parse(numStr.Replace(digit, '9')) - minVal;
        }
        // If all digits are '9', return the difference between the original number and minVal
        return num - minVal;
    }
}