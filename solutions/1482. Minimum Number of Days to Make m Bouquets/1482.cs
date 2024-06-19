public class Solution {
    public int MinDays(int[] bloomDay, int m, int k) {
        int n = bloomDay.Length;

        long val = (long)m * (long)k;
        if(val > n)
            return -1;

        int maxElement = bloomDay[0];
        int minElement = bloomDay[0];
        for(int i = 0; i < n; i++)
        {
            maxElement = Math.Max(maxElement, bloomDay[i]);
            minElement = Math.Min(minElement, bloomDay[i]);
        }

        int low = minElement, high = maxElement;
        int ans = high;

        while(low <= high)
        {
            int mid = (low + high) / 2;
            if(Possible(bloomDay, mid, m, k))
            {
                ans = mid;
                high = mid - 1;
            }
            else
                low = mid + 1;
        }

        return ans;
    }

    private bool Possible(int[] bloomDay, int day, int m, int k)
    {
        int cnt = 0, bouquet = 0;
        for(int i = 0; i < bloomDay.Length; i++)
        {
            if(bloomDay[i] <= day)
            {
                cnt++;
            }
            else
            {
                bouquet += cnt / k;
                cnt = 0;
            }
        }

        bouquet += cnt / k;

        return bouquet >= m ? true : false;
    }
}