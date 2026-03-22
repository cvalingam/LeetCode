class Solution {

    public boolean isValid(String str) {
        String[] arr = str.split("\\.", -1);

        for (String s : arr) {
            if (s.length() <= 0 || s.length() > 3)
                return false;

            int num = Integer.parseInt(s);
            if (num > 255)
                return false;
        }

        return true;
    }
}