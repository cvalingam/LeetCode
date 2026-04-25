
import java.util.*;

class Solution {

    /*
     * Approach:
     * Use a stack to maintain the current reduced sequence.
     * For each incoming value x, resolve conflicts while the top of stack and x
     * have opposite signs. Compare absolute values:
     * 1) |x| > |top|: top is removed, x may continue colliding.
     * 2) |x| < |top|: x is removed (implemented by replacing x with top and popping).
     * 3) |x| == |top|: both are removed.
     *
     * This is the same collision pattern as the classic asteroid-collision idea,
     * and guarantees each element is pushed/popped at most once.
     *
     * Time Complexity: O(n)
     * Space Complexity: O(n)
     */

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
