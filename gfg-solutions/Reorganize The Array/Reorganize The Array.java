class Solution {
    public List<Integer> rearrange(List<Integer> arr) {
        int n = arr.size();
        List<Integer> ans = new ArrayList<Integer>();

        for (int i = 0; i < arr.size(); i++)
            ans.add(-1);

        for (int ele : arr) {
            if (ele >= 0 && ele < arr.size())
                ans.set(ele, ele);
        }

        return ans;
    }
}