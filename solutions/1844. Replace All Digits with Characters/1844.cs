public class Solution
{
    public string ReplaceDigits(string s)
    {
        char[] chars = s.ToCharArray();
        for (int i = 1; i < chars.Length; i += 2)
            chars[i] = (char)(chars[i] + chars[i - 1] - '0');

        return new string(chars);
    }
}