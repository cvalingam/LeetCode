class Solution {
    public static ArrayList<Integer> getPrimes(int n) {
        int[] prime = new int[n + 1];
        prime[0] = prime[1] = 1;
        ArrayList<Integer> ans = new ArrayList<Integer>();
        
        for(int i = 2; i * i <= n; i++)
        {
            if(prime[i] == 0)
            {
                for(int j = i * i; j <= n; j += i)
                    prime[j] = 1;
            }
        }
        
        for(int i = 2; i <= n / 2; i++)
        {
            if(prime[i] == 0 && prime[n - i] == 0)
            {
                ans.add(i);
                ans.add(n - i);
                return ans;
            }
        }
        
        ans.add(-1);
        ans.add(-1);
        return ans;
    }
}
