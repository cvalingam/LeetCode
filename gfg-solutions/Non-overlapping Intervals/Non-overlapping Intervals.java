class Solution {
    static int minRemoval(int arr[][]) {
        Arrays.sort(arr, (a, b) -> (a[1] - b[1]));
        int s = arr[0][0];
        int e = arr[0][1];
        int cnt = 0;
        for (int i = 1; i < arr.length; i++) {
            if (Math.max(s, arr[i][0]) < Math.min(e, arr[i][1]))
                cnt++;
            else {
                s = arr[i][0];
                e = arr[i][1];
            }
        }
        
        return cnt;
    }
}