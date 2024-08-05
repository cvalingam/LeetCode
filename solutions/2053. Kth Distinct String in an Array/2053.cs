public class Solution
{
    public string KthDistinct(string[] arr, int k)
    {
        Dictionary<string, int> count = new Dictionary<string, int>();

        foreach (var a in arr)
            count[a] = count.GetValueOrDefault(a, 0) + 1;

        foreach (var a in arr)
            if (count[a] == 1 && --k == 0)
                return a;

        return string.Empty;
    }
}