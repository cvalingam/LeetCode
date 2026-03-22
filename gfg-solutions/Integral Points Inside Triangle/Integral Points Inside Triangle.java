class Solution {
    long InternalCount(long p[], long q[], long r[]) {
        long x1 = p[0], y1 = p[1];
        long x2 = q[0], y2 = q[1];
        long x3 = r[0], y3 = r[1];
        
        long points = getEdgePoint(x1, y1, x2, y2) 
                    + getEdgePoint(x2, y2, x3, y3) 
                    + getEdgePoint(x3, y3, x1, y1) + 3;
                    
        long area = Math.abs(x1 * (y2 - y3) + x2 * (y3 - y1) + x3 * (y1 - y2));
        
        return (area - points + 2) / 2;
    }
    
    long gcd(long a, long b) 
    {
        if(b == 0)
            return a;
            
        return gcd(b, a % b);
    }
    
    long getEdgePoint(long x1, long y1, long x2, long y2)
    {
        if(x1 == x2)
            return Math.abs(y2 - y1) - 1;
            
        if(y1 == y2)
            return Math.abs(x2 - x1) - 1;
            
        return gcd(Math.abs(x2 - x1), Math.abs(y2 - y1)) - 1;
    }
};