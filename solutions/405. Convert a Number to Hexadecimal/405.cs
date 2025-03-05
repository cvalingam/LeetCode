public class Solution
{
    public string ToHex(int number)
    {
        if (number == 0)
            return "0";

        System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
        for (int index = 7; index >= 0; --index)
        {
            int hexDigit = (number >> (4 * index)) & 0xf;
            if (stringBuilder.Length > 0 || hexDigit != 0)
            {
                char character = hexDigit < 10 ? (char)(hexDigit + '0') : (char)(hexDigit - 10 + 'a');
                stringBuilder.Append(character);
            }
        }
        return stringBuilder.ToString();
    }
}