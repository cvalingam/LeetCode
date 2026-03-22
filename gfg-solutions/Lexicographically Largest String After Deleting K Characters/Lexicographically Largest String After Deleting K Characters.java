import java.util.*;

class Solution {
    public String maxSubseq(String s, int k) {
        Stack<Character> st = new Stack<>();
        int n = s.length();
        int count = k;

        for (char i : s.toCharArray()) {
            if (st.isEmpty())
                st.push(i);
            else {
                while (!st.isEmpty() && count > 0 && st.peek() < i) {
                    st.pop();
                    count--;
                }
                st.push(i);
            }
        }

        while (st.size() > n - k)
            st.pop();

        StringBuilder ans = new StringBuilder();

        while (!st.isEmpty())
            ans.append(st.pop());

        return ans.reverse().toString();
    }
}