public class Solution
{
    public IList<IList<int>> FindWinners(int[][] matches)
    {
        var wmap = new Dictionary<int, int>();
        var lmap = new Dictionary<int, int>();

        foreach (int[] match in matches)
        {
            int winner = match[0];
            int loser = match[1];
            if (wmap.ContainsKey(winner))
                wmap[winner]++;
            else
                wmap.Add(winner, 1);

            if (lmap.ContainsKey(loser))
                lmap[loser]++;
            else
                lmap.Add(loser, 1);
        }

        var lostOnlyOne = new List<int>();
        foreach (var kvp in lmap)
        {
            if (kvp.Value == 1)
                lostOnlyOne.Add(kvp.Key);
        }
        lostOnlyOne.Sort();

        var neverLost = new List<int>();
        foreach (var kvp in wmap)
        {
            if (!lmap.ContainsKey(kvp.Key))
                neverLost.Add(kvp.Key);
        }
        neverLost.Sort();

        var ans = new List<IList<int>>();
        ans.Add(neverLost);
        ans.Add(lostOnlyOne);

        return ans;
    }
}