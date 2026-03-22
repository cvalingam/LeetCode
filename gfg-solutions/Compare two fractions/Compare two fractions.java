class Solution {

    String compareFrac(String str) {
        String[] fractions = str.split(",");

        String[] fraction1 = fractions[0].split("/");
        double a = Double.parseDouble(fraction1[0]);
        double b = Double.parseDouble(fraction1[1]);

        String[] fraction2 = fractions[1].split("/");
        double c = Double.parseDouble(fraction2[0]);
        double d = Double.parseDouble(fraction2[1]);

        double res1 = (a / b);
        double res2 = (c / d);

        if (res1 == res2)
            return "equal";
        else if (res1 > res2)
            return fraction1[0] + "/" + fraction1[1];
        else
            return fraction2[0] + "/" + fraction2[1];
    }
}
