// Approach: Check each row and column for palindrome property. Report row/column indices with this property.
// Time: O(n*m) Space: O(1)
class Solution {
    public String pattern(int[][] arr) {
        int n = arr.length;

        for (int i = 0; i < n; i++) {
            StringBuilder sb = new StringBuilder();
            for (int j = 0; j < n; j++) {
                sb.append(arr[i][j]);
            }

            String s = sb.toString();
            String reversed = new StringBuilder(s).reverse().toString();

            if (s.equals(reversed))
                return i + " R";
        }

        for (int i = 0; i < n; i++) {
            StringBuilder sb = new StringBuilder();
            for (int j = 0; j < n; j++) {
                sb.append(arr[j][i]);
            }

            String s = sb.toString();
            String reversed = new StringBuilder(s).reverse().toString();

            if (s.equals(reversed))
                return i + " C";
        }

        return "-1";
    }
}
