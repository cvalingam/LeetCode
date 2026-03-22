class Solution {
    public ArrayList<ArrayList<String>> anagrams(String[] arr) {
        ArrayList<ArrayList<String>> res = new ArrayList<>();
        HashMap<String, Integer> mp = new HashMap<>();
        for (int i = 0; i < arr.length; i++) {
            String s = arr[i];
            char[] chars = s.toCharArray();
            Arrays.sort(chars);
            s = new String(chars);
            if (!mp.containsKey(s)) {
                mp.put(s, res.size());
                res.add(new ArrayList<>());
            }
            res.get(mp.get(s)).add(arr[i]);
        }
        return res;
    }
}