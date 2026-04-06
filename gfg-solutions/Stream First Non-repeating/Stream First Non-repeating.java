// Approach: Queue plus frequency map. On each new character, if frequency > 1, remove from queue front.
// Time: O(n) Space: O(26)
import java.util.*;

class Solution {
    public String firstNonRepeating(String s) {
        int n = s.length();
        Map<Character, Integer> map = new LinkedHashMap<>();
        StringBuilder ans = new StringBuilder();
        int[] freq = new int[26];
        for (int i = 0; i < n; i++) {
            char c = s.charAt(i);
            if (map.containsKey(c))
                map.remove(c);
            else {
                if (freq[c - 'a'] < 1)
                    map.put(c, 1);
            }
            if (!map.isEmpty()) {
                for (char a : map.keySet()) {
                    ans.append(a);
                    break;
                }
            } else
                ans.append('#');
            freq[c - 'a']++;
        }
        
        return ans.toString();
    }
}