public class Solution
{
    public string[] UncommonFromSentences(string s1, string s2)
    {
        var map = new Dictionary<string, int>();

        string[] words = (s1 + " " + s2).Split(" ");

        foreach (string word in words)
        {
            if (map.ContainsKey(word))
                map[word]++;
            else
                map[word] = 1;
        }

        var ans = new List<string>();
        foreach (KeyValuePair<string, int> item in map)
        {
            if (item.Value == 1)
                ans.Add(item.Key);
        }

        return ans.ToArray();
    }
}