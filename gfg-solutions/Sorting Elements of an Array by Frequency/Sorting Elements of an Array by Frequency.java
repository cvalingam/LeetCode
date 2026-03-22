import java.util.*;

class Solution {
    // Function to sort the array according to frequency of elements.
    public ArrayList<Integer> sortByFreq(int arr[]) {
        HashMap<Integer, Integer> map = new HashMap<>();
        ArrayList<Integer> list = new ArrayList<>();

        for (int i = 0; i < arr.length; i++) {
            map.put(arr[i], map.getOrDefault(arr[i], 0) + 1);
        }

        List<Map.Entry<Integer, Integer>> mapList = new LinkedList<>(map.entrySet());

        mapList.sort((a, b) -> {
            int freqCompare = b.getValue().compareTo(a.getValue());
            int valueCompare = a.getKey().compareTo(b.getKey());
            if (freqCompare == 0) {
                return valueCompare;
            } else {
                return freqCompare;
            }
        });

        for (Map.Entry<Integer, Integer> entry : mapList) {
            for (int i = 0; i < entry.getValue(); i++) {
                list.add(entry.getKey());
            }
        }

        return list;
    }
}