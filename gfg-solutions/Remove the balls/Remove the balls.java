import java.util.*;

class Solution {
    public int findLength(int[] color, int[] radius) {
        int n = color.length;
        Stack<Pair> st = new Stack<>();
        for (int i = 0; i < n; i++) {
            if (!st.isEmpty() && st.peek().col == color[i] && st.peek().rad == radius[i])
                st.pop();
            else
                st.push(new Pair(color[i], radius[i]));
        }

        return st.size();
    }

    class Pair {
        int col;
        int rad;

        public Pair(int col, int rad) {
            this.col = col;
            this.rad = rad;
        }
    }
}