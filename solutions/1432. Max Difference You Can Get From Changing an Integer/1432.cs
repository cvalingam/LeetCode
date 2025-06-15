public class Solution
{
    public int MaxDiff(int num)
    {
        // Convert the integer to a String for easier manipulation.
        string numStr = num.ToString();
        // Create two copies of the string, one for the maximum value and one for the minimum.
        string maxNumStr = numStr;
        string minNumStr = numStr;

        // Find the first non-'9' digit and replace all its occurrences with '9' to get the maximum number.
        for (int i = 0; i < numStr.Length; ++i)
        {
            if (numStr[i] != '9')
            {
                maxNumStr = numStr.Replace(numStr[i], '9');
                break;
            }
        }

        // For minimum number, if the first digit is not '1', replace all its occurrences with '1'.
        if (minNumStr[0] != '1')
            minNumStr = minNumStr.Replace(minNumStr[0], '1');
        else
        {
            // If the first digit is '1', find the first digit that is not '0' or '1' from the second digit onwards
            // and replace all its occurrences with '0'.
            for (int i = 1; i < minNumStr.Length; ++i)
            {
                if (minNumStr[i] != '0' && minNumStr[i] != '1')
                {
                    minNumStr = minNumStr.Replace(minNumStr[i], '0');
                    break;
                }
            }
        }

        // Parse the max and min strings back to integers and return the difference.
        return int.Parse(maxNumStr) - int.Parse(minNumStr);
    }
}