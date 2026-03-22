class Solution {
    // Function to find the majority elements in the array
    public List<Integer> findMajority(List<Integer> nums) {
        int n = nums.size(); // size of the array

        int cnt1 = 0, cnt2 = 0; // counts
        int el1 = Integer.MIN_VALUE; // element 1
        int el2 = Integer.MIN_VALUE; // element 2

        // applying the Extended Boyer Moore's Voting Algorithm:
        for (int i = 0; i < n; i++) {
            if (cnt1 == 0 && el2 != nums.get(i)) {
                cnt1 = 1;
                el1 = nums.get(i);
            } else if (cnt2 == 0 && el1 != nums.get(i)) {
                cnt2 = 1;
                el2 = nums.get(i);
            } else if (nums.get(i) == el1)
                cnt1++;
            else if (nums.get(i) == el2)
                cnt2++;
            else {
                cnt1--;
                cnt2--;
            }
        }

        List<Integer> ls = new ArrayList<>(); // list of answers

        // Manually check if the stored elements in
        // el1 and el2 are the majority elements:
        cnt1 = 0;
        cnt2 = 0;
        for (int i = 0; i < n; i++) {
            if (nums.get(i) == el1)
                cnt1++;
            if (nums.get(i) == el2)
                cnt2++;
        }

        int mini = (int) (n / 3) + 1;
        if (cnt1 >= mini)
            ls.add(el1);
        if (cnt2 >= mini && el2 != el1)
            ls.add(el2);

        if (ls.size() == 0)
            ls.add(-1);

        return ls;
    }
}
