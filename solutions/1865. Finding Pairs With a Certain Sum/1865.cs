public class FindSumPairs
{
    // Arrays to store the two input integer arrays
    private int[] nums1;
    private int[] nums2;
    // Dictionary to keep the frequency count of elements in the second array
    private Dictionary<int, int> frequencyMap = new Dictionary<int, int>();

    // Constructor initializes the class with two integer arrays
    public FindSumPairs(int[] nums1, int[] nums2)
    {
        this.nums1 = nums1;
        this.nums2 = nums2;

        // Populating the frequency map with the count of each number in nums2
        foreach (int value in nums2)
        {
            if (frequencyMap.ContainsKey(value))
                frequencyMap[value]++;
            else
                frequencyMap[value] = 1;
        }
    }

    // Method that increments an element of nums2 at a given index by a given value
    public void Add(int index, int value)
    {
        // Obtain the original value at the given index in nums2
        int originalValue = nums2[index];
        // Decrement the frequency of the original value in the frequency map
        frequencyMap[originalValue]--;
        // Increment the original value by the given value and update in nums2
        nums2[index] += value;
        // Increment the frequency of the new value in the frequency map
        if (frequencyMap.ContainsKey(nums2[index]))
            frequencyMap[nums2[index]]++;
        else
            frequencyMap[nums2[index]] = 1;
    }

    // Method that counts the pairs across nums1 and nums2 that sum up to a given total
    public int Count(int total)
    {
        int count = 0;
        // Iterate through each value in nums1
        foreach (int value in nums1)
            // For the current value in nums1, check if there's a complement in nums2 that sums up to total
            count += frequencyMap.ContainsKey(total - value) ? frequencyMap[total - value] : 0;

        // Return the count of such pairs
        return count;
    }
}

/**
 * Your FindSumPairs object will be instantiated and called as such:
 * FindSumPairs obj = new FindSumPairs(nums1, nums2);
 * obj.Add(index,val);
 * int param_2 = obj.Count(tot);
 */