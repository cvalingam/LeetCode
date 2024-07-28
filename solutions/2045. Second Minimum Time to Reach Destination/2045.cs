public class Solution
{
    public int SecondMinimum(int n, int[][] edges, int time, int change)
    {
        var gr = new List<int>[n + 1];

        for (int i = 1; i <= n; i++)
            gr[i] = new List<int>();


        foreach (int[] edge in edges)
        {
            int u = edge[0];
            int v = edge[1];
            gr[u].Add(v);
            gr[v].Add(u);
        }

        int[][] minTime = new int[n + 1][];

        for (int i = 0; i <= n; i++)
        {
            int[] arr = new int[2];
            Array.Fill(arr, Int32.MaxValue);
            minTime[i] = arr;
        }

        var q = new Queue<int[]>();
        q.Enqueue(new int[] { 1, 0 });
        minTime[1][0] = 0;

        while (q.Count > 0)
        {
            int node = q.Peek()[0];
            int prevTime = q.Peek()[1];
            q.Dequeue();

            int numChangeSignal = prevTime / change;
            int waitTime = (numChangeSignal % 2) == 0 ? 0 : change - (prevTime % change);
            int newTime = prevTime + waitTime + time;

            foreach (int adjNode in gr[node])
            {
                if (newTime < minTime[adjNode][0])
                {
                    minTime[adjNode][0] = newTime;
                    q.Enqueue(new int[] { adjNode, newTime });
                }
                else if (minTime[adjNode][0] < newTime && newTime < minTime[adjNode][1])
                {
                    if (adjNode == n)
                        return newTime;
                    minTime[adjNode][1] = newTime;
                    q.Enqueue(new int[] { adjNode, newTime });
                }
            }
        }

        throw new ArgumentException();
    }
}