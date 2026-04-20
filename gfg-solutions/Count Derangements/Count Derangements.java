
// Approach: Recursive DP using the derangement recurrence D(n) = (n-1) * (D(n-1) + D(n-2)).
// When placing element n, it can go to any of n-1 positions (not its own).
// For each chosen position i, either element i swaps with n (Case 1: D(n-2) sub-problems remain)
// or element i avoids position n (Case 2: D(n-1) sub-problems remain).
// Base cases: D(1) = 0, D(2) = 1.
// Time: O(2^n) Space: O(n)
class Solution {

    public int derangeCount(int n) {
        // A dearrangement of n elements is a permutation, where no elements gets its original 
        // position.

        // so. for every elements we only have n-1 choices left, as the nth choice will be
        // the right position.
        //  We now focus on the element that originally belonged to position i
        // There are two possible cases
        // Case 1: Element i goes to position 1 and 1 goes to position of i every time, both position fixed
        // Case 2: Element i does NOT go to position 1
        if (n == 1) {
            return 0;
        }
        if (n == 2) {
            return 1;
        }

        return (n - 1) * (derangeCount(n - 1) + derangeCount(n - 2));

        // “why only 1?” usually comes up for the base case F(0) = 1
        // F(0) stands for number of 0 elements
        // Because there is exactly one way to do nothing
    }
};
