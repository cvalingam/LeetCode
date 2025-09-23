public class Solution
{
    public int CompareVersion(string version1, string version2)
    {
        string[] v1 = version1.Split('.');
        string[] v2 = version2.Split('.');

        int len = Math.Max(v1.Length, v2.Length);

        for (int i = 0; i < len; i++)
        {
            int val1 = i < v1.Length ? Int32.Parse(v1[i]) : 0;
            int val2 = i < v2.Length ? Int32.Parse(v2[i]) : 0;

            int compare = val1.CompareTo(val2);

            if (compare != 0)
                return compare;
        }

        return 0;
    }
}