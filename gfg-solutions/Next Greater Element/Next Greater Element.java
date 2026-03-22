class Solution {
    // Function to find the next greater element for each element of the array.
    public ArrayList<Integer> nextLargerElement(int[] arr) {
        ArrayList<Integer> ans = new ArrayList<>(Collections.nCopies(arr.length, -1));
        Stack<Integer> s = new Stack<>();
        for (int i = 0; i < arr.length; i++) {
            while (!s.isEmpty() && arr[s.peek()] < arr[i])
                ans.set(s.pop(), arr[i]);

            s.push(i);
        }
        return ans;
    }
}