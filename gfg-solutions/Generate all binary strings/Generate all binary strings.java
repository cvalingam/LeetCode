import java.util.*;

class Solution {
    public ArrayList<String> binstr(int n) {
        ArrayList<String> res = new ArrayList<>();
        if (n <= 0)
            return res;

        char[] cur = new char[n];
        generate(0, n, cur, res);
        return res;

    }

    private void generate(int idx, int n, char[] cur, ArrayList<String> res) {
        if (idx == n) {
            res.add(new String(cur));
            return;
        }

        cur[idx] = '0';
        generate(idx + 1, n, cur, res);

        cur[idx] = '1';
        generate(idx + 1, n, cur, res);
    }
}
