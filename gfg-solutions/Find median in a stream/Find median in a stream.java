class Solution {
    public ArrayList<Double> getMedian(int[] arr) {
        ArrayList<Double> ans = new ArrayList<>();
        ArrayList<Integer> sorted = new ArrayList<>();
        boolean isOdd = true;
        for (int num : arr) {
            add(sorted, num);
            int mid = sorted.size() / 2;
            if (isOdd)
                ans.add((double) sorted.get(mid));
            else {
                double m1 = (double) sorted.get(mid);
                double m2 = (double) sorted.get(mid - 1);
                ans.add((m1 + m2) / 2d);
            }

            isOdd = !isOdd;
        }
        
        return ans;
    }

    void add(ArrayList<Integer> list, int num) {
        if (list.size() == 0 || list.get(list.size() - 1) <= num) {
            list.add(num);
            return;
        }

        if (list.get(0) > num)
            list.add(0, num);
        else {
            int high = list.size() - 1;
            int low = 0;
            int pos = -1;
            while (low <= high) {
                int mid = (low + high) / 2;
                if (list.get(mid) <= num)
                    low = mid + 1;
                else {
                    pos = mid;
                    high = mid - 1;
                }
            }

            list.add(pos, num);
        }
    }
}