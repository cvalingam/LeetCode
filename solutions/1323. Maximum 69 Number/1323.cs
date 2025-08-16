public class Solution
{
    public int Maximum69Number(int num)
    {
        // Convert the integer to a string to manipulate individual characters
        string numStr = num.ToString();

        // Iterate over the characters in the string
        char[] charArray = numStr.ToCharArray();
        for (int i = 0; i < charArray.Length; i++)
        {
            // If the character is '6', change it to '9'
            if (charArray[i] == '6')
            {
                charArray[i] = '9';
                // After the first change, break out of the loop since we are 
                // allowed to change at most one digit
                break;
            }
        }

        // Convert the string back to an integer to obtain the final result
        return int.Parse(new string(charArray));
    }
}