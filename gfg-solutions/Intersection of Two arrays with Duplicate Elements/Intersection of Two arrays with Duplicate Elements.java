class Solution {
    public ArrayList<Integer> intersectionWithDuplicates(int[] a, int[] b) {
        ArrayList<Integer> li = new ArrayList<>();
        int n = a.length;
        int m = b.length;
        HashSet<Integer> hs1 = new HashSet<>();
        HashSet<Integer> hs2 = new HashSet<>();
        for (int i = 0; i < n; i++) {
            int temp = a[i];
            hs1.add(temp);
        }

        for (int i = 0; i < m; i++) {
            int temp = b[i];
            hs2.add(temp);
        }

        for (int key : hs1) {
            if (hs2.contains(key))
                li.add(key);
        }

        return li;
    }
}