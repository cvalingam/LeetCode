public class Solution
{
    public string ClearDigits(string s)
    {
        StringBuilder sb = new StringBuilder();

        foreach (char c in s)
        {
            if (char.IsDigit(c))
            {
                // Since `sb` only contains non-digit characters, popping the last
                // character is equivalent to deleting the closest non-digit character.
                if (sb.Length > 0)
                    sb.Length--;
            }
            else
                sb.Append(c);
        }

        return sb.ToString();
    }
}