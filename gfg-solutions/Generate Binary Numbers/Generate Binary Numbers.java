import java.util.*;

class Solution {
    public ArrayList<String> generateBinary(int n) {
        Queue<String> q = new LinkedList<>();
        ArrayList<String> ans = new ArrayList<>();

        q.add("1");

        while (n-- != 0) {
            String curr = q.peek();
            ans.add(q.poll());
            q.add(curr + "0");
            q.add(curr + "1");
        }

        return ans;
    }
}
