public class Solution
{
    public long DividePlayers(int[] skill)
    {
        int n = skill.Length;
        int teamSkill = skill.Sum() / (n / 2);
        long ans = 0;
        Dictionary<int, int> count = new Dictionary<int, int>();

        foreach (int s in skill)
        {
            if (count.ContainsKey(s))
                count[s]++;
            else
                count[s] = 1;
        }

        foreach (var entry in count)
        {
            int s = entry.Key;
            int freq = entry.Value;
            int requiredSkill = teamSkill - s;
            if (!count.ContainsKey(requiredSkill) || count[requiredSkill] != freq)
                return -1;

            ans += (long)s * requiredSkill * freq;
        }

        return ans / 2;
    }
}