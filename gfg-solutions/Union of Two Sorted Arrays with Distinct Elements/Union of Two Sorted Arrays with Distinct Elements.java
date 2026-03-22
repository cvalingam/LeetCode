class Solution {
    // Function to return a list containing the union of the two arrays.
    public static ArrayList<Integer> findUnion(int a[], int b[]) {
        HashSet<Integer> set = new HashSet<>();
        ArrayList<Integer> union = new ArrayList<>();

        for (int i : a)
            set.add(i);

        for (int j : b) {
            if (!set.contains(j))
                set.add(j);
        }
        for (int k : set)
            union.add(k);

        Collections.sort(union);
        return union;
    }
}
