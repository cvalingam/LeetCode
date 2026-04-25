
import java.util.*;

class Solution {
    // Approach: Stack-based collision simulation on opposite-sign adjacent survivors.
    // Time: O(n) Space: O(n)

    public ArrayList<Integer> reducePairs(int[] arr) {
        Stack<Integer> st = new Stack<>();
        ArrayList<Integer> ans = new ArrayList<>();

        for (int i = 0; i < arr.length; i++) {
            int x = arr[i];
            boolean p = true;
            while (!st.isEmpty() && ((st.peek() < 0 && x > 0) || (st.peek() > 0 && x < 0))) {
                int a = Math.abs(x);
                int b = Math.abs(st.peek());
                if (a > b) {
                    st.pop();
                } else if (b > a) {
                    x = st.peek();
                    st.pop();
                } else {
                    st.pop();
                    p = false;
                    break;
                }
            }
            if (p) {
                st.push(x);
            }
        }

        while (!st.isEmpty()) {
            ans.add(st.peek());
            st.pop();

        }

        Collections.reverse(ans);

        return ans;
    }
}
