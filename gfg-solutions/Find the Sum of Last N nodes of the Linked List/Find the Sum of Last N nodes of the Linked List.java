class Solution {

    // Return the sum of last k nodes
    public int sumOfLastN_Nodes(Node head, int n) {
        Node fast = head;
        Node slow = head;
        int sum = 0;
        int count = 0;
        while (fast != null) {
            sum = sum + fast.data;
            fast = fast.next;
            if (count >= n) {
                sum = sum - slow.data;
                slow = slow.next;
            }
            count++;
        }
        return sum;
    }
}