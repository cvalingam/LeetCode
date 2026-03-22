class Solution {
    static ArrayList<Integer> modifyAndRearrangeArr(int arr[]) {
        for (int i = 1; i < arr.length; i++) {
            if (arr[i - 1] == arr[i]) {
                arr[i - 1] = (arr[i - 1]) * 2;
                arr[i] = 0;
            }
        }

        ArrayList<Integer> ans = new ArrayList<>();
        for (int num : arr) {
            if (num != 0)
                ans.add(num); // Autoboxing from int to Integer
        }
        int rs = arr.length - ans.size();
        while (rs > 0) {
            ans.add(0);
            rs--;
        }

        return ans;
    }
}
