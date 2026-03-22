import java.util.*;

class Solution {

    int Maximize(int arr[]) {
        Arrays.sort(arr);
        
        long sum = 0; 
        int mod = (int)1e9 + 7;
        
        for(int i = 0; i < arr.length; i++)
            sum = (sum + (long)arr[i] * i) % mod;
        
        return (int)sum;
    }
}
