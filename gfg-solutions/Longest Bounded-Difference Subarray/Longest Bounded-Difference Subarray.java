import java.util.*;

class Solution {

    public ArrayList<Integer> longestSubarray(int[] arr, int x) {
        Deque<Integer> dq = new LinkedList<>();
        ArrayList<Integer> obj = new ArrayList<>();
        int max = arr[0];
        int min = arr[0];
        dq.addFirst(0);

        Deque<Integer> ans = new LinkedList<>();
        int maxc = 0;

        for (int i = 1; i < arr.length; i++) {
            if ((Math.abs(arr[i] - max) <= x) && (Math.abs(arr[i] - min) <= x)) {
                dq.addLast(i);
                min = (min < arr[i]) ? min : arr[i];
                max = (max > arr[i]) ? max : arr[i];
            } else {
                if (dq.size() > maxc) {
                    maxc = dq.size();
                    ans = new LinkedList<>(dq);
                } else if (dq.size() == maxc && ans.getFirst() > dq.getFirst())
                    ans = new LinkedList<>(dq);

                Deque<Integer> dq2 = new LinkedList<>();
                min = arr[i];
                max = arr[i];
                while (dq.peekLast() != null && Math.abs(arr[dq.peekLast()] - arr[i]) <= x) {
                    dq2.addFirst(dq.pollLast());
                    if (arr[dq2.peekFirst()] > max)
                        max = arr[dq2.getFirst()];
                    if (arr[dq2.peekFirst()] < min)
                        min = arr[dq2.getFirst()];
                }
                dq2.addLast(i);
                dq.clear();
                dq = dq2;
            }
            // System.out.println(dq+" "+ans);
        }

        if (dq.size() > maxc) {
            maxc = dq.size();
            ans = new LinkedList<>(dq);
        } else if (dq.size() == maxc && ans.getFirst() > dq.getFirst())
            ans = new LinkedList<>(dq);

        for (int i : ans)
            obj.add(arr[i]);

        return obj;
    }
}

// Version 2
class Solution1 {
    public ArrayList<Integer> longestSubarray(int[] arr, int x) {
        int n = arr.length;

        // maxHeap stores (-value, index), minHeap stores (value, index)
        PriorityQueue<int[]> maxHeap = new PriorityQueue<>((a, b) -> b[0] - a[0]);
        PriorityQueue<int[]> minHeap = new PriorityQueue<>((a, b) -> a[0] - b[0]);

        int l = 0, bestLen = 0, bestStart = 0;

        for (int r = 0; r < n; r++) {
            maxHeap.offer(new int[] { arr[r], r });
            minHeap.offer(new int[] { arr[r], r });

            // shrink window while condition violated
            while (!maxHeap.isEmpty() && !minHeap.isEmpty() &&
                    maxHeap.peek()[0] - minHeap.peek()[0] > x) {
                l++;
                // remove elements that are outside window
                while (!maxHeap.isEmpty() && maxHeap.peek()[1] < l)
                    maxHeap.poll();
                while (!minHeap.isEmpty() && minHeap.peek()[1] < l)
                    minHeap.poll();
            }

            // update answer if longer window found
            int len = r - l + 1;
            if (len > bestLen) {
                bestLen = len;
                bestStart = l;
            }
        }

        // build result
        ArrayList<Integer> result = new ArrayList<>();
        for (int i = 0; i < bestLen; i++)
            result.add(arr[bestStart + i]);

        return result;
    }
}