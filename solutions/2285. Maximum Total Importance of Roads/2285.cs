public class Solution
{
    public long MaximumImportance(int n, int[][] roads)
    {
        long ans = 0;

        long[] inDegree = new long[n];

        foreach (int[] road in roads)
        {
            int u = road[0];
            int v = road[1];
            inDegree[u]++;
            inDegree[v]++;
        }

        Array.Sort(inDegree);

        for (int i = 0; i < n; i++)
        {
            //Console.WriteLine("Index: " + (i + 1) + " Val: " + inDegree[i]);
            ans += (i + 1) * inDegree[i];
        }

        return ans;
    }
}