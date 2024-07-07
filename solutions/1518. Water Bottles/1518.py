class Solution(object):
    def numWaterBottles(self, numBottles, numExchange):
        """
        :type numBottles: int
        :type numExchange: int
        :rtype: int
        """

        ans = numBottles

        while numBottles >= numExchange:
            numBottles -= numExchange
            ans += 1
            numBottles += 1

        return ans
        