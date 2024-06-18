public class Solution {
    public int ShipWithinDays(int[] weights, int days) {
        int maxEle = Int32.MinValue;
        int sumofW = 0;
        for(int i = 0; i < weights.Length; i++)
        {
            maxEle = Math.Max(maxEle, weights[i]);
            sumofW += weights[i];
        }

        int low = maxEle, high = sumofW;
        int ans = -1;
        while(low <= high)
        {
            int mid = (low + high) / 2;
            int daysRequired = GetDaysRequired(weights, mid);
            if(daysRequired <= days)
            {
                ans = mid;
                high = mid - 1;
            }
            else
                low = mid + 1;
        }

        return ans;
    }

    private int GetDaysRequired(int[] weights, int capacity)
    {
        int days = 1, load = 0;
        for(int i = 0; i < weights.Length; i++)
        {
            load += weights[i];
            if(load > capacity)
            {
                load = weights[i];
                days++;
            }
        }

        return days;
    }
}