class Solution {

    public boolean checkSorted(List<Integer> arr) {
        int minSwap = 0;
        for (int i = 0; i < arr.size(); i++) {
            while (i + 1 != arr.get(i)) {
                int ind = arr.get(i) - 1;
                int t = arr.get(ind);
                arr.set(ind, arr.get(i));
                arr.set(i, t);
                minSwap++;
            }
        }

        if (minSwap == 0 || minSwap == 2)
            return true;
        return false;
    }
}