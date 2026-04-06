// Approach: Iteratively build next term: scan current term counting consecutive equal digits, append count+digit.
// Time: O(n * 2^n) in worst Space: O(2^n)
class Solution {
    public String countAndSay(int n) {
        if (n <= 0)
            return "";
        String result = "1";

        for (int i = 1; i < n; i++) {
            StringBuilder current = new StringBuilder();
            int count = 1;

            // Read the previous result and generate the next
            for (int j = 1; j < result.length(); j++) {
                if (result.charAt(j) == result.charAt(j - 1)) {
                    count++;
                } else {
                    current.append(count).append(result.charAt(j - 1));
                    count = 1;
                }
            }

            // Append the last counted group
            current.append(count).append(result.charAt(result.length() - 1));
            result = current.toString();
        }

        return result;
    }
}