/**
 * Rich structured explanations for LeetCode problems.
 * When present, the detail page renders these instead of the plain approach comment block.
 * Keys are problem numbers (integers).
 */
export interface RichExplanation {
  /** The key insight — why this approach works, in 2-4 sentences. */
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

  // ─── 4. Median of Two Sorted Arrays ─────────────────────────────────────────
  4: {
    intuition:
      'The naive approach merges both arrays and picks the middle element — O(m+n). The insight is that we never actually need to merge. Instead, binary search for the correct partition index in the smaller array: once we know how many elements belong in the combined left half, the median falls out directly from the four elements at the boundary.',
    algorithm: [
      'Ensure nums1 is the smaller array (swap if needed) to keep binary search on the shorter side.',
      'Binary search the partition index `cut1` in nums1 from 0 to m. Derive `cut2 = (m+n+1)/2 - cut1` for nums2.',
      'The partition is valid when maxLeft1 ≤ minRight2 AND maxLeft2 ≤ minRight1.',
      'If maxLeft1 > minRight2, move cut1 left (high = cut1 − 1). If maxLeft2 > minRight1, move cut1 right (low = cut1 + 1).',
      'Once the partition is valid: if (m+n) is odd, the median is max(maxLeft1, maxLeft2). If even, it is (max(maxLeft1, maxLeft2) + min(minRight1, minRight2)) / 2.',
    ],
    example: {
      input: 'nums1 = [1, 3], nums2 = [2]',
      steps: [
        'Total length = 3 (odd), so we need 2 elements in the left half.',
        'Binary search: cut1 = 1 → maxLeft1 = 1, minRight1 = 3. cut2 = 1 → maxLeft2 = 2, minRight2 = ∞.',
        'Check: maxLeft1 (1) ≤ minRight2 (∞) ✓ and maxLeft2 (2) ≤ minRight1 (3) ✓ — valid partition.',
        'Odd total → median = max(1, 2) = 2.',
      ],
      output: '2.0',
    },
    pitfalls: [
      'Use INT_MIN / INT_MAX as sentinels when cut1 = 0 or cut1 = m to avoid array out-of-bounds.',
      'Calculate mid as lo + (hi − lo) / 2 to avoid integer overflow when lo + hi is large.',
      'Ensure binary search is on the shorter array so cut2 never goes negative.',
    ],
  },

  // ─── 11. Container With Most Water ──────────────────────────────────────────
  11: {
    intuition:
      'Place two pointers at opposite ends and ask: which pointer should move? The area is limited by the shorter side. Moving the taller side inward can only keep or reduce the height limit while reducing width — guaranteed to be worse. Moving the shorter side inward may find a taller line that compensates for the reduced width. So always advance the shorter pointer.',
    algorithm: [
      'Initialise left = 0, right = n−1, maxArea = 0.',
      'While left < right: compute area = min(height[left], height[right]) × (right − left).',
      'Update maxArea = max(maxArea, area).',
      'Advance the pointer pointing to the shorter line: if height[left] < height[right] → left++; else → right--.',
      'Return maxArea.',
    ],
    example: {
      input: 'height = [1, 8, 6, 2, 5, 4, 8, 3, 7]',
      steps: [
        'left=0 (h=1), right=8 (h=7): area = 1×8 = 8. height[left]<height[right] → left++.',
        'left=1 (h=8), right=8 (h=7): area = 7×7 = 49. height[right]<height[left] → right--.',
        'left=1 (h=8), right=7 (h=3): area = 3×6 = 18. right--.',
        'Continue until left=1, right=6 (h=8): area = 8×5 = 40.',
        'Max found so far is 49 — no further pair beats it.',
      ],
      output: '49',
    },
    pitfalls: [
      'Do NOT move the pointer with the greater height — that is always suboptimal.',
      'The algorithm works because if a better container exists, the two-pointer sweep is guaranteed to visit it.',
    ],
  },

  // ─── 15. 3Sum ────────────────────────────────────────────────────────────────
  15: {
    intuition:
      'Brute force is O(n³) — check every triplet. Sort first: this costs O(n log n) but unlocks the two-pointer technique. With the array sorted, fix one number and reduce the problem to "find a pair summing to its negation" — exactly the Two Sum II pattern, solvable in O(n) with two pointers. Total: O(n²).',
    algorithm: [
      'Sort the array in ascending order.',
      'Iterate i from 0 to n−3. If nums[i] > 0, break early (no three positives can sum to 0).',
      'Skip duplicate values of nums[i]: if i > 0 and nums[i] == nums[i−1], continue.',
      'Set left = i+1, right = n−1. Run two-pointer loop while left < right.',
      'If sum == 0: record [nums[i], nums[left], nums[right]], skip duplicate lefts and rights, then advance both pointers.',
      'If sum < 0: left++ (need a larger value). If sum > 0: right-- (need a smaller value).',
    ],
    example: {
      input: 'nums = [−1, 0, 1, 2, −1, −4]  → sorted: [−4, −1, −1, 0, 1, 2]',
      steps: [
        'i=0, nums[i]=−4. Two pointers: left=1(−1), right=5(2). Sum=−3 < 0 → left++.',
        'left=2(−1), right=5(2). Sum=−3 < 0 → left++. left=3(0), right=5(2). Sum=−2 < 0 → left++. Exhaust without match.',
        'i=1, nums[i]=−1. left=2(−1), right=5(2). Sum=0 ✓ → record [−1,−1,2]. Skip dups, advance.',
        'left=3(0), right=4(1). Sum=0 ✓ → record [−1,0,1].',
        'i=2, nums[i]=−1 == nums[1] → skip (duplicate outer).',
      ],
      output: '[[-1,-1,2], [-1,0,1]]',
    },
    pitfalls: [
      'Skip outer duplicates with `i > 0 && nums[i] == nums[i-1]` — not `nums[i] == nums[i+1]`.',
      'After finding a match, also skip inner duplicates on both left and right pointers.',
      'The early break `if nums[i] > 0 return` only works because the array is sorted.',
    ],
  },

  // ─── 19. Remove Nth Node From End of List ───────────────────────────────────
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
      input: 'head = [1→2→3→4→5], n = 2',
      steps: [
        'dummy→1→2→3→4→5. Advance fast 3 steps: fast=3, slow=dummy.',
        'Move both: fast=4, slow=1. Move both: fast=5, slow=2. Move both: fast=null, slow=3.',
        'slow.next (node 4) is the 2nd from end. slow.next = node 5.',
        'List becomes 1→2→3→5.',
      ],
      output: '[1, 2, 3, 5]',
    },
    pitfalls: [
      'Advance fast n+1 (not n) steps so slow stops one node BEFORE the target.',
      'The dummy node is essential: without it, removing the head (n == list length) requires a special case.',
    ],
  },

  // ─── 22. Generate Parentheses ───────────────────────────────────────────────
  22: {
    intuition:
      'At each position in the string we have at most two choices: place "(" or ")". The constraints — open count ≤ n and close count ≤ open count — automatically prune all invalid branches, so every leaf of the recursion tree is already a valid string. No post-validation is needed.',
    algorithm: [
      'Recurse with state: (currentString, openCount, closeCount).',
      'Base case: if currentString.Length == 2×n, add it to results.',
      'If openCount < n: recurse with "(" appended and openCount+1.',
      'If closeCount < openCount: recurse with ")" appended and closeCount+1.',
    ],
    example: {
      input: 'n = 2',
      steps: [
        'Start: ("", 0, 0). Can add "(" → ("(", 1, 0).',
        'From ("(", 1, 0): add "(" → ("((", 2, 0) or add ")" → ("()", 1, 1).',
        'From ("((", 2, 0): can only add ")" → ("(()", 2, 1) → ("(())", 2, 2) ✓.',
        'From ("()", 1, 1): add "(" → ("()(", 2, 1) → ("()()", 2, 2) ✓.',
      ],
      output: '["(())", "()()"]',
    },
    pitfalls: [
      'Do not use close < n as the condition for adding ")". Use close < open — otherwise you generate invalid strings like "))(".',
      'The total valid combinations equal the Catalan number C(n), not 2^(2n).',
    ],
  },

  // ─── 33. Search in Rotated Sorted Array ─────────────────────────────────────
  33: {
    intuition:
      'A rotated sorted array always has at least one "sorted half" — either [lo, mid] or [mid, hi]. Once you identify which half is sorted, checking whether the target lies in that range is a simple boundary comparison. This is what standard binary search does, but applied to the sorted half rather than the whole array.',
    algorithm: [
      'Initialise lo = 0, hi = n−1.',
      'While lo ≤ hi: compute mid = lo + (hi−lo)/2. If nums[mid] == target, return mid.',
      'Determine which half is sorted: if nums[lo] ≤ nums[mid], the left half [lo, mid] is sorted.',
      'Left sorted: if nums[lo] ≤ target < nums[mid], search left (hi = mid−1). Else search right (lo = mid+1).',
      'Right sorted (else): if nums[mid] < target ≤ nums[hi], search right (lo = mid+1). Else search left (hi = mid−1).',
      'Return −1 if not found.',
    ],
    example: {
      input: 'nums = [4, 5, 6, 7, 0, 1, 2], target = 0',
      steps: [
        'lo=0, hi=6, mid=3 (nums[mid]=7). nums[lo]=4 ≤ nums[mid]=7 → left half sorted.',
        'target=0 not in [4,7] → search right: lo=4.',
        'lo=4, hi=6, mid=5 (nums[mid]=1). nums[lo]=0 ≤ nums[mid]=1 → left half sorted.',
        'target=0 in [0,1] → search left: hi=4.',
        'lo=4, hi=4, mid=4 (nums[mid]=0) == target. Return 4.',
      ],
      output: '4',
    },
    pitfalls: [
      'Use nums[lo] ≤ nums[mid] (not strict <) to handle the case where lo == mid.',
      'Duplicate values (problem 81) break this approach — requires handling nums[lo] == nums[mid] by shrinking lo.',
    ],
  },

  // ─── 56. Merge Intervals ─────────────────────────────────────────────────────
  56: {
    intuition:
      'If intervals were sorted by start time, any two overlapping intervals would be adjacent. So sort first, then a single linear scan can greedily merge any interval that overlaps with the last recorded merged interval.',
    algorithm: [
      'Sort intervals by start value.',
      'Initialise the result list with the first interval.',
      'For each remaining interval [s, e]: if s ≤ result.Last.end (overlap), extend: result.Last.end = max(result.Last.end, e).',
      'Otherwise they do not overlap: push [s, e] as a new separate interval.',
      'Return the result list.',
    ],
    example: {
      input: '[[1,3],[2,6],[8,10],[15,18]]',
      steps: [
        'Sort (already sorted). Start with result = [[1,3]].',
        '[2,6]: start 2 ≤ 3 → overlap. Extend: result = [[1,6]].',
        '[8,10]: start 8 > 6 → no overlap. Push: result = [[1,6],[8,10]].',
        '[15,18]: start 15 > 10 → no overlap. Push: result = [[1,6],[8,10],[15,18]].',
      ],
      output: '[[1,6],[8,10],[15,18]]',
    },
    pitfalls: [
      'When extending, take max(current.end, new.end) — the new interval might be entirely contained inside the current one.',
      'Sorting by start is essential; without it, non-adjacent overlapping intervals are missed.',
    ],
  },

  // ─── 70. Climbing Stairs ────────────────────────────────────────────────────
  70: {
    intuition:
      'To reach step n you must come from step n−1 (one stair) or step n−2 (two stairs). So the total ways equals ways(n−1) + ways(n−2) — the Fibonacci recurrence. There is no need for memoization or a full array; two rolling variables suffice.',
    algorithm: [
      'Handle base cases: n=1 → 1 way. n=2 → 2 ways.',
      'Initialise prev2 = 1 (ways to reach step 1), prev1 = 2 (ways to reach step 2).',
      'For i from 3 to n: cur = prev1 + prev2; prev2 = prev1; prev1 = cur.',
      'Return prev1.',
    ],
    example: {
      input: 'n = 5',
      steps: [
        'Step 1: 1 way. Step 2: 2 ways. Step 3: 1+2=3 ways.',
        'Step 4: 2+3=5 ways. Step 5: 3+5=8 ways.',
        'Sequence: 1, 2, 3, 5, 8 — the Fibonacci numbers offset by one.',
      ],
      output: '8',
    },
    pitfalls: [
      'The answer is Fibonacci(n+1), not Fibonacci(n) — make sure your base cases match.',
      'Do not create a dp[n+1] array; two variables is sufficient and avoids O(n) space.',
    ],
  },

  // ─── 76. Minimum Window Substring ───────────────────────────────────────────
  76: {
    intuition:
      'Sliding window: expand the right edge until all required characters are covered, then shrink the left edge to minimise the window size while still covering all characters. Track "how many required characters are still unmet" as a counter to decide when the window is valid — this avoids re-scanning the frequency array on every check.',
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
        'Expand right until required=0: window "ADOBEC" (indices 0–5). Record length 6.',
        'Shrink left: remove A → required=1. Expand right to include next A.',
        'Window "DOBECODEBA" — shrink left again until "BANC" (indices 9–12). Length 4.',
        'Shrink left: remove B → required=1. Right exhausted. Best window is "BANC".',
      ],
      output: '"BANC"',
    },
    pitfalls: [
      'Use an int[128] character array instead of a Dictionary for O(1) per character operations.',
      'Decrement count BEFORE checking if it was > 0 (or check > 0 before decrement) — order matters for the required counter.',
      'Edge case: if t is longer than s or s is empty, return "" immediately.',
    ],
  },

  // ─── 100. Same Tree ──────────────────────────────────────────────────────────
  100: {
    intuition:
      'Two binary trees are the same if and only if their roots hold the same value AND their left subtrees are the same AND their right subtrees are the same. This directly translates to a recursive definition with simple base cases.',
    algorithm: [
      'Base case: if both nodes are null → return true (two empty trees are identical).',
      'Base case: if one is null and the other is not → return false.',
      'Base case: if root values differ → return false.',
      'Recurse: return IsSameTree(p.left, q.left) AND IsSameTree(p.right, q.right).',
    ],
    example: {
      input: 'p = [1,2,3], q = [1,2,3]',
      steps: [
        'Compare roots: both 1 → match. Recurse on left children (both 2) and right children (both 3).',
        'Left: both 2 → match. Their children are null → base case, return true.',
        'Right: both 3 → match. Their children are null → base case, return true.',
        'All checks pass → return true.',
      ],
      output: 'true',
    },
    pitfalls: [
      'Check for null before comparing values — accessing .val on null causes a NullReferenceException.',
      'The null check `p == null && q == null` must come before `p == null || q == null` to avoid false negatives.',
    ],
  },

  // ─── 102. Binary Tree Level Order Traversal ─────────────────────────────────
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
        'Queue: [3]. levelSize=1. Dequeue 3 → level=[3]. Enqueue 9,20. Result=[[3]].',
        'Queue: [9,20]. levelSize=2. Dequeue 9 → enqueue nothing. Dequeue 20 → enqueue 15,7. Result=[[3],[9,20]].',
        'Queue: [15,7]. levelSize=2. Dequeue both → level=[15,7]. Result=[[3],[9,20],[15,7]].',
      ],
      output: '[[3],[9,20],[15,7]]',
    },
    pitfalls: [
      'Snapshot queue.Count BEFORE the inner loop — dequeuing nodes during the loop changes the count.',
      'Add both left and right children only if non-null to avoid null entries in the queue.',
    ],
  },

  // ─── 146. LRU Cache ──────────────────────────────────────────────────────────
  146: {
    intuition:
      'An LRU cache needs O(1) lookup and O(1) reordering to track recency. A hash map gives O(1) lookup. A doubly-linked list gives O(1) insertion and deletion at any position. Combining both: the map stores key → node, and the list maintains order from most-recent (head) to least-recent (tail).',
    algorithm: [
      'Create dummy head and tail nodes. Connect them. Map starts empty.',
      'get(key): if not in map, return −1. Otherwise move the node to just after the dummy head and return its value.',
      'put(key, value): if key exists, update value and move to front. If new: insert new node at front.',
      'After inserting a new node: if size > capacity, remove the node just before the dummy tail (LRU) and delete its key from the map.',
      'Helper Remove(node) unlinks a node in O(1). Helper InsertFront(node) inserts after head in O(1).',
    ],
    example: {
      input: 'capacity=2, operations: put(1,1), put(2,2), get(1), put(3,3), get(2)',
      steps: [
        'put(1,1): list = [1]. put(2,2): list = [2,1] (2 is most recent).',
        'get(1): move 1 to front → list = [1,2]. Return 1.',
        'put(3,3): list full. Evict LRU (tail = 2). list = [3,1].',
        'get(2): key 2 was evicted → return −1.',
      ],
      output: 'get(1)=1, get(2)=-1',
    },
    pitfalls: [
      'Sentinel dummy head and tail nodes eliminate all null checks in Remove/InsertFront.',
      'Always remove the old node before inserting the updated one to avoid the map having two entries for the same key.',
      'On eviction, remove from BOTH the list and the map or subsequent gets will return stale data.',
    ],
  },

  // ─── 160. Intersection of Two Linked Lists ───────────────────────────────────
  160: {
    intuition:
      'If both pointers walk the same total distance (|A| + |B|), they will arrive at the intersection at the same step — or both arrive at null together if there is no intersection. Redirecting each pointer to the other list\'s head when it reaches null achieves exactly this total-distance equality with no extra memory.',
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
      'Compare node references, not node values — multiple nodes can have the same value but only one is the true intersection.',
      'The loop exits when a == b (including both being null for non-intersecting lists). Do NOT check a != null.',
    ],
  },

  // ─── 189. Rotate Array ───────────────────────────────────────────────────────
  189: {
    intuition:
      'Rotating right by k means the last k elements move to the front and the first n−k elements shift right. Observe: if you reverse the entire array, then independently reverse the first k elements and the last n−k elements, you get exactly the rotated result. Three reverses, no extra array.',
    algorithm: [
      'Reduce k = k % n to handle rotations larger than the array.',
      'Reverse the entire array.',
      'Reverse the first k elements (indices 0 to k−1).',
      'Reverse the remaining n−k elements (indices k to n−1).',
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
      'Reduce k mod n first — otherwise k=7 on a 7-element array does nothing but the naive reversal would still run.',
      'k = 0 after reduction means no rotation is needed; the three-reversal still works (each reverse is a no-op or reverses then re-reverses the same range).',
    ],
  },

  // ─── 198. House Robber ───────────────────────────────────────────────────────
  198: {
    intuition:
      'At each house you have two choices: rob it (and skip the previous) or skip it (and keep whatever was best through the previous house). This gives the recurrence dp[i] = max(dp[i−2] + nums[i], dp[i−1]). Only the last two dp values are ever needed, so the array collapses to two variables.',
    algorithm: [
      'If n == 1, return nums[0].',
      'Initialise prev2 = nums[0] (best loot through house 0), prev1 = max(nums[0], nums[1]) (best through house 1).',
      'For i from 2 to n−1: cur = max(prev1, prev2 + nums[i]); prev2 = prev1; prev1 = cur.',
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
      'Initialise prev1 = max(nums[0], nums[1]) not just nums[1] — you might not rob house 1.',
      'Do not reset dp to 0 at any step — you always carry forward the best previous answer.',
    ],
  },

  // ─── 210. Course Schedule II ────────────────────────────────────────────────
  210: {
    intuition:
      'Finding a valid course order is exactly topological sorting of a directed graph. Kahn\'s algorithm (BFS-based) is the cleaner approach: start with all courses that have no prerequisites (in-degree 0), process them one by one, and "unlock" courses whose last prerequisite has just been completed. If a cycle exists, some courses will never reach in-degree 0.',
    algorithm: [
      'Build adjacency list and in-degree array from prerequisites.',
      'Enqueue all nodes with in-degree 0.',
      'Dequeue a course: add it to the result order. For each neighbour, decrement its in-degree.',
      'If a neighbour\'s in-degree reaches 0, enqueue it.',
      'If result.Count == numCourses, return result. Otherwise a cycle exists — return [].',
    ],
    example: {
      input: 'numCourses=4, prerequisites=[[1,0],[2,0],[3,1],[3,2]]',
      steps: [
        'In-degrees: 0→0, 1→1, 2→1, 3→2. Queue: [0].',
        'Dequeue 0: result=[0]. Decrement 1 (→0), 2 (→0). Queue: [1,2].',
        'Dequeue 1: result=[0,1]. Decrement 3 (→1). Queue: [2].',
        'Dequeue 2: result=[0,1,2]. Decrement 3 (→0). Queue: [3].',
        'Dequeue 3: result=[0,1,2,3]. Count=4=numCourses → valid.',
      ],
      output: '[0,1,2,3]',
    },
    pitfalls: [
      'A cycle is detected by checking result.Count < numCourses at the end, not during BFS.',
      'The order returned is one valid topological order — many valid orderings may exist.',
      'Build the graph so edges point FROM prerequisite TO the course that requires it (forward direction).',
    ],
  },

  // ─── 213. House Robber II ────────────────────────────────────────────────────
  213: {
    intuition:
      'The circular constraint means houses 0 and n−1 cannot both be robbed. Break the circle by solving two independent sub-problems: one excluding the first house, one excluding the last. The answer is the maximum of both. Each sub-problem is the classic linear House Robber.',
    algorithm: [
      'If n == 1, return nums[0].',
      'Define Rob(start, end): run the rolling-variable DP on nums[start..end]. O(n) time, O(1) space.',
      'Return max(Rob(0, n−2), Rob(1, n−1)).',
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
      'Do not try to "stitch" the two sub-problems together — they are fully independent.',
      'Edge case n=1: return nums[0] before calling Rob, since Rob(0, -1) would have an empty range.',
    ],
  },

  // ─── 236. Lowest Common Ancestor ────────────────────────────────────────────
  236: {
    intuition:
      'Post-order DFS: we need information from both subtrees before deciding. If a node equals p or q, return it immediately — even if the other target is a descendant, the current node is still the LCA. If both left and right recursive calls return non-null, we are at the node where p and q split — that\'s the LCA.',
    algorithm: [
      'Base cases: if root is null, return null. If root == p or root == q, return root.',
      'Recurse: left = LCA(root.left, p, q); right = LCA(root.right, p, q).',
      'If both left and right are non-null → root is the LCA. Return root.',
      'Otherwise return whichever is non-null (the LCA is deeper in that subtree).',
    ],
    example: {
      input: 'root=[3,5,1,6,2,0,8,null,null,7,4], p=5, q=4',
      steps: [
        'DFS left of 3: reaches 5. 5 == p → return node 5.',
        'From 5, DFS right: reaches 2, then 4. 4 == q → returns up through 2, then 5.',
        'Back at node 3: left returned node 5 (found p). Dive right of 3: reaches 1,0,8 — none match p or q → returns null.',
        'Node 3: left=node5 (non-null), right=null → return node5 as LCA.',
      ],
      output: 'Node with value 5',
    },
    pitfalls: [
      'The algorithm assumes both p and q exist in the tree. If either is missing, the result is undefined.',
      'Do NOT descend into a subtree after finding one target — the early return `if root == p || root == q` handles the ancestor case correctly.',
    ],
  },

  // ─── 239. Sliding Window Maximum ────────────────────────────────────────────
  239: {
    intuition:
      'The maximum of every window of size k is needed. A naive approach rechecks each window in O(k) — O(nk) total. The insight: maintain a monotonically decreasing deque of indices. Any index with a smaller value than the incoming element can never be the maximum for any current or future window, so it is discarded immediately.',
    algorithm: [
      'Use a LinkedList<int> (deque) storing indices. Process each index i from 0 to n−1.',
      'Remove from the front any index ≤ i−k (outside the current window).',
      'Remove from the back any index whose value is ≤ nums[i] (they are dominated).',
      'Add i to the back of the deque.',
      'When i ≥ k−1 (first full window reached): the front of the deque is the index of the window maximum.',
    ],
    example: {
      input: 'nums = [1,3,-1,-3,5,3,6,7], k = 3',
      steps: [
        'i=0: deque=[0(1)]. i=1: 3>1, remove 0 → deque=[1(3)]. i=2: -1<3, deque=[1(3),2(-1)]. Window [1,3,-1]: max=nums[1]=3.',
        'i=3: -3<-1, deque=[1(3),2(-1),3(-3)]. Window [3,-1,-3]: max=nums[1]=3.',
        'i=4: 5>everything, clear deque → deque=[4(5)]. Window [-1,-3,5]: max=5.',
        'i=5: 3<5, deque=[4(5),5(3)]. i=6: 6>3 and 6>5, clear → deque=[6(6)]. max=6.',
        'i=7: 7>6, clear → deque=[7(7)]. max=7.',
      ],
      output: '[3,3,5,3,6,7]',
    },
    pitfalls: [
      'Remove from FRONT when out of window. Remove from BACK when dominated. These are two separate conditions, not one.',
      'Each element is pushed and popped at most once — total O(n), not O(nk).',
    ],
  },

}

export default explanations
