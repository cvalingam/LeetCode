import java.util.*;

class Solution {
    public ArrayList<Integer> calculateSpan(int[] arr) {
        ArrayList<Integer> res = new ArrayList<>();
        Stack<Integer> st = new Stack<>();

        res.add(1);
        st.push(0);
        for (int i = 1; i < arr.length; i++) {
            while (!st.isEmpty() && arr[i] >= arr[st.peek()])
                st.pop();

            if (st.isEmpty())
                res.add(i + 1);
            else
                res.add(i - st.peek());

            st.push(i);
        }

        return res;
    }
}