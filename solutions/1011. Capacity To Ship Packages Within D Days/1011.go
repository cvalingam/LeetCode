import "math"

func shipWithinDays(weights []int, days int) int {
    maxEle := math.MinInt32;
    var sumOfW int

    for i := 0; i < len(weights); i++ {
        if maxEle < weights[i] {
            maxEle = weights[i]
        }
        sumOfW += weights[i]
    }

    low := maxEle
    high := sumOfW
    ans := -1
    
    for low <= high {
        mid := (low + high) / 2
        daysRequired := getDaysRequired(weights, mid)

        if(daysRequired <= days) {
            ans = mid
            high = mid - 1
        } else {
            low = mid + 1
        }
    }

    return ans
}

func getDaysRequired(weights []int, capacity int) int {
    days := 1
    var load int

    for i := 0; i < len(weights); i++ {
        load += weights[i]
        if(load > capacity) {
            load = weights[i]
            days++
        }
    }

    return days
}