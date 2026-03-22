class Solution:
    def compareFrac (self, str):
        
        arr = str.split(',')
        m = arr[0]
        n = arr[1][1:]
        
        a = arr[0].split('/')
        b = arr[1].split('/')
        
        
        x = int(a[0]) / int(a[1])
        y = int(b[0]) / int(b[1])
        
        
        if x > y : return m  
        elif y > x : return n   
        else : return 'equal'  