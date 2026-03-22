class Solution {
    // Function to check if two strings are rotations of each other or not.
    public static boolean areRotations(String s1, String s2) {
        StringBuilder obj = new StringBuilder(s2);
        int m = s2.length();
        obj.append('$');
        obj.append(s1);
        obj.append(s1);
        s1 = new String(obj);
        int n = s1.length();
        int lps[] = new int[n];
        int len = 0;
        int i = 1;
        while (i < n) {
            if (s1.charAt(i) == s1.charAt(len)) {
                len++;
                if (len == m)
                    return true;
                lps[i] = len;
                i++;
            } else {
                if (len > 0)
                    len = lps[len - 1];
                else {
                    lps[i] = 0;
                    i++;
                }
            }
        }
        return false;
    }
}