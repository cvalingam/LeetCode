class Solution {
    public boolean isSubSeq(String s1, String s2) {
        int l = s1.length(), n = s2.length(), i = 0, j = 0;
        while (j < n && i < l) {
            if (s1.charAt(i) == s2.charAt(j))
                i++;
            j++;
        }

        if (i == l)
            return true;
        return false;
    }
};