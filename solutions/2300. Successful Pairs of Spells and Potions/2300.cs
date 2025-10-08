public class Solution
{
    public int[] SuccessfulPairs(int[] spells, int[] potions, long success)
    {
        int[] ans = new int[spells.Length];
        Array.Sort(potions);

        for (int i = 0; i < spells.Length; ++i)
            ans[i] = potions.Length - FirstIndexSuccess(spells[i], potions, success);

        return ans;
    }

    // Returns the first index i s.t. spell * potions[i] >= success.
    private int FirstIndexSuccess(int spell, int[] potions, long success)
    {
        int l = 0;
        int r = potions.Length;
        while (l < r)
        {
            int m = (l + r) / 2;
            if ((long)spell * potions[m] >= success)
                r = m;
            else
                l = m + 1;
        }
        return l;
    }
}