public class Solution
{
    public int RomanToInt(string s)
    {
        Dictionary<char, int> romanNumerals = new Dictionary<char, int>();
        romanNumerals.Add('I', 1);
        romanNumerals.Add('V', 5);
        romanNumerals.Add('X', 10);
        romanNumerals.Add('L', 50);
        romanNumerals.Add('C', 100);
        romanNumerals.Add('D', 500);
        romanNumerals.Add('M', 1000);

        int result = 0;
        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] == 'V' || s[i] == 'X')
            {
                if (i > 0 && s[i - 1] == 'I')
                {
                    result += romanNumerals[s[i]] - 2;
                    continue;
                }
            }
            else if (s[i] == 'L' || s[i] == 'C')
            {
                if (i > 0 && s[i - 1] == 'X')
                {
                    result += romanNumerals[s[i]] - 20;
                    continue;
                }
            }
            else if (s[i] == 'D' || s[i] == 'M')
            {
                if (i > 0 && s[i - 1] == 'C')
                {
                    result += romanNumerals[s[i]] - 200;
                    continue;
                }
            }
            result += romanNumerals[s[i]];
        }

        return result;
    }
}