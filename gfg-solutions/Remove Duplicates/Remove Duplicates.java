// Approach: Linked list: traverse keeping previous; skip duplicate consecutive nodes.
// Time: O(n) Space: O(1)
import java.util.*;

class Solution {
    String removeDups(String str) {
        HashSet<Character> set = new HashSet<>();

        StringBuilder ans = new StringBuilder();

        for (char c : str.toCharArray()) {
            if (!set.contains(c))
                ans.append(c);
            set.add(c);
        }

        return ans.toString();
    }
}