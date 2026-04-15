// Approach: Traverse characters and build the result; replace each space with "%20"
// and append non-space characters directly using StringBuilder.
// Time: O(n) Space: O(n)
class Solution {

    String URLify(String s) {
        StringBuilder res = new StringBuilder();
        for (char c : s.toCharArray()) {
            if (c == ' ') {
                res.append("%20");
            } else {
                res.append(c);
            }
        }
        return res.toString();
    }
}
