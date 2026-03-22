class Solution {
    public int median(int[][] mat) {
        int n = mat.length;
        int m = mat[0].length;
        int med = (n * m) / 2 + 1;
        int[] counter = new int[2001];
        for (int i = 0; i < mat.length; i++) {
            for (int j = 0; j < mat[0].length; j++) {
                counter[mat[i][j]]++;
            }
        }

        int total = 0;
        for (int i = 1; i < 2001; i++) {
            total += counter[i];
            if (total >= med)
                return i;
        }
        
        return -1;
    }
}