import java.util.*;

class Solution {
    public int maxPartitions(String s) {
        int n = s.length();
        HashMap<Character, Integer> map = new HashMap<>();
        for (int i = 0; i < n; i++) {
            char ch = s.charAt(i);
            if (!map.containsKey(ch))
                map.put(ch, i);
            else {
                map.remove(ch);
                map.put(ch, i);
            }
        }
        int i = 0;
        int j = 0;
        int maxi = -1;
        int cnt = 0;
        List<Integer> ans = new ArrayList<>();
        while (j < n) {
            char ch = s.charAt(j);
            maxi = Math.max(maxi, map.get(ch));
            if (maxi == j) {
                cnt++;
                // If you want the length of that partitioned string
                ans.add(j - i + 1);
                i = j + 1;
            }
            j++;
        }
        // you can return ans.size() as also your answer.
        return cnt;
    }
}