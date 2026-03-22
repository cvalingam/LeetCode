import java.util.*;

class Solution {
    public int longestKSubstr(String s, int k) {
        HashMap<Character, Integer> map = new HashMap<>();
        int left = 0;
        int maxLen = -1;

        for (int i = 0; i < s.length(); i++) {
            char ch = s.charAt(i);

            map.put(ch, map.getOrDefault(ch, 0) + 1);

            while (map.size() > k) {
                char leftChar = s.charAt(left);
                map.put(leftChar, map.get(leftChar) - 1);
                if (map.get(leftChar) == 0)
                    map.remove(leftChar);

                left++;
            }

            if (map.size() == k)
                maxLen = Math.max(maxLen, i - left + 1);
        }

        return maxLen;
    }
}