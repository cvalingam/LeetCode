public class Solution
{
    public int NumTilePossibilities(string tiles)
    {
        int[] count = new int[26];

        foreach (char t in tiles)
            count[t - 'A']++;

        return Dfs(count);
    }

    private int Dfs(int[] count)
    {
        int possibleSequences = 0;

        for (int i = 0; i < count.Length; i++)
        {
            if (count[i] == 0)
                continue;
            // Put c in the current position. We only care about the number of
            // possible sequences of letters but don't care about the actual
            // combination.
            count[i]--;
            possibleSequences += 1 + Dfs(count);
            count[i]++;
        }

        return possibleSequences;
    }
}