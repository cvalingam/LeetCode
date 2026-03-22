class Solution {
    public int getSingle(int[] arr) {
        int res = 0;

        for (int i = 0; i < 32; i++) {
            int bitsum = 0;
            for (int num : arr) {
                if (((num >> i) & 1) != 0)
                    bitsum++;
            }
            
            if (bitsum % 3 != 0)
                res |= (1 << i);
        }
        return res;
    }
}