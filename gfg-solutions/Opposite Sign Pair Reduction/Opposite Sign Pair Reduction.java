
import java.util.*;

class Solution {

    /*
     * Rich Explanation:
     * We process the array left to right and keep a stack of elements that are
     * still alive after all reductions among processed elements.
     *
     * Key invariant:
     * After processing arr[0..i], stack stores exactly the reduced form of that
     * prefix in correct order.
     *
     * When current value x arrives, only stack top can conflict with x first.
     * A conflict happens only if signs are opposite.
     *
     * Conflict resolution by magnitude:
     * 1) |x| > |top| : top is eliminated, x may continue fighting next top.
     * 2) |x| < |top| : x is eliminated, and the surviving top value continues.
     * 3) |x| == |top|: both are eliminated.
     *
     * Why this is correct:
     * - Conflicts are local and sequential; x cannot skip top and interact with
     *   deeper elements before top is resolved.
     * - Each resolution exactly matches the problem rule, so invariant remains true.
     * - After loop ends, either x is destroyed or safely pushed.
     *
     * Complexity:
     * - Each number is pushed at most once and popped at most once.
     * - Total operations are linear.
     * Time  : O(n)
     * Space : O(n)
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
