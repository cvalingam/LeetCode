public class Solution
{
    public int LeastBricks(IList<IList<int>> wall)
    {
        int maxFreq = 0;
        Dictionary<int, int> count = new Dictionary<int, int>();

        foreach (var row in wall)
        {
            int prefix = 0;
            for (int i = 0; i < row.Count - 1; ++i)
            {
                prefix += row[i];
                if (count.ContainsKey(prefix))
                    count[prefix]++;
                else
                    count[prefix] = 1;
                    
                maxFreq = Math.Max(maxFreq, count[prefix]);
            }
        }

        return wall.Count - maxFreq;
    }
}