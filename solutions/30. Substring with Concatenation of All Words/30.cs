public class Solution
{
    public IList<int> FindSubstring(string s, string[] words)
    {
        IList<int> indices = new List<int>();

        if (s == null || words == null || words.Length == 0)
            return indices;

        Dictionary<string, int> map = new Dictionary<string, int>();

        for (int i = 0; i < words.Length; i++)
        {
            if (map.ContainsKey(words[i]))
            {
                map[words[i]] += 1;
            }
            else
                map.Add(words[i], 1);
        }

        int wordLen = words[0].Length;
        int windowLen = words.Length * wordLen;
        for (int i = 0; i <= s.Length - windowLen; i++)
        {
            Dictionary<string, int> subMap = new Dictionary<string, int>(map);
            int j = i;
            while (j < i + windowLen)
            {
                string currWord = s.Substring(j, wordLen);

                if (!subMap.ContainsKey(currWord))
                {
                    //Console.WriteLine("Not int the map");
                    break;
                }
                else
                {
                    if (subMap[currWord] > 1)
                        subMap[currWord] -= 1;
                    else
                        subMap.Remove(currWord);
                }

                //Console.WriteLine("Current word: "+ currWord + " j value: " + j + " Count: " + subMap.Count);

                j = j + wordLen;
            }

            if (subMap.Count > 0)
                continue;

            if (j == i + windowLen)
                indices.Add(i);
        }

        return indices;
    }
}