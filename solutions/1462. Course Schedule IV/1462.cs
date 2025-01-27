public class Solution
{
    public IList<bool> CheckIfPrerequisite(int numCourses, int[][] prerequisites, int[][] queries)
    {
        List<bool> ans = new List<bool>();
        // isPrerequisite[i][j] := true if course i is a prerequisite of course j
        bool[,] isPrerequisite = new bool[numCourses, numCourses];

        foreach (var prerequisite in prerequisites)
        {
            int u = prerequisite[0];
            int v = prerequisite[1];
            isPrerequisite[u, v] = true;
        }

        for (int k = 0; k < numCourses; ++k)
        {
            for (int i = 0; i < numCourses; ++i)
            {
                for (int j = 0; j < numCourses; ++j)
                    isPrerequisite[i, j] = isPrerequisite[i, j] || (isPrerequisite[i, k] && isPrerequisite[k, j]);
            }
        }

        foreach (var query in queries)
        {
            int u = query[0];
            int v = query[1];
            ans.Add(isPrerequisite[u, v]);
        }

        return ans;
    }
}