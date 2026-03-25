// Approach: Sort folders lexicographically; a folder is a sub-folder if it starts with the previous kept folder followed by '/'.
// Time: O(n log n · m) Space: O(n)

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