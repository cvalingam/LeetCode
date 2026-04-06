// Approach: Compute total sum; if odd, impossible. Find split point where left prefix sum = sum/2.
// Time: O(n) Space: O(1)
class Solution {
    public boolean canSplit(int arr[]) {
        int sum = 0;
        for (int a : arr)
            sum += a;

        int temp = 0;
        for (int a : arr) {
            temp += a;
            if (temp == (sum - temp))
                return true;
        }

        return false;
    }
}