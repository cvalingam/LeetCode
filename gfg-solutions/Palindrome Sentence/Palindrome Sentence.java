// Approach: Clean the string (lowercase, remove non-alpha), then check if it equals its reverse.
// Time: O(n) Space: O(n)
class Solution {
    public boolean isPalinSent(String s) {
        StringBuilder builder = new StringBuilder();
        for (char i : s.toCharArray()) {
            if (i >= '0' && i <= '9')
                builder.append(i);
            else if ((i >= 'A' && i <= 'Z') || (i >= 'a' && i <= 'z'))
                builder.append(("" + i).toLowerCase());
        }
        
        return builder.toString().equals(builder.reverse().toString());
    }
}