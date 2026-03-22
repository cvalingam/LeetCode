class Solution {
    public static int getMaxArea(int arr[]) {
        Stack<Integer> st = new Stack<>();

        int i = 0, max = 0, n = arr.length;

        while (i < n || !st.isEmpty()) {

            if (i < n && (st.isEmpty() || arr[i] > arr[st.peek()]))
                st.add(i++);

            else
                max = Math.max(max, arr[st.pop()] * (st.isEmpty() ? i : i - st.peek() - 1));

        }
        return max;

    }
}