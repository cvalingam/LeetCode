class Solution {
    static String longestPalindrome(String s) {
        int maxLength = 0;
        String longest = "";

        for (int i = 0; i < s.length(); i++) {

            String odd = check(s, i, i);
            if (odd.length() > maxLength) {
                maxLength = odd.length();
                longest = odd;
            }

            String even = check(s, i, i + 1);
            if (even.length() > maxLength) {
                maxLength = even.length();
                longest = even;
            }
        }

        return longest;
    }

    static String check(String s, int left, int right) {
        
        while (left >= 0 && right < s.length() && s.charAt(left) == s.charAt(right)) {
            left--;
            right++;
        }

        return s.substring(left + 1, right);
    }
}