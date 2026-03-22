import java.util.*;

class Solution {
    public int longestCommonSum(int[] a1, int[] a2) {
        HashMap<Integer, Integer> map = new HashMap<>();
        map.put(0, -1);
        int sum = 0;
        int ans = 0;
        
        for (int i = 0; i < a1.length; i++) {
            sum += (a1[i] - a2[i]);
            map.put(sum, map.getOrDefault(sum, i));
            ans = Math.max(ans, i - map.get(sum));
        }

        return ans;
    }
}