import java.util.*;

class Solution {
    public int hIndex(int[] citations) {
        int maxCitation = 0;
        for (int citation : citations)
            maxCitation = Math.max(maxCitation, citation);

        int[] count = new int[maxCitation + 2];
        for (int citation : citations) {
            count[0]++;
            count[citation + 1]--;
        }

        for (int i = 1; i < count.length; i++)
            count[i] += count[i - 1];

        for (int i = count.length - 1; i >= 0; i--) {
            if (count[i] >= i)
                return i;
        }

        return 0;
    }
}

class Solution1 {
    public int hIndex(int[] citations) {
        int n = citations.length;
        int index = 1;
        int count = 0;
        Arrays.sort(citations);
        if (citations[n - 1] == 0)
            return 0;
        
        for (int i = n - 1; i >= 0; i--) {
            if (citations[i] >= index) {
                count++;
                index++;
            }
        }
        return count;
    }
}