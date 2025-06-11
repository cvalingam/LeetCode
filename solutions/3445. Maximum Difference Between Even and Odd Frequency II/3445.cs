public class Solution
{
    public int MaxDifference(string s, int k)
    {
        int ans = int.MinValue;

        foreach (var pair in GetPermutations())
        {
            char a = pair.Item1;
            char b = pair.Item2;

            // minDiff[parityA][parityB] := min(a - b) of all valid windows with
            // parityA and parityB
            int[][] minDiff = new int[2][];
            minDiff[0] = Enumerable.Repeat(int.MaxValue / 2, 2).ToArray();
            minDiff[1] = Enumerable.Repeat(int.MaxValue / 2, 2).ToArray();
            // prefixA[i] := the number of 'a's in s[0..i)
            List<int> prefixA = new List<int> { 0 };
            // prefixB[i] := the number of 'b's in s[0..i)
            List<int> prefixB = new List<int> { 0 };
            for (int l = 0, r = 0; r < s.Length; ++r)
            {
                prefixA.Add(prefixA[prefixA.Count - 1] + (s[r] == a ? 1 : 0));
                prefixB.Add(prefixB[prefixB.Count - 1] + (s[r] == b ? 1 : 0));
                while (r - l + 1 >= k &&                                   // the window size >= k
                       prefixA[l] < prefixA[prefixA.Count - 1] && // the number of 'a's > 0
                       prefixB[l] < prefixB[prefixB.Count - 1])
                { // the number of 'b's > 0
                    minDiff[prefixA[l] % 2][prefixB[l] % 2] = Math.Min(minDiff[prefixA[l] % 2][prefixB[l] % 2],
                        prefixA[l] - prefixB[l]);
                    ++l;
                }
                ans = Math.Max(ans, (prefixA[prefixA.Count - 1] - prefixB[prefixB.Count - 1]) -
                                    minDiff[1 - prefixA[prefixA.Count - 1] % 2][prefixB[prefixB.Count - 1] % 2]);
            }
        }

        return ans;
    }

    private List<(char, char)> GetPermutations()
    {
        var permutations = new List<(char, char)>();
        foreach (char a in "01234")
        {
            foreach (char b in "01234")
            {
                if (a != b)
                    permutations.Add((a, b));
            }
        }

        return permutations;
    }
}