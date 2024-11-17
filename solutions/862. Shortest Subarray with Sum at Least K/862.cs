public class Solution
{
    public int ShortestSubarray(int[] nums, int k)
    {
        int n = nums.Length;
        int ans = n + 1;
        var dq = new LinkedList<int>();
        var prefix = new List<long> { 0 };

        for (int i = 0; i < n; ++i)
            prefix.Add(prefix[prefix.Count - 1] + nums[i]);

        for (int i = 0; i < n + 1; ++i)
        {
            while (dq.Count > 0 && prefix[i] - prefix[dq.First.Value] >= k)
            {
                ans = Math.Min(ans, i - dq.First.Value);
                dq.RemoveFirst();
            }

            while (dq.Count > 0 && prefix[i] <= prefix[dq.Last.Value])
                dq.RemoveLast();

            dq.AddLast(i);
        }

        return ans <= n ? ans : -1;
    }
}