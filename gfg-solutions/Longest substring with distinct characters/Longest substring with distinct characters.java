class Solution {
    public int longestUniqueSubstr(String s) {
        boolean c[] = new boolean[26];
        int l = 0;
        int r = 0;
        int len = Integer.MIN_VALUE;
        int n = s.length();
        while (r < n) {
            if (c[s.charAt(r) - 'a']) {
                while (s.charAt(l) != s.charAt(r)) {
                    c[s.charAt(l) - 'a'] = false;
                    l++;
                }
                c[s.charAt(l) - 'a'] = false;
                l++;
            }
            c[s.charAt(r) - 'a'] = true;
            len = Math.max(len, r - l + 1);
            r++;
        }
        return len;
    }
}