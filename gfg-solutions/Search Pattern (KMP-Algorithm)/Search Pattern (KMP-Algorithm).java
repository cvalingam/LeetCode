class Solution {

    ArrayList<Integer> search(String pat, String txt) {
        ArrayList<Integer> result = new ArrayList<>();
        int[] lps = new int[pat.length()];
        lps[0] = 0;
        int i = 1;
        int length = 0;

        while (i < pat.length()) {
            if (pat.charAt(i) == pat.charAt(length))
                lps[i++] = ++length;
            else {
                if (length == 0)
                    lps[i++] = 0;
                else
                    length = lps[length - 1];
            }
        }

        i = 0;
        int j = 0;
        while (i < txt.length()) {
            if (txt.charAt(i) != pat.charAt(j)) {
                if (j == 0)
                    ++i;
                else
                    j = lps[j - 1];
            } else {
                ++i;
                ++j;
            }
            if (j == pat.length()) {
                result.add(i - j);
                j = lps[j - 1];
            }
        }

        return result;
    }
}