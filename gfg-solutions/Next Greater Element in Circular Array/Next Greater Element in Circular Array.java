import java.util.*;

class Solution {
    public ArrayList<Integer> nextLargerElement(int[] nums) {
        int n = nums.length;
        ArrayList<Integer> res = new ArrayList<>(Collections.nCopies(n, -1));
        Stack<Integer> stack = new Stack<>(); // Store indices

        // Loop through twice to simulate circular array
        for (int i = 0; i < 2 * n; i++) {
            int num = nums[i % n];

            while (!stack.isEmpty() && nums[stack.peek()] < num) {
                int idx = stack.pop();
                res.set(idx, num);
            }

            if (i < n)
                stack.push(i);
        }

        return res;
    }
}