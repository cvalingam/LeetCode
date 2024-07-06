public class Solution
{
    public void ReverseString(char[] s)
    {
        Reverse(0, s.Length - 1, s);
    }

    private void Reverse(int l, int r, char[] s)
    {
        if (l > r)
            return;

        char temp = s[l];
        s[l] = s[r];
        s[r] = temp;

        Reverse(l + 1, r - 1, s);
    }
}