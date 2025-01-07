public class Solution
{
    public string[] GetFolderNames(string[] names)
    {
        string[] ans = new string[names.Length];
        Dictionary<string, int> nameToSuffix = new Dictionary<string, int>();

        for (int i = 0; i < names.Length; ++i)
        {
            string name = names[i];
            if (nameToSuffix.ContainsKey(name))
            {
                int suffix = nameToSuffix[name];
                string newName = GetName(name, ++suffix);
                while (nameToSuffix.ContainsKey(newName))
                    newName = GetName(name, ++suffix);
                nameToSuffix[name] = suffix;
                nameToSuffix[newName] = 0;
                ans[i] = newName;
            }
            else
            {
                nameToSuffix[name] = 0;
                ans[i] = name;
            }
        }

        return ans;
    }

    private string GetName(string name, int suffix)
    {
        return name + "(" + suffix.ToString() + ")";
    }
}