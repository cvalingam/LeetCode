public class Solution
{
    public int RotatedDigits(int n)
    {
        int ans = 0;

        for (int i = 1; i <= n; ++i)
        {
            if (IsGoodNumber(i))
                ++ans;
        }

        return ans;
    }

    private bool IsGoodNumber(int i)
    {
        bool isRotated = false;

        foreach (char c in i.ToString())
        {
            if (c == '0' || c == '1' || c == '8')
                continue;
            if (c == '2' || c == '5' || c == '6' || c == '9')
                isRotated = true;
            else
                return false;
        }

        return isRotated;
    }
}