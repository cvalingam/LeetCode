import java.util.*;

class Solution {
    public int findMaxDiff(int[] arr) {
        // code here
        int n = arr.length, maxDiff = 0;
        int leftSmaller[] = new int[n];
        int rightSmaller[] = new int[n];

        Stack<Integer> stk = new Stack<>();
        stk.push(0);
        for (int i = 1; i < n; i++) {
            while (!stk.isEmpty() && arr[stk.peek()] >= arr[i])
                stk.pop();
            leftSmaller[i] = stk.isEmpty() ? 0 : arr[stk.peek()];
            stk.push(i);
        }
        stk.clear();
        stk.push(n - 1);
        for (int i = n - 2; i >= 0; i--) {
            while (!stk.isEmpty() && arr[stk.peek()] >= arr[i])
                stk.pop();
            rightSmaller[i] = stk.isEmpty() ? 0 : arr[stk.peek()];
            stk.push(i);
        }

        for (int i = 0; i < n; i++)
            maxDiff = Math.max(maxDiff, Math.abs(leftSmaller[i] - rightSmaller[i]));

        return maxDiff;
    }
}
