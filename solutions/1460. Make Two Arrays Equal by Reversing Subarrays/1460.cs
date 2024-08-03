public class Solution
{
    public bool CanBeEqual(int[] target, int[] arr)
    {
        var map1 = new Dictionary<int, int>();
        var map2 = new Dictionary<int, int>();

        foreach (int val in arr)
            map1[val] = map1.ContainsKey(val) ? ++map1[val] : 1;

        foreach (int val in target)
            map2[val] = map2.ContainsKey(val) ? ++map2[val] : 1;

        if (map1.Count != map2.Count)
            return false;

        for (int i = 0; i < map1.Count; i++)
        {
            KeyValuePair<int, int> kvp = map1.ElementAt(i);
            if (!map2.ContainsKey(kvp.Key))
                return false;
            int val = map2[kvp.Key];

            if (kvp.Value != val)
                return false;
        }

        return true;
    }
}