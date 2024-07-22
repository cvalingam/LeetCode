public class Solution
{
    public string[] SortPeople(string[] names, int[] heights)
    {
        List<KeyValuePair<int, string>> heightAndNames = new List<KeyValuePair<int, string>>();

        for (int i = 0; i < names.Length; ++i)
            heightAndNames.Add(new KeyValuePair<int, string>(heights[i], names[i]));

        heightAndNames.Sort((a, b) => b.Key.CompareTo(a.Key));

        for (int i = 0; i < heightAndNames.Count; ++i)
            names[i] = heightAndNames[i].Value;

        return names;
    }
}