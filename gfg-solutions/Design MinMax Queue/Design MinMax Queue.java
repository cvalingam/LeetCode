import java.util.*;

class SpecialQueue {

    class Node {
        int val;
        Node next;

        Node(int val) {
            this.val = val;
        }
    }

    class Entry {
        Node node;
        int val;

        Entry(Node node, int val) {
            this.node = node;
            this.val = val;
        }
    }

    Node front, rear;
    HashSet<Node> active;
    PriorityQueue<Entry> maxHeap, minHeap;

    public SpecialQueue() {
        rear = new Node(-1);
        front = rear;
        active = new HashSet<>();
        maxHeap = new PriorityQueue<>((a, b) -> b.val - a.val);
        minHeap = new PriorityQueue<>((a, b) -> a.val - b.val);
    }

    public void enqueue(int val) {
        Node node = new Node(val);
        rear.next = node;
        rear = node;
        active.add(node);
        maxHeap.add(new Entry(node, val));
        minHeap.add(new Entry(node, val));
    }

    public void dequeue() {
        active.remove(front.next);
        front = front.next;
    }

    public int getFront() {
        return front.next.val;
    }

    public int getMin() {
        cleanMin();
        return minHeap.peek().val;
    }

    public int getMax() {
        cleanMax();
        return maxHeap.peek().val;
    }

    private void cleanMin() {
        while (!minHeap.isEmpty() && !active.contains(minHeap.peek().node))
            minHeap.poll();
    }

    private void cleanMax() {
        while (!maxHeap.isEmpty() && !active.contains(maxHeap.peek().node))
            maxHeap.poll();
    }
}