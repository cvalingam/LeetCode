import java.util.*;

class Solution {
    public int sumSubMins(int[] arr) {
        int n = arr.length;
        long res = 0;
        int[] left = new int[n];
        int[] right = new int[n];
        Stack<Integer> stack = new Stack<>();

        // Previous Less Element
        for (int i = 0; i < n; i++) {
            while (!stack.isEmpty() && arr[stack.peek()] > arr[i])
                stack.pop();

            left[i] = stack.isEmpty() ? i + 1 : i - stack.peek();
            stack.push(i);
        }

        stack.clear();

        // Next Less Element
        for (int i = n - 1; i >= 0; i--) {
            while (!stack.isEmpty() && arr[stack.peek()] >= arr[i])
                stack.pop();

            right[i] = stack.isEmpty() ? n - i : stack.peek() - i;
            stack.push(i);
        }

        for (int i = 0; i < n; i++)
            res += (long) arr[i] * left[i] * right[i];

        return (int) res;
    }
}
