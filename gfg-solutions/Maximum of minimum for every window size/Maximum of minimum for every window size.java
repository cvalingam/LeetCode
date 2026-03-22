class Solution {
    public ArrayList<Integer> maxOfMins(int[] arr) {
        int n = arr.length;
        int[] left = new int[n];
        int[] right = new int[n];
        Stack<Integer> stack = new Stack<>();

        for (int i = 0; i < n; i++) {
            while (!stack.isEmpty() && arr[stack.peek()] >= arr[i])
                stack.pop();

            left[i] = stack.isEmpty() ? -1 : stack.peek();
            stack.push(i);
        }

        stack.clear();

        for (int i = n - 1; i >= 0; i--) {
            while (!stack.isEmpty() && arr[stack.peek()] >= arr[i])
                stack.pop();

            right[i] = stack.isEmpty() ? n : stack.peek();
            stack.push(i);
        }

        ArrayList<Integer> ans = new ArrayList<>();
        for (int i = 0; i < n; i++)
            ans.add(0);

        for (int i = 0; i < n; i++) {
            int winSize = right[i] - left[i] - 1;
            ans.set(winSize - 1, Math.max(ans.get(winSize - 1), arr[i]));
        }

        for (int i = n - 2; i >= 0; i--)
            ans.set(i, Math.max(ans.get(i), ans.get(i + 1)));

        return ans;
    }
}