import java.util.*;

class Solution {
    // Function is to check whether two strings are anagram of each other or not.
    public static boolean areAnagrams(String s1, String s2) {
        if (s1.length() != s2.length()) {
            return false;
        } else {
            HashMap<Character, Integer> h1 = new HashMap<>();
            HashMap<Character, Integer> h2 = new HashMap<>();
            for (int i = 0; i < s1.length(); i++) {
                if (h1.containsKey(s1.charAt(i)))
                    h1.put(s1.charAt(i), h1.get(s1.charAt(i)) + 1);
                else
                    h1.put(s1.charAt(i), 1);
            }
            for (int i = 0; i < s2.length(); i++) {
                if (h2.containsKey(s2.charAt(i)))
                    h2.put(s2.charAt(i), h2.get(s2.charAt(i)) + 1);
                else
                    h2.put(s2.charAt(i), 1);
            }

            return h1.equals(h2);
        }
    }
}