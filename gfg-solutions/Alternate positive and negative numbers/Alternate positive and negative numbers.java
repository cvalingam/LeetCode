import java.util.*;

class Solution {
    void rearrange(ArrayList<Integer> arr) {
        Queue<Integer> p = new LinkedList<>();
        Queue<Integer> n = new LinkedList<>();

        for (int i = 0; i < arr.size(); i++) {
            if (arr.get(i) < 0)
                n.add(arr.get(i));
            else
                p.add(arr.get(i));
        }

        int i = 0;
        while (!p.isEmpty() && !n.isEmpty()) {
            arr.set(i++, p.poll());
            arr.set(i++, n.poll());
        }

        while (!p.isEmpty())
            arr.set(i++, p.poll());

        while (!n.isEmpty())
            arr.set(i++, n.poll());
    }
}