func reverseString(s []byte)  {
    l := 0
    r := len(s) - 1
    for l <= r {
        temp := s[l]
        s[l] = s[r]
        s[r] = temp
        l++
        r--
    }
}