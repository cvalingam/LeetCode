// Approach: Each bit in elements contributes independently. Total XOR sum = OR of all elements * 2^(n-1).
// Time: O(n) Space: O(1)
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