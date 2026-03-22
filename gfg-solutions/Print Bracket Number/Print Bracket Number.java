import java.util.ArrayList;

class Solution {
    ArrayList<Integer> bracketNumbers(String str) {
        ArrayList<Integer> ans = new ArrayList<>();
        numbers(str, ans);
        return ans;
    }

    static void numbers(String str, ArrayList<Integer> ans) {
        ArrayList<Integer> opens = new ArrayList<>();
        int n = str.length();
        int open = 0;
        int close = 0;
        for (int i = 0; i < n; i++) {
            if (str.charAt(i) == '(') {
                open++;
                opens.add(open);
                ans.add(open);
            } else if (str.charAt(i) == ')') {
                close = opens.get(opens.size() - 1);
                ans.add(close);
                opens.remove(opens.size() - 1);
            }
        }
    }
};