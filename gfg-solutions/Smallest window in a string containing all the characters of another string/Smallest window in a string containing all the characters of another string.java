class Solution {
    // Function to find the smallest window in the string s consisting
    // of all the characters of string p.
    public static String smallestWindow(String s, String p) {
        int[] freq = new int[26];
        int[] store = new int[26];

        for (char ch : p.toCharArray()) {
            freq[ch - 'a']++;
            store[ch - 'a']++;
        }

        int start = 0;
        int end = 0;
        int min = Integer.MAX_VALUE;
        int i = 0;
        int j = 0;
        int len = 0;

        while (j < s.length()) {
            if (store[s.charAt(j) - 'a'] > 0) {
                freq[s.charAt(j) - 'a']--;
                if (freq[s.charAt(j) - 'a'] >= 0)
                    ++len;
            }

            while (len == p.length()) {
                if (j - i + 1 < min) {
                    start = i;
                    end = j;
                    min = j - i + 1;
                }
                if (store[s.charAt(i) - 'a'] > 0) {
                    freq[s.charAt(i) - 'a']++;
                    if (freq[s.charAt(i) - 'a'] > 0)
                        --len;
                }
                ++i;
            }
            ++j;
        }
        return (min == Integer.MAX_VALUE) ? "-1" : s.substring(start, end + 1);
    }
}