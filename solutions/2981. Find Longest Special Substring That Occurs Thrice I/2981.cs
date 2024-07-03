public class Solution
{
    public int MaximumLength(string s)
    {
        int n = s.Length, ans = -1;
        int[][] count = new int[26][];

        for (int i = 0; i < 26; i++)
        {
            int[] arr = new int[n + 1];
            count[i] = arr;
        }

        int runningLen = 0;
        char prev = '@';

        foreach (char c in s)
        {
            if (c == prev)
            {
                runningLen++;
                count[c - 'a'][runningLen]++;
            }
            else
            {
                runningLen = 1;
                count[c - 'a'][runningLen]++;
                prev = c;
            }
        }

        foreach (int[] cnt in count)
            ans = Math.Max(ans, getMaxFreq(cnt, n));

        return ans;
    }

    private int getMaxFreq(int[] cnt, int maxFreq)
    {
        int times = 0;
        for (int freq = maxFreq; freq >= 1; freq--)
        {
            times += cnt[freq];
            if (times >= 3)
                return freq;
        }

        return -1;
    }
}