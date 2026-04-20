/**
 * Rich structured explanations for LeetCode problems.
 * When present, the detail page renders these instead of the plain approach comment block.
 * Keys are problem numbers (integers).
 */
export interface RichExplanation {
  /** The key insight â€” why this approach works, in 2-4 sentences. */
  intuition: string
  /** Numbered algorithm steps. Each string is one step. */
  algorithm: string[]
  /** Optional concrete walkthrough of a small example. */
  example?: {
    input: string
    steps: string[]
    output: string
  }
  /** Optional list of common mistakes to avoid. */
  pitfalls?: string[]
}

const explanations: Record<number, RichExplanation> = {

  // â”€â”€â”€ 4. Median of Two Sorted Arrays â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
  4: {
    intuition:
      'The naive approach merges both arrays and picks the middle element â€” O(m+n). The insight is that we never actually need to merge. Instead, binary search for the correct partition index in the smaller array: once we know how many elements belong in the combined left half, the median falls out directly from the four elements at the boundary.',
    algorithm: [
      'Ensure nums1 is the smaller array (swap if needed) to keep binary search on the shorter side.',
      'Binary search the partition index `cut1` in nums1 from 0 to m. Derive `cut2 = (m+n+1)/2 - cut1` for nums2.',
      'The partition is valid when maxLeft1 â‰¤ minRight2 AND maxLeft2 â‰¤ minRight1.',
      'If maxLeft1 > minRight2, move cut1 left (high = cut1 âˆ’ 1). If maxLeft2 > minRight1, move cut1 right (low = cut1 + 1).',
      'Once the partition is valid: if (m+n) is odd, the median is max(maxLeft1, maxLeft2). If even, it is (max(maxLeft1, maxLeft2) + min(minRight1, minRight2)) / 2.',
    ],
    example: {
      input: 'nums1 = [1, 3], nums2 = [2]',
      steps: [
        'Total length = 3 (odd), so we need 2 elements in the left half.',
        'Binary search: cut1 = 1 â†’ maxLeft1 = 1, minRight1 = 3. cut2 = 1 â†’ maxLeft2 = 2, minRight2 = âˆž.',
        'Check: maxLeft1 (1) â‰¤ minRight2 (âˆž) âœ“ and maxLeft2 (2) â‰¤ minRight1 (3) âœ“ â€” valid partition.',
        'Odd total â†’ median = max(1, 2) = 2.',
      ],
      output: '2.0',
    },
    pitfalls: [
      'Use INT_MIN / INT_MAX as sentinels when cut1 = 0 or cut1 = m to avoid array out-of-bounds.',
      'Calculate mid as lo + (hi âˆ’ lo) / 2 to avoid integer overflow when lo + hi is large.',
      'Ensure binary search is on the shorter array so cut2 never goes negative.',
    ],
  },

  // â”€â”€â”€ 11. Container With Most Water â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
  11: {
    intuition:
      'Place two pointers at opposite ends and ask: which pointer should move? The area is limited by the shorter side. Moving the taller side inward can only keep or reduce the height limit while reducing width â€” guaranteed to be worse. Moving the shorter side inward may find a taller line that compensates for the reduced width. So always advance the shorter pointer.',
    algorithm: [
      'Initialise left = 0, right = nâˆ’1, maxArea = 0.',
      'While left < right: compute area = min(height[left], height[right]) Ã— (right âˆ’ left).',
      'Update maxArea = max(maxArea, area).',
      'Advance the pointer pointing to the shorter line: if height[left] < height[right] â†’ left++; else â†’ right--.',
      'Return maxArea.',
    ],
    example: {
      input: 'height = [1, 8, 6, 2, 5, 4, 8, 3, 7]',
      steps: [
        'left=0 (h=1), right=8 (h=7): area = 1Ã—8 = 8. height[left]<height[right] â†’ left++.',
        'left=1 (h=8), right=8 (h=7): area = 7Ã—7 = 49. height[right]<height[left] â†’ right--.',
        'left=1 (h=8), right=7 (h=3): area = 3Ã—6 = 18. right--.',
        'Continue until left=1, right=6 (h=8): area = 8Ã—5 = 40.',
        'Max found so far is 49 â€” no further pair beats it.',
      ],
      output: '49',
    },
    pitfalls: [
      'Do NOT move the pointer with the greater height â€” that is always suboptimal.',
      'The algorithm works because if a better container exists, the two-pointer sweep is guaranteed to visit it.',
    ],
  },

  // â”€â”€â”€ 15. 3Sum â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
  15: {
    intuition:
      'Brute force is O(nÂ³) â€” check every triplet. Sort first: this costs O(n log n) but unlocks the two-pointer technique. With the array sorted, fix one number and reduce the problem to "find a pair summing to its negation" â€” exactly the Two Sum II pattern, solvable in O(n) with two pointers. Total: O(nÂ²).',
    algorithm: [
      'Sort the array in ascending order.',
      'Iterate i from 0 to nâˆ’3. If nums[i] > 0, break early (no three positives can sum to 0).',
      'Skip duplicate values of nums[i]: if i > 0 and nums[i] == nums[iâˆ’1], continue.',
      'Set left = i+1, right = nâˆ’1. Run two-pointer loop while left < right.',
      'If sum == 0: record [nums[i], nums[left], nums[right]], skip duplicate lefts and rights, then advance both pointers.',
      'If sum < 0: left++ (need a larger value). If sum > 0: right-- (need a smaller value).',
    ],
    example: {
      input: 'nums = [âˆ’1, 0, 1, 2, âˆ’1, âˆ’4]  â†’ sorted: [âˆ’4, âˆ’1, âˆ’1, 0, 1, 2]',
      steps: [
        'i=0, nums[i]=âˆ’4. Two pointers: left=1(âˆ’1), right=5(2). Sum=âˆ’3 < 0 â†’ left++.',
        'left=2(âˆ’1), right=5(2). Sum=âˆ’3 < 0 â†’ left++. left=3(0), right=5(2). Sum=âˆ’2 < 0 â†’ left++. Exhaust without match.',
        'i=1, nums[i]=âˆ’1. left=2(âˆ’1), right=5(2). Sum=0 âœ“ â†’ record [âˆ’1,âˆ’1,2]. Skip dups, advance.',
        'left=3(0), right=4(1). Sum=0 âœ“ â†’ record [âˆ’1,0,1].',
        'i=2, nums[i]=âˆ’1 == nums[1] â†’ skip (duplicate outer).',
      ],
      output: '[[-1,-1,2], [-1,0,1]]',
    },
    pitfalls: [
      'Skip outer duplicates with `i > 0 && nums[i] == nums[i-1]` â€” not `nums[i] == nums[i+1]`.',
      'After finding a match, also skip inner duplicates on both left and right pointers.',
      'The early break `if nums[i] > 0 return` only works because the array is sorted.',
    ],
  },

  // â”€â”€â”€ 19. Remove Nth Node From End of List â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
  19: {
    intuition:
      'To find the nth node from the end without knowing the list length, use a two-pointer gap trick: if fast is exactly n steps ahead of slow, then when fast reaches the tail, slow is precisely at the node we want to remove. A dummy node before head lets us handle removing the head itself cleanly.',
    algorithm: [
      'Create a dummy node pointing to head; initialise both fast and slow at dummy.',
      'Advance fast n+1 steps forward (so the gap between slow and fast is n+1).',
      'Move both fast and slow one step at a time until fast == null.',
      'Now slow.next is the node to delete. Set slow.next = slow.next.next.',
      'Return dummy.next.',
    ],
    example: {
      input: 'head = [1â†’2â†’3â†’4â†’5], n = 2',
      steps: [
        'dummyâ†’1â†’2â†’3â†’4â†’5. Advance fast 3 steps: fast=3, slow=dummy.',
        'Move both: fast=4, slow=1. Move both: fast=5, slow=2. Move both: fast=null, slow=3.',
        'slow.next (node 4) is the 2nd from end. slow.next = node 5.',
        'List becomes 1â†’2â†’3â†’5.',
      ],
      output: '[1, 2, 3, 5]',
    },
    pitfalls: [
      'Advance fast n+1 (not n) steps so slow stops one node BEFORE the target.',
      'The dummy node is essential: without it, removing the head (n == list length) requires a special case.',
    ],
  },

  // â”€â”€â”€ 22. Generate Parentheses â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
  22: {
    intuition:
      'At each position in the string we have at most two choices: place "(" or ")". The constraints â€” open count â‰¤ n and close count â‰¤ open count â€” automatically prune all invalid branches, so every leaf of the recursion tree is already a valid string. No post-validation is needed.',
    algorithm: [
      'Recurse with state: (currentString, openCount, closeCount).',
      'Base case: if currentString.Length == 2Ã—n, add it to results.',
      'If openCount < n: recurse with "(" appended and openCount+1.',
      'If closeCount < openCount: recurse with ")" appended and closeCount+1.',
    ],
    example: {
      input: 'n = 2',
      steps: [
        'Start: ("", 0, 0). Can add "(" â†’ ("(", 1, 0).',
        'From ("(", 1, 0): add "(" â†’ ("((", 2, 0) or add ")" â†’ ("()", 1, 1).',
        'From ("((", 2, 0): can only add ")" â†’ ("(()", 2, 1) â†’ ("(())", 2, 2) âœ“.',
        'From ("()", 1, 1): add "(" â†’ ("()(", 2, 1) â†’ ("()()", 2, 2) âœ“.',
      ],
      output: '["(())", "()()"]',
    },
    pitfalls: [
      'Do not use close < n as the condition for adding ")". Use close < open â€” otherwise you generate invalid strings like "))(".',
      'The total valid combinations equal the Catalan number C(n), not 2^(2n).',
    ],
  },

  // â”€â”€â”€ 33. Search in Rotated Sorted Array â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
  33: {
    intuition:
      'A rotated sorted array always has at least one "sorted half" â€” either [lo, mid] or [mid, hi]. Once you identify which half is sorted, checking whether the target lies in that range is a simple boundary comparison. This is what standard binary search does, but applied to the sorted half rather than the whole array.',
    algorithm: [
      'Initialise lo = 0, hi = nâˆ’1.',
      'While lo â‰¤ hi: compute mid = lo + (hiâˆ’lo)/2. If nums[mid] == target, return mid.',
      'Determine which half is sorted: if nums[lo] â‰¤ nums[mid], the left half [lo, mid] is sorted.',
      'Left sorted: if nums[lo] â‰¤ target < nums[mid], search left (hi = midâˆ’1). Else search right (lo = mid+1).',
      'Right sorted (else): if nums[mid] < target â‰¤ nums[hi], search right (lo = mid+1). Else search left (hi = midâˆ’1).',
      'Return âˆ’1 if not found.',
    ],
    example: {
      input: 'nums = [4, 5, 6, 7, 0, 1, 2], target = 0',
      steps: [
        'lo=0, hi=6, mid=3 (nums[mid]=7). nums[lo]=4 â‰¤ nums[mid]=7 â†’ left half sorted.',
        'target=0 not in [4,7] â†’ search right: lo=4.',
        'lo=4, hi=6, mid=5 (nums[mid]=1). nums[lo]=0 â‰¤ nums[mid]=1 â†’ left half sorted.',
        'target=0 in [0,1] â†’ search left: hi=4.',
        'lo=4, hi=4, mid=4 (nums[mid]=0) == target. Return 4.',
      ],
      output: '4',
    },
    pitfalls: [
      'Use nums[lo] â‰¤ nums[mid] (not strict <) to handle the case where lo == mid.',
      'Duplicate values (problem 81) break this approach â€” requires handling nums[lo] == nums[mid] by shrinking lo.',
    ],
  },

  // â”€â”€â”€ 56. Merge Intervals â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
  56: {
    intuition:
      'If intervals were sorted by start time, any two overlapping intervals would be adjacent. So sort first, then a single linear scan can greedily merge any interval that overlaps with the last recorded merged interval.',
    algorithm: [
      'Sort intervals by start value.',
      'Initialise the result list with the first interval.',
      'For each remaining interval [s, e]: if s â‰¤ result.Last.end (overlap), extend: result.Last.end = max(result.Last.end, e).',
      'Otherwise they do not overlap: push [s, e] as a new separate interval.',
      'Return the result list.',
    ],
    example: {
      input: '[[1,3],[2,6],[8,10],[15,18]]',
      steps: [
        'Sort (already sorted). Start with result = [[1,3]].',
        '[2,6]: start 2 â‰¤ 3 â†’ overlap. Extend: result = [[1,6]].',
        '[8,10]: start 8 > 6 â†’ no overlap. Push: result = [[1,6],[8,10]].',
        '[15,18]: start 15 > 10 â†’ no overlap. Push: result = [[1,6],[8,10],[15,18]].',
      ],
      output: '[[1,6],[8,10],[15,18]]',
    },
    pitfalls: [
      'When extending, take max(current.end, new.end) â€” the new interval might be entirely contained inside the current one.',
      'Sorting by start is essential; without it, non-adjacent overlapping intervals are missed.',
    ],
  },

  // â”€â”€â”€ 70. Climbing Stairs â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
  70: {
    intuition:
      'To reach step n you must come from step nâˆ’1 (one stair) or step nâˆ’2 (two stairs). So the total ways equals ways(nâˆ’1) + ways(nâˆ’2) â€” the Fibonacci recurrence. There is no need for memoization or a full array; two rolling variables suffice.',
    algorithm: [
      'Handle base cases: n=1 â†’ 1 way. n=2 â†’ 2 ways.',
      'Initialise prev2 = 1 (ways to reach step 1), prev1 = 2 (ways to reach step 2).',
      'For i from 3 to n: cur = prev1 + prev2; prev2 = prev1; prev1 = cur.',
      'Return prev1.',
    ],
    example: {
      input: 'n = 5',
      steps: [
        'Step 1: 1 way. Step 2: 2 ways. Step 3: 1+2=3 ways.',
        'Step 4: 2+3=5 ways. Step 5: 3+5=8 ways.',
        'Sequence: 1, 2, 3, 5, 8 â€” the Fibonacci numbers offset by one.',
      ],
      output: '8',
    },
    pitfalls: [
      'The answer is Fibonacci(n+1), not Fibonacci(n) â€” make sure your base cases match.',
      'Do not create a dp[n+1] array; two variables is sufficient and avoids O(n) space.',
    ],
  },

  // â”€â”€â”€ 76. Minimum Window Substring â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
  76: {
    intuition:
      'Sliding window: expand the right edge until all required characters are covered, then shrink the left edge to minimise the window size while still covering all characters. Track "how many required characters are still unmet" as a counter to decide when the window is valid â€” this avoids re-scanning the frequency array on every check.',
    algorithm: [
      'Build a frequency count of t in a 128-element int array. Set required = t.Length.',
      'Expand right pointer: for each character s[right], decrement count[s[right]]. If it was > 0 before, decrement required.',
      'When required == 0 (all characters covered): record window if it is smaller than the best so far.',
      'Shrink left pointer: increment count[s[left]]. If it becomes > 0 again, increment required. Advance left.',
      'Repeat until right reaches end of s.',
    ],
    example: {
      input: 's = "ADOBECODEBANC", t = "ABC"',
      steps: [
        'Expand right until required=0: window "ADOBEC" (indices 0â€“5). Record length 6.',
        'Shrink left: remove A â†’ required=1. Expand right to include next A.',
        'Window "DOBECODEBA" â€” shrink left again until "BANC" (indices 9â€“12). Length 4.',
        'Shrink left: remove B â†’ required=1. Right exhausted. Best window is "BANC".',
      ],
      output: '"BANC"',
    },
    pitfalls: [
      'Use an int[128] character array instead of a Dictionary for O(1) per character operations.',
      'Decrement count BEFORE checking if it was > 0 (or check > 0 before decrement) â€” order matters for the required counter.',
      'Edge case: if t is longer than s or s is empty, return "" immediately.',
    ],
  },

  // â”€â”€â”€ 100. Same Tree â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
  100: {
    intuition:
      'Two binary trees are the same if and only if their roots hold the same value AND their left subtrees are the same AND their right subtrees are the same. This directly translates to a recursive definition with simple base cases.',
    algorithm: [
      'Base case: if both nodes are null â†’ return true (two empty trees are identical).',
      'Base case: if one is null and the other is not â†’ return false.',
      'Base case: if root values differ â†’ return false.',
      'Recurse: return IsSameTree(p.left, q.left) AND IsSameTree(p.right, q.right).',
    ],
    example: {
      input: 'p = [1,2,3], q = [1,2,3]',
      steps: [
        'Compare roots: both 1 â†’ match. Recurse on left children (both 2) and right children (both 3).',
        'Left: both 2 â†’ match. Their children are null â†’ base case, return true.',
        'Right: both 3 â†’ match. Their children are null â†’ base case, return true.',
        'All checks pass â†’ return true.',
      ],
      output: 'true',
    },
    pitfalls: [
      'Check for null before comparing values â€” accessing .val on null causes a NullReferenceException.',
      'The null check `p == null && q == null` must come before `p == null || q == null` to avoid false negatives.',
    ],
  },

  // â”€â”€â”€ 102. Binary Tree Level Order Traversal â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
  102: {
    intuition:
      'BFS naturally visits nodes level by level. The key trick to group nodes by level: at the start of each BFS iteration, snapshot the current queue size. That size is exactly how many nodes belong to the current level. Process exactly that many nodes before moving to the next level.',
    algorithm: [
      'If root is null, return empty list.',
      'Enqueue root. While the queue is not empty:',
      'Snapshot levelSize = queue.Count.',
      'Dequeue exactly levelSize nodes, add their values to a level list, enqueue their non-null children.',
      'Add the completed level list to the result.',
    ],
    example: {
      input: 'root = [3,9,20,null,null,15,7]',
      steps: [
        'Queue: [3]. levelSize=1. Dequeue 3 â†’ level=[3]. Enqueue 9,20. Result=[[3]].',
        'Queue: [9,20]. levelSize=2. Dequeue 9 â†’ enqueue nothing. Dequeue 20 â†’ enqueue 15,7. Result=[[3],[9,20]].',
        'Queue: [15,7]. levelSize=2. Dequeue both â†’ level=[15,7]. Result=[[3],[9,20],[15,7]].',
      ],
      output: '[[3],[9,20],[15,7]]',
    },
    pitfalls: [
      'Snapshot queue.Count BEFORE the inner loop â€” dequeuing nodes during the loop changes the count.',
      'Add both left and right children only if non-null to avoid null entries in the queue.',
    ],
  },

  // â”€â”€â”€ 146. LRU Cache â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
  146: {
    intuition:
      'An LRU cache needs O(1) lookup and O(1) reordering to track recency. A hash map gives O(1) lookup. A doubly-linked list gives O(1) insertion and deletion at any position. Combining both: the map stores key â†’ node, and the list maintains order from most-recent (head) to least-recent (tail).',
    algorithm: [
      'Create dummy head and tail nodes. Connect them. Map starts empty.',
      'get(key): if not in map, return âˆ’1. Otherwise move the node to just after the dummy head and return its value.',
      'put(key, value): if key exists, update value and move to front. If new: insert new node at front.',
      'After inserting a new node: if size > capacity, remove the node just before the dummy tail (LRU) and delete its key from the map.',
      'Helper Remove(node) unlinks a node in O(1). Helper InsertFront(node) inserts after head in O(1).',
    ],
    example: {
      input: 'capacity=2, operations: put(1,1), put(2,2), get(1), put(3,3), get(2)',
      steps: [
        'put(1,1): list = [1]. put(2,2): list = [2,1] (2 is most recent).',
        'get(1): move 1 to front â†’ list = [1,2]. Return 1.',
        'put(3,3): list full. Evict LRU (tail = 2). list = [3,1].',
        'get(2): key 2 was evicted â†’ return âˆ’1.',
      ],
      output: 'get(1)=1, get(2)=-1',
    },
    pitfalls: [
      'Sentinel dummy head and tail nodes eliminate all null checks in Remove/InsertFront.',
      'Always remove the old node before inserting the updated one to avoid the map having two entries for the same key.',
      'On eviction, remove from BOTH the list and the map or subsequent gets will return stale data.',
    ],
  },

  // â”€â”€â”€ 160. Intersection of Two Linked Lists â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
  160: {
    intuition:
      'If both pointers walk the same total distance (|A| + |B|), they will arrive at the intersection at the same step â€” or both arrive at null together if there is no intersection. Redirecting each pointer to the other list\'s head when it reaches null achieves exactly this total-distance equality with no extra memory.',
    algorithm: [
      'Initialise a = headA, b = headB.',
      'While a != b: advance each by one step. When a reaches null, redirect it to headB. When b reaches null, redirect it to headA.',
      'If the lists intersect, a == b will be the intersection node. If not, both will be null simultaneously (null == null).',
      'Return a (or b).',
    ],
    example: {
      input: 'A = [4,1,8,4,5], B = [5,6,1,8,4,5] (intersect at node with value 8)',
      steps: [
        'a walks A (5 nodes) then B (6 nodes) = 11 steps to reach node 8.',
        'b walks B (6 nodes) then A (5 nodes) = 11 steps to reach node 8.',
        'At step 11, a == b == the intersection node.',
      ],
      output: 'Reference to node with value 8',
    },
    pitfalls: [
      'Compare node references, not node values â€” multiple nodes can have the same value but only one is the true intersection.',
      'The loop exits when a == b (including both being null for non-intersecting lists). Do NOT check a != null.',
    ],
  },

  // â”€â”€â”€ 189. Rotate Array â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
  189: {
    intuition:
      'Rotating right by k means the last k elements move to the front and the first nâˆ’k elements shift right. Observe: if you reverse the entire array, then independently reverse the first k elements and the last nâˆ’k elements, you get exactly the rotated result. Three reverses, no extra array.',
    algorithm: [
      'Reduce k = k % n to handle rotations larger than the array.',
      'Reverse the entire array.',
      'Reverse the first k elements (indices 0 to kâˆ’1).',
      'Reverse the remaining nâˆ’k elements (indices k to nâˆ’1).',
    ],
    example: {
      input: 'nums = [1,2,3,4,5,6,7], k = 3',
      steps: [
        'Reverse all:        [7,6,5,4,3,2,1]',
        'Reverse first 3:    [5,6,7,4,3,2,1]',
        'Reverse last 4:     [5,6,7,1,2,3,4]',
      ],
      output: '[5,6,7,1,2,3,4]',
    },
    pitfalls: [
      'Reduce k mod n first â€” otherwise k=7 on a 7-element array does nothing but the naive reversal would still run.',
      'k = 0 after reduction means no rotation is needed; the three-reversal still works (each reverse is a no-op or reverses then re-reverses the same range).',
    ],
  },

  // â”€â”€â”€ 198. House Robber â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
  198: {
    intuition:
      'At each house you have two choices: rob it (and skip the previous) or skip it (and keep whatever was best through the previous house). This gives the recurrence dp[i] = max(dp[iâˆ’2] + nums[i], dp[iâˆ’1]). Only the last two dp values are ever needed, so the array collapses to two variables.',
    algorithm: [
      'If n == 1, return nums[0].',
      'Initialise prev2 = nums[0] (best loot through house 0), prev1 = max(nums[0], nums[1]) (best through house 1).',
      'For i from 2 to nâˆ’1: cur = max(prev1, prev2 + nums[i]); prev2 = prev1; prev1 = cur.',
      'Return prev1.',
    ],
    example: {
      input: 'nums = [2,7,9,3,1]',
      steps: [
        'prev2=2, prev1=max(2,7)=7.',
        'i=2 (nums=9): cur=max(7, 2+9)=11. prev2=7, prev1=11.',
        'i=3 (nums=3): cur=max(11, 7+3)=11. prev2=11, prev1=11.',
        'i=4 (nums=1): cur=max(11, 11+1)=12. prev2=11, prev1=12.',
      ],
      output: '12  (rob houses 0,2,4: 2+9+1=12)',
    },
    pitfalls: [
      'Initialise prev1 = max(nums[0], nums[1]) not just nums[1] â€” you might not rob house 1.',
      'Do not reset dp to 0 at any step â€” you always carry forward the best previous answer.',
    ],
  },

  // â”€â”€â”€ 210. Course Schedule II â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
  210: {
    intuition:
      'Finding a valid course order is exactly topological sorting of a directed graph. Kahn\'s algorithm (BFS-based) is the cleaner approach: start with all courses that have no prerequisites (in-degree 0), process them one by one, and "unlock" courses whose last prerequisite has just been completed. If a cycle exists, some courses will never reach in-degree 0.',
    algorithm: [
      'Build adjacency list and in-degree array from prerequisites.',
      'Enqueue all nodes with in-degree 0.',
      'Dequeue a course: add it to the result order. For each neighbour, decrement its in-degree.',
      'If a neighbour\'s in-degree reaches 0, enqueue it.',
      'If result.Count == numCourses, return result. Otherwise a cycle exists â€” return [].',
    ],
    example: {
      input: 'numCourses=4, prerequisites=[[1,0],[2,0],[3,1],[3,2]]',
      steps: [
        'In-degrees: 0â†’0, 1â†’1, 2â†’1, 3â†’2. Queue: [0].',
        'Dequeue 0: result=[0]. Decrement 1 (â†’0), 2 (â†’0). Queue: [1,2].',
        'Dequeue 1: result=[0,1]. Decrement 3 (â†’1). Queue: [2].',
        'Dequeue 2: result=[0,1,2]. Decrement 3 (â†’0). Queue: [3].',
        'Dequeue 3: result=[0,1,2,3]. Count=4=numCourses â†’ valid.',
      ],
      output: '[0,1,2,3]',
    },
    pitfalls: [
      'A cycle is detected by checking result.Count < numCourses at the end, not during BFS.',
      'The order returned is one valid topological order â€” many valid orderings may exist.',
      'Build the graph so edges point FROM prerequisite TO the course that requires it (forward direction).',
    ],
  },

  // â”€â”€â”€ 213. House Robber II â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
  213: {
    intuition:
      'The circular constraint means houses 0 and nâˆ’1 cannot both be robbed. Break the circle by solving two independent sub-problems: one excluding the first house, one excluding the last. The answer is the maximum of both. Each sub-problem is the classic linear House Robber.',
    algorithm: [
      'If n == 1, return nums[0].',
      'Define Rob(start, end): run the rolling-variable DP on nums[start..end]. O(n) time, O(1) space.',
      'Return max(Rob(0, nâˆ’2), Rob(1, nâˆ’1)).',
    ],
    example: {
      input: 'nums = [2,3,2]',
      steps: [
        'Sub-problem 1 (exclude last): Rob([2,3]). Best = 3.',
        'Sub-problem 2 (exclude first): Rob([3,2]). Best = 3.',
        'Return max(3,3) = 3.',
      ],
      output: '3',
    },
    pitfalls: [
      'Do not try to "stitch" the two sub-problems together â€” they are fully independent.',
      'Edge case n=1: return nums[0] before calling Rob, since Rob(0, -1) would have an empty range.',
    ],
  },

  // â”€â”€â”€ 236. Lowest Common Ancestor â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
  236: {
    intuition:
      'Post-order DFS: we need information from both subtrees before deciding. If a node equals p or q, return it immediately â€” even if the other target is a descendant, the current node is still the LCA. If both left and right recursive calls return non-null, we are at the node where p and q split â€” that\'s the LCA.',
    algorithm: [
      'Base cases: if root is null, return null. If root == p or root == q, return root.',
      'Recurse: left = LCA(root.left, p, q); right = LCA(root.right, p, q).',
      'If both left and right are non-null â†’ root is the LCA. Return root.',
      'Otherwise return whichever is non-null (the LCA is deeper in that subtree).',
    ],
    example: {
      input: 'root=[3,5,1,6,2,0,8,null,null,7,4], p=5, q=4',
      steps: [
        'DFS left of 3: reaches 5. 5 == p â†’ return node 5.',
        'From 5, DFS right: reaches 2, then 4. 4 == q â†’ returns up through 2, then 5.',
        'Back at node 3: left returned node 5 (found p). Dive right of 3: reaches 1,0,8 â€” none match p or q â†’ returns null.',
        'Node 3: left=node5 (non-null), right=null â†’ return node5 as LCA.',
      ],
      output: 'Node with value 5',
    },
    pitfalls: [
      'The algorithm assumes both p and q exist in the tree. If either is missing, the result is undefined.',
      'Do NOT descend into a subtree after finding one target â€” the early return `if root == p || root == q` handles the ancestor case correctly.',
    ],
  },

  // â”€â”€â”€ 239. Sliding Window Maximum â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
  239: {
    intuition:
      'The maximum of every window of size k is needed. A naive approach rechecks each window in O(k) â€” O(nk) total. The insight: maintain a monotonically decreasing deque of indices. Any index with a smaller value than the incoming element can never be the maximum for any current or future window, so it is discarded immediately.',
    algorithm: [
      'Use a LinkedList<int> (deque) storing indices. Process each index i from 0 to nâˆ’1.',
      'Remove from the front any index â‰¤ iâˆ’k (outside the current window).',
      'Remove from the back any index whose value is â‰¤ nums[i] (they are dominated).',
      'Add i to the back of the deque.',
      'When i â‰¥ kâˆ’1 (first full window reached): the front of the deque is the index of the window maximum.',
    ],
    example: {
      input: 'nums = [1,3,-1,-3,5,3,6,7], k = 3',
      steps: [
        'i=0: deque=[0(1)]. i=1: 3>1, remove 0 â†’ deque=[1(3)]. i=2: -1<3, deque=[1(3),2(-1)]. Window [1,3,-1]: max=nums[1]=3.',
        'i=3: -3<-1, deque=[1(3),2(-1),3(-3)]. Window [3,-1,-3]: max=nums[1]=3.',
        'i=4: 5>everything, clear deque â†’ deque=[4(5)]. Window [-1,-3,5]: max=5.',
        'i=5: 3<5, deque=[4(5),5(3)]. i=6: 6>3 and 6>5, clear â†’ deque=[6(6)]. max=6.',
        'i=7: 7>6, clear â†’ deque=[7(7)]. max=7.',
      ],
      output: '[3,3,5,3,6,7]',
    },
    pitfalls: [
      'Remove from FRONT when out of window. Remove from BACK when dominated. These are two separate conditions, not one.',
      'Each element is pushed and popped at most once â€” total O(n), not O(nk).',
    ],
  },


  // â”€â”€â”€ 12. Integer to Roman â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
  12: {
    intuition:
      'Roman numerals use a fixed set of symbols (I=1, V=5, X=10, L=50, C=100, D=500, M=1000) plus six subtractive combinations (IV=4, IX=9, XL=40, XC=90, CD=400, CM=900). Greedily subtract the largest symbol value that fits, emitting its string each time. Since the symbol list is finite and ordered, a simple loop works.',
    algorithm: [
      'Build parallel arrays: values = [1000,900,500,400,100,90,50,40,10,9,5,4,1], symbols = ["M","CM","D","CD","C","XC","L","XL","X","IX","V","IV","I"].',
      'Iterate through each (value, symbol) pair.',
      'While num â‰¥ value: append symbol to result, subtract value from num.',
      'Return result.',
    ],
    example: {
      input: 'num = 1994',
      steps: [
        '1994 â‰¥ 1000 â†’ append "M", num=994.',
        '994 â‰¥ 900  â†’ append "CM", num=94.',
        '94 â‰¥ 90   â†’ append "XC", num=4.',
        '4 â‰¥ 4     â†’ append "IV", num=0.',
      ],
      output: '"MCMXCIV"',
    },
    pitfalls: [
      'Include the subtractive cases (4, 9, 40, 90, 400, 900) in the value table â€” do not try to detect them dynamically.',
    ],
  },

  // â”€â”€â”€ 13. Roman to Integer â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
  13: {
    intuition:
      'In a valid Roman numeral, a smaller value before a larger value means subtraction; otherwise it means addition. Scan left to right: if the current symbol\'s value is less than the next symbol\'s value, subtract it; otherwise add it.',
    algorithm: [
      'Build a map: Iâ†’1, Vâ†’5, Xâ†’10, Lâ†’50, Câ†’100, Dâ†’500, Mâ†’1000.',
      'Iterate i from 0 to nâˆ’1.',
      'If i < nâˆ’1 and map[s[i]] < map[s[i+1]]: subtract map[s[i]] from result.',
      'Else: add map[s[i]] to result.',
      'Return result.',
    ],
    example: {
      input: '"MCMXCIV"',
      steps: [
        'M(1000): next is C(100). 1000 > 100 â†’ add. result=1000.',
        'C(100): next is M(1000). 100 < 1000 â†’ subtract. result=900.',
        'M(1000): next is X(10). add. result=1900.',
        'X(10): next is C(100). 10 < 100 â†’ subtract. result=1890.',
        'C(100): next is I(1). add. result=1990.',
        'I(1): next is V(5). 1 < 5 â†’ subtract. result=1989.',
        'V(5): last. add. result=1994.',
      ],
      output: '1994',
    },
    pitfalls: [
      'The last character always adds â€” the compare-with-next rule handles all subtractive cases automatically.',
    ],
  },

  // â”€â”€â”€ 14. Longest Common Prefix â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
  14: {
    intuition:
      'The longest common prefix of all strings cannot be longer than the shortest string, and it must be a prefix of every string. Vertical scanning: check each character position across all strings simultaneously, stopping at the first mismatch.',
    algorithm: [
      'If the array is empty, return "".',
      'Iterate column index i from 0 to strs[0].Lengthâˆ’1.',
      'For each string s in strs: if i >= s.Length or s[i] != strs[0][i], return strs[0][0..i] (exclusive).',
      'Return strs[0] (all strings are equal).',
    ],
    example: {
      input: '["flower","flow","flight"]',
      steps: [
        'i=0: f==f==f âœ“. i=1: l==l==l âœ“. i=2: o==o, but "flight"[2]=i â‰  o. Stop.',
        'Return strs[0][0..2] = "fl".',
      ],
      output: '"fl"',
    },
    pitfalls: [
      'Check i >= s.Length BEFORE accessing s[i] to avoid IndexOutOfRange on shorter strings.',
    ],
  },

  // â”€â”€â”€ 16. 3Sum Closest â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
  16: {
    intuition:
      'Sort the array, then for each fixed element i use two pointers on the remainder. The sorted order lets you deterministically move closer to the target: if the current sum is too small, advance left; if too large, retreat right. Update the closest sum whenever you find a smaller gap.',
    algorithm: [
      'Sort nums.',
      'Initialise closest = nums[0]+nums[1]+nums[2].',
      'For i from 0 to nâˆ’3: set left=i+1, right=nâˆ’1.',
      'While left < right: compute sum = nums[i]+nums[left]+nums[right]. If |sumâˆ’target| < |closestâˆ’target|, update closest.',
      'If sum < target â†’ left++. If sum > target â†’ right--. If sum == target â†’ return target.',
      'Return closest.',
    ],
    example: {
      input: 'nums = [-1,2,1,-4], target = 1  â†’ sorted: [-4,-1,1,2]',
      steps: [
        'i=0(-4): left=1(-1),right=3(2). sum=-3. |diff|=4. sum<targetâ†’left++.',
        'left=2(1),right=3(2). sum=-1. |diff|=2. sum<targetâ†’left++. Loop ends.',
        'i=1(-1): left=2(1),right=3(2). sum=2. |diff|=1. sum>targetâ†’right--. Loop ends.',
        'Closest=2.',
      ],
      output: '2',
    },
    pitfalls: [
      'Early return when sum == target since you cannot get closer than 0.',
    ],
  },

  // â”€â”€â”€ 25. Reverse Nodes in k-Group â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
  25: {
    intuition:
      'Reverse exactly k nodes at a time, then recurse (or iterate) on the rest. The tricky part is connecting the reversed group back to the previous part and the next group. Use a dummy head to simplify the boundary.',
    algorithm: [
      'Use a dummy node before head. prevGroupTail = dummy.',
      'Count k nodes ahead from the current position. If fewer than k remain, stop.',
      'Reverse the k nodes in-place, keeping track of the new head and new tail of the reversed group.',
      'Connect prevGroupTail.next = newHead and newTail.next = nextGroup.',
      'Advance prevGroupTail to newTail. Repeat.',
    ],
    example: {
      input: 'head = [1â†’2â†’3â†’4â†’5], k = 2',
      steps: [
        'Group 1: reverse [1,2] â†’ [2,1]. Connect: dummyâ†’2â†’1.',
        'Group 2: reverse [3,4] â†’ [4,3]. Connect: 1â†’4â†’3.',
        'Only 1 node [5] left â€” fewer than k=2, leave as-is. Connect: 3â†’5.',
      ],
      output: '[2,1,4,3,5]',
    },
    pitfalls: [
      'Check there are exactly k nodes left before reversing â€” do not reverse a partial group.',
      'Save the "next group\'s head" before reversing, or you lose the pointer to the rest of the list.',
    ],
  },

  // â”€â”€â”€ 26. Remove Duplicates from Sorted Array â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
  26: {
    intuition:
      'The array is sorted, so duplicates are adjacent. Use a slow pointer k that tracks where the next unique element should go. The fast pointer i scans ahead; whenever it finds a value different from the last accepted value, copy it to position k.',
    algorithm: [
      'If array is empty, return 0.',
      'Initialise k = 1 (first element is always unique).',
      'For i from 1 to nâˆ’1: if nums[i] != nums[iâˆ’1], set nums[k] = nums[i], k++.',
      'Return k.',
    ],
    example: {
      input: 'nums = [1,1,2,3,3]',
      steps: [
        'i=1: 1==1 skip. i=2: 2â‰ 1 â†’ nums[1]=2, k=2.',
        'i=3: 3â‰ 2 â†’ nums[2]=3, k=3. i=4: 3==3 skip.',
        'Array first 3 = [1,2,3].',
      ],
      output: 'k = 3',
    },
    pitfalls: [
      'Compare nums[i] with nums[iâˆ’1] (not nums[kâˆ’1]) â€” same result since the sorted property is preserved.',
      'Return k, not kâˆ’1; k is a count, not an index.',
    ],
  },

  // â”€â”€â”€ 27. Remove Element â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
  27: {
    intuition:
      'Use two pointers: a slow write pointer k and a fast scan pointer i. Copy nums[i] to nums[k] only when nums[i] != val. This effectively filters out all instances of val in-place.',
    algorithm: [
      'Initialise k = 0.',
      'For i from 0 to nâˆ’1: if nums[i] != val, set nums[k] = nums[i], k++.',
      'Return k.',
    ],
    example: {
      input: 'nums = [3,2,2,3], val = 3',
      steps: [
        'i=0: 3==val, skip. i=1: 2â‰ val â†’ nums[0]=2, k=1.',
        'i=2: 2â‰ val â†’ nums[1]=2, k=2. i=3: 3==val, skip.',
      ],
      output: 'k = 2, nums = [2,2,_,_]',
    },
    pitfalls: [
      'The remaining elements beyond index k do not matter â€” only the first k elements are checked.',
    ],
  },

  // â”€â”€â”€ 29. Divide Two Integers â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
  29: {
    intuition:
      'Division without multiplication/division: use bit-shifting to implement exponential doubling. Find the largest multiple of divisor (as a power of 2) that fits in dividend, subtract it, record the multiple, and repeat. This achieves O(logÂ² n) instead of O(n) for repeated subtraction.',
    algorithm: [
      'Handle overflow: if dividend == INT_MIN and divisor == -1, return INT_MAX.',
      'Track sign: result is negative if exactly one of dividend/divisor is negative. Work with absolute values.',
      'While |dividend| >= |divisor|: double divisor (shift left) and double count (1 << shift) until it overshoots. Back off one step. Subtract from dividend, add count to result.',
      'Repeat until dividend < divisor.',
      'Apply sign and return.',
    ],
    example: {
      input: 'dividend = 10, divisor = 3',
      steps: [
        'Both positive. |10| >= |3|: 3<<1=6 fits, 6<<1=12 > 10. Back off: subtract 6, result=2. Remaining=4.',
        '|4| >= |3|: 3<<1=6 > 4. Subtract 3, result=3. Remaining=1.',
        '|1| < |3|. Done. result=3.',
      ],
      output: '3',
    },
    pitfalls: [
      'Must handle INT_MIN / -1 = INT_MAX overflow separately.',
      'Use long arithmetic for intermediate values to avoid overflow during doubling.',
    ],
  },

  // â”€â”€â”€ 32. Longest Valid Parentheses â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
  32: {
    intuition:
      'Use a stack to track indices of unmatched characters. Push -1 as a base sentinel. When ")" is seen and the stack top is a "(" index, pop it (they form a matched pair) and the current valid length is i âˆ’ stack.Peek(). If the stack becomes empty, push i as the new base.',
    algorithm: [
      'Push âˆ’1 onto stack as base.',
      'For each index i: if s[i] == "(", push i.',
      'Else (s[i] == ")"): pop from stack. If stack is empty, push i as new base. Else update maxLen = max(maxLen, i âˆ’ stack.Peek()).',
      'Return maxLen.',
    ],
    example: {
      input: 's = ")()())"',
      steps: [
        'i=0 ")" : pop âˆ’1 â†’ empty. Push 0 as base.',
        'i=1 "(" : push 1. i=2 ")" : pop 1. Stack=[0]. len=2âˆ’0=2.',
        'i=3 "(" : push 3. i=4 ")" : pop 3. Stack=[0]. len=4âˆ’0=4.',
        'i=5 ")" : pop 0 â†’ empty. Push 5 as base.',
        'maxLen=4.',
      ],
      output: '4',
    },
    pitfalls: [
      'The base sentinel (âˆ’1 or the index of an unmatched ")") is critical for correct length calculation.',
    ],
  },

  // â”€â”€â”€ 36. Valid Sudoku â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
  36: {
    intuition:
      'Validate each row, each column, and each 3Ã—3 box independently â€” all in one pass. The box index for cell (r,c) is (r/3)*3 + (c/3). Use three arrays of 9 HashSets (or 9Ã—9 boolean arrays), one per constraint type.',
    algorithm: [
      'Allocate rows[9], cols[9], boxes[9] â€” each a HashSet<char>.',
      'Iterate over every cell (r, c). Skip cells containing ".".',
      'Compute boxIdx = (r/3)*3 + c/3.',
      'If the digit already exists in rows[r], cols[c], or boxes[boxIdx] â†’ return false.',
      'Otherwise add the digit to all three sets.',
      'Return true after the full scan.',
    ],
    example: {
      input: 'A partially filled 9Ã—9 board',
      steps: [
        'For cell (0,0)="5": check rows[0], cols[0], boxes[0]. All empty â†’ add "5" to each.',
        'For cell (0,3)="5": check rows[0] â€” "5" already there â†’ return false.',
      ],
      output: 'true / false',
    },
    pitfalls: [
      'The box index formula (r/3)*3 + c/3 uses integer division â€” do not use floating point.',
    ],
  },

  // â”€â”€â”€ 37. Sudoku Solver â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
  37: {
    intuition:
      'Backtracking: find the next empty cell, try digits 1â€“9, check validity with the same three-set approach as problem 36, place the digit and recurse. If recursion returns false (dead end), remove the digit and try the next. When no empty cell remains, the board is solved.',
    algorithm: [
      'Find the first empty cell (containing "."). If none exists, return true (solved).',
      'Try each digit "1"â€“"9". Check if it is valid in the current row, column, and 3Ã—3 box.',
      'Place the digit, recurse. If recursion returns true, propagate true up.',
      'Backtrack: reset the cell to "." if recursion fails.',
      'If no digit works, return false.',
    ],
    example: {
      input: 'A valid Sudoku puzzle',
      steps: [
        'Find first empty (r=0,c=0). Try "1": valid? Place "1", recurse.',
        'Recursion eventually fails â†’ backtrack, try "2", ..., try "5": valid, recurse.',
        'Continue until all 81 cells are filled consistently.',
      ],
      output: 'Board filled in-place',
    },
    pitfalls: [
      'Cache row/col/box membership in sets for O(1) checks â€” do not re-scan the board on every placement.',
      'Return immediately when a valid solution is found to avoid unnecessary backtracking.',
    ],
  },

  // â”€â”€â”€ 38. Count and Say â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
  38: {
    intuition:
      'Each term describes the previous term using run-length encoding: count consecutive identical digits and say "count digit". Build each string from the previous one iteratively.',
    algorithm: [
      'Start with s = "1".',
      'Repeat nâˆ’1 times: scan s, group consecutive identical characters, build the next string as "count + char" for each group.',
      'Return s.',
    ],
    example: {
      input: 'n = 4',
      steps: [
        'n=1: "1"',
        'n=2: one 1 â†’ "11"',
        'n=3: two 1s â†’ "21"',
        'n=4: one 2, one 1 â†’ "1211"',
      ],
      output: '"1211"',
    },
    pitfalls: [
      'Use a StringBuilder for O(n) string building â€” repeated string concatenation is O(nÂ²).',
    ],
  },

  // â”€â”€â”€ 40. Combination Sum II â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
  40: {
    intuition:
      'Like Combination Sum I (unbounded), but each number can only be used once. Sort to enable duplicate skipping: after choosing candidates[i], skip over any later indices j where candidates[j] == candidates[jâˆ’1] at the same recursion depth. This prevents identical combinations.',
    algorithm: [
      'Sort candidates.',
      'Backtrack(start, current, remaining):',
      'If remaining == 0: add current to results.',
      'For i from start to nâˆ’1: if i > start and candidates[i] == candidates[iâˆ’1], skip (duplicate).',
      'If candidates[i] > remaining, break (sorted â†’ no later element can work).',
      'Choose candidates[i], recurse with start=i+1 (not i, since each element used once).',
      'Undo the choice.',
    ],
    example: {
      input: 'candidates = [10,1,2,7,6,1,5], target = 8  â†’ sorted: [1,1,2,5,6,7,10]',
      steps: [
        'Start with []. Choose 1(idx0), recurse: choose 1(idx1) â†’ [1,1], recurse: choose 6 â†’ [1,1,6] = 8 âœ“.',
        'Back at [1,1]: skip 7 (would be [1,1,7]=9>8). Done.',
        'Back at [1]: skip idx1 (1==1 dup at same level). Choose 2 â†’ [1,2], choose 5 â†’ [1,2,5] = 8 âœ“.',
        'Also find [2,6] and [1,7].',
      ],
      output: '[[1,1,6],[1,2,5],[1,7],[2,6]]',
    },
    pitfalls: [
      'The duplicate skip condition `i > start && candidates[i] == candidates[i-1]` uses `start`, not 0 â€” to allow using the same value at different depth levels.',
      'Recurse with i+1, not i, to enforce "each element at most once".',
    ],
  },

  // â”€â”€â”€ 44. Wildcard Matching â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
  44: {
    intuition:
      'DP table dp[i][j] = true if pattern p[0..jâˆ’1] matches string s[0..iâˆ’1]. Base: dp[0][0]=true; leading "*"s in p can match empty string. Transition: if p[j-1]=="?" or p[j-1]==s[i-1]: dp[i][j]=dp[i-1][j-1]. If p[j-1]=="*": dp[i][j] = dp[i-1][j] (star matches one more char) OR dp[i][j-1] (star matches nothing).',
    algorithm: [
      'Allocate dp[m+1][n+1] where m=s.Length, n=p.Length.',
      'dp[0][0] = true. For j from 1 to n: if p[j-1]=="*", dp[0][j] = dp[0][j-1].',
      'For i from 1 to m, j from 1 to n:',
      '  if p[j-1]=="?" or p[j-1]==s[i-1]: dp[i][j] = dp[i-1][j-1].',
      '  if p[j-1]=="*": dp[i][j] = dp[i-1][j] || dp[i][j-1].',
      'Return dp[m][n].',
    ],
    example: {
      input: 's = "adceb", p = "*a*b"',
      steps: [
        'Leading "*" in p matches empty. dp[0][1]=true.',
        '"a" in p matches "a" in s. dp[1][2]=true.',
        '"*" matches any sequence â†’ dp[i][3]=true for all iâ‰¥1.',
        '"b" matches "b" (s[4]) using dp[4][3]=true â†’ dp[5][4]=true.',
      ],
      output: 'true',
    },
    pitfalls: [
      'A "*" can match zero characters â€” include dp[i][j-1] (star matches empty) in the OR condition.',
      'Pattern leading stars must initialise the top row of dp, not just dp[0][0].',
    ],
  },

  // â”€â”€â”€ 51. N-Queens â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
  51: {
    intuition:
      'Place one queen per row. For each row, try each column; a column is valid if no previously placed queen shares that column, positive diagonal (rowâˆ’col = constant), or negative diagonal (row+col = constant). Three HashSets track conflicts in O(1).',
    algorithm: [
      'Backtrack row by row, starting at row 0.',
      'For each column col in [0, nâˆ’1]: skip if col, rowâˆ’col, or row+col is already in the conflict sets.',
      'Place queen: add col to cols, rowâˆ’col to posDiag, row+col to negDiag.',
      'Recurse on row+1. If row+1==n, record the current board.',
      'Remove the queen (backtrack).',
    ],
    example: {
      input: 'n = 4',
      steps: [
        'Row 0: try col 1 (valid). Row 1: col 3 (valid). Row 2: col 0 (valid). Row 3: col 2 (valid). Record [[".Q..","...Q","Q...","..Q."]].',
        'Backtrack to find second solution: [["..Q.","Q...","...Q",".Q.."] ].',
      ],
      output: '2 solutions',
    },
    pitfalls: [
      'Track diagonals as rowâˆ’col and row+col constants, not as slope comparisons.',
      'Build the board string only when a complete valid placement (row == n) is found.',
    ],
  },

  // â”€â”€â”€ 52. N-Queens II â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
  52: {
    intuition:
      'Same as N-Queens I but count solutions instead of collecting them. The backtracking logic is identical; replace board recording with a counter increment.',
    algorithm: [
      'Same backtracking as N-Queens I, but when row == n: count++.',
      'Return count.',
    ],
    example: {
      input: 'n = 4',
      steps: ['Same search as problem 51 finds 2 complete placements.'],
      output: '2',
    },
    pitfalls: [
      'Bit manipulation alternative: use integer bitmasks for cols/posDiag/negDiag to speed up the inner loop.',
    ],
  },

  // â”€â”€â”€ 58. Length of Last Word â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
  58: {
    intuition:
      'Scan from the right: skip trailing spaces, then count characters until another space or the start of the string is reached.',
    algorithm: [
      'Set i = s.Length âˆ’ 1.',
      'Skip trailing spaces: while i >= 0 and s[i] == " ", i--.',
      'Count word characters: while i >= 0 and s[i] != " ", i--, count++.',
      'Return count.',
    ],
    example: {
      input: '"   fly me   to   the moon  "',
      steps: [
        'Skip trailing spaces at indices 28,27. i=26 ("n").',
        'Count: n,o,o,m = 4. i hits space. count=4.',
      ],
      output: '4',
    },
    pitfalls: ['Do not split by spaces â€” "Hello World   " has a trailing space that confuses Split().'],
  },

  // â”€â”€â”€ 63. Unique Paths II â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
  63: {
    intuition:
      'Same DP as Unique Paths I, but cells with obstacles are set to 0 (no paths through them). The recurrence is: dp[i][j] = (obstacleGrid[i][j]==1) ? 0 : dp[iâˆ’1][j] + dp[i][jâˆ’1].',
    algorithm: [
      'If start or end has an obstacle, return 0.',
      'Fill dp[0][j]=1 for all j until an obstacle is hit (all 0 after the obstacle).',
      'Fill dp[i][0]=1 for all i until an obstacle is hit.',
      'For each interior cell: dp[i][j] = (obstacle) ? 0 : dp[i-1][j] + dp[i][j-1].',
      'Return dp[m-1][n-1].',
    ],
    example: {
      input: 'obstacleGrid = [[0,0,0],[0,1,0],[0,0,0]]',
      steps: [
        'First row: dp=[1,1,1]. First col: dp[1][0]=1, dp[2][0]=1.',
        'dp[1][1]=0 (obstacle). dp[1][2]=dp[0][2]+0=1.',
        'dp[2][1]=dp[1][1]+dp[2][0]=0+1=1. dp[2][2]=dp[1][2]+dp[2][1]=1+1=2.',
      ],
      output: '2',
    },
    pitfalls: [
      'Stop filling the first row/column once an obstacle is encountered â€” all cells beyond it are unreachable.',
    ],
  },

  // â”€â”€â”€ 66. Plus One â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
  66: {
    intuition:
      'Simulate adding 1 from the rightmost digit. Carry propagates left. The only special case is all 9s (e.g., [9,9,9]) which becomes [1,0,0,0] â€” requiring a new leading digit.',
    algorithm: [
      'Traverse from the last index to 0.',
      'If digits[i] < 9: increment digits[i], return digits (no carry).',
      'Else set digits[i] = 0 (carry).',
      'If the loop completes (all 9s): create int[n+1] with [0]=1, rest 0. Return it.',
    ],
    example: {
      input: '[9,9,9]',
      steps: [
        'i=2: 9â†’0, carry. i=1: 9â†’0, carry. i=0: 9â†’0, carry. Loop ends.',
        'Return [1,0,0,0].',
      ],
      output: '[1,0,0,0]',
    },
    pitfalls: ['Allocating a new array only for the all-9s case; otherwise modify in place.'],
  },

  // â”€â”€â”€ 67. Add Binary â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
  67: {
    intuition:
      'Add two binary strings digit by digit from right to left, maintaining a carry. The result is built in reverse (or using a StringBuilder prepending at index 0, or reversing at the end).',
    algorithm: [
      'Initialise i=a.Lengthâˆ’1, j=b.Lengthâˆ’1, carry=0, StringBuilder sb.',
      'While i>=0 or j>=0 or carry>0:',
      '  sum = carry + (i>=0 ? a[i--]-"0" : 0) + (j>=0 ? b[j--]-"0" : 0).',
      '  Prepend (sum%2) to sb. carry = sum/2.',
      'Return sb.ToString().',
    ],
    example: {
      input: 'a = "11", b = "1"',
      steps: [
        'i=1,j=0: sum=0+1+1=2. append 0, carry=1.',
        'i=0,j=-1: sum=1+1+0=2. append 0, carry=1.',
        'i=-1,j=-1,carry=1: sum=1. append 1, carry=0.',
        'Reversed: "100".',
      ],
      output: '"100"',
    },
    pitfalls: ['Continue the loop while carry>0 even after both strings are exhausted.'],
  },

  // â”€â”€â”€ 73. Set Matrix Zeroes â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
  73: {
    intuition:
      'Use the first row and first column as in-place marker arrays. Two extra booleans track whether the first row/column themselves should be zeroed. This gives O(1) extra space.',
    algorithm: [
      'Check if row 0 contains a zero (firstRowZero) and if col 0 contains a zero (firstColZero).',
      'For each cell (i,j) with i>0,j>0: if matrix[i][j]==0, set matrix[i][0]=0 and matrix[0][j]=0.',
      'Zero out interior rows and columns using the markers in row 0 and col 0.',
      'If firstRowZero, zero out entire row 0. If firstColZero, zero out entire col 0.',
    ],
    example: {
      input: '[[1,1,1],[1,0,1],[1,1,1]]',
      steps: [
        'Cell (1,1)=0 â†’ mark matrix[1][0]=0 and matrix[0][1]=0.',
        'Zero row 1 (because matrix[1][0]=0): [0,0,0]. Zero col 1 (because matrix[0][1]=0): col all become 0.',
        'Result: [[1,0,1],[0,0,0],[1,0,1]].',
      ],
      output: '[[1,0,1],[0,0,0],[1,0,1]]',
    },
    pitfalls: [
      'Handle the first row and column LAST â€” their original values are used as markers for the rest of the matrix.',
    ],
  },

  // â”€â”€â”€ 75. Sort Colors (Dutch National Flag) â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
  75: {
    intuition:
      'Three-way partition using Dijkstra\'s Dutch National Flag algorithm: maintain three regions â€” [0, lowâˆ’1] all 0s, [low, midâˆ’1] all 1s, [high+1, nâˆ’1] all 2s â€” expanding them via swaps.',
    algorithm: [
      'Initialise low=0, mid=0, high=nâˆ’1.',
      'While mid <= high:',
      '  if nums[mid]==0: swap(mid, low), low++, mid++.',
      '  if nums[mid]==1: mid++ (already in correct region).',
      '  if nums[mid]==2: swap(mid, high), high-- (do NOT increment mid â€” new nums[mid] is unknown).',
    ],
    example: {
      input: '[2,0,2,1,1,0]',
      steps: [
        'mid=0(2): swap(0,5)â†’[0,0,2,1,1,2], high=4.',
        'mid=0(0): swap(0,0)â†’same, low=1,mid=1.',
        'mid=1(0): swap(1,1), low=2,mid=2.',
        'mid=2(2): swap(2,4)â†’[0,0,1,1,2,2], high=3.',
        'mid=2(1): mid=3. mid=3(1): mid=4. 4>3=high, stop.',
      ],
      output: '[0,0,1,1,2,2]',
    },
    pitfalls: [
      'When swapping with high, do NOT increment mid â€” the swapped element from high could be 0, 1, or 2 and needs to be re-examined.',
    ],
  },

  // â”€â”€â”€ 85. Maximal Rectangle â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
  85: {
    intuition:
      'Transform each row into a histogram of consecutive 1s above it. Then the largest rectangle in each histogram (problem 84) gives the largest rectangle ending at that row. Run the histogram approach for each row in O(n) with a stack.',
    algorithm: [
      'Initialise heights[n] = 0.',
      'For each row: if matrix[row][col]=="1", heights[col]++; else heights[col]=0.',
      'Run the largest-rectangle-in-histogram algorithm on heights to get the max area for this row.',
      'Update overall max across all rows.',
    ],
    example: {
      input: '[["1","0","1","0","0"],["1","0","1","1","1"],["1","1","1","1","1"],["1","0","0","1","0"]]',
      steps: [
        'After row 0: heights=[1,0,1,0,0]. Max rectangle=1.',
        'After row 1: heights=[2,0,2,1,1]. Max rectangle=3.',
        'After row 2: heights=[3,1,3,2,2]. Max rectangle=6.',
        'After row 3: heights=[4,0,0,3,0]. Max rectangle=4.',
        'Overall max=6.',
      ],
      output: '6',
    },
    pitfalls: [
      'Reset heights[col]=0 when a "0" is encountered â€” consecutive 1s are broken.',
    ],
  },

  // â”€â”€â”€ 87. Scramble String â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
  87: {
    intuition:
      'A string t is a scramble of s if there exists a split point k such that either: (s[0..k] scrambles to t[0..k] AND s[k+1..] scrambles to t[k+1..]), or (s[0..k] scrambles to t[n-k..] AND s[k+1..] scrambles to t[0..n-k-1]). Memoize on (s, t) pairs.',
    algorithm: [
      'If s == t, return true. If sorted(s) != sorted(t), return false (fast prune).',
      'Check memo map for (s, t).',
      'For k from 1 to nâˆ’1: try both the non-swapped split and the swapped split.',
      'If any k satisfies either condition, store true in memo and return true.',
      'Store false and return false.',
    ],
    example: {
      input: 's = "great", t = "rgeat"',
      steps: [
        'Try k=1: s[0..0]="g", t[0..0]="r" not scramble. s[0..0]="g" vs t[4..4]="t" â€” no.',
        'Try k=2: s[0..1]="gr" vs t[0..1]="rg" â€” yes (swapped). s[2..4]="eat" vs t[2..4]="eat" â€” yes.',
        'Return true.',
      ],
      output: 'true',
    },
    pitfalls: [
      'The anagram check (sorted chars equal) prunes many impossible branches quickly.',
      'Use a Dictionary<(string,string), bool> for memoization.',
    ],
  },

  // â”€â”€â”€ 92. Reverse Linked List II â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
  92: {
    intuition:
      'Reverse only the sublist from position left to right. Navigate to the node just before position left, then perform exactly (rightâˆ’left) pointer reversals on the sublist, reconnecting the reversed portion back into the original list.',
    algorithm: [
      'Use a dummy node before head. Advance prev to the node at position leftâˆ’1.',
      'cur = prev.next (start of sublist). For rightâˆ’left iterations: remove cur.next and insert it right after prev.',
      'Return dummy.next.',
    ],
    example: {
      input: 'head = [1â†’2â†’3â†’4â†’5], left=2, right=4',
      steps: [
        'prev = node1. cur = node2.',
        'Iteration 1: move node3 after node1. List: 1â†’3â†’2â†’4â†’5.',
        'Iteration 2: move node4 after node1. List: 1â†’4â†’3â†’2â†’5.',
      ],
      output: '[1,4,3,2,5]',
    },
    pitfalls: [
      'The "insert after prev" technique (not a full reversal loop) makes reconnection trivial â€” prev.next always points to the new head of the reversed section.',
    ],
  },

  // â”€â”€â”€ 95. Unique Binary Search Trees II â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
  95: {
    intuition:
      'For each value i as root in range [start, end], the left subtree uses [start, iâˆ’1] and the right uses [i+1, end]. The total tree count is the Catalan number. Generate all combinations by iterating over every possible root and recursively generating all left and right subtrees.',
    algorithm: [
      'Generate(start, end): if start > end, return [null].',
      'result = [].',
      'For root from start to end: leftTrees = Generate(start, rootâˆ’1), rightTrees = Generate(root+1, end).',
      'For each (L, R) pair: create node(root, left=L, right=R), add to result.',
      'Return result.',
    ],
    example: {
      input: 'n = 3',
      steps: [
        'Root=1: left=[], right=Generate(2,3)=[{2,null,3},{3,2,null}]. 2 trees.',
        'Root=2: left=[{1}], right=[{3}]. 1 tree.',
        'Root=3: left=Generate(1,2)=[{1,null,2},{2,1,null}], right=[]. 2 trees.',
        'Total 5 trees.',
      ],
      output: '5 distinct BSTs',
    },
    pitfalls: [
      'Returning [null] (a list with one null element) when start>end is critical â€” it means "one way to have an empty subtree".',
    ],
  },

  // â”€â”€â”€ 99. Recover Binary Search Tree â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
  99: {
    intuition:
      'Exactly two nodes are swapped. An in-order traversal of a BST yields a sorted sequence, so the swap creates at most two "inversions" (positions where arr[i] > arr[i+1]). The first swapped node is at the first inversion\'s larger value; the second is at the last inversion\'s smaller value.',
    algorithm: [
      'In-order traversal, tracking prev node.',
      'If prev.val > curr.val: if first is null, set first=prev. Set second=curr (always update second).',
      'After traversal: swap first.val and second.val.',
    ],
    example: {
      input: 'BST with 3 and 1 swapped: [3,1,4,null,null,2]',
      steps: [
        'In-order visits: 1, 3, 2, 4.',
        'At (3â†’2): inversion. first=3, second=2.',
        'At (2â†’next visits correctly). Swap 3.val and 2.val.',
      ],
      output: 'Corrected BST',
    },
    pitfalls: [
      'There may be one or two inversions. Using a single in-order pass and always updating second captures both cases.',
    ],
  },

  // â”€â”€â”€ 106. Construct Binary Tree from Inorder and Postorder â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
  106: {
    intuition:
      'The last element of postorder is always the root. Find it in inorder to split into left and right subtrees. The number of elements in the left inorder slice tells you exactly how many elements belong to the left postorder slice.',
    algorithm: [
      'Build a map: inorder value â†’ index.',
      'Recurse with (inLeft, inRight, postRight).',
      'Root = postorder[postRight]. Find its inorder index rootIdx.',
      'Left subtree size = rootIdx âˆ’ inLeft.',
      'Recurse left: (inLeft, rootIdxâˆ’1, postRightâˆ’1âˆ’(inRightâˆ’rootIdx)).',
      'Recurse right: (rootIdx+1, inRight, postRightâˆ’1).',
    ],
    example: {
      input: 'inorder=[9,3,15,20,7], postorder=[9,15,7,20,3]',
      steps: [
        'Root=3 (postorder last). rootIdx=1 in inorder.',
        'Left: inorder[0..0]=[9], postorder[0..0]=[9] â†’ root=9.',
        'Right: inorder[2..4]=[15,20,7], postorder[1..3]=[15,7,20] â†’ root=20, etc.',
      ],
      output: 'Tree [3,9,20,null,null,15,7]',
    },
    pitfalls: ['Use a HashMap for inorder lookups â€” linear search makes this O(nÂ²).'],
  },

  // â”€â”€â”€ 107. Binary Tree Level Order Traversal II â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
  107: {
    intuition:
      'Same BFS level-order as problem 102, but reverse the result list at the end. Reversing a list is O(levels) â€” negligible.',
    algorithm: [
      'Run standard BFS level order (same as problem 102).',
      'Reverse the result list.',
      'Return.',
    ],
    example: {
      input: 'root = [3,9,20,null,null,15,7]',
      steps: [
        'BFS gives [[3],[9,20],[15,7]].',
        'Reverse: [[15,7],[9,20],[3]].',
      ],
      output: '[[15,7],[9,20],[3]]',
    },
    pitfalls: ['Use LinkedList<List<int>> with AddFirst to avoid O(n) reversal entirely.'],
  },

  // â”€â”€â”€ 108. Convert Sorted Array to BST â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
  108: {
    intuition:
      'The middle element of a sorted array becomes the root of the BST (ensuring height balance). Recurse on the left half for the left subtree and on the right half for the right subtree.',
    algorithm: [
      'If left > right, return null.',
      'mid = left + (right âˆ’ left) / 2.',
      'Create node with nums[mid].',
      'node.left = Build(left, midâˆ’1). node.right = Build(mid+1, right).',
      'Return node.',
    ],
    example: {
      input: 'nums = [-10,-3,0,5,9]',
      steps: [
        'mid=2 (0) â†’ root=0.',
        'Left: [-10,-3] â†’ mid=0(-10)... mid=-10, right: [-3] â†’ -3.',
        'Right: [5,9] â†’ mid=5, right: [9] â†’ 9.',
      ],
      output: 'BST [0,-3,9,-10,null,5]',
    },
    pitfalls: ['For even-length arrays, either mid=(left+right)/2 or mid=(left+right+1)/2 is valid â€” the judge accepts both.'],
  },

  // â”€â”€â”€ 110. Balanced Binary Tree â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
  110: {
    intuition:
      'A tree is balanced iff for every node, |height(left) âˆ’ height(right)| â‰¤ 1. Compute height bottom-up; return âˆ’1 as a sentinel when imbalance is detected to short-circuit the recursion.',
    algorithm: [
      'Height(node): if null, return 0.',
      'lh = Height(left). If lh == âˆ’1, return âˆ’1.',
      'rh = Height(right). If rh == âˆ’1, return âˆ’1.',
      'If |lh âˆ’ rh| > 1, return âˆ’1.',
      'Return max(lh, rh) + 1.',
      'IsBalanced: return Height(root) != âˆ’1.',
    ],
    example: {
      input: 'root = [3,9,20,null,null,15,7]',
      steps: [
        'Height(9)=1, Height(20): Height(15)=1, Height(7)=1 â†’ max+1=2.',
        'Height(3): lh=1, rh=2. |1âˆ’2|=1 â‰¤ 1 âœ“. Return 3.',
      ],
      output: 'true',
    },
    pitfalls: ['Do not compute height separately for balance check and height â€” that creates O(nÂ²). Combine into one bottom-up pass.'],
  },

  // â”€â”€â”€ 111. Minimum Depth of Binary Tree â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
  111: {
    intuition:
      'Minimum depth is the depth to the nearest leaf. BFS stops at the first leaf encountered â€” that level is the minimum depth. This avoids exploring the entire tree (DFS would need to).',
    algorithm: [
      'If root is null, return 0.',
      'BFS with a queue, tracking depth.',
      'For each node: if both children are null (leaf), return current depth.',
      'Enqueue non-null children.',
    ],
    example: {
      input: 'root = [2,null,3,null,4,null,5,null,6]',
      steps: [
        'Level 1: node 2 has only right child â€” not a leaf. Level 2: node 3 â€” not a leaf. ... Level 5: node 6 â€” leaf. Return 5.',
      ],
      output: '5',
    },
    pitfalls: [
      'A node with only one child is NOT a leaf â€” do not return early there.',
      'DFS approach: min(left, right) + 1 fails when one child is null. Must handle: if left == null return right+1 (and vice versa).',
    ],
  },

  // â”€â”€â”€ 112. Path Sum â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
  112: {
    intuition:
      'DFS: subtract the current node\'s value from the target. At a leaf, check if the remaining target equals zero. Recurse down both children.',
    algorithm: [
      'If root is null, return false.',
      'If leaf (both children null): return root.val == targetSum.',
      'Return HasPathSum(root.left, targetSum âˆ’ root.val) || HasPathSum(root.right, targetSum âˆ’ root.val).',
    ],
    example: {
      input: 'root = [5,4,8,11,null,13,4,7,2,null,null,null,1], targetSum = 22',
      steps: [
        'Subtract 5â†’17. Go left: subtract 4â†’13. Go left: subtract 11â†’2. Go left: 7â‰ 2 no. Go right: 2==2 âœ“.',
      ],
      output: 'true',
    },
    pitfalls: ['Do not return true when reaching null â€” a null node is not a leaf.'],
  },

  // â”€â”€â”€ 113. Path Sum II â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
  113: {
    intuition:
      'Same as Path Sum I but record the current path when a valid leaf is found. Use backtracking to maintain the path: add node before recursion, remove after.',
    algorithm: [
      'DFS(node, remaining, path, result):',
      'If null, return.',
      'Add node.val to path. remaining -= node.val.',
      'If leaf and remaining == 0: add copy of path to result.',
      'Else: recurse left and right.',
      'Remove last element from path (backtrack).',
    ],
    example: {
      input: 'root = [5,4,8,11,null,13,4,7,2,null,null,5,1], targetSum = 22',
      steps: [
        'Path 5â†’4â†’11â†’2: sum=22 âœ“. Record [5,4,11,2]. Backtrack.',
        'Path 5â†’8â†’4â†’5: sum=22 âœ“. Record [5,8,4,5].',
      ],
      output: '[[5,4,11,2],[5,8,4,5]]',
    },
    pitfalls: ['Add a COPY of path (new List), not a reference â€” otherwise all recorded paths will be mutated by subsequent backtracking.'],
  },

  // â”€â”€â”€ 114. Flatten Binary Tree to Linked List â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
  114: {
    intuition:
      'Pre-order traversal visits root â†’ left â†’ right. The flattened list follows the same order using right pointers. The Morris-style in-place approach: for each node with a left child, find the rightmost node of the left subtree, link it to the right child, move the left subtree to right, and null out left.',
    algorithm: [
      'curr = root. While curr != null:',
      'If curr.left != null: find the rightmost node of curr.left (call it rightmost).',
      'rightmost.right = curr.right. curr.right = curr.left. curr.left = null.',
      'curr = curr.right.',
    ],
    example: {
      input: 'root = [1,2,5,3,4,null,6]',
      steps: [
        'curr=1. left=2. Rightmost of 2 = 4. Link 4.right=5. 1.right=2, 1.left=null. List:1â†’2â†’3â†’4â†’5â†’6.',
        'curr=2. left=3. Rightmost=3. Link 3.right=4. 2.right=3, 2.left=null.',
        'Continue until all left pointers are null.',
      ],
      output: '[1,null,2,null,3,null,4,null,5,null,6]',
    },
    pitfalls: ['Move the left subtree to right BEFORE advancing curr â€” otherwise you lose the right child.'],
  },

  // â”€â”€â”€ 118. Pascal\'s Triangle â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
  118: {
    intuition:
      'Each row starts and ends with 1. Interior element [i][j] = [i-1][j-1] + [i-1][j]. Build row by row.',
    algorithm: [
      'result = [[1]].',
      'For row i from 1 to numRowsâˆ’1: start new row with [1].',
      'For j from 1 to iâˆ’1: row[j] = prev[jâˆ’1] + prev[j].',
      'Append 1 at the end. Add row to result.',
    ],
    example: {
      input: 'numRows = 5',
      steps: [
        'Row 0: [1]. Row 1: [1,1]. Row 2: [1,2,1]. Row 3: [1,3,3,1]. Row 4: [1,4,6,4,1].',
      ],
      output: '[[1],[1,1],[1,2,1],[1,3,3,1],[1,4,6,4,1]]',
    },
    pitfalls: ['Build each row from the previous row, not by computing binomial coefficients separately.'],
  },

  // â”€â”€â”€ 120. Triangle â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
  120: {
    intuition:
      'Bottom-up DP: starting from the second-to-last row, each cell becomes its value plus the minimum of the two cells below it. After processing all rows, triangle[0][0] holds the answer. Modify in-place or use a 1D dp array.',
    algorithm: [
      'For row from nâˆ’2 down to 0: for col from 0 to row: triangle[row][col] += min(triangle[row+1][col], triangle[row+1][col+1]).',
      'Return triangle[0][0].',
    ],
    example: {
      input: '[[2],[3,4],[6,5,7],[4,1,8,3]]',
      steps: [
        'Row 2: 6+min(4,1)=7, 5+min(1,8)=6, 7+min(8,3)=10. â†’ [7,6,10].',
        'Row 1: 3+min(7,6)=9, 4+min(6,10)=10. â†’ [9,10].',
        'Row 0: 2+min(9,10)=11.',
      ],
      output: '11',
    },
    pitfalls: ['Process bottom-up to avoid needing an extra dp array â€” the triangle itself becomes the dp table.'],
  },

  // â”€â”€â”€ 122. Best Time to Buy and Sell Stock II â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
  122: {
    intuition:
      'You can hold at most one share at a time but can trade any number of times. Capture every upward price movement: if prices[i] > prices[iâˆ’1], add the difference to profit. This is equivalent to summing all positive day-to-day differences.',
    algorithm: [
      'profit = 0.',
      'For i from 1 to nâˆ’1: if prices[i] > prices[iâˆ’1], profit += prices[i] âˆ’ prices[iâˆ’1].',
      'Return profit.',
    ],
    example: {
      input: 'prices = [7,1,5,3,6,4]',
      steps: [
        '1â†’5: +4. 3â†’6: +3. Total=7.',
      ],
      output: '7',
    },
    pitfalls: ['This greedy works ONLY when transactions are unlimited and there are no fees.'],
  },

  // â”€â”€â”€ 135. Candy â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
  135: {
    intuition:
      'Two greedy passes: left-to-right ensures a child with higher rating than its left neighbour gets more candy. Right-to-left ensures a child with higher rating than its right neighbour gets more candy. Take the max at each position.',
    algorithm: [
      'Initialise candies[i] = 1 for all i.',
      'Left pass: for i from 1 to nâˆ’1: if ratings[i] > ratings[iâˆ’1], candies[i] = candies[iâˆ’1]+1.',
      'Right pass: for i from nâˆ’2 down to 0: if ratings[i] > ratings[i+1], candies[i] = max(candies[i], candies[i+1]+1).',
      'Return sum(candies).',
    ],
    example: {
      input: 'ratings = [1,0,2]',
      steps: [
        'Init: [1,1,1]. Left pass: ratings[2]=2>0 â†’ candies[2]=2. â†’ [1,1,2].',
        'Right pass: ratings[0]=1>0 â†’ candies[0]=max(1,1+1)=2. â†’ [2,1,2].',
        'Sum=5.',
      ],
      output: '5',
    },
    pitfalls: ['The right pass must take max(candies[i], candies[i+1]+1) â€” do not blindly overwrite the left-pass value.'],
  },

  // â”€â”€â”€ 137. Single Number II â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
  137: {
    intuition:
      'Every number appears three times except one which appears once. Use two bit-accumulator variables `ones` and `twos` that track bits seen 1 and 2 times mod 3. The state machine transitions ensure bits seen 3 times are zeroed out.',
    algorithm: [
      'ones = 0, twos = 0.',
      'For each num: ones = (ones ^ num) & ~twos. twos = (twos ^ num) & ~ones.',
      'Return ones (contains bits seen exactly once).',
    ],
    example: {
      input: '[2,2,3,2]',
      steps: [
        'After 2: ones=2, twos=0. After 2: ones=0, twos=2. After 3: ones=3, twos=2. After 2: ones=3, twos=0.',
      ],
      output: '3',
    },
    pitfalls: ['The order of updating ones and twos matters â€” compute new ones first, then new twos using the updated ones.'],
  },

  // â”€â”€â”€ 144. Binary Tree Preorder Traversal â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
  144: {
    intuition:
      'Preorder: root â†’ left â†’ right. Iterative: push right child first so the left child is processed first (LIFO stack).',
    algorithm: [
      'Push root onto stack.',
      'While stack is not empty: pop node, add to result.',
      'Push node.right (if not null), then node.left (if not null).',
    ],
    example: {
      input: 'root = [1,null,2,3]',
      steps: [
        'Push 1. Pop 1â†’result=[1]. Push 2. Pop 2â†’result=[1,2]. Push 3. Pop 3â†’result=[1,2,3].',
      ],
      output: '[1,2,3]',
    },
    pitfalls: ['Push right BEFORE left so left is popped first.'],
  },

  // â”€â”€â”€ 145. Binary Tree Postorder Traversal â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
  145: {
    intuition:
      'Postorder (leftâ†’rightâ†’root) is the reverse of a modified preorder (rootâ†’rightâ†’left). Collect rootâ†’rightâ†’left using a stack (push left before right), then reverse the result.',
    algorithm: [
      'Push root onto stack.',
      'While not empty: pop node, prepend to result (or push to another stack).',
      'Push node.left (if not null), then node.right (if not null).',
      'Result is rootâ†’rightâ†’left reversed â†’ leftâ†’rightâ†’root.',
    ],
    example: {
      input: 'root = [1,null,2,3]',
      steps: [
        'Pop 1â†’collect. Push right(2). Pop 2â†’collect. Push right(null), left(3). Pop 3â†’collect.',
        'Collected (rootâ†’rightâ†’left): [1,2,3]. Reversed: [3,2,1].',
      ],
      output: '[3,2,1]',
    },
    pitfalls: ['Reverse or use AddFirst â€” postorder is not a simple stack reversal of preorder.'],
  },

  // â”€â”€â”€ 162. Find Peak Element â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
  162: {
    intuition:
      'A peak exists on the side where the slope is ascending. If nums[mid] < nums[mid+1], the peak is to the right (ascending right); otherwise it\'s to the left or at mid. Binary search narrows to one element â€” that is a peak.',
    algorithm: [
      'lo=0, hi=nâˆ’1.',
      'While lo < hi: mid = lo + (hiâˆ’lo)/2.',
      'If nums[mid] < nums[mid+1]: lo = mid+1 (peak is right).',
      'Else: hi = mid (peak is left or at mid).',
      'Return lo.',
    ],
    example: {
      input: 'nums = [1,2,3,1]',
      steps: [
        'lo=0,hi=3. mid=1: nums[1]=2 < nums[2]=3 â†’ lo=2.',
        'lo=2,hi=3. mid=2: nums[2]=3 > nums[3]=1 â†’ hi=2.',
        'lo=hi=2. Return 2.',
      ],
      output: '2',
    },
    pitfalls: ['Use hi=mid (not midâˆ’1) to include mid as a candidate â€” it might itself be the peak.'],
  },

  // â”€â”€â”€ 165. Compare Version Numbers â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
  165: {
    intuition:
      'Split both version strings by "." and compare corresponding integer components. If one version has fewer parts, treat missing parts as 0.',
    algorithm: [
      'Split v1 and v2 by ".".',
      'Iterate up to max(len1, len2). Parse each part as int (0 if missing).',
      'If part1 < part2 return âˆ’1. If part1 > part2 return 1.',
      'Return 0 if all parts equal.',
    ],
    example: {
      input: 'version1 = "1.01", version2 = "1.001"',
      steps: [
        'Part 0: 1 vs 1 â€” equal. Part 1: 01â†’1 vs 001â†’1 â€” equal.',
        'Return 0.',
      ],
      output: '0',
    },
    pitfalls: ['Parse as int to strip leading zeros â€” "01" and "1" are the same version component.'],
  },

  // â”€â”€â”€ 166. Fraction to Recurring Decimal â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
  166: {
    intuition:
      'Long division: track remainders in a HashMap. When a remainder repeats, the decimal portion from that point is the repeating part. Insert parentheses at the stored position.',
    algorithm: [
      'Handle sign and zero separately. Work with absolute values as long.',
      'Integer part = numerator / denominator. Remainder = numerator % denominator.',
      'While remainder != 0: if remainder in map â†’ insert "(" at map[remainder] and append ")". Break.',
      'Else store map[remainder] = current position. Multiply remainder by 10. Append (remainder / denominator). remainder %= denominator.',
      'Return result.',
    ],
    example: {
      input: 'numerator=1, denominator=6',
      steps: [
        'Integer part=0. Remainder=1.',
        '1â†’10/6=1, remainder=4. 4â†’40/6=6, remainder=4.',
        'Remainder 4 repeats â†’ insert "(" at position where 4 first appeared. Append ")". â†’ "0.1(6)".',
      ],
      output: '"0.1(6)"',
    },
    pitfalls: [
      'Use long to avoid overflow â€” INT_MIN / -1 overflows int.',
      'Handle negative results: exactly one of numerator/denominator is negative.',
    ],
  },

  // â”€â”€â”€ 171. Excel Sheet Column Number â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
  171: {
    intuition:
      'Base-26 number system where A=1, B=2, ..., Z=26 (no zero digit). Scan left to right: result = result * 26 + (char âˆ’ "A" + 1).',
    algorithm: [
      'result = 0.',
      'For each character c: result = result * 26 + (c âˆ’ \'A\' + 1).',
      'Return result.',
    ],
    example: {
      input: '"ZY"',
      steps: [
        'Z: 0*26+26=26. Y: 26*26+25=701.',
      ],
      output: '701',
    },
    pitfalls: ['This is like converting a base-26 number but with digits 1â€“26 (not 0â€“25).'],
  },

  // â”€â”€â”€ 172. Factorial Trailing Zeroes â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
  172: {
    intuition:
      'Trailing zeros come from factors of 10 = 2Ã—5. There are always more factors of 2 than 5 in n!, so count only factors of 5. Every multiple of 5 contributes one 5; every multiple of 25 contributes an extra; every multiple of 125 another, etc.',
    algorithm: [
      'count = 0.',
      'While n >= 5: n /= 5. count += n.',
      'Return count.',
    ],
    example: {
      input: 'n = 25',
      steps: [
        '25/5=5 â†’ count=5. 5/5=1 â†’ count=6. 1/5=0 â†’ stop.',
      ],
      output: '6',
    },
    pitfalls: ['Do not count factors of 2 â€” they always exceed factors of 5 in n!.'],
  },

  // â”€â”€â”€ 174. Dungeon Game â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
  174: {
    intuition:
      'Forward DP fails because we don\'t know how much health we\'ll have in the future. Bottom-up DP from the bottom-right: dp[i][j] = minimum health needed when entering cell (i,j) to survive the rest of the journey. dp[i][j] = max(1, min(dp[i+1][j], dp[i][j+1]) âˆ’ dungeon[i][j]).',
    algorithm: [
      'dp[i][j] = minimum health needed at (i,j).',
      'Base: dp[m-1][n-1] = max(1, 1 âˆ’ dungeon[m-1][n-1]).',
      'Last row/col: only one direction available.',
      'Fill backwards: dp[i][j] = max(1, min(dp[i+1][j], dp[i][j+1]) âˆ’ dungeon[i][j]).',
      'Answer is dp[0][0].',
    ],
    example: {
      input: 'dungeon = [[-2,-3,3],[-5,-10,1],[10,30,-5]]',
      steps: [
        'dp[2][2]=max(1,1+5)=6. dp[2][1]=max(1,6-30)=1. dp[2][0]=max(1,1-10)=1.',
        'dp[1][2]=max(1,6-1)=5. dp[1][1]=max(1,min(1,5)+10)=11. dp[1][0]=max(1,min(11,1)+5)=6.',
        'dp[0][2]=max(1,5-3)=2. dp[0][1]=max(1,min(2,11)+3)=5. dp[0][0]=max(1,min(5,6)+2)=7.',
      ],
      output: '7',
    },
    pitfalls: ['Ensure dp values are at least 1 â€” you cannot enter a cell with 0 or negative health.'],
  },

  // â”€â”€â”€ 179. Largest Number â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
  179: {
    intuition:
      'To determine which of two numbers a and b should come first, compare the concatenations "ab" and "ba" as strings. If "ab" > "ba", place a before b. Sort all numbers using this comparator, then join.',
    algorithm: [
      'Convert all integers to strings.',
      'Sort with custom comparator: compare(a, b) = (b+a).CompareTo(a+b) â€” descending order (larger concat first).',
      'If the first element of sorted array is "0", return "0" (all zeros case).',
      'Join sorted strings and return.',
    ],
    example: {
      input: '[3,30,34,5,9]',
      steps: [
        'Compare 3 vs 30: "330" vs "303" â†’ 330>303, 3 first.',
        'Compare 34 vs 3: "343" vs "334" â†’ 343>334, 34 first.',
        'Sorted: [9,5,34,3,30]. Joined: "9534330".',
      ],
      output: '"9534330"',
    },
    pitfalls: ['The all-zeros edge case: sorted order would give "0000..." â€” return "0" instead.'],
  },

  // â”€â”€â”€ 202. Happy Number â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
  202: {
    intuition:
      'A happy number eventually reaches 1; an unhappy one enters a cycle. Detect the cycle using Floyd\'s tortoise-and-hare algorithm on the sequence of digit-square-sum values. If the slow and fast pointers ever point to 1, it\'s happy.',
    algorithm: [
      'Define Next(n): sum of squares of digits of n.',
      'slow = Next(n), fast = Next(Next(n)).',
      'While slow != fast: slow = Next(slow), fast = Next(Next(fast)).',
      'Return slow == 1.',
    ],
    example: {
      input: 'n = 19',
      steps: [
        '19 â†’ 1Â²+9Â²=82 â†’ 8Â²+2Â²=68 â†’ 6Â²+8Â²=100 â†’ 1Â²+0+0=1. Happy!',
      ],
      output: 'true',
    },
    pitfalls: ['A HashSet of visited values also works and may be clearer; Floyd\'s is O(1) space.'],
  },

  // â”€â”€â”€ 212. Word Search II â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
  212: {
    intuition:
      'Build a Trie from the word list. DFS the board; at each cell, follow the Trie to prune invalid paths immediately. When a Trie node marks the end of a word, record it. Pruning by removing found words from the Trie avoids duplicates.',
    algorithm: [
      'Insert all words into a Trie.',
      'DFS from every cell (r,c) traversing the Trie simultaneously.',
      'If the current Trie node has no child for board[r][c], return (prune).',
      'If the node is a word end, add the word to results and clear the word to avoid duplicates.',
      'Mark cell as visited ("x"), recurse into 4 neighbors, restore cell.',
    ],
    example: {
      input: 'board with "eat","oath","oat","pea"; words=["oath","eat"]',
      steps: [
        'DFS from "o" â†’ "o"â†’"a"â†’"t"â†’"h". Trie path matches "oath" â†’ add.',
        'DFS from "e" â†’ "e"â†’"a"â†’"t". Trie path matches "eat" â†’ add.',
      ],
      output: '["oath","eat"]',
    },
    pitfalls: [
      'Clear node.word after recording to prevent duplicate results.',
      'After DFS, prune leaf Trie nodes to speed up subsequent searches.',
    ],
  },

  // â”€â”€â”€ 214. Shortest Palindrome â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
  214: {
    intuition:
      'Find the longest palindromic prefix of s. The shortest palindrome is formed by appending the reverse of the non-palindromic suffix. Use KMP failure function on s + "#" + reverse(s) to find the longest prefix of s that matches a suffix of reverse(s) â€” that\'s the longest palindromic prefix.',
    algorithm: [
      'rev = reverse of s.',
      'Compute KMP failure function for combined = s + "#" + rev.',
      'The failure value at the last position tells us the length of the longest palindromic prefix of s.',
      'Prefix = s[0..lpsâˆ’1] (palindrome). Suffix = s[lps..] (non-palindromic remainder).',
      'Return reverse(suffix) + s.',
    ],
    example: {
      input: 's = "aacecaaa"',
      steps: [
        'combined = "aacecaaa#aaacecaa".',
        'KMP lps at end = 7. Longest palindromic prefix = "aacecaa" (length 7).',
        'Remaining suffix = "a". Reverse = "a". Return "a" + "aacecaaa" = "aaacecaaa".',
      ],
      output: '"aaacecaaa"',
    },
    pitfalls: ['The "#" separator is critical â€” prevents the KMP from matching across the boundary between s and rev.'],
  },

  // â”€â”€â”€ 218. The Skyline Problem â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
  218: {
    intuition:
      'Use a max-heap (sorted set) of active building heights. For each event (start or end of a building), update the heap and emit a keypoint when the maximum height changes. Process starts before ends at the same x-coordinate (to avoid height-0 gaps).',
    algorithm: [
      'Create events: for each building [l,r,h], add (l, âˆ’h) for start and (r, h) for end.',
      'Sort events by x; for equal x, starts (negative h) come before ends.',
      'Use a sorted multiset of heights, initialised with [0].',
      'For each event: if start (h<0), insert |h|. If end (h>0), remove h.',
      'If the current max height changes, emit (x, maxHeight) as a keypoint.',
    ],
    example: {
      input: '[[2,9,10],[3,7,15],[5,12,12]]',
      steps: [
        'x=2: add 10. max=10 â†’ emit [2,10].',
        'x=3: add 15. max=15 â†’ emit [3,15].',
        'x=5: add 12. max=15 (unchanged).',
        'x=7: remove 15. max=12 â†’ emit [7,12].',
        'x=9: remove 10. max=12 (unchanged).',
        'x=12: remove 12. max=0 â†’ emit [12,0].',
      ],
      output: '[[2,10],[3,15],[7,12],[12,0]]',
    },
    pitfalls: ['Sort starts before ends at the same x to avoid premature height-drop keypoints.'],
  },

  // â”€â”€â”€ 219. Contains Duplicate II â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
  219: {
    intuition:
      'Use a sliding window of size k maintained as a HashSet. As the window slides, add the new element and check if it was already present. If the window size exceeds k, remove the oldest element.',
    algorithm: [
      'window = HashSet.',
      'For i from 0 to nâˆ’1: if window.Contains(nums[i]), return true.',
      'window.Add(nums[i]). If window.Count > k, window.Remove(nums[iâˆ’k]).',
      'Return false.',
    ],
    example: {
      input: 'nums = [1,2,3,1], k = 3',
      steps: [
        'i=0: add 1. i=1: add 2. i=2: add 3. i=3: 1 is in window â†’ return true.',
      ],
      output: 'true',
    },
    pitfalls: ['Check for duplicate BEFORE adding to the window and BEFORE removing the oldest element.'],
  },

  // â”€â”€â”€ 221. Maximal Square â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
  221: {
    intuition:
      'dp[i][j] = side length of the largest square whose bottom-right corner is (i,j). If matrix[i][j]=="1": dp[i][j] = min(dp[iâˆ’1][j], dp[i][jâˆ’1], dp[iâˆ’1][jâˆ’1]) + 1. The bottleneck is the smallest of the three neighbors. Track max dp value and return maxÂ².',
    algorithm: [
      'dp[i][j] = 0 if matrix[i][j]=="0".',
      'If i==0 or j==0: dp[i][j] = matrix[i][j]âˆ’"0".',
      'Else: dp[i][j] = min(dp[i-1][j], dp[i][j-1], dp[i-1][j-1]) + 1.',
      'Track maxSide. Return maxSideÂ².',
    ],
    example: {
      input: '[["1","0","1","0","0"],["1","0","1","1","1"],["1","1","1","1","1"],["1","0","0","1","0"]]',
      steps: [
        'dp[2][3]: min(dp[1][3]=1, dp[2][2]=1, dp[1][2]=1)+1=2.',
        'dp[2][4]: min(dp[1][4]=1, dp[2][3]=2, dp[1][3]=1)+1=2.',
        'maxSide=2, answer=4.',
      ],
      output: '4',
    },
    pitfalls: ['The min of THREE neighbors (not two) â€” you need all three to be â‰¥ k for a kÃ—k square to form.'],
  },

  // â”€â”€â”€ 222. Count Complete Tree Nodes â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
  222: {
    intuition:
      'In a complete binary tree, count the height by going all-left and all-right. If they\'re equal, the left subtree is a perfect tree of height hâˆ’1 (so 2^(hâˆ’1)âˆ’1 nodes) plus root = 2^hâˆ’1 ... or use binary search on the last-level nodes in O(logÂ²n).',
    algorithm: [
      'Compute leftH (go left) and rightH (go right) from root.',
      'If leftH == rightH: full tree â†’ return (1 << leftH) âˆ’ 1.',
      'Else: return CountNodes(root.left) + CountNodes(root.right) + 1.',
    ],
    example: {
      input: 'Complete tree with 6 nodes',
      steps: [
        'Root: leftH=3, rightH=2 â†’ not full. Recurse.',
        'Root.left: leftH=2, rightH=2 â†’ full subtree, 3 nodes.',
        'Root.right: leftH=1, rightH=1 â†’ full subtree, 1 node.',
        'Total = 3+1+1 = 5... (depends on actual tree structure).',
      ],
      output: '6',
    },
    pitfalls: ['Only O(logÂ²n) recursion depth â€” not O(n). The leftH==rightH check prunes half the tree each time.'],
  },

  // â”€â”€â”€ 230. Kth Smallest Element in a BST â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
  230: {
    intuition:
      'In-order traversal of a BST visits nodes in ascending sorted order. The k-th visited node is the k-th smallest. Stop as soon as k reaches 0.',
    algorithm: [
      'InOrder(node): if null, return.',
      'InOrder(node.left).',
      'k--. If k == 0, record node.val and return.',
      'InOrder(node.right).',
    ],
    example: {
      input: 'BST = [3,1,4,null,2], k = 1',
      steps: [
        'In-order: 1, 2, 3, 4. The 1st is 1.',
      ],
      output: '1',
    },
    pitfalls: ['Decrement k during traversal and stop early â€” do not collect all nodes and index.'],
  },

  // â”€â”€â”€ 231. Power of Two â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
  231: {
    intuition:
      'A power of two in binary has exactly one bit set. The bit trick n & (nâˆ’1) clears the lowest set bit. If the result is 0 (and n > 0), only one bit was set â†’ n is a power of two.',
    algorithm: [
      'Return n > 0 && (n & (n âˆ’ 1)) == 0.',
    ],
    example: {
      input: 'n = 16',
      steps: ['16 = 10000â‚‚. nâˆ’1=15=01111â‚‚. 16&15=0. Return true.'],
      output: 'true',
    },
    pitfalls: ['n must be positive â€” 0 satisfies n&(nâˆ’1)==0 but is not a power of two.'],
  },

  // â”€â”€â”€ 237. Delete Node in a Linked List â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
  237: {
    intuition:
      'You don\'t have the previous node, but you have the node to delete. Copy the value from the next node into the current node, then skip the next node. The current node effectively becomes the next node.',
    algorithm: [
      'node.val = node.next.val.',
      'node.next = node.next.next.',
    ],
    example: {
      input: 'head = [4,5,1,9], node = 5',
      steps: [
        'Copy 1 (next\'s val) into node. node.next = node.next.next (skip old "1" node).',
        'List: [4,1,9].',
      ],
      output: '[4,1,9]',
    },
    pitfalls: ['This only works because the problem guarantees node is not the tail.'],
  },

  // â”€â”€â”€ 241. Different Ways to Add Parentheses â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
  241: {
    intuition:
      'Each operator divides the expression into a left and right sub-expression. Recursively compute all possible results from each sub-expression, then combine every left result with every right result using the operator. Memoize on the sub-string to avoid recomputation.',
    algorithm: [
      'For each operator (+, âˆ’, *) at position i: left = DiffWays(expr[0..iâˆ’1]), right = DiffWays(expr[i+1..]).',
      'Combine every l in left with every r in right using the operator. Collect all results.',
      'If no operator found, the expression is a number â€” return [int.Parse(expression)].',
    ],
    example: {
      input: '"2-1-1"',
      steps: [
        'Split at first "-": left=[2], right=DiffWays("1-1")=[0,2]. Combine: 2âˆ’0=2, 2âˆ’2=0.',
        'Split at second "-": left=DiffWays("2-1")=[1], right=[1]. Combine: 1âˆ’1=0... wait, 1âˆ’1=0 already counted.',
        'Results: [0, 2].',
      ],
      output: '[0, 2]',
    },
    pitfalls: ['Always return a copy list from the memo â€” not a reference â€” if using memoization.'],
  },

  // â”€â”€â”€ 257. Binary Tree Paths â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
  257: {
    intuition:
      'DFS with backtracking: build the path string as you go down. When you reach a leaf, add the complete path to results.',
    algorithm: [
      'DFS(node, path):',
      'If leaf: result.Add(path + node.val).',
      'Else: DFS(left, path + node.val + "->"); DFS(right, path + node.val + "->").',
    ],
    example: {
      input: 'root = [1,2,3,null,5]',
      steps: [
        'From 1â†’2â†’5: path="1->2->5". From 1â†’3: path="1->3".',
      ],
      output: '["1->2->5","1->3"]',
    },
    pitfalls: ['Use string concatenation or StringBuilder carefully â€” in C# string is immutable so no explicit backtracking needed.'],
  },

  // â”€â”€â”€ 263. Ugly Number â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
  263: {
    intuition:
      'An ugly number\'s only prime factors are 2, 3, and 5. Repeatedly divide out all factors of 2, then 3, then 5. If the result is 1, it was an ugly number. Non-positive numbers are not ugly.',
    algorithm: [
      'If n <= 0, return false.',
      'For each factor in [2, 3, 5]: while n % factor == 0, n /= factor.',
      'Return n == 1.',
    ],
    example: {
      input: 'n = 6',
      steps: ['6 / 2 = 3. 3 / 3 = 1. Result = 1 â†’ ugly.'],
      output: 'true',
    },
    pitfalls: ['n=1 is ugly (2â°Â·3â°Â·5â°). nâ‰¤0 is not ugly.'],
  },

  // â”€â”€â”€ 264. Ugly Number II â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
  264: {
    intuition:
      'Generate ugly numbers in order using three pointers, each tracking which ugly number to multiply by 2, 3, or 5 next. Always pick the minimum of the three next candidates and advance the corresponding pointer(s).',
    algorithm: [
      'dp[1] = 1. p2 = p3 = p5 = 0.',
      'For i from 1 to nâˆ’1: next = min(dp[p2]*2, dp[p3]*3, dp[p5]*5).',
      'dp[i] = next. If dp[p2]*2 == next, p2++. If dp[p3]*3 == next, p3++. If dp[p5]*5 == next, p5++.',
      'Return dp[nâˆ’1].',
    ],
    example: {
      input: 'n = 10',
      steps: [
        'Sequence: 1,2,3,4,5,6,8,9,10,12. 10th = 12.',
      ],
      output: '12',
    },
    pitfalls: ['Advance ALL pointers that produced the minimum to avoid duplicates (e.g., 2*3=6=3*2 must advance both p2 and p3).'],
  },

  // â”€â”€â”€ 273. Integer to English Words â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
  273: {
    intuition:
      'Process 3-digit groups (billions, millions, thousands, units) right to left. Each group is converted by a helper that handles hundreds, tens, and ones separately. Concatenate group strings with their magnitude labels.',
    algorithm: [
      'Define ONES=["","One","Two",...,"Nineteen"], TENS=["","","Twenty",...,"Ninety"].',
      'Helper(n) converts 1â€“999 to words.',
      'Process groups: billions=(num/1e9), millions=(num%1e9/1e6), thousands=(num%1e6/1e3), units=(num%1e3).',
      'For each non-zero group, prepend its words and magnitude label.',
    ],
    example: {
      input: '1234567',
      steps: [
        '1 million + 234 thousand + 567.',
        '"One Million Two Hundred Thirty Four Thousand Five Hundred Sixty Seven".',
      ],
      output: '"One Million Two Hundred Thirty Four Thousand Five Hundred Sixty Seven"',
    },
    pitfalls: ['Handle 0 â†’ "Zero" as a special case before the general logic.'],
  },

  // â”€â”€â”€ 278. First Bad Version â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
  278: {
    intuition:
      'Classic binary search for the leftmost true condition. If isBadVersion(mid) is true, the first bad version is at mid or earlier (hi = mid). If false, it\'s after mid (lo = mid+1).',
    algorithm: [
      'lo = 1, hi = n.',
      'While lo < hi: mid = lo + (hiâˆ’lo)/2.',
      'If isBadVersion(mid): hi = mid. Else: lo = mid+1.',
      'Return lo.',
    ],
    example: {
      input: 'n = 5, bad = 4',
      steps: [
        'lo=1,hi=5. mid=3: not bad â†’ lo=4.',
        'lo=4,hi=5. mid=4: bad â†’ hi=4.',
        'lo=hi=4. Return 4.',
      ],
      output: '4',
    },
    pitfalls: ['Use hi=mid (not midâˆ’1) to not skip the first bad version itself.'],
  },

  // â”€â”€â”€ 299. Bulls and Cows â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
  299: {
    intuition:
      'Bulls: count exact position matches in one pass. Cows: count non-bull digits in secret that appear as non-bull digits in guess. Use two frequency arrays for digits 0â€“9.',
    algorithm: [
      'For each position i: if secret[i]==guess[i], bulls++. Else: sCount[secret[i]]++, gCount[guess[i]]++.',
      'cows = sum over 0â€“9 of min(sCount[d], gCount[d]).',
      'Return "{bulls}A{cows}B".',
    ],
    example: {
      input: 'secret = "1807", guess = "7810"',
      steps: [
        'Position 1: "8"=="8" â†’ bulls=1. Others: sCount[1,0,7]++, gCount[7,1,0]++.',
        'cows: min(1,1)+min(1,1)+min(1,1)=3.',
      ],
      output: '"1A3B"',
    },
    pitfalls: ['Count non-bull occurrences only â€” do not double-count bull positions in the cow calculation.'],
  },

  // â”€â”€â”€ 303. Range Sum Query â€“ Immutable â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
  303: {
    intuition:
      'Precompute prefix sums: prefix[i] = nums[0]+...+nums[iâˆ’1]. Then SumRange(l,r) = prefix[r+1] âˆ’ prefix[l] in O(1).',
    algorithm: [
      'Constructor: prefix[0]=0. For i from 1 to n: prefix[i]=prefix[i-1]+nums[i-1].',
      'SumRange(l,r): return prefix[r+1]âˆ’prefix[l].',
    ],
    example: {
      input: 'nums = [-2,0,3,-5,2,-1], l=0, r=2',
      steps: ['prefix=[0,-2,-2,1,-4,-2,-3]. SumRange(0,2)=prefix[3]âˆ’prefix[0]=1âˆ’0=1.'],
      output: '1',
    },
    pitfalls: ['prefix array has length n+1 with prefix[0]=0 as sentinel â€” avoids boundary checks.'],
  },

  // â”€â”€â”€ 304. Range Sum Query 2D â€“ Immutable â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
  304: {
    intuition:
      '2D prefix sums: prefix[i][j] = sum of all elements in the rectangle [0,0] to [i-1,j-1]. Region sum uses inclusion-exclusion: sumRegion(r1,c1,r2,c2) = prefix[r2+1][c2+1] âˆ’ prefix[r1][c2+1] âˆ’ prefix[r2+1][c1] + prefix[r1][c1].',
    algorithm: [
      'Build prefix[m+1][n+1]. prefix[i][j] = matrix[i-1][j-1] + prefix[i-1][j] + prefix[i][j-1] âˆ’ prefix[i-1][j-1].',
      'SumRegion(r1,c1,r2,c2): return prefix[r2+1][c2+1]âˆ’prefix[r1][c2+1]âˆ’prefix[r2+1][c1]+prefix[r1][c1].',
    ],
    example: {
      input: '3Ã—3 matrix, query (2,1,4,3)',
      steps: ['Use the 4 corner prefix values with inclusion-exclusion.'],
      output: 'Constant time query',
    },
    pitfalls: ['The inclusion-exclusion formula: add the top-left corner back because it was subtracted twice.'],
  },

  // â”€â”€â”€ 309. Buy and Sell Stock with Cooldown â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
  309: {
    intuition:
      'Three states: "held" (have stock), "sold" (just sold, in cooldown), "rest" (no stock, no cooldown). Transitions: held = max(prev_held, prev_rest âˆ’ price). sold = prev_held + price. rest = max(prev_rest, prev_sold). Only need the previous day\'s three values.',
    algorithm: [
      'held = âˆ’INF, sold = 0, rest = 0.',
      'For each price: newHeld = max(held, rest âˆ’ price). newSold = held + price. newRest = max(rest, sold).',
      'held=newHeld, sold=newSold, rest=newRest.',
      'Return max(sold, rest).',
    ],
    example: {
      input: 'prices = [1,2,3,0,2]',
      steps: [
        'p=1: held=max(-âˆž,0-1)=-1, sold=-âˆž, rest=0.',
        'p=2: held=max(-1,0-2)=-1, sold=-1+2=1, rest=0.',
        'p=3: held=max(-1,0-3)=-1, sold=-1+3=2, rest=max(0,1)=1.',
        'p=0: held=max(-1,1-0)=1, sold=-1+0=-1, rest=max(1,2)=2.',
        'p=2: held=max(1,2-2)=1, sold=1+2=3, rest=max(2,-1)=2.',
        'Return max(3,2)=3.',
      ],
      output: '3',
    },
    pitfalls: ['Update all three states simultaneously (from previous values) â€” do not read updated values mid-step.'],
  },

  // â”€â”€â”€ 310. Minimum Height Trees â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
  310: {
    intuition:
      'The roots of MHTs are the center node(s) of the tree (1 or 2 nodes). Iteratively trim leaf nodes (degree 1) like peeling an onion. The last remaining 1 or 2 nodes are the answer.',
    algorithm: [
      'Build adjacency list and degree array.',
      'Enqueue all leaves (degree == 1).',
      'While remaining nodes > 2: dequeue leaves, decrement neighbor degrees, enqueue new leaves (degree now 1). Remaining -= leaves.Count.',
      'Return remaining node indices.',
    ],
    example: {
      input: 'n=6, edges=[[3,0],[3,1],[3,2],[3,4],[5,4]]',
      steps: [
        'Initial leaves: [0,1,2,5]. Trim â†’ 3 and 4 become new leaves.',
        '2 nodes remain: [3,4]. Return [3,4].',
      ],
      output: '[3,4]',
    },
    pitfalls: ['Stop when 1 or 2 nodes remain â€” do not trim further.'],
  },

  // â”€â”€â”€ 316. Remove Duplicate Letters â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
  316: {
    intuition:
      'Greedy + monotonic stack: for each character, pop characters from the stack that are greater than the current one AND still appear later in the string (so they can be included later). This ensures the lexicographically smallest result while including each character exactly once.',
    algorithm: [
      'Count remaining occurrences of each character. Track which characters are in the stack (inStack set).',
      'For each character c: decrement count[c]. If c is in stack, skip.',
      'While stack top > c AND count[stack.top] > 0: pop top, remove from inStack.',
      'Push c, add to inStack.',
      'Return stack as string.',
    ],
    example: {
      input: '"cbacdcbc"',
      steps: [
        'c(count: c=4,b=2,a=1,d=1). Process c: stack=[c].',
        'b: c>b and count[c]=3>0 â†’ pop c. stack=[b].',
        'a: b>a and count[b]=1>0 â†’ pop b. stack=[a].',
        'c: push. stack=[a,c]. d: push. stack=[a,c,d]. c: in stack skip. b: push. stack=[a,c,d,b]. c: in stack, skip.',
      ],
      output: '"acdb"',
    },
    pitfalls: ['Only pop a character if it still appears later (count > 0) â€” otherwise removing it would lose the character entirely.'],
  },

  // â”€â”€â”€ 319. Bulb Switcher â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
  319: {
    intuition:
      'Bulb i is toggled by all its divisors. A bulb ends ON only if it has an odd number of divisors â€” which happens only for perfect squares. Count of perfect squares â‰¤ n = floor(âˆšn).',
    algorithm: [
      'Return (int)Math.Sqrt(n).',
    ],
    example: {
      input: 'n = 3',
      steps: [
        'Perfect squares â‰¤ 3: 1. floor(âˆš3)=1.',
        'Only bulb 1 stays on.',
      ],
      output: '1',
    },
    pitfalls: ['Use integer square root carefully â€” floating point sqrt(4) might give 1.9999... for some n.'],
  },

  // â”€â”€â”€ 326. Power of Three â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
  326: {
    intuition:
      'The largest power of 3 that fits in an int is 3^19 = 1,162,261,467. A number n is a power of 3 iff it divides this maximum power exactly.',
    algorithm: [
      'Return n > 0 && 1162261467 % n == 0.',
    ],
    example: {
      input: 'n = 9',
      steps: ['1162261467 % 9 = 0. Return true.'],
      output: 'true',
    },
    pitfalls: ['This only works because 3 is prime â€” the same trick does not apply to composite bases (e.g., 6 is not a power of 2 or 3 but 12 % 6 = 0).'],
  },

  // â”€â”€â”€ 329. Longest Increasing Path in a Matrix â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
  329: {
    intuition:
      'DFS with memoization on each cell: memo[i][j] = length of longest increasing path starting at (i,j). Explore all 4 directions, only moving to strictly larger values.',
    algorithm: [
      'memo[m][n] = 0 (uncomputed).',
      'DFS(i,j): if memo[i][j] != 0, return it.',
      'For each neighbor (ni,nj): if matrix[ni][nj] > matrix[i][j], best = max(best, DFS(ni,nj)+1).',
      'memo[i][j] = best. Return.',
      'Answer = max DFS(i,j) over all cells.',
    ],
    example: {
      input: '[[9,9,4],[6,6,8],[2,1,1]]',
      steps: [
        'DFS(2,0)=2 â†’ 2â†’6 path. DFS(2,1)=3 â†’ 1â†’6â†’9. Best=4 (1â†’2â†’6â†’9).',
      ],
      output: '4',
    },
    pitfalls: ['Memoize to avoid exponential recomputation â€” each cell is computed at most once.'],
  },

  // â”€â”€â”€ 330. Patching Array â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
  330: {
    intuition:
      'Greedily maintain the range [1, reach] that can be formed from the current elements. If nums[i] â‰¤ reach+1, it extends reach to reach+nums[i]. Otherwise, patch by adding reach+1 to the array, doubling reach.',
    algorithm: [
      'reach=0, patches=0, i=0.',
      'While reach < n: if i < nums.Length and nums[i] <= reach+1: reach += nums[i]; i++.',
      'Else: reach += reach+1 (patch); patches++.',
      'Return patches.',
    ],
    example: {
      input: 'nums = [1,3], n = 6',
      steps: [
        'reach=0. nums[0]=1â‰¤1: reach=1.',
        'nums[1]=3â‰¤2? No. Patch: add 2, reach=3. patches=1.',
        'nums[1]=3â‰¤4: reach=6.',
        'reach=6 â‰¥ n=6. Done. patches=1.',
      ],
      output: '1',
    },
    pitfalls: ['When patching, always add reach+1 (the smallest uncoverable number) â€” this maximally extends reach.'],
  },

  // â”€â”€â”€ 331. Verify Preorder Serialization of a Binary Tree â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
  331: {
    intuition:
      'Use slot counting: the root consumes 1 slot and produces 2 child slots. A null ("#") consumes 1 slot and produces 0. Start with 1 slot (for the root). The sequence is valid iff slots never go negative and ends at exactly 0.',
    algorithm: [
      'slots = 1.',
      'For each token in preorder.Split(","):',
      '  slots-- (consume one slot). If slots < 0, return false.',
      '  If token != "#": slots += 2 (add two child slots).',
      'Return slots == 0.',
    ],
    example: {
      input: '"9,3,4,#,#,1,#,#,2,#,6,#,#"',
      steps: [
        'slots=1. "9":âˆ’1+2=2. "3":1+2=3. "4":2+2=4. "#":3. "#":2. "1":1+2=3. "#":2. "#":1. "2":0+2=2. "#":1. "6":0+2=2. "#":1. "#":0.',
        'slots=0 â†’ true.',
      ],
      output: 'true',
    },
    pitfalls: ['The slot count must stay non-negative throughout â€” not just be 0 at the end.'],
  },

  // â”€â”€â”€ 342. Power of Four â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
  342: {
    intuition:
      'A power of four is a power of two (n & (nâˆ’1) == 0) whose single set bit is in an even position (bits 0, 2, 4, ...). The mask 0x55555555 selects all even-position bits. Combine all three conditions.',
    algorithm: [
      'Return n > 0 && (n & (n-1)) == 0 && (n & 0x55555555) != 0.',
    ],
    example: {
      input: 'n = 16',
      steps: ['16=10000â‚‚. Power of two âœ“. Bit at position 4 (even) âœ“. 16 & 0x55555555 = 0x10 â‰  0 âœ“.'],
      output: 'true',
    },
    pitfalls: ['n=2 is a power of two but not four: bit 1 is odd. The mask correctly rejects it.'],
  },

  // â”€â”€â”€ 344. Reverse String â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
  344: {
    intuition:
      'Two-pointer swap: left starts at 0, right at nâˆ’1. Swap and move both inward until they meet.',
    algorithm: [
      'lo=0, hi=nâˆ’1. While lo < hi: swap(s[lo], s[hi]); lo++; hi--.',
    ],
    example: {
      input: '["h","e","l","l","o"]',
      steps: ['Swap h,o â†’ ["o","e","l","l","h"]. Swap e,l â†’ ["o","l","l","e","h"].'],
      output: '["o","l","l","e","h"]',
    },
    pitfalls: ['In-place modification â€” no extra array needed.'],
  },

  // â”€â”€â”€ 350. Intersection of Two Arrays II â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
  350: {
    intuition:
      'Count frequencies in the smaller array via a HashMap. Iterate the larger array: for each element, if it exists in the map with count > 0, add it to results and decrement the count.',
    algorithm: [
      'Build count map from nums1.',
      'For each val in nums2: if count[val] > 0, add to result, decrement count[val].',
      'Return result.',
    ],
    example: {
      input: 'nums1 = [1,2,2,1], nums2 = [2,2]',
      steps: [
        'count={1:2, 2:2}. Process 2: count[2]=1, result=[2]. Process 2: count[2]=0, result=[2,2].',
      ],
      output: '[2,2]',
    },
    pitfalls: ['Unlike problem 349 (unique intersection), here duplicates matter â€” use counts, not a set.'],
  },

  // â”€â”€â”€ 367. Valid Perfect Square â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
  367: {
    intuition:
      'Binary search for an integer x such that xÂ² == num. Use long to avoid overflow.',
    algorithm: [
      'lo=1, hi=num.',
      'While lo â‰¤ hi: mid = lo + (hiâˆ’lo)/2. sq = (long)mid*mid.',
      'If sq == num: return true. If sq < num: lo=mid+1. Else: hi=midâˆ’1.',
      'Return false.',
    ],
    example: {
      input: 'num = 16',
      steps: ['mid=8: 64>16 â†’ hi=7. mid=4: 16==16 â†’ true.'],
      output: 'true',
    },
    pitfalls: ['Use long for sq â€” mid*mid overflows int for large num.'],
  },

  // â”€â”€â”€ 368. Largest Divisible Subset â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
  368: {
    intuition:
      'Sort the array. dp[i] = length of the largest divisible subset ending at nums[i]. For nums[i] to extend subset dp[j], we need nums[i] % nums[j] == 0 (since sorted, nums[j] â‰¤ nums[i]). Track parent pointers to reconstruct the subset.',
    algorithm: [
      'Sort nums. dp[i]=1, parent[i]=âˆ’1.',
      'For i from 1 to nâˆ’1: for j from iâˆ’1 to 0: if nums[i]%nums[j]==0 and dp[j]+1>dp[i]: dp[i]=dp[j]+1, parent[i]=j.',
      'Find index of max dp value. Trace back using parent pointers.',
    ],
    example: {
      input: 'nums = [1,2,3,6]  â†’ sorted: [1,2,3,6]',
      steps: [
        'dp[0]=1. dp[1]: 2%1==0 â†’ dp[1]=2. dp[2]: 3%1==0 â†’ dp[2]=2. dp[3]: 6%3==0 â†’ dp[3]=3.',
        'Max at index 3, trace: 6â†3â†1.',
      ],
      output: '[1,3,6]',
    },
    pitfalls: ['Only check divisibility in one direction since array is sorted â€” nums[i] % nums[j] (not nums[j] % nums[i]).'],
  },

  // â”€â”€â”€ 386. Lexicographical Numbers â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
  386: {
    intuition:
      'Lexicographic order is DFS traversal of a 10-ary trie (each node 0â€“9 as children). Start from 1, go as deep as possible (multiply by 10), backtrack when needed (increment + skip trailing 9s and divisors of 10).',
    algorithm: [
      'curr=1, result=[].',
      'For i from 1 to n: append curr to result.',
      'If curr*10 â‰¤ n: curr *= 10.',
      'Else: if curr >= n: curr /= 10. curr++. While curr % 10 == 0: curr /= 10.',
    ],
    example: {
      input: 'n = 13',
      steps: [
        '1â†’10â†’11â†’12â†’13â†’(backtrack)â†’2â†’3â†’...â†’9.',
        'Order: 1,10,11,12,13,2,3,4,5,6,7,8,9.',
      ],
      output: '[1,10,11,12,13,2,3,4,5,6,7,8,9]',
    },
    pitfalls: ['After backtracking, keep dividing by 10 while the number ends in 0 to maintain valid prefix form.'],
  },

  // â”€â”€â”€ 400. Nth Digit â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
  400: {
    intuition:
      'Digits are grouped by number of digits: 1-digit (1â€“9, 9 numbers, 9 digits total), 2-digit (10â€“99, 90 numbers, 180 digits), etc. Find which group the n-th digit falls in, then the exact number, then the exact digit within that number.',
    algorithm: [
      'digits=1, count=9, start=1.',
      'While n > digits*count: n -= digits*count. digits++. count*=10. start*=10.',
      'The target number is start + (nâˆ’1)/digits.',
      'The digit within that number: (nâˆ’1) % digits, counted from the left.',
    ],
    example: {
      input: 'n = 11',
      steps: [
        'Group 1 (1-digit): 9 digits. n=11>9 â†’ n=2, digits=2, start=10.',
        'Number = 10 + (2-1)/2 = 10. Digit index = (2-1)%2 = 1. "10"[1] = "0".',
      ],
      output: '0',
    },
    pitfalls: ['Subtract group total from n before advancing â€” the remaining n indexes within the next group.'],
  },

  // â”€â”€â”€ 401. Binary Watch â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
  401: {
    intuition:
      'Enumerate all valid times (hours 0â€“11, minutes 0â€“59) and count the number of 1-bits in the combined binary representation (hours take 4 bits, minutes take 6 bits). If bit count == num, add the time to results.',
    algorithm: [
      'For h from 0 to 11: for m from 0 to 59: if BitCount(h)+BitCount(m)==num: add "{h}:{m:D2}" to results.',
    ],
    example: {
      input: 'num = 1',
      steps: [
        'h=0,m=1: bits=0+1=1 âœ“ â†’ "0:01". h=0,m=2: 1 bit âœ“ â†’ "0:02". ... h=1,m=0: 1+0=1 âœ“ â†’ "1:00". Etc.',
      ],
      output: '["0:01","0:02","0:04","0:08","0:16","0:32","1:00","2:00","4:00","8:00"]',
    },
    pitfalls: ['Format minutes with leading zero â€” "0:1" is wrong, must be "0:01".'],
  },

  // â”€â”€â”€ 405. Convert a Number to Hexadecimal â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
  405: {
    intuition:
      'For negative numbers, use two\'s complement (treat as unsigned 32-bit). Process 4 bits at a time (one hex digit) by AND-ing with 0xF and right-shifting. For two\'s complement in C#, cast to uint first.',
    algorithm: [
      'If num == 0, return "0".',
      'Use uint n = (uint)num to handle negatives as 32-bit unsigned.',
      'While n != 0: digit = n & 0xF. Prepend "0123456789abcdef"[digit] to result. n >>= 4.',
      'Return result.',
    ],
    example: {
      input: 'num = 26',
      steps: ['26 & 0xF = 10 â†’ "a". 26>>4 = 1. 1 & 0xF = 1 â†’ "1". Result = "1a".'],
      output: '"1a"',
    },
    pitfalls: ['Cast to uint before processing to correctly handle negative numbers via two\'s complement.'],
  },

  // â”€â”€â”€ 407. Trapping Rain Water II â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
  407: {
    intuition:
      'Extend problem 42 to 2D: water is trapped by the lowest boundary cell around any inner cell. Use a min-heap (priority queue) initialized with all border cells. BFS/Dijkstra-style: always process the current minimum-height border, push unvisited neighbors, and the water trapped = max(0, borderHeight âˆ’ cellHeight).',
    algorithm: [
      'Add all border cells to the min-heap with their heights. Mark visited.',
      'While heap is not empty: pop (h, r, c) with minimum height.',
      'For each unvisited neighbor (nr, nc): water += max(0, h âˆ’ heightMap[nr][nc]).',
      'Push (max(h, heightMap[nr][nc]), nr, nc) to heap. Mark visited.',
    ],
    example: {
      input: 'heightMap = [[1,4,3,1,3,2],[3,2,1,3,2,4],[2,3,3,2,3,1]]',
      steps: [
        'Border cells form initial boundary. Inner cells are filled to the boundary height they\'re surrounded by.',
        'Total trapped = 4.',
      ],
      output: '4',
    },
    pitfalls: ['The neighbor is pushed with max(h, heightMap[nr][nc]) â€” not the raw neighbor height â€” because the water level cannot drop below the current boundary.'],
  },

  // â”€â”€â”€ 417. Pacific Atlantic Water Flow â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
  417: {
    intuition:
      'Instead of simulating water flow from each cell to oceans, reverse the problem: BFS/DFS from ocean borders inward (visiting cells that can flow TO the ocean). Cells reachable from both Pacific and Atlantic borders are the answer.',
    algorithm: [
      'pacificQueue = all top row and left column cells. atlanticQueue = all bottom row and right column cells.',
      'BFS from each queue: mark cells reachable from Pacific / Atlantic.',
      'A cell moves to neighbor if neighbor height >= current (water flows uphill in reverse).',
      'Return cells marked by both BFS passes.',
    ],
    example: {
      input: 'heights = [[1,2,2,3,5],[3,2,3,4,4],[2,4,5,3,1],[6,7,1,4,5],[5,1,1,2,4]]',
      steps: [
        'Pacific BFS from top/left border expands inward.',
        'Atlantic BFS from bottom/right border expands inward.',
        'Intersection = cells reachable from both.',
      ],
      output: '[[0,4],[1,3],[1,4],[2,2],[3,0],[3,1],[4,0]]',
    },
    pitfalls: ['Reverse the comparison: neighbor.height >= current.height (in reverse, water can flow uphill).'],
  },

}

export default explanations
