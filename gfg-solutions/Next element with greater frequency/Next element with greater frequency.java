import java.util.*;

class Solution {
    public ArrayList<Integer> findGreater(int[] arr) {
        ArrayList<Integer> a = new ArrayList<>(Collections.nCopies(arr.length, -1));
        Map<Integer, Integer> m = new HashMap<>();
        Stack<Integer> s = new Stack<>();

        for (int i : arr)
            m.put(i, m.getOrDefault(i, 0) + 1);

        for (int i = arr.length - 1; i >= 0; i--) {
            while (!s.isEmpty() && m.get(s.peek()) <= m.get(arr[i]))
                s.pop();

            if (!s.isEmpty())
                a.set(i, s.peek());

            s.push(arr[i]);
        }
        
        return a;
    }
}