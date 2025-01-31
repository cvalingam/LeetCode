public class Solution
{
    private Dictionary<string, bool> mem = new Dictionary<string, bool>();

    public bool IsScramble(string s1, string s2)
    {
        if (s1.Equals(s2))
            return true;
        string hashKey = s1 + "+" + s2;
        if (mem.ContainsKey(hashKey))
            return mem[hashKey];

        int[] count = new int[128];

        for (int i = 0; i < s1.Length; ++i)
        {
            ++count[s1[i]];
            --count[s2[i]];
        }

        foreach (int freq in count)
        {
            if (freq != 0)
            {
                mem[hashKey] = false;
                return false;
            }
        }

        for (int i = 1; i < s1.Length; ++i)
        {
            if (IsScramble(s1.Substring(0, i), s2.Substring(0, i)) &&
                IsScramble(s1.Substring(i), s2.Substring(i)))
            {
                mem[hashKey] = true;
                return true;
            }
            if (IsScramble(s1.Substring(0, i), s2.Substring(s2.Length - i)) &&
                IsScramble(s1.Substring(i), s2.Substring(0, s2.Length - i)))
            {
                mem[hashKey] = true;
                return true;
            }
        }

        mem[hashKey] = false;
        return false;
    }
}