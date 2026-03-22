class Solution {
    public int myAtoi(String s) {
        int i = 0;
        while (i < s.length() && s.charAt(i) == ' ')
            i++;

        int sign = 1;
        if (i < s.length() && (s.charAt(i) == '+' || s.charAt(i) == '-')) {
            if (s.charAt(i) == '-')
                sign = -1;

            i++;
        }

        long result = 0;
        while (i < s.length() && Character.isDigit(s.charAt(i))) {
            result = result * 10 + (s.charAt(i) - '0');

            if (result * sign > Integer.MAX_VALUE)
                return Integer.MAX_VALUE;

            if (result * sign < Integer.MIN_VALUE)
                return Integer.MIN_VALUE;

            i++;
        }

        return (int) (result * sign);
    }
}