public class Solution {
    public int[] FrequencySort(int[] nums) {
        int[] cnt = new int[201];
        var t = new List<int>();

        foreach(int num in nums)
        {
            int v = num + 100;
            ++cnt[v];
            t.Add(v);
        }

        t.Sort((a, b) => cnt[a] == cnt[b] ? b - a : cnt[a] - cnt[b]);

        int[] ans = new int[nums.Length];

        for(int i = 0; i < t.Count; i++)
            ans[i] = t[i] - 100;

        return ans;
    }
}