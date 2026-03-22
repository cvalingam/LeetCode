class Solution {

    public int maxWater(int arr[]) {
        int n = arr.length;
        int s = 0;
        int e = n - 1;
        int m = 0;

        while (s <= e) {
            int w = e - s;
            int h = Math.min(arr[s], arr[e]);
            m = Math.max(m, w * h);

            if (arr[s] < arr[e])
                s++;
            else
                e--;
        }
        
        return m;
    }
}