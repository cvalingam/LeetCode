public class Solution
{
    public bool AreAlmostEqual(string s1, string s2)
    {
        List<int> diffIndices = new List<int>();

        for (int i = 0; i < s1.Length; ++i)
        {
            if (s1[i] != s2[i])
                diffIndices.Add(i);
        }

        return diffIndices.Count == 0 ||
               (diffIndices.Count == 2 &&
                s1[diffIndices[0]] == s2[diffIndices[1]] &&
                s1[diffIndices[1]] == s2[diffIndices[0]]);
    }
}