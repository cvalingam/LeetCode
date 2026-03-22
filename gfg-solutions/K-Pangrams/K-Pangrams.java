class Solution {
    boolean kPangram(String str, int k) {
        int n = str.length();

        if (n < 26)
            return false;

        int cnt = 0, cntSpaces = 0;
        int[] ch = new int[26];

        for (int i = 0; i < n; i++) {
            char c = str.charAt(i);

            if (Character.isLowerCase(c)) {
                ch[c - 'a']++;

                if (ch[c - 'a'] == 1)
                    cnt++;
            } else
                cntSpaces++;
        }

        int value = n - (cntSpaces + cnt);
        int remainLC = 26 - cnt;

        if (value >= remainLC && k >= remainLC)
            return true;

        return false;
    }
}