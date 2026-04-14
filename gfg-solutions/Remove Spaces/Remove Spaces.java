
// Approach: Iterate over the string and append each non-space character to a StringBuilder.
// Time: O(n) Space: O(n)
class Solution {

    String removeSpaces(String s) {
        StringBuilder sb = new StringBuilder("");
        int n = s.length();
        for (int i = 0; i < n; i++) {
            if (s.charAt(i) != ' ') {
                sb.append(s.charAt(i));
            }
        }
        
        return sb.toString();
    }
}
