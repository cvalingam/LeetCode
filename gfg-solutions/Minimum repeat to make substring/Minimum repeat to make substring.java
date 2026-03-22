class Solution {
    static int minRepeats(String s1, String s2) {
        StringBuilder str = new StringBuilder(s1);

        for (int i = 0; i < s2.length(); i++) {
            if (!s1.contains("" + s2.charAt(i)))
                return -1;
        }

        int count = 0;
        while (str.length() < 4 * s2.length()) {
            count++;
            if (str.toString().contains(s2))
                return count;

            str.append(s1);
        }

        return -1;
    }
};