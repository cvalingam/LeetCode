
import java.util.*;

// Approach: Store each word's reversed form in a hash map for O(1) partner lookups.
// For every split of a word into prefix/suffix, if one part is palindrome,
// check whether the reverse of the other part exists as a different index.
// If such a match exists for any split, a palindrome pair exists.
// Time: O(n * L^2) Space: O(n * L)

class Solution {

    public boolean palindromePair(String[] arr) {
        HashMap<String, Integer> hm = new HashMap<>();
        int n = arr.length;
        for (int i = 0; i < n; i++) {
            StringBuilder sb = new StringBuilder(arr[i]);
            hm.put(sb.reverse().toString(), i);
        }

        for (int i = 0; i < n; i++) {
            String s = arr[i];
            int l = s.length();
            for (int j = 0; j <= l; j++) {
                String s1 = s.substring(0, j);
                String s2 = s.substring(j, l);
                if (pal(s, j) && hm.containsKey(s2) && i != hm.get(s2)) {
                    return true;
                }
                if (pal(s2, l - j) && hm.containsKey(s1) && i != hm.get(s1)) {
                    return true;
                }
            }
        }

        return false;
    }

    static boolean pal(String s, int n) {
        if (n == 0 || n == 1) {
            return true;
        }
        
        int i = 0, j = n - 1;
        while (i <= j) {
            if (s.charAt(i) != s.charAt(j)) {
                return false;
            }
            i++;
            j--;
        }

        return true;
    }
}
