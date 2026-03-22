import java.util.*;

class Solution {

    class Pair implements Comparable<Pair> {
        int x;
        int y;
        int dist;

        Pair(int x, int y, int dist) {
            this.x = x;
            this.y = y;
            this.dist = dist;
        }

        @Override
        public int compareTo(Pair p2) {
            return this.dist - p2.dist;
        }
    }

    public int[][] kClosest(int[][] points, int k) {
        int[][] ans = new int[k][2];
        PriorityQueue<Pair> pq = new PriorityQueue<>();

        for (int i = 0; i < points.length; i++) {
            int x = points[i][0];
            int y = points[i][1];
            int dist = (x * x) + (y * y);

            pq.offer(new Pair(x, y, dist));
        }

        while (k > 0) {
            k--;
            Pair curr = pq.poll();
            ans[k][0] = curr.x;
            ans[k][1] = curr.y;
        }
        return ans;
    }
}

// Version 2
class Solution1 {
    public ArrayList<ArrayList<Integer>> kClosest(int[][] points, int k) {
        Arrays.sort(points, (p1, p2) -> {
            int dist1 = p1[0] * p1[0] + p1[1] * p1[1];
            int dist2 = p2[0] * p2[0] + p2[1] * p2[1];

            return Integer.compare(dist1, dist2);
        });

        ArrayList<ArrayList<Integer>> res = new ArrayList<>();

        for (int i = 0; i < k; i++) {
            int[] point = points[i];

            ArrayList<Integer> pointList = new ArrayList<>();
            pointList.add(point[0]);
            pointList.add(point[1]);

            res.add(pointList);
        }

        return res;
    }
}