class Solution {
    int lps(String str) {
        int[] preArry = new int[str.length()];
        int j = 0;

        for (int i = 1; i < str.length(); i++) {

            while (j > 0 && str.charAt(i) != str.charAt(j))
                j = preArry[j - 1];

            if (str.charAt(i) == str.charAt(j))
                j++;

            preArry[i] = j;
        }
        return preArry[str.length() - 1];
    }
}

class Solution1 {
    int getLPSLength(String s) {
        int n = s.length();
        int[] lps = new int[n];
        int len = 0;
        int i = 1;
        while (i < n) {
            if (s.charAt(i) == s.charAt(len)) {
                len++;
                lps[i] = len;
                i++;
            } else {
                if (len != 0)
                    len = lps[len - 1];
                else {
                    lps[i] = 0;
                    i++;
                }
            }
        }
        
        return lps[n - 1];
    }
}