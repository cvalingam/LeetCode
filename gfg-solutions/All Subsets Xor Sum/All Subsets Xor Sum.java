class Solution {
    int subsetXORSum(int arr[]) {
        int or = 0;
        for (int x : arr) {
            or |= x;
        }

        int n = arr.length;
        return or * (1 << (n - 1));
    }
}