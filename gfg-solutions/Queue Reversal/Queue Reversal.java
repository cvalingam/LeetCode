import java.util.*;

class Solution {
    public void reverseQueue(Queue<Integer> q) {
        Stack<Integer> st = new Stack<>();

        while (q.size() > 0)
            st.push(q.remove());

        while (st.size() > 0)
            q.add(st.pop());
    }
}