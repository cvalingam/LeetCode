func minDays(bloomDay []int, m int, k int) int {
    n := len(bloomDay)

    val := m * k;

    if(val > n) {
        return -1
    }

    maxElement := bloomDay[0]
    minElement := bloomDay[0]

    for i := 0; i < n; i++ {
        maxElement = max(maxElement, bloomDay[i])
        minElement = min(minElement, bloomDay[i])
    }

    low := minElement
    high := maxElement
    ans := high

    for low <= high {
        mid := (low + high) / 2;

        if possible(bloomDay, mid, m, k) {
            ans = mid
            high = mid - 1
        } else {
            low = mid + 1
        }
    }

    return ans
}

func possible(bloomDay []int, day int, m int, k int) bool {
    cnt := 0
    bouquet := 0

    for i := 0; i < len(bloomDay); i++ {
        if bloomDay[i] <= day {
            cnt++
        } else {
            bouquet += cnt / k
            cnt = 0
        }
    }

    bouquet += cnt / k

    return bouquet >= m
}

func max(a int, b int) int {
    if(a > b) {
        return a
    }

    return b
}

func min(a int, b int) int {
    if(a > b) {
        return b
    }

    return a
}