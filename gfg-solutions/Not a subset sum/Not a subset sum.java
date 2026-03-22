class Solution {
    public long findSmallest(int[] arr) {
        int res = 1;
        for (int i = 0; i <= arr.length - 1; i++) {
            // checking the first elemant is less than res
            if (res < arr[0])
                return res;
            // checking if arr[i] is greater thn res then we cannot add
            if (arr[i] > res)
                break;
            else // checking the number is present or not if present than add
                res = res + arr[i];
        }

        return res;
    }
}