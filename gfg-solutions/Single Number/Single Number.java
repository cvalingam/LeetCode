// Approach: XOR all elements. Paired elements cancel; the unpaired element remains.
// Time: O(n) Space: O(1)
class Solution {
    int getSingle(int arr[]) {
        int ans = 0;
        for (int i = 0; i < arr.length; i++)
            ans = ans ^ arr[i];

        return ans;
    }
}