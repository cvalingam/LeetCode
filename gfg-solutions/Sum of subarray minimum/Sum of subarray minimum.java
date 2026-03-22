import java.util.Stack;

class Solution {
    public int sumSubMins(int[] arr) {
        final int MOD = 1_000_000_007;
        int n = arr.length;
        int[] prev = new int[n];
        int[] next = new int[n];
        Stack<Integer> stack = new Stack<>();

        // Find Previous Less Element for each index
        for (int i = 0; i < n; i++) {
            while (!stack.isEmpty() && arr[stack.peek()] > arr[i])
                stack.pop();
            
            prev[i] = stack.isEmpty() ? -1 : stack.peek();
            stack.push(i);
        }

        stack.clear();

        // Find Next Less or Equal Element for each index
        for (int i = n - 1; i >= 0; i--) {
            while (!stack.isEmpty() && arr[stack.peek()] >= arr[i])
                stack.pop();
            
            next[i] = stack.isEmpty() ? n : stack.peek();
            stack.push(i);
        }

        long sum = 0L;
        for (int i = 0; i < n; i++) {
            long left = i - prev[i];
            long right = next[i] - i;
            sum = (sum + arr[i] * left % MOD * right % MOD) % MOD;
        }
        return (int) sum;
    }
}
