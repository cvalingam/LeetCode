import java.util.*;

class Solution {
    public ArrayList<Integer> maxOfMins(int[] arr) {
        int n = arr.length;
        int[] res = new int[n];
        int[] lenArr = new int[n];
        Stack<Integer> s = new Stack<>();

        for (int i = 0; i < n; i++) {
            while (!s.isEmpty() && arr[s.peek()] >= arr[i]) {
                int top = s.pop();
                int windowSize = s.isEmpty() ? i : i - s.peek() - 1;
                lenArr[top] = windowSize;
            }
            s.push(i);
        }

        while (!s.isEmpty()) {
            int top = s.pop();
            int windowSize = s.isEmpty() ? n : n - s.peek() - 1;
            lenArr[top] = windowSize;
        }

        for (int i = 0; i < n; i++) {
            int windowSize = lenArr[i];
            if (windowSize > 0)
                res[windowSize - 1] = Math.max(res[windowSize - 1], arr[i]);
        }

        for (int i = n - 2; i >= 0; i--)
            res[i] = Math.max(res[i], res[i + 1]);

        ArrayList<Integer> ans = new ArrayList<>();
        for (int val : res)
            ans.add(val);

        return ans;
    }
}