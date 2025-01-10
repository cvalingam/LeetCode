public class Solution
{
    public IList<string> WordSubsets(string[] A, string[] B)
    {
        List<string> ans = new List<string>();
        int[] countB = new int[26];

        foreach (var b in B)
        {
            int[] temp = Counter(b);
            for (int i = 0; i < 26; ++i)
                countB[i] = Math.Max(countB[i], temp[i]);
        }

        foreach (var a in A)
        {
            if (IsUniversal(Counter(a), countB))
                ans.Add(a);
        }

        return ans;
    }

    private int[] Counter(string s)
    {
        int[] count = new int[26];
        foreach (char c in s)
            ++count[c - 'a'];
        return count;
    }

    private bool IsUniversal(int[] countA, int[] countB)
    {
        for (int i = 0; i < 26; ++i)
        {
            if (countA[i] < countB[i])
                return false;
        }
        return true;
    }
}