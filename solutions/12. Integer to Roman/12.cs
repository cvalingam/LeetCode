public class Solution
{
    public string IntToRoman(int num)
    {
        int[] values = { 1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1 };
        string[] symbols = { "M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I" };

        StringBuilder sb = new StringBuilder();

        for (int i = 0; i < values.Length; i++)
        {
            if (num == 0)
                break;

            while (num >= values[i])
            {
                num -= values[i];
                sb.Append(symbols[i]);
            }
        }

        return sb.ToString();
    }
}