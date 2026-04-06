// Approach: Simulate the process: rotate array and delete specified element per round.
// Time: O(n^2) Space: O(n)
class Solution {
    public static int rotateDelete(ArrayList<Integer> arr) {
        boolean flag = true;
        int n = arr.size();
        int x = n / 2;

        while (x != 0) {
            if (flag) {
                n -= 1;
                flag = false;
            } else {
                n -= 2;
                flag = true;
            }
            x--;
        }
        return arr.get(n);
    }
}