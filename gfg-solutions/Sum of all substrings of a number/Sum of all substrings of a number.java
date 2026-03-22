class Solution {
    public static int sumSubstrings(String s) {
        int n = s.length();

        int sum = 0;
        int prev = 0;

        for (int i = 0; i < n; i++) {
            int x = s.charAt(i) - '0';
            prev = prev * 10 + x * (i + 1);
            sum += prev;
        }

        return sum;
    }
}