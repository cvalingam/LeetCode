import java.util.*;

class Solution {
    public ArrayList<Integer> asciirange(String s) {
        int n = s.length();
        int pre[] = new int[n];
        int next[] = new int[n];
        ArrayList<Integer> res = new ArrayList<>();
        HashSet<Character> set = new HashSet<>();
        pre[0] = s.charAt(0);
        next[n - 1] = s.charAt(n - 1);
        for (int i = 1; i < n; i++)
            pre[i] = pre[i - 1] + s.charAt(i);

        for (int i = n - 2; i >= 0; i--)
            next[i] = next[i + 1] + s.charAt(i);

        for (int i = 0; i < n; i++) {
            char ch = s.charAt(i);
            if (set.contains(ch))
                continue;
            set.add(ch);
            int val = pre[n - 1] - (pre[s.indexOf(ch)] + next[s.lastIndexOf(ch)]);
            if (val > 0)
                res.add(val);
        }
        
        return res;
    }
}