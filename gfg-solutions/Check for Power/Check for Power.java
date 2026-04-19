
// Approach: Repeatedly multiply x starting from 1 until the product reaches or exceeds y.
// If x == 1, y must also equal 1 (since 1^k == 1 for all k).
// Otherwise keep multiplying: if the product equals y at any point, y is a power of x.
// Using a long prevents integer overflow during multiplication.
// Time: O(log_x(y)) Space: O(1)
class Solution {

    public boolean isPower(int x, int y) {
        long num = 1;
        if (x == 1) {
            return (y == 1);
        }
        while (num < y) {
            num *= x;
        }
        
        return (num == y);
    }
}
