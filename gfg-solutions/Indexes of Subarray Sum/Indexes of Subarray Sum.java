
class Solution {
    static ArrayList<Integer> subarraySum(int[] arr, int target) {
        ArrayList<Integer> obj = new ArrayList<>();
        for (int i = 0; i < arr.length; i++) {
            int sum = 0;
            for (int j = i; j < arr.length; j++) {
                sum += arr[j];
                if (sum == target) {
                    obj.add(i + 1);
                    obj.add(j + 1);
                    return obj;
                }
                if (sum > target)
                    break;
            }
        }
        obj.add(-1);
        return obj;// code here
    }
}
