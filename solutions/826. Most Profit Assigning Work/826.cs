public class Solution {
    public int MaxProfitAssignment(int[] difficulty, int[] profit, int[] worker) {
        int ans = 0;
        List<int[]> jobs = new List<int[]>();

        for(int i = 0; i < difficulty.Length; i++)
            jobs.Add(new int[] {difficulty[i], profit[i]});

        jobs.Sort((a, b) => a[0].CompareTo(b[0]));
        Array.Sort(worker);

        int j = 0, maxProfit = 0;
        foreach(int w in worker)
        {
            for(; j < jobs.Count && w >= jobs[j][0]; j++)
                maxProfit = Math.Max(maxProfit, jobs[j][1]);

            ans += maxProfit;
        }

        return ans;
    }
}