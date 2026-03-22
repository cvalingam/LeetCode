class Node {
    Node next;
    int val;

    public Node(int data) {
        val = data;
        next = null;
    }
}

class Solution {
    Node primeList(Node head) {
        Node current = head;
        while (current != null) {
            current.val = nearestPrime(current.val);
            current = current.next;
        }
        return head;
    }

    // Check if a number is prime
    private boolean isPrime(int n) {
        if (n <= 1)
            return false;
        if (n == 2 || n == 3)
            return true;
        if (n % 2 == 0 || n % 3 == 0)
            return false;
        for (int i = 5; i * i <= n; i += 6) {
            if (n % i == 0 || n % (i + 2) == 0)
                return false;
        }
        return true;
    }

    // Find the nearest prime to a number
    private int nearestPrime(int n) {
        if (isPrime(n))
            return n;

        int low = n - 1, high = n + 1;

        while (true) {
            if (low > 0 && isPrime(low))
                return low;
            if (isPrime(high))
                return high;
            low--;
            high++;
        }
    }
}