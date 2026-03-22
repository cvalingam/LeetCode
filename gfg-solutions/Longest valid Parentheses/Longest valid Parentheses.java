class Solution {
    static int maxLength(String S) {

        int open = 0, close = 0;
        int max = 0;

        // traverse from first
        for (char c : S.toCharArray()) {

            if (c == '(')
                open++;

            else
                close++;

            if (open == close)
                max = Math.max(open + close, max);

            // close is greater than open means , reset
            else if (close > open) {
                open = 0;
                close = 0;
            }
        }

        // traverse from last , if open is greater than means , reset
        open = 0;
        close = 0;

        for (int i = S.length() - 1; i >= 0; i--) {

            if (S.charAt(i) == ')')
                close++;
            else
                open++;

            if (open == close)
                max = Math.max(open + close, max);

            if (open > close) {
                open = 0;
                close = 0;
            }
        }

        return max;
    }
}