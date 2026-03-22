class Solution {
    public int findMaxSum(int arr[]) {
        if (arr.length == 0)
            return 0;
        if (arr.length == 1)
            return arr[0];

        int prev2 = 0;
        int prev = arr[0];

        for (int i = 1; i < arr.length; i++) {
            int take = arr[i];
            if (i > 1)
                take += prev2;
            int notTake = prev;

            int curr = Math.max(take, notTake);
            prev2 = prev;
            prev = curr;
        }

        return prev;
    }
}