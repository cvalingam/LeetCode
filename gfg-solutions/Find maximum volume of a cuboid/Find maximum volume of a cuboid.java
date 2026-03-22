class Solution {

    double maxVolume(double perimeter, double area) {
        double l = (perimeter - Math.sqrt(Math.pow(perimeter, 2) - 24 * area)) / 12;
        double h = (perimeter / 4) - 2 * l;
        
        return l * l * h;
    }
}