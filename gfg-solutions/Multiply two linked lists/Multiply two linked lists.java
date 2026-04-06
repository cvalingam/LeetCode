// Approach: Traverse both lists to compute their numeric values (mod 10^9+7), then multiply.
// Time: O(n+m) Space: O(1)
class Solution {
    long e = 1000000007;

    public long multiplyTwoLists(Node first, Node second) {
        long sum1 = 0, sum2 = 0;

        while (first != null) {
            sum1 = ((sum1 * 10) + first.data) % e;
            first = first.next;
        }

        while (second != null) {
            sum2 = ((sum2 * 10) + second.data) % e;
            second = second.next;
        }

        return (sum1 * sum2) % e;
    }
}