class Node {
    int data;
    Node next;

    Node(int key) {
        data = key;
        next = null;
    }
}

class Solution {
    public Node mergeSort(Node head) {
        if (head == null || head.next == null)
            return head;

        Node mid = findMid(head);
        Node left = head;
        Node right = mid.next;
        mid.next = null;

        left = mergeSort(left);
        right = mergeSort(right);

        Node result = merge(left, right);

        return result;
    }

    static Node findMid(Node head) {
        if (head == null || head.next == null)
            return head;

        Node slow = head;
        Node fast = head;

        while (fast != null && fast.next != null && fast.next.next != null) { // fast.next.next != null (Handle The Even
                                                                              // Length Linked List)
            slow = slow.next;
            fast = fast.next.next;
        }
        return slow;
    }

    static Node merge(Node list1, Node list2) {
        Node dummy = new Node(0);
        Node temp = dummy;
        while (list1 != null && list2 != null) {
            if (list1.data > list2.data) {
                temp.next = list2;
                list2 = list2.next;
            } else {
                temp.next = list1;
                list1 = list1.next;
            }
            temp = temp.next;
        }
        temp.next = (list1 != null) ? list1 : list2;
        
        return dummy.next;
    }
}