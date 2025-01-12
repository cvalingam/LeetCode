public class Solution
{
    public bool CanBeValid(string s, string locked)
    {
        if (s.Length % 2 == 1)
            return false;

        return Check(s, locked, true) && Check(ReverseString(s), ReverseString(locked), false);
    }

    private bool Check(string s, string locked, bool isForward)
    {
        int changeable = 0;
        int l = 0;
        int r = 0;

        for (int i = 0; i < s.Length; ++i)
        {
            char c = s[i];
            char lockChar = locked[i];
            if (lockChar == '0')
                ++changeable;
            else if (c == '(')
                ++l;
            else // c == ')'
                ++r;
            if (isForward && changeable + l - r < 0)
                return false;
            if (!isForward && changeable + r - l < 0)
                return false;
        }

        return true;
    }

    private string ReverseString(string s)
    {
        char[] charArray = s.ToCharArray();
        Array.Reverse(charArray);
        return new string(charArray);
    }
}