class Solution {
    // Returns count buildings that can see sunlight
    public int countBuildings(int[] height) {
        int maxi = height[0];
        int cnt = 1;

        for (int i = 1; i < height.length; i++) {
            if (height[i] > maxi) {
                maxi = height[i];
                cnt++;
            }

        }
        return cnt;
    }
}