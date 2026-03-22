import java.util.*;

class Solution {
    public int countSubarrays(int arr[], int k) {
        HashMap<Integer, Integer> mp = new HashMap<>();
        int res = 0;
        int sum = 0;

        for (int i = 0; i < arr.length; i++) {
            sum += arr[i];

            if (sum == k)
                res++;

            if (mp.containsKey(sum - k))
                res += mp.get(sum - k);

            mp.put(sum, mp.getOrDefault(sum, 0) + 1);
        }
        return res;
    }
}