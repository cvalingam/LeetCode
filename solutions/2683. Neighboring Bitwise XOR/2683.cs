public class Solution
{
    public bool DoesValidArrayExist(int[] derived)
    {
        int n = derived.Length;
        int ans = 0;

        for (int i = 0; i < n - 1; i++)
        {
            if (derived[i] == 1)
                ans ^= 1;
        }

        if (derived[n - 1] == 1)
            return ans != 0;
        else
            return ans == 0;
    }
}