// Approach: Greedy with max-heap. Remove the most frequent character k times, minimize distinct remaining.
// Time: O(n + k log 26) Space: O(26)
import java.util.*;

class Solution {
    public int minValue(String s, int k) {
        int freq[] = new int[26];

        for (int c : s.toCharArray())
            freq[c - 'a']++;

        while (k > 0) {
            Arrays.sort(freq);
            if (freq[25] == 0)
                break;
                
            freq[25]--;
            k--;
        }

        int result = 0;

        for (int i = 25; i >= 0; i--) {
            if (freq[i] == 0)
                continue;

            result += freq[i] * freq[i];
        }

        return result;
    }
}