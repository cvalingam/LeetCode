
import java.util.*;

// Approach: BFS level by level, each level removes exactly one parenthesis character.
// At the first level where any valid string is found, collect all valid results from that level and stop going deeper.
// A HashSet tracks visited strings to prune duplicate states.
// Time: O(2^n * n) Space: O(2^n * n)

class Solution {

    public List<String> validParenthesis(String s) {
        List<String> ans = new ArrayList<>();

        if (s == null) {
            return ans;
        }

        Set<String> vis = new HashSet<>();
        Queue<String> q = new ArrayDeque<>();
        q.add(s);
        vis.add(s);
        boolean found = false;

        while (!q.isEmpty()) {
            String cur = q.poll();
            if (check(cur)) {
                ans.add(cur);
                found = true;
            }

            if (found) {
                continue;
            }

            for (int i = 0; i < cur.length(); i++) {

                if (cur.charAt(i) != '(' && cur.charAt(i) != ')') {
                    continue;
                }

                String temp = cur.substring(0, i) + cur.substring(i + 1);
                if (!vis.contains(temp)) {
                    q.add(temp);
                    vis.add(temp);
                }
            }
        }

        return ans;
    }

    private boolean check(String s) {
        int bal = 0;

        for (char c : s.toCharArray()) {
            if (c == '(') {
                bal++;
            } else if (c == ')') {
                bal--;
            }

            if (bal < 0) {
                return false;
            }
        }

        return (bal == 0);

    }
}
