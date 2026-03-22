class Node {
    int data;
    Node next, random;

    Node(int d) {
        data = d;
        next = random = null;

    }
}

class Solution {
    // Function to clone a linked list with next and random pointer.
    Node copyList(Node head) {
        Node temp = head;
        Node copy = new Node(0);
        Node point = copy;
        while (temp != null) {
            point.next = new Node(temp.data);
            temp = temp.next;
            point = point.next;
        }
        temp = head;
        point = copy.next;
        while (point != null) {
            if (temp.random != null) {

                Node randomPoint = copy.next;
                while (randomPoint != null) {
                    if (randomPoint.data == temp.random.data) {
                        point.random = randomPoint;
                        break;
                    }
                    randomPoint = randomPoint.next;
                }
            }
            point = point.next;
            temp = temp.next;

        }
        return copy.next;
    }
}
