public class Solution
{
    public IList<string> RemoveSubfolders(string[] folder)
    {
        List<string> ans = new List<string>();
        string prev = "";

        Array.Sort(folder);

        foreach (var f in folder)
        {
            if (!string.IsNullOrEmpty(prev) && f.StartsWith(prev) && f[prev.Length] == '/')
                continue;
            ans.Add(f);
            prev = f;
        }

        return ans;
    }
}