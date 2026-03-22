class Solution {
    // Function to find maximum number of consecutive steps
    // to gain an increase in altitude with each step.
    public int maxStep(int arr[]) {
        int res = 0, count = 0;
        for (int i = 1; i < arr.length; i++) {
            if (arr[i - 1] < arr[i]) {
                count++;
            } else {
                count = 0;
            }
            res = Math.max(res, count);
        }
        return res;
    }
}