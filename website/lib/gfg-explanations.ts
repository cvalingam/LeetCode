/**
 * Rich structured explanations for GFG problems.
 * Keys are problem slugs (derived from folder names via toSlug()).
 */
export interface RichExplanation {
  intuition: string
  algorithm: string[]
  example?: {
    input: string
    steps: string[]
    output: string
  }
  pitfalls?: string[]
}

const gfgExplanations: Record<string, RichExplanation> = {

  // â”€â”€â”€ 0-1 Knapsack Problem â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
  '0-1-knapsack-problem': {
    intuition:
      'Each item is either taken (0) or not (1). DP table dp[i][w] = max value using first i items with capacity w. Taking item i: dp[i][w] = dp[i-1][w-wi] + vi. Not taking: dp[i][w] = dp[i-1][w]. Optimise to 1D by processing weights in reverse.',
    algorithm: [
      'Initialise dp[W+1] = 0.',
      'For each item i: for w from W down to weights[i]: dp[w] = max(dp[w], dp[w-weights[i]] + values[i]).',
      'Return dp[W].',
    ],
    example: {
      input: 'weights=[1,3,4,5], values=[1,4,5,7], W=7',
      steps: [
        'Item 1 (w=1,v=1): dp[1..7] updated. Item 2 (w=3,v=4): dp[7]=dp[4]+4=5.',
        'Item 3 (w=4,v=5): dp[7]=dp[3]+5=9. Item 4 (w=5,v=7): dp[7]=max(9,dp[2]+7)=9.',
      ],
      output: '9',
    },
    pitfalls: ['Process weights in reverse (W down to wi) to prevent reusing the same item.'],
  },

  // â”€â”€â”€ Activity Selection â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
  'activity-selection': {
    intuition:
      'Greedy: among all activities compatible with the last selected one, always pick the one that finishes earliest. This leaves maximum room for future activities. Sort by end time first.',
    algorithm: [
      'Sort activities by end time.',
      'Select activity 0. lastEnd = end[0], count = 1.',
      'For i from 1 to nâˆ’1: if start[i] >= lastEnd: select it, count++, lastEnd = end[i].',
      'Return count.',
    ],
    example: {
      input: 'start=[1,3,0,5,8,5], end=[2,4,6,7,9,9]',
      steps: [
        'Sort by end: (1,2),(3,4),(0,6),(5,7),(8,9),(5,9). Select (1,2). lastEnd=2.',
        'Select (3,4). lastEnd=4. Skip (0,6): 0<4. Select (5,7). lastEnd=7. Select (8,9). count=4.',
      ],
      output: '4',
    },
    pitfalls: ['Sort by END time, not start time â€” a greedy on start times is incorrect.'],
  },

  // â”€â”€â”€ Aggressive Cows â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
  'aggressive-cows': {
    intuition:
      'Binary search on the minimum distance between any two cows. For a given minimum distance d, greedily check if k cows can be placed: place first cow at stall 0, then each next cow at the first stall at distance â‰¥ d from the previous.',
    algorithm: [
      'Sort stalls.',
      'Binary search lo=1, hi=stalls[n-1]âˆ’stalls[0].',
      'For each mid: check if k cows can be placed with min distance mid.',
      'Canplace(d): place first cow at stalls[0]. For each stall: if gap â‰¥ d, place cow here, count++. Return count >= k.',
      'If canplace(mid): lo=mid+1 (try larger). Else: hi=midâˆ’1.',
      'Return loâˆ’1.',
    ],
    example: {
      input: 'stalls=[1,2,4,8,9], k=3',
      steps: [
        'lo=1,hi=8. mid=4: place at 1,4? gap=3<4. mid=3: place at 1,4,8. 3 cows âœ“ â†’ lo=4.',
        'mid=6: can we? 1,8(gap=7â‰¥6),next? No more. Only 2 â†’ hi=5.',
        'mid=4: same â†’ lo=5. lo>hi. Answer=4.',
      ],
      output: '3 (minimum distance = 3)',
    },
    pitfalls: ['Sort stalls first. Binary search on the ANSWER (distance), not the index.'],
  },

  // â”€â”€â”€ Alien Dictionary â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
  'alien-dictionary': {
    intuition:
      'Build a directed graph of character ordering by comparing adjacent words in the dictionary. Topological sort (Kahn\'s) on this graph gives the alien character order. If a cycle exists, no valid ordering exists.',
    algorithm: [
      'For each pair of adjacent words: find the first differing character. Add edge char1 â†’ char2.',
      'Topological sort via BFS (Kahn\'s). Start with in-degree-0 characters.',
      'If all characters are processed, return order. If cycle detected, return "".',
    ],
    example: {
      input: 'words = ["wrt","wrf","er","ett","rftt"]',
      steps: [
        'wrt vs wrf: tâ†’f. wrf vs er: wâ†’e. er vs ett: râ†’t. ett vs rftt: eâ†’r.',
        'Topo order: w,e,r,t,f.',
      ],
      output: '"wertf"',
    },
    pitfalls: [
      'Only compare the first differing character between adjacent words.',
      'If word1 is a prefix of word2 but comes after it, that\'s invalid â€” return "" immediately.',
    ],
  },

  // â”€â”€â”€ Anagram â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
  'anagram': {
    intuition:
      'Two strings are anagrams if they have the same character frequencies. Use a single int[256] array: increment for each character in s1, decrement for each in s2. If all entries are 0, they are anagrams.',
    algorithm: [
      'If lengths differ, return false.',
      'int[256] count. For each i: count[s1[i]]++; count[s2[i]]--.',
      'Return count.All(x => x == 0).',
    ],
    example: {
      input: 's1 = "listen", s2 = "silent"',
      steps: ['After processing: all counts are 0. Return true.'],
      output: 'YES',
    },
    pitfalls: ['Use a char frequency array, not sort â€” sort is O(n log n) vs O(n).'],
  },

  // â”€â”€â”€ Bellman-Ford â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
  'bellman-ford': {
    intuition:
      'Relax all edges Vâˆ’1 times. After Vâˆ’1 iterations, shortest paths are found (a shortest path has at most Vâˆ’1 edges). A V-th relaxation that still reduces any distance indicates a negative cycle.',
    algorithm: [
      'dist[src]=0, all others=INF.',
      'Repeat Vâˆ’1 times: for each edge (u,v,w): if dist[u]+w < dist[v], dist[v]=dist[u]+w.',
      'Check negative cycle: if any edge (u,v,w) has dist[u]+w < dist[v], report negative cycle.',
    ],
    example: {
      input: 'V=5, edges: 0â†’1(2),0â†’2(4),1â†’2(1),1â†’3(7),2â†’4(3)',
      steps: [
        'Iter 1: dist=[0,2,3,9,6]. Iter 2â€“4: no further relaxations.',
      ],
      output: 'dist = [0,2,3,9,6]',
    },
    pitfalls: ['Bellman-Ford handles negative weights; Dijkstra does not. Use Bellman-Ford when negative weights are present.'],
  },

  // â”€â”€â”€ BFS of Graph â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
  'bfs-of-graph': {
    intuition:
      'BFS explores nodes level by level using a queue. Start from source, enqueue all unvisited neighbors, mark them visited when enqueued (not when dequeued) to avoid duplicate processing.',
    algorithm: [
      'visited[src]=true. Enqueue src.',
      'While queue not empty: dequeue u. Add u to result.',
      'For each neighbor v of u: if not visited: visited[v]=true, enqueue v.',
    ],
    example: {
      input: 'Graph: 0â†’[1,2], 1â†’[3], 2â†’[3], 3â†’[]',
      steps: [
        'Queue:[0]. Dequeue 0 â†’ result=[0]. Enqueue 1,2.',
        'Dequeue 1 â†’ result=[0,1]. Enqueue 3. Dequeue 2 â†’ result=[0,1,2]. Dequeue 3 â†’ result=[0,1,2,3].',
      ],
      output: '[0,1,2,3]',
    },
    pitfalls: ['Mark visited when ENQUEUING, not when dequeuing â€” prevents the same node being enqueued multiple times.'],
  },

  // â”€â”€â”€ Binary Tree to DLL â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
  'binary-tree-to-dll': {
    intuition:
      'In-order traversal (leftâ†’rootâ†’right) of a BST gives sorted order. Convert by linking each node\'s left pointer to the previous node and right pointer to the next node during in-order traversal. Track the last processed node (prev).',
    algorithm: [
      'In-order traversal. Maintain prev node.',
      'For each node: node.left = prev. If prev != null: prev.right = node.',
      'Track head (first node). Update prev = node.',
      'Return head.',
    ],
    example: {
      input: 'BST: 10, left=12, right=15, 12\'s right=25, 15\'s left=36',
      steps: [
        'In-order: 12â†’25â†’10â†’36â†’15. Link each: 12â†â†’25â†â†’10â†â†’36â†â†’15.',
      ],
      output: 'DLL: 12â†”25â†”10â†”36â†”15',
    },
    pitfalls: ['Link prevâ†’curr before updating prev = curr, otherwise you lose the predecessor.'],
  },

  // â”€â”€â”€ Boolean Parenthesization â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
  'boolean-parenthesization': {
    intuition:
      'DP on sub-expressions: dp_true[i][j] = number of ways substring [i,j] evaluates to TRUE; dp_false[i][j] = FALSE. Split at each operator k. Combine left and right using truth-table rules for AND, OR, XOR.',
    algorithm: [
      'Base: dp_true[i][i] = (sym[i]=="T") ? 1 : 0. dp_false[i][i] = 1 âˆ’ dp_true[i][i].',
      'For length l from 2 to n: for each (i,j): for each operator at k between i and j:',
      '  Compute lt,lf,rt,rf (left/right true/false counts).',
      '  AND: true += lt*rt. OR: true += lt*rt+lt*rf+lf*rt. XOR: true += lt*rf+lf*rt.',
      '  false = totalWays âˆ’ true.',
      'Return dp_true[0][n-1].',
    ],
    example: {
      input: '"T|T&F^T"',
      steps: [
        'Symbols: T,T,F,T. Operators: |,&,^.',
        'dp_true[0][3] = 4.',
      ],
      output: '4',
    },
    pitfalls: ['Total ways for a substring of length n = Catalan(n-1). Use it to compute false = total âˆ’ true.'],
  },

  // â”€â”€â”€ Bottom View of Binary Tree â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
  'bottom-view-of-binary-tree': {
    intuition:
      'Level-order traversal with horizontal distance (HD): root=0, left child=HDâˆ’1, right child=HD+1. For each HD, the LAST node seen at that HD (deepest level) is the bottom view.',
    algorithm: [
      'BFS with (node, HD) pairs. HashMap: HD â†’ last seen node value.',
      'Process each (node, hd): map[hd] = node.val (overwrite â€” last wins).',
      'Enqueue (left, hdâˆ’1) and (right, hd+1) if non-null.',
      'Return map values sorted by HD.',
    ],
    example: {
      input: 'Tree: 20(root), left=8[left=5,right=3], right=22[right=25], 3 has left=10,right=14',
      steps: ['HD: 5â†’-2, 8â†’-1, 10â†’0, 20â†’0, 3â†’0, 14â†’1, 22â†’1, 25â†’2. Bottom: 5,10,3,14,25.'],
      output: '[5,10,3,14,25]',
    },
    pitfalls: ['BFS ensures we process level by level â€” map[hd] is always overwritten by deeper nodes.'],
  },

  // â”€â”€â”€ Check for BST â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
  'check-for-bst': {
    intuition:
      'Pass valid range [min, max] down the tree. Each node must be strictly within (min, max). Left child has max=current.val; right child has min=current.val.',
    algorithm: [
      'IsValidBST(node, min, max):',
      'If node is null, return true.',
      'If node.val <= min or node.val >= max, return false.',
      'Return IsValidBST(left, min, node.val) && IsValidBST(right, node.val, max).',
    ],
    example: {
      input: 'root = [2,1,3]',
      steps: [
        'Node 2: range (âˆ’âˆž,+âˆž) âœ“. Node 1: range (âˆ’âˆž,2) âœ“. Node 3: range (2,+âˆž) âœ“.',
      ],
      output: 'true',
    },
    pitfalls: ['Use long.MinValue/MaxValue (or null) as initial bounds â€” int bounds fail on equal-value edge cases.'],
  },

  // â”€â”€â”€ Coin Change (Count Ways) â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
  'coin-change-count-ways': {
    intuition:
      'Unbounded knapsack: dp[i] = number of ways to make sum i using the given coins (each coin can be used any number of times). For each coin, iterate forward through the dp array.',
    algorithm: [
      'dp[0]=1, dp[1..sum]=0.',
      'For each coin c: for w from c to sum: dp[w] += dp[wâˆ’c].',
      'Return dp[sum].',
    ],
    example: {
      input: 'coins=[1,2,3], sum=4',
      steps: [
        'coin=1: dp=[1,1,1,1,1]. coin=2: dp[2]+=dp[0]=2, dp[3]+=dp[1]=2, dp[4]+=dp[2]=3. â†’ dp=[1,1,2,2,3].',
        'coin=3: dp[3]+=dp[0]=3, dp[4]+=dp[1]=4. â†’ dp[4]=4.',
      ],
      output: '4',
    },
    pitfalls: ['Outer loop over coins, inner loop over amounts â€” this counts combinations (not permutations). Swap loops for permutations.'],
  },

  // â”€â”€â”€ Coin Change (Minimum Coins) â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
  'coin-change-minimum-coins': {
    intuition:
      'dp[i] = minimum coins to make sum i. For each coin c and each amount w >= c: dp[w] = min(dp[w], dp[w-c]+1). Initialize dp[1..sum] = INF.',
    algorithm: [
      'dp[0]=0, dp[1..sum]=INF.',
      'For each coin c: for w from c to sum: if dp[w-c] != INF: dp[w]=min(dp[w], dp[w-c]+1).',
      'Return dp[sum] if not INF, else âˆ’1.',
    ],
    example: {
      input: 'coins=[1,5,6,9], sum=11',
      steps: [
        'dp[5]=1, dp[6]=1, dp[9]=1. dp[10]=2(5+5 or 4+6...). dp[11]=2 (5+6).',
      ],
      output: '2',
    },
    pitfalls: ['Return âˆ’1 if dp[sum] remains INF â€” the sum is unreachable.'],
  },

  // â”€â”€â”€ Count Inversions â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
  'count-inversions': {
    intuition:
      'An inversion is a pair (i, j) where i < j but arr[i] > arr[j]. Merge sort counts inversions during the merge step: when an element from the right half is placed before elements from the left half, each of those left-half elements forms an inversion with it.',
    algorithm: [
      'Merge sort recursively. Count inversions during merge.',
      'During merge: whenever right[j] < left[i], all elements left[i..mid] are inversions with right[j]. inv_count += (mid âˆ’ i + 1).',
    ],
    example: {
      input: 'arr = [2,4,1,3,5]',
      steps: [
        'Merge [2,4] and [1,3]: 1<2 â†’ 2 inversions. 3>2, 3>4: 0.',
        'Merge [2,4,1,3] and [5]: 0 inversions.',
        'Total = 3 (pairs: (2,1),(4,1),(4,3)).',
      ],
      output: '3',
    },
    pitfalls: ['Count inversions during merge (not during split) â€” only then do you know the relative positions.'],
  },

  // â”€â”€â”€ DFS of Graph â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
  'dfs-of-graph': {
    intuition:
      'DFS explores as deep as possible along each branch before backtracking. Use a stack (or recursion): visit a node, mark it, then recursively visit all unvisited neighbors.',
    algorithm: [
      'visited[src]=true. DFS(src).',
      'DFS(u): add u to result. For each neighbor v: if not visited: visited[v]=true. DFS(v).',
    ],
    example: {
      input: 'Graph: 0â†’[1,2,3], 1â†’[4], 2â†’[], 3â†’[], 4â†’[]',
      steps: [
        'DFS(0): visit 0. Go to 1: visit 1. Go to 4: visit 4. Backtrack. Go to 2: visit 2. Go to 3: visit 3.',
        'Result: [0,1,4,2,3].',
      ],
      output: '[0,1,4,2,3]',
    },
    pitfalls: ['Mark as visited BEFORE recursing â€” not after â€” to prevent revisiting in undirected graphs.'],
  },

  // â”€â”€â”€ Detect Loop in linked list â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
  'detect-loop-in-linked-list': {
    intuition:
      'Floyd\'s cycle detection: slow pointer moves one step, fast moves two. If they meet, a cycle exists. If fast reaches null, no cycle.',
    algorithm: [
      'slow = fast = head.',
      'While fast != null and fast.next != null: slow = slow.next. fast = fast.next.next.',
      'If slow == fast: return true (cycle). Return false.',
    ],
    example: {
      input: '1â†’2â†’3â†’4â†’5â†’(back to 3)',
      steps: [
        'Step 1: slow=2, fast=3. Step 2: slow=3, fast=5. Step 3: slow=4, fast=4. Meet at 4. Cycle!',
      ],
      output: 'true',
    },
    pitfalls: ['Check fast != null AND fast.next != null before each step to avoid NullPointerException.'],
  },

  // â”€â”€â”€ Dijkstra Algorithm â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
  'dijkstra-algorithm': {
    intuition:
      'Greedy shortest path: always extend the unvisited node with the smallest current distance. Use a min-heap (priority queue) to efficiently get the next minimum. Only works with non-negative edge weights.',
    algorithm: [
      'dist[src]=0, all others=INF. Add (0,src) to min-heap.',
      'While heap not empty: extract (d,u). If d > dist[u], skip (stale entry).',
      'For each neighbor (v,w): if dist[u]+w < dist[v]: dist[v]=dist[u]+w. Push (dist[v],v).',
    ],
    example: {
      input: 'V=5, edges: 0â†’1(4),0â†’2(1),2â†’1(2),1â†’3(1),2â†’3(5)',
      steps: [
        'dist=[0,âˆž,âˆž,âˆž,âˆž]. Process 0: dist[1]=4, dist[2]=1.',
        'Process 2(d=1): dist[1]=min(4,3)=3, dist[3]=6.',
        'Process 1(d=3): dist[3]=min(6,4)=4.',
      ],
      output: 'dist=[0,3,1,4,âˆž]',
    },
    pitfalls: ['Skip stale heap entries by checking if extracted distance > dist[u].'],
  },

  // â”€â”€â”€ Directed Graph Cycle â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
  'directed-graph-cycle': {
    intuition:
      'A directed cycle exists iff DFS finds a back edge â€” an edge pointing to an ancestor in the current DFS stack. Use two states: "in-stack" (currently being explored) and "visited" (fully explored). A back edge leads to an "in-stack" node.',
    algorithm: [
      'visited[n]=false, inStack[n]=false.',
      'DFS(u): visited[u]=inStack[u]=true.',
      'For each neighbor v: if !visited: DFS(v). If cycle found, return true.',
      'Else if inStack[v]: return true (back edge â†’ cycle).',
      'inStack[u]=false. Return false.',
    ],
    example: {
      input: 'Graph: 0â†’1â†’2â†’0 (cycle)',
      steps: [
        'DFS(0): mark. DFS(1): mark. DFS(2): neighbor 0 is inStack â†’ cycle!',
      ],
      output: 'true',
    },
    pitfalls: ['For directed graphs, use inStack (recursion stack). For undirected graphs, just use visited + parent tracking.'],
  },

  // â”€â”€â”€ Edit Distance â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
  'edit-distance': {
    intuition:
      'dp[i][j] = minimum edits to convert s1[0..i-1] to s2[0..j-1]. If characters match: dp[i][j]=dp[i-1][j-1]. Else: 1 + min(insert=dp[i][j-1], delete=dp[i-1][j], replace=dp[i-1][j-1]).',
    algorithm: [
      'dp[0][j]=j (j deletions), dp[i][0]=i (i insertions).',
      'For i,j from 1: if s1[i-1]==s2[j-1]: dp[i][j]=dp[i-1][j-1].',
      'Else: dp[i][j]=1+min(dp[i][j-1], dp[i-1][j], dp[i-1][j-1]).',
      'Return dp[m][n].',
    ],
    example: {
      input: 's1="sunday", s2="saturday"',
      steps: [
        'dp table fills to give dp[6][8]=3 (insert a,t, replace n).',
      ],
      output: '3',
    },
    pitfalls: ['Three operations: insert (dp[i][j-1]+1), delete (dp[i-1][j]+1), replace (dp[i-1][j-1]+1).'],
  },

  // â”€â”€â”€ Equilibrium Point â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
  'equilibrium-point': {
    intuition:
      'An equilibrium point is where the sum of elements to the left equals the sum to the right. Compute total sum first. Then traverse left to right: subtract current element from right sum after checking equality.',
    algorithm: [
      'total = sum(arr). leftSum = 0.',
      'For each index i: total -= arr[i] (now total = rightSum).',
      'If leftSum == total: return i+1 (1-indexed).',
      'leftSum += arr[i].',
      'Return âˆ’1.',
    ],
    example: {
      input: 'arr = [-7,1,5,2,-4,3,0]',
      steps: [
        'total=0. leftSum=0. i=0: total=7â‰ leftSum. i=1: total=6â‰ -7. ... i=3: total=-1,leftSum=-1 âœ“. Return 4.',
      ],
      output: '4',
    },
    pitfalls: ['Subtract the current element from rightSum BEFORE comparing (the current element belongs to neither side).'],
  },

  // â”€â”€â”€ Floyd Warshall â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
  'floyd-warshall': {
    intuition:
      'All-pairs shortest paths using dynamic programming over intermediate nodes. dist[i][j] = shortest path from i to j. For each intermediate node k: if going through k is shorter, update. Three nested loops: k (intermediate), i (source), j (destination).',
    algorithm: [
      'Initialise dist from adjacency matrix. dist[i][i]=0.',
      'For k from 0 to V-1: for i,j: dist[i][j] = min(dist[i][j], dist[i][k]+dist[k][j]).',
      'Return dist matrix.',
    ],
    example: {
      input: 'V=4, edges: 0â†’1(5),0â†’3(10),1â†’2(3),2â†’3(1)',
      steps: [
        'k=0: no improvement. k=1: dist[0][2]=min(âˆž,5+3)=8. k=2: dist[0][3]=min(10,8+1)=9.',
      ],
      output: 'Shortest paths: 0â†’3=9',
    },
    pitfalls: ['k must be the OUTER loop â€” intermediate nodes are added one at a time.'],
  },

  // â”€â”€â”€ Gas Station â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
  'gas-station': {
    intuition:
      'If total gas >= total cost, a solution exists and is unique. Use a greedy scan: track running surplus; when it goes negative, the current starting station is impossible â€” reset to the next station.',
    algorithm: [
      'totalGas=0, currentGas=0, start=0.',
      'For i from 0 to nâˆ’1: totalGas += gas[i]âˆ’cost[i]. currentGas += gas[i]âˆ’cost[i].',
      'If currentGas < 0: start=i+1. currentGas=0.',
      'Return (totalGas >= 0) ? start : âˆ’1.',
    ],
    example: {
      input: 'gas=[1,2,3,4,5], cost=[3,4,5,1,2]',
      steps: [
        'i=0: cur=-2 < 0 â†’ start=1. i=1: cur=-2 < 0 â†’ start=2. i=2: cur=-2 < 0 â†’ start=3.',
        'i=3: cur=3. i=4: cur=6. Total=2â‰¥0. Return start=3.',
      ],
      output: '3',
    },
    pitfalls: ['The existence of a solution is guaranteed when total gas >= total cost â€” only one valid start exists.'],
  },

  // â”€â”€â”€ Height of Binary Tree â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
  'height-of-binary-tree': {
    intuition:
      'The height is the number of nodes on the longest path from root to a leaf. Recursively: height = 1 + max(height(left), height(right)). Base: null node has height 0.',
    algorithm: [
      'If node is null, return 0.',
      'Return 1 + max(Height(node.left), Height(node.right)).',
    ],
    example: {
      input: 'Tree: 1â†’(2â†’4, 3)',
      steps: [
        'Height(4)=1. Height(2)=2. Height(3)=1. Height(1)=3.',
      ],
      output: '3',
    },
    pitfalls: ['Height of a single node is 1 (not 0). Height of empty tree is 0.'],
  },

  // â”€â”€â”€ Histogram Max Rectangular Area â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
  'histogram-max-rectangular-area': {
    intuition:
      'For each bar, find how far left and right it extends as the minimum bar. Use a monotonic increasing stack: when a shorter bar is found, the popped bar is bounded on the right by the current bar and on the left by the new stack top.',
    algorithm: [
      'Stack of indices. Append heights[n]=0 as sentinel.',
      'For i from 0 to n: while stack not empty and heights[i] < heights[stack.top]:',
      '  h = heights[stack.pop()]. w = (stack empty) ? i : iâˆ’stack.topâˆ’1.',
      '  area = h*w. Update maxArea.',
      'Push i.',
    ],
    example: {
      input: 'heights = [2,1,5,6,2,3]',
      steps: [
        'Process 5,6: pushed. At 2: pop 6 (area=6), pop 5 (area=10). At sentinel: pop 2(area=2*5=10),1(area=6).',
        'maxArea=10.',
      ],
      output: '10',
    },
    pitfalls: ['Append a 0-height bar at the end to flush all remaining bars from the stack.'],
  },

  // â”€â”€â”€ Implement Trie â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
  'implement-trie': {
    intuition:
      'A Trie is a prefix tree. Each node has up to 26 children (for lowercase letters) and an isEnd flag. Insert: walk/create nodes for each character. Search: walk nodes, return isEnd at the last node. StartsWith: walk nodes, return true if path exists.',
    algorithm: [
      'TrieNode: TrieNode[26] children; bool isEnd.',
      'Insert(word): for each char c, create child[c-"a"] if null. Mark isEnd at last node.',
      'Search(word): traverse nodes. Return isEnd at last node (false if path not found).',
      'StartsWith(prefix): traverse nodes. Return true if all nodes exist.',
    ],
    example: {
      input: 'Insert "apple". Search "apple", "app".',
      steps: [
        'Insert: aâ†’pâ†’pâ†’lâ†’e (isEnd=true). Search "apple": reach isEnd=true âœ“. Search "app": reach e node, isEnd=false â†’ false.',
      ],
      output: 'true, false',
    },
    pitfalls: ['isEnd marks a complete word â€” do not confuse with "has children" (which indicates a prefix).'],
  },

  // â”€â”€â”€ Job Sequencing Problem â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
  'job-sequencing-problem': {
    intuition:
      'Greedy: sort jobs by profit (descending). For each job, schedule it in the latest available time slot before its deadline. Use a boolean array of time slots; greedily pick the latest available slot â‰¤ deadline.',
    algorithm: [
      'Sort jobs by profit descending.',
      'result[maxDeadline], slot[maxDeadline]=false.',
      'For each job (id,deadline,profit): for t from min(maxDeadline,deadline)-1 down to 0: if !slot[t]: slot[t]=true, result[t]=job, break.',
      'Count filled slots and sum profits.',
    ],
    example: {
      input: 'jobs=[(a,2,100),(b,1,19),(c,2,27),(d,1,25),(e,3,15)]',
      steps: [
        'Sort: a(100),c(27),d(25),b(19),e(15). aâ†’slot[1]. câ†’slot[0]. eâ†’slot[2]. Maxprofit=100+27+15=142.',
      ],
      output: 'Max profit = 142, 3 jobs',
    },
    pitfalls: ['Fill slots from right to left (latest available) â€” filling from the start wastes slots for earlier-deadline jobs.'],
  },

  // â”€â”€â”€ Kadane\'s Algorithm â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
  'kadanes-algorithm': {
    intuition:
      'Maximum subarray sum. At each position, decide: extend the current subarray or start fresh. If the running sum becomes negative, starting fresh is always better. dp[i] = max(nums[i], dp[i-1]+nums[i]).',
    algorithm: [
      'maxSum = currentSum = arr[0].',
      'For i from 1 to nâˆ’1: currentSum = max(arr[i], currentSum+arr[i]).',
      'maxSum = max(maxSum, currentSum).',
      'Return maxSum.',
    ],
    example: {
      input: 'arr = [-2,1,-3,4,-1,2,1,-5,4]',
      steps: [
        'cur: -2â†’1â†’-2â†’4â†’3â†’5â†’6â†’1â†’5. maxSum=6.',
      ],
      output: '6',
    },
    pitfalls: ['Initialize both maxSum and currentSum to arr[0] to handle all-negative arrays correctly.'],
  },

  // â”€â”€â”€ Level order traversal â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
  'level-order-traversal': {
    intuition:
      'BFS with level-size snapshotting: enqueue root, then for each level, dequeue exactly levelSize nodes and enqueue their children.',
    algorithm: [
      'Same as LeetCode 102: BFS with queue. Snapshot size at start of each level.',
    ],
    example: {
      input: 'root = [1, [2,3], [4,5,6,7]]',
      steps: ['Level 0: [1]. Level 1: [2,3]. Level 2: [4,5,6,7].'],
      output: '[[1],[2,3],[4,5,6,7]]',
    },
    pitfalls: ['Snapshot queue.size() BEFORE the inner dequeue loop.'],
  },

  // â”€â”€â”€ Longest Common Subsequence â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
  'longest-common-subsequence': {
    intuition:
      'dp[i][j] = LCS length of s1[0..i-1] and s2[0..j-1]. If chars match: dp[i][j]=dp[i-1][j-1]+1. Else: dp[i][j]=max(dp[i-1][j], dp[i][j-1]).',
    algorithm: [
      'dp[m+1][n+1], all 0.',
      'For i from 1 to m, j from 1 to n: if s1[i-1]==s2[j-1]: dp[i][j]=dp[i-1][j-1]+1. Else: dp[i][j]=max(dp[i-1][j],dp[i][j-1]).',
      'Return dp[m][n].',
    ],
    example: {
      input: 's1="ABCBDAB", s2="BDCAB"',
      steps: [
        'LCS = "BCAB" or "BDAB" (length 4). dp[7][5]=4.',
      ],
      output: '4',
    },
    pitfalls: ['LCS counts non-contiguous characters in order â€” not the same as Longest Common Substring.'],
  },

  // â”€â”€â”€ Longest Increasing Subsequence â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
  'longest-increasing-subsequence': {
    intuition:
      'Two approaches: O(nÂ²) DP where dp[i]=LIS ending at index i, or O(n log n) using patience sorting with a "tails" array. In the patience approach, tails[i] = smallest tail element of all increasing subsequences of length i+1.',
    algorithm: [
      'tails = [].',
      'For each num: binary search for the position in tails where tails[pos] >= num.',
      'If pos == tails.Length, append num (extend LIS). Else replace tails[pos] = num.',
      'Return tails.Length.',
    ],
    example: {
      input: 'arr = [10,9,2,5,3,7,101,18]',
      steps: [
        '10: [10]. 9: [9]. 2: [2]. 5: [2,5]. 3: [2,3]. 7: [2,3,7]. 101: [2,3,7,101]. 18: [2,3,7,18].',
        'Length=4.',
      ],
      output: '4',
    },
    pitfalls: ['The tails array does not represent the actual LIS â€” only its length is meaningful. Reconstruct using parent pointers from the O(nÂ²) approach if needed.'],
  },

  // â”€â”€â”€ Longest Palindrome in a String â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
  'longest-palindrome-in-a-string': {
    intuition:
      'Expand around each center. For each character (and each gap between characters), expand outward as long as characters match. Track the maximum expansion. O(nÂ²) time, O(1) space.',
    algorithm: [
      'For each center (2n-1 centers for odd + even): expand while valid.',
      'ExpandAroundCenter(left, right): while left>=0 and right<n and s[left]==s[right]: left--, right++.',
      'Track max length and start index.',
    ],
    example: {
      input: 's = "babad"',
      steps: [
        'Center at i=1("a"): expand â†’ "bab"(len=3). Center at i=2("b"): expand â†’ "aba"(len=3).',
        'Return "bab" (first found).',
      ],
      output: '"bab"',
    },
    pitfalls: ['Check both odd (single-char center) and even (between-char center) palindromes.'],
  },

  // â”€â”€â”€ Longest Palindromic Subsequence â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
  'longest-palindromic-subsequence': {
    intuition:
      'LPS(s) = LCS(s, reverse(s)). Alternatively, dp[i][j] = LPS of s[i..j]. If s[i]==s[j]: dp[i][j]=dp[i+1][j-1]+2. Else: dp[i][j]=max(dp[i+1][j], dp[i][j-1]).',
    algorithm: [
      'dp[i][j] = 1 for all i (single char palindrome).',
      'For length l from 2 to n: for each (i,j) with j=i+l-1: if s[i]==s[j]: dp[i][j]=dp[i+1][j-1]+2.',
      'Else: dp[i][j]=max(dp[i+1][j], dp[i][j-1]).',
      'Return dp[0][n-1].',
    ],
    example: {
      input: 's = "bbabcbcab"',
      steps: ['LPS = "babcbab" length 7, or use LCS with reverse.'],
      output: '7',
    },
    pitfalls: ['Fill dp bottom-up by increasing subproblem length, not by row.'],
  },

  // â”€â”€â”€ LRU Cache â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
  'lru-cache': {
    intuition:
      'Same as LeetCode 146: HashMap + doubly linked list. O(1) get and put. HashMap maps key to node; DLL maintains recency order.',
    algorithm: [
      'See LeetCode 146 explanation â€” identical structure.',
    ],
    example: {
      input: 'capacity=2, put(1,1),put(2,2),get(1),put(3,3),get(2)',
      steps: ['get(1)=1. After put(3): evicts key 2. get(2)=-1.'],
      output: 'get(1)=1, get(2)=-1',
    },
    pitfalls: ['Evict the LEAST recently used (tail node), not the least frequently used.'],
  },

  // â”€â”€â”€ Majority Element â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
  'majority-element': {
    intuition:
      'Boyer-Moore Voting Algorithm: the majority element (appears > n/2 times) will survive cancellation. Maintain a candidate and counter; increment for matching, decrement for non-matching; when counter reaches 0, switch candidate.',
    algorithm: [
      'candidate = arr[0], count = 1.',
      'For i from 1 to nâˆ’1: if arr[i]==candidate: count++. Else: count--. If count==0: candidate=arr[i], count=1.',
      'Return candidate.',
    ],
    example: {
      input: 'arr = [3,3,4,2,4,4,2,4,4]',
      steps: [
        '3(1),3(2),4(1),2(0)â†’4(1),4(2),2(1),4(2),4(3). Candidate=4.',
      ],
      output: '4',
    },
    pitfalls: ['The problem guarantees a majority element exists â€” no verification step needed. If not guaranteed, verify by counting.'],
  },

  // â”€â”€â”€ Matrix Chain Multiplication â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
  'matrix-chain-multiplication': {
    intuition:
      'dp[i][j] = minimum number of scalar multiplications to compute the product of matrices i through j. Split at every position k between i and j; the cost is dp[i][k] + dp[k+1][j] + p[i-1]*p[k]*p[j].',
    algorithm: [
      'dp[i][i]=0. Fill for increasing chain lengths.',
      'For l from 2 to n: for i from 1 to n-l+1: j=i+l-1. dp[i][j]=INF.',
      'For k from i to j-1: cost=dp[i][k]+dp[k+1][j]+p[i-1]*p[k]*p[j]. dp[i][j]=min.',
    ],
    example: {
      input: 'p=[1,2,3,4] (3 matrices: 1Ã—2, 2Ã—3, 3Ã—4)',
      steps: [
        'dp[1][2]=1*2*3=6. dp[2][3]=2*3*4=24. dp[1][3]=min(dp[1][1]+dp[2][3]+1*2*4, dp[1][2]+dp[3][3]+1*3*4)=min(0+24+8,6+0+12)=min(32,18)=18.',
      ],
      output: '18',
    },
    pitfalls: ['p[i] is the number of ROWS of matrix i and COLUMNS of matrix i-1. Use 1-indexed arrays carefully.'],
  },

  // â”€â”€â”€ Max Circular Subarray Sum â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
  'max-circular-subarray-sum': {
    intuition:
      'Two cases: (1) the max subarray does NOT wrap around â†’ Kadane\'s algorithm. (2) The max subarray WRAPS â†’ total sum minus the minimum subarray (non-wrapping). Answer = max(case1, totalSum âˆ’ minSubarray). Handle all-negative edge case.',
    algorithm: [
      'Case 1: maxSum = Kadane(arr).',
      'totalSum = sum(arr). Case 2: minSum = Kadane(âˆ’arr) negated = minimum subarray sum. circularMax = totalSum âˆ’ minSum.',
      'If maxSum < 0 (all negative): return maxSum.',
      'Return max(maxSum, circularMax).',
    ],
    example: {
      input: 'arr = [8,-8,9,-9,10,-11,12]',
      steps: [
        'Kadane: maxSum=22. totalSum=11. minKadane=-19 â†’ circularMax=30.',
        'Return max(22,30)=30.',
      ],
      output: '30',
    },
    pitfalls: ['If all elements are negative, circularMax = totalSum âˆ’ minSum = 0, which is wrong â€” return maxSum directly.'],
  },

  // â”€â”€â”€ Merge K sorted linked lists â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
  'merge-k-sorted-linked-lists': {
    intuition:
      'Use a min-heap of size k: initialise with the head of each list. Repeatedly extract the minimum node, add it to the result, and push its successor (if any) back into the heap.',
    algorithm: [
      'Min-heap of (node.val, node). Insert head of each non-null list.',
      'While heap not empty: extract (val, node). Append to result. If node.next != null: push (node.next.val, node.next).',
      'Return result head.',
    ],
    example: {
      input: 'lists = [1â†’4â†’5, 1â†’3â†’4, 2â†’6]',
      steps: [
        'Heap: [(1,L1),(1,L2),(2,L3)]. Extract 1â†’push 4. Extract 1â†’push 3. Extract 2â†’push 6. ...continue...',
        'Result: 1â†’1â†’2â†’3â†’4â†’4â†’5â†’6.',
      ],
      output: '[1,1,2,3,4,4,5,6]',
    },
    pitfalls: ['For C# PriorityQueue, compare by node.val to maintain min-heap property.'],
  },

  // â”€â”€â”€ Minimum Cost Path â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
  'minimum-cost-path': {
    intuition:
      'Grid DP: dp[i][j] = minimum cost to reach (i,j) from (0,0). Transitions come from above, left, and top-left diagonal. dp[i][j] = cost[i][j] + min(dp[i-1][j], dp[i][j-1], dp[i-1][j-1]).',
    algorithm: [
      'dp[0][0]=cost[0][0].',
      'Fill first row: dp[0][j]=dp[0][j-1]+cost[0][j].',
      'Fill first col: dp[i][0]=dp[i-1][0]+cost[i][0].',
      'Interior: dp[i][j]=cost[i][j]+min(dp[i-1][j], dp[i][j-1], dp[i-1][j-1]).',
    ],
    example: {
      input: 'cost=[[1,2,3],[4,8,2],[1,5,3]]',
      steps: ['dp[2][2] = 3+min(dp[1][2]=9,dp[2][1]=10,dp[1][1]=13) = 3+9=12. Wait, let me trace: dp=[1,3,6;5,9,8;6,11,11]. dp[2][2]=3+min(8,11,9)=11.'],
      output: '8',
    },
    pitfalls: ['Unlike Unique Paths, diagonal moves are also allowed here.'],
  },

  // â”€â”€â”€ Minimum Jumps â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
  'minimum-jumps': {
    intuition:
      'Greedy BFS: at each step, track the farthest reachable position (currentEnd) and the farthest position reachable in the next step (farthestReach). When we reach currentEnd, we must take a jump; increment jumps and update currentEnd to farthestReach.',
    algorithm: [
      'jumps=0, currentEnd=0, farthest=0.',
      'For i from 0 to nâˆ’2: farthest = max(farthest, i+arr[i]).',
      'If i == currentEnd: jumps++. currentEnd=farthest. If currentEnd >= n-1: break.',
      'Return jumps if reachable, else -1.',
    ],
    example: {
      input: 'arr = [2,3,1,1,4]',
      steps: [
        'i=0: farthest=2. currentEnd=0 â†’ jump, currentEnd=2, jumps=1.',
        'i=1: farthest=4. i=2: farthest=4. currentEnd=2 â†’ jump, currentEnd=4â‰¥4, jumps=2. Break.',
      ],
      output: '2',
    },
    pitfalls: ['Iterate only to nâˆ’2 (not nâˆ’1) â€” you don\'t need a jump from the last position.'],
  },

  // â”€â”€â”€ Minimum Platforms â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
  'minimum-platforms': {
    intuition:
      'Sort arrivals and departures separately. Use two pointers: for each arrival, if a train has departed by then, it frees a platform. Count max overlapping arrivals.',
    algorithm: [
      'Sort arr[] and dep[].',
      'i=1, j=0, platforms=1, maxPlatforms=1.',
      'While i<n and j<n: if arr[i]<=dep[j]: platforms++; i++. Else: platforms--; j++.',
      'maxPlatforms=max(maxPlatforms,platforms).',
      'Return maxPlatforms.',
    ],
    example: {
      input: 'arr=[0900,0940,0950,1100,1500,1800], dep=[0910,1200,1120,1130,1900,2000]',
      steps: [
        'Sorted. At 0940: 3 trains (0940,0950 arrived, 0910 departed by 0950). Peak=3.',
      ],
      output: '3',
    },
    pitfalls: ['Sort BOTH arrays independently â€” the i-th arrival does not correspond to the i-th departure after sorting.'],
  },

  // â”€â”€â”€ Missing And Repeating â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
  'missing-and-repeating': {
    intuition:
      'Two equations: let x=missing, y=repeating. Sum difference: Sâˆ’S_expected = yâˆ’x. Sum of squares difference: S2âˆ’S2_expected = yÂ²âˆ’xÂ² = (yâˆ’x)(y+x). Solve for x and y.',
    algorithm: [
      'S=sum(arr), S_exp=n(n+1)/2. sumDiff=Sâˆ’S_exp = yâˆ’x.',
      'S2=sum(arr[i]Â²), S2_exp=n(n+1)(2n+1)/6. sq_diff=S2âˆ’S2_exp = yÂ²âˆ’xÂ².',
      'y+x = sq_diff/(y-x). Solve: y=(sumDiff+(y+x))/2, x=yâˆ’sumDiff.',
    ],
    example: {
      input: 'arr=[3,1,3,4,5] (n=5)',
      steps: [
        'S=16, S_exp=15. sumDiff=1=yâˆ’x.',
        'S2=60, S2_exp=55. sqDiff=5=(yâˆ’x)(y+x)=1*(y+x) â†’ y+x=5.',
        'y=3, x=2.',
      ],
      output: 'Missing=2, Repeating=3',
    },
    pitfalls: ['Use long arithmetic to avoid overflow in sum of squares.'],
  },

  // â”€â”€â”€ N-Queen Problem â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
  'n-queen-problem': {
    intuition:
      'Same as LeetCode 51. Backtracking row by row with three HashSets tracking occupied columns, positive diagonals (row-col), and negative diagonals (row+col).',
    algorithm: [
      'See LeetCode 51 explanation â€” identical approach.',
    ],
    example: {
      input: 'n = 4',
      steps: ['Two valid placements for 4-Queens.'],
      output: '2 solutions',
    },
    pitfalls: ['Track row+col and row-col as diagonal identifiers â€” not the actual diagonal position.'],
  },

  // â”€â”€â”€ Next Greater Element â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
  'next-greater-element': {
    intuition:
      'Monotonic stack: maintain a decreasing stack. For each element, pop all elements smaller than it â€” the current element is their "next greater". Elements left in the stack have no next greater â†’ assign -1.',
    algorithm: [
      'Stack of indices. result[n]=-1.',
      'For i from 0 to n-1: while stack not empty and arr[stack.top] < arr[i]: result[stack.pop()] = arr[i].',
      'Push i.',
    ],
    example: {
      input: 'arr = [4,5,2,25]',
      steps: [
        'i=0: push 0. i=1: 4<5 â†’ result[0]=5. Push 1.',
        'i=2: push 2. i=3: 2<25 â†’ result[2]=25. 5<25 â†’ result[1]=25. Push 3.',
        'result=[5,25,25,-1].',
      ],
      output: '[5,25,25,-1]',
    },
    pitfalls: ['The stack stores INDICES, not values â€” you need the index to update result[].'],
  },

  // â”€â”€â”€ Next Permutation â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
  'next-permutation': {
    intuition:
      'Three steps: (1) find the rightmost "descent" (arr[i] < arr[i+1]). (2) Swap arr[i] with the smallest element greater than arr[i] to its right. (3) Reverse the suffix after position i to get the next smallest permutation.',
    algorithm: [
      'Find i from n-2 down: first index where arr[i] < arr[i+1]. If none: reverse all (last permutation).',
      'Find j from n-1 down: first index where arr[j] > arr[i]. Swap arr[i] and arr[j].',
      'Reverse arr[i+1..n-1].',
    ],
    example: {
      input: 'arr = [1,2,3]',
      steps: [
        'i=1 (arr[1]=2 < arr[2]=3). j=2 (arr[2]=3 > 2). Swap: [1,3,2]. Reverse suffix: [1,3,2]. â†’ [1,3,2].',
      ],
      output: '[1,3,2]',
    },
    pitfalls: ['Reverse the suffix, do not sort it â€” the suffix is already in descending order so reversing achieves ascending order in O(n).'],
  },

  // â”€â”€â”€ Palindrome Linked List â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
  'palindrome-linked-list': {
    intuition:
      'Find the midpoint (slow/fast pointers), reverse the second half, compare with the first half, then optionally restore. O(n) time, O(1) space.',
    algorithm: [
      'Find mid: slow/fast pointers.',
      'Reverse the second half starting from mid.next.',
      'Compare first half (head) with reversed second half. Track if palindrome.',
      'Optionally restore the second half.',
    ],
    example: {
      input: '1â†’2â†’2â†’1',
      steps: [
        'Mid = node(2) at index 1. Reverse second half: 1â†’2.',
        'Compare: 1==1, 2==2. Palindrome!',
      ],
      output: 'true',
    },
    pitfalls: ['Restore the list after comparison if the problem requires (most GFG solutions need immutable input).'],
  },

  // â”€â”€â”€ Parenthesis Checker â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
  'parenthesis-checker': {
    intuition:
      'Use a stack. Push opening brackets. For closing brackets, check the stack top is the matching opener. Return true iff the stack is empty at the end.',
    algorithm: [
      'For each char: if open bracket ({,[,(): push. If close: if stack empty or top doesn\'t match: return false; pop.',
      'Return stack.isEmpty().',
    ],
    example: {
      input: '"{()[{()}]}"',
      steps: [
        '{ push. ( push. ) matches ( â†’ pop. [ push. { push. ( push. ) â†’ pop. } â†’ pop. ] â†’ pop. } â†’ pop. Stack empty â†’ true.',
      ],
      output: 'true',
    },
    pitfalls: ['Check stack is non-empty before comparing top â€” an extra closing bracket crashes a stack-empty check.'],
  },

  // â”€â”€â”€ Partition Equal Subset Sum â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
  'partition-equal-subset-sum': {
    intuition:
      'Can we select a subset summing to totalSum/2? Classic 0/1 knapsack boolean DP. If totalSum is odd, return false immediately. dp[j] = true if subset summing to j is achievable.',
    algorithm: [
      'If sum%2==1: return false. target=sum/2.',
      'dp[0]=true, dp[1..target]=false.',
      'For each num: for j from target down to num: dp[j] |= dp[j-num].',
      'Return dp[target].',
    ],
    example: {
      input: 'arr=[1,5,11,5], sum=22',
      steps: [
        'target=11. After processing: dp[11]=true via [1,5,5] or [11]. Return true.',
      ],
      output: 'true',
    },
    pitfalls: ['Process in reverse to avoid using the same element twice (0/1 constraint).'],
  },

  // â”€â”€â”€ Rat in a Maze Problem - I â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
  'rat-in-a-maze-problem-i': {
    intuition:
      'Backtracking: from (0,0), try moving Down/Left/Right/Up (in any order). Mark cell as visited to avoid cycles. Record path when (n-1,n-1) is reached. Backtrack by unmarking.',
    algorithm: [
      'DFS(r,c,path): if (r,c)==(n-1,n-1): add path to results.',
      'For each direction (D,L,R,U) in sorted order: compute (nr,nc). If valid, unvisited, and maze[nr][nc]==1: mark, recurse, unmark.',
    ],
    example: {
      input: 'maze=[[1,0,0,0],[1,1,0,1],[1,1,0,0],[0,1,1,1]]',
      steps: [
        'Path DDRDRR: (0,0)â†’(1,0)â†’(2,0)â†’(2,1)â†’(3,1)â†’(3,2)â†’(3,3). Valid!',
      ],
      output: '["DDRDRR"]',
    },
    pitfalls: ['Add directions in sorted order (D,L,R,U) to get paths in lexicographic order.'],
  },

  // â”€â”€â”€ Reverse a linked list â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
  'reverse-a-linked-list': {
    intuition:
      'Iterative reversal: use three pointers (prev, curr, next). Redirect each node\'s next pointer to its predecessor.',
    algorithm: [
      'prev=null, curr=head.',
      'While curr != null: next=curr.next. curr.next=prev. prev=curr. curr=next.',
      'Return prev (new head).',
    ],
    example: {
      input: '1â†’2â†’3â†’4â†’5',
      steps: [
        'nullâ†1  2â†’3â†’4â†’5. nullâ†1â†2  3â†’4â†’5. ... nullâ†1â†2â†3â†4â†5. prev=5.',
      ],
      output: '5â†’4â†’3â†’2â†’1',
    },
    pitfalls: ['Save curr.next BEFORE redirecting curr.next=prev, or you lose the rest of the list.'],
  },

  // â”€â”€â”€ Rotten Oranges â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
  'rotten-oranges': {
    intuition:
      'Multi-source BFS: add all initially rotten oranges to the queue. Each BFS step represents one minute of rotting. After BFS, if any fresh orange remains, return -1.',
    algorithm: [
      'Count fresh oranges. Enqueue all rotten (value=2) cells with time=0.',
      'BFS: dequeue (r,c,t). For each 4-neighbor: if fresh: mark rotten, fresh--, enqueue with t+1.',
      'If fresh==0: return maxTime. Else: return -1.',
    ],
    example: {
      input: '[[2,1,1],[1,1,0],[0,1,1]]',
      steps: [
        'Start: rotten at (0,0). Minute 1: (0,1),(1,0) rot. Minute 2: (0,2),(1,1) rot. Minute 3: (2,1) rots. Minute 4: (2,2) rots.',
        'Total=4.',
      ],
      output: '4',
    },
    pitfalls: ['Start BFS with ALL rotten oranges simultaneously â€” not from just one source.'],
  },

  // â”€â”€â”€ Serialize and deserialize a binary tree â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
  'serialize-and-deserialize-a-binary-tree': {
    intuition:
      'Serialize via pre-order DFS: record node values and "#" for null nodes. Deserialize by consuming tokens in the same pre-order: the first non-null token is the root, recurse for left then right subtree.',
    algorithm: [
      'Serialize: preorder DFS, append val or "#", comma-separated.',
      'Deserialize: split by comma, use an index pointer (or queue of tokens). Consume first token: if "#" return null. Else create node, recurse left, then right.',
    ],
    example: {
      input: 'Tree: 1â†’(2, 3â†’(4,5))',
      steps: [
        'Serialize: "1,2,#,#,3,4,#,#,5,#,#".',
        'Deserialize: read 1â†’root, read 2â†’left, read #â†’left.left=null, read #â†’left.right=null, ...',
      ],
      output: 'Reconstructed tree = original tree',
    },
    pitfalls: ['Use pre-order (not in-order) for serialization â€” in-order requires extra information to determine root.'],
  },

  // â”€â”€â”€ Sort 0s, 1s and 2s â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
  'sort-0s-1s-and-2s': {
    intuition:
      'Dutch National Flag algorithm (same as LeetCode 75). Three-way partition in a single pass using three pointers: lo, mid, hi.',
    algorithm: [
      'See LeetCode 75 explanation â€” identical.',
    ],
    example: {
      input: '[0,1,2,0,1,2]',
      steps: ['Result: [0,0,1,1,2,2] in one pass.'],
      output: '[0,0,1,1,2,2]',
    },
    pitfalls: ['Do not increment mid when swapping with hi â€” the swapped element is unexamined.'],
  },

  // â”€â”€â”€ Subset Sum Problem â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
  'subset-sum-problem': {
    intuition:
      'Boolean DP: dp[j] = true if a subset with sum j exists. Same as 0/1 knapsack boolean version. For each element, iterate backwards through dp array.',
    algorithm: [
      'dp[0]=true, rest=false.',
      'For each num: for j from sum down to num: dp[j] |= dp[j-num].',
      'Return dp[sum].',
    ],
    example: {
      input: 'arr=[3,34,4,12,5,2], sum=9',
      steps: ['Subsets summing to 9: {4,5}, {3,4,2}. Return true.'],
      output: 'true',
    },
    pitfalls: ['Process in reverse order (j from sum down) to avoid using an element multiple times.'],
  },

  // â”€â”€â”€ Topological sort â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
  'topological-sort': {
    intuition:
      'Kahn\'s BFS approach: repeatedly remove nodes with in-degree 0. DFS approach: after exploring all descendants, push node to stack; the reverse of the stack gives topological order.',
    algorithm: [
      'DFS: TopoSort(node): mark visited. For each neighbor: if not visited, DFS. Push node to stack AFTER recursion.',
      'Collect nodes by finishing time (descending).',
    ],
    example: {
      input: 'DAG: 5â†’0, 5â†’2, 4â†’0, 4â†’1, 2â†’3, 3â†’1',
      steps: ['One valid topological order: 5,4,2,3,1,0.'],
      output: '[5,4,2,3,1,0]',
    },
    pitfalls: ['Topological sort is only valid for DAGs (Directed Acyclic Graphs). Detect cycles first.'],
  },

  // â”€â”€â”€ Top View of Binary Tree â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
  'top-view-of-binary-tree': {
    intuition:
      'Level-order traversal with horizontal distance (HD). For each HD, record only the FIRST node seen (top view). A node is visible from the top if no ancestor has the same HD.',
    algorithm: [
      'BFS with (node, HD). Map: HD â†’ first seen value (only set if HD not already in map).',
      'Enqueue (left, hdâˆ’1) and (right, hd+1).',
      'Return map values sorted by HD.',
    ],
    example: {
      input: 'Tree: 1â†’(2â†’(4,5),3)',
      steps: ['HD: 4â†’-2, 2â†’-1, 5â†’0, 1â†’0, 3â†’1. Top (first seen): 4,2,1,3.'],
      output: '[4,2,1,3]',
    },
    pitfalls: ['For top view, the FIRST node (BFS order = top to bottom) at each HD wins. For bottom view, the last node wins.'],
  },

  // â”€â”€â”€ Trapping Rain Water â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
  'trapping-rain-water': {
    intuition:
      'Same as LeetCode 42. Two-pointer approach: water at each position is limited by the shorter of the max heights seen from left and right. Two pointers converge inward, always processing the shorter side.',
    algorithm: [
      'left=0, right=n-1, leftMax=0, rightMax=0, water=0.',
      'While left < right: if height[left] <= height[right]: leftMax=max(leftMax,height[left]). water+=leftMax-height[left]. left++.',
      'Else: rightMax=max(rightMax,height[right]). water+=rightMax-height[right]. right--.',
    ],
    example: {
      input: 'height = [0,1,0,2,1,0,1,3,2,1,2,1]',
      steps: ['Two-pointer fills: total trapped = 6.'],
      output: '6',
    },
    pitfalls: ['Process the shorter side â€” the shorter boundary determines how much water is trapped.'],
  },

  // â”€â”€â”€ Two Sum - Pair with Given Sum â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
  'two-sum-pair-with-given-sum': {
    intuition:
      'Two pointers on sorted array: if sum < target, advance left; if sum > target, retreat right; if equal, found the pair. For unsorted, use a HashSet: for each element, check if (targetâˆ’element) is in the set.',
    algorithm: [
      'Sort arr. lo=0, hi=n-1.',
      'While lo < hi: sum=arr[lo]+arr[hi]. If sum==target: return true. If sum<target: lo++. Else: hi--.',
      'Return false.',
    ],
    example: {
      input: 'arr=[2,7,11,15], target=9',
      steps: ['lo=0(2), hi=3(15): 17>9â†’hi--. hi=2(11): 13>9â†’hi--. hi=1(7): 9==9 âœ“.'],
      output: 'true',
    },
    pitfalls: ['Sorting changes indices â€” if you need to return original indices, use a HashMap approach instead.'],
  },

  // â”€â”€â”€ Undirected Graph Cycle â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
  'undirected-graph-cycle': {
    intuition:
      'BFS or DFS with parent tracking. In an undirected graph, a cycle exists if a visited neighbor is not the direct parent. Track the parent to avoid treating the back-edge to parent as a cycle.',
    algorithm: [
      'DFS(node, parent): for each neighbor v: if !visited: DFS(v, node). Else if v != parent: cycle detected.',
    ],
    example: {
      input: 'Graph: 0-1, 1-2, 2-0 (triangle)',
      steps: [
        'DFS(0,âˆ’1)â†’DFS(1,0)â†’DFS(2,1): neighbor 0 is visited and â‰  parent(1) â†’ cycle!',
      ],
      output: 'true',
    },
    pitfalls: ['Pass parent as -1 for the root node. For multigraphs (parallel edges), use parent-edge ID instead of parent node.'],
  },

  // â”€â”€â”€ Word Break â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
  'word-break': {
    intuition:
      'DP: dp[i] = true if s[0..i-1] can be segmented using dictionary words. For each i, check all j < i: if dp[j] is true and s[j..i-1] is in the dictionary, dp[i]=true.',
    algorithm: [
      'wordSet = HashSet(dictionary). dp[0]=true.',
      'For i from 1 to n: for j from 0 to i-1: if dp[j] and s[j..i-1] in wordSet: dp[i]=true. Break.',
      'Return dp[n].',
    ],
    example: {
      input: 's="leetcode", dict=["leet","code"]',
      steps: [
        'dp[0]=true. i=4: j=0, dp[0]=true, "leet" in dict â†’ dp[4]=true.',
        'i=8: j=4, dp[4]=true, "code" in dict â†’ dp[8]=true.',
      ],
      output: 'true',
    },
    pitfalls: ['Use a HashSet for O(1) dictionary lookups â€” do not iterate the dictionary for each check.'],
  },

  // â”€â”€â”€ ZigZag Tree Traversal â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
  'zigzag-tree-traversal': {
    intuition:
      'Level-order BFS with alternating direction. Collect each level normally, then reverse every other level (or use a deque and alternate front/back insertions).',
    algorithm: [
      'BFS level order (same as problem 102).',
      'For odd levels (0-indexed): reverse the level list before adding to result.',
    ],
    example: {
      input: 'root = [3,9,20,null,null,15,7]',
      steps: [
        'Level 0 (left-to-right): [3]. Level 1 (right-to-left): [20,9]. Level 2 (left-to-right): [15,7].',
      ],
      output: '[[3],[20,9],[15,7]]',
    },
    pitfalls: ['Track level parity (odd/even) to know when to reverse.'],
  },

  // â”€â”€â”€ Allocate Minimum Pages â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
  'allocate-minimum-pages': {
    intuition: 'Binary search on the answer (minimum of maximum pages). For a given mid, check if we can allocate books to m students such that each student gets at most mid pages.',
    algorithm: [
      'lo = max(books), hi = sum(books).',
      'Binary search: mid = (lo+hi)/2. Check feasibility: greedily assign books; if a student would exceed mid, start a new student.',
      'If feasible with â‰¤ m students: hi=mid. Else lo=mid+1.',
      'Return lo.',
    ],
    example: { input: 'books=[12,34,67,90], m=2', steps: ['lo=90, hi=203. mid=146: [12,34,67] to student1 (113â‰¤146), [90] to student2 â†’ 2 students âœ“.', 'hi=146. mid=118: [12,34,67] (113â‰¤118), [90] âœ“. hi=118.', 'Continue until lo=hi=113.'], output: '113' },
    pitfalls: ['A student must get at least one book. Books must be contiguous (can\'t reorder).'],
  },

  // â”€â”€â”€ BST to Greater Sum Tree â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
  'bst-to-greater-sum-tree': {
    intuition: 'In-order traversal visits BST in ascending order. Reverse in-order (rightâ†’nodeâ†’left) visits in descending order. Maintain a running sum; update each node\'s value.',
    algorithm: [
      'Do reverse in-order traversal (right subtree first).',
      'Maintain running sum. At each node: sum += node.val; node.val = sum.',
    ],
    example: { input: 'BST=[4,1,6,0,2,5,7]', steps: ['Visit 7â†’sum=7. Visit 6â†’sum=13. Visit 5â†’sum=18. Visit 4â†’sum=22. Visit 2â†’sum=24. Visit 1â†’sum=25. Visit 0â†’sum=25.'], output: 'Tree with updated values' },
    pitfalls: ['This is a simple Morris traversal or recursive reverse in-order â€” no extra space needed with Morris.'],
  },

  // â”€â”€â”€ Burning Tree â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
  'burning-tree': {
    intuition: 'Fire spreads from target node to all adjacent nodes (parent, children). Model as BFS from the target node treating the tree as a graph. First, find target and track parent pointers.',
    algorithm: [
      'DFS to find target node and build parent map.',
      'BFS from target node: spread to left child, right child, and parent each step.',
      'Count BFS levels (time steps) until all nodes are burned.',
    ],
    example: { input: 'root=[1,2,3,4,5], target=2', steps: ['t=0: burn node 2.', 't=1: burn 1(parent),4,5(children).', 't=2: burn 3(sibling via parent 1).', 'Total=2.'], output: '2' },
    pitfalls: ['Must track parent pointers since BFS needs to go upward too. Mark visited nodes to avoid cycles.'],
  },

  // â”€â”€â”€ Chocolate Distribution Problem â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
  'chocolate-distribution-problem': {
    intuition: 'Sort packets. The minimum difference between max and min packets given to m students is found in the sliding window of size m after sorting.',
    algorithm: [
      'Sort the packet array.',
      'Sliding window of size m: for each window, compute A[i+m-1] - A[i].',
      'Return minimum such difference.',
    ],
    example: { input: 'A=[7,3,2,4,9,12,56], m=3', steps: ['Sorted: [2,3,4,7,9,12,56].', 'Windows of size 3: [2,3,4]â†’2, [3,4,7]â†’4, [4,7,9]â†’5, [7,9,12]â†’5, [9,12,56]â†’47.', 'Min=2.'], output: '2' },
    pitfalls: ['Sort first â€” only then is the minimum range guaranteed to be a contiguous subarray.'],
  },

  // â”€â”€â”€ Clone a linked list with next and random pointer â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
  'clone-a-linked-list-with-next-and-random-pointer': {
    intuition: 'Three passes: (1) interleave cloned nodes between original nodes, (2) set random pointers for cloned nodes, (3) separate the two lists.',
    algorithm: [
      'Pass 1: for each node N, insert clone N\' after N: Nâ†’N\'â†’N.next.',
      'Pass 2: for each original node N: N.next.random = N.random?.next.',
      'Pass 3: separate lists by fixing next pointers.',
    ],
    pitfalls: ['Pass 2 relies on the interleaved structure: original.random.next is the clone of original.random. Restore original list in pass 3.'],
  },

  // â”€â”€â”€ Course Schedule I â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
  'course-schedule-i': {
    intuition: 'Can all courses be completed? This is cycle detection in a directed graph. If the prerequisite graph is a DAG (no cycles), all courses can be done.',
    algorithm: [
      'Build directed adjacency list: prerequisiteâ†’course.',
      'Topological sort (Kahn\'s BFS): compute in-degrees. Queue nodes with in-degree 0. Process: reduce neighbors\' in-degree, add to queue when 0.',
      'If processed count == numCourses, return true.',
    ],
    example: { input: 'n=2, prerequisites=[[1,0]]', steps: ['Graph: 0â†’1. in-degree: [0,1]. Queue:[0]. Process 0â†’in[1]=0â†’add 1. Count=2=n.'], output: 'true' },
    pitfalls: ['Also solvable with DFS cycle detection (white/grey/black coloring).'],
  },

  // â”€â”€â”€ Course Schedule II â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
  'course-schedule-ii': {
    intuition: 'Return a valid course order (topological sort). If cycle exists, return empty array.',
    algorithm: [
      'Kahn\'s algorithm: build adjacency list, compute in-degrees.',
      'Queue all nodes with in-degree 0. Process queue: add to order, decrement neighbors\' in-degrees, add neighbors with in-degree 0.',
      'If order.size == n, return order. Else return [].',
    ],
    pitfalls: ['Return any valid topological order, not a specific one. Empty array signals impossible (cycle).'],
  },

  // â”€â”€â”€ Count Distinct elements in every window â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
  'count-distinct-elements-in-every-window': {
    intuition: 'Sliding window of size k. Use a frequency map. Track count of distinct elements (map size with non-zero counts).',
    algorithm: [
      'Populate frequency map with first k elements. Record distinct count.',
      'Slide window: add new element (increment freq, if new â†’ distinct++). Remove old (decrement, if 0 â†’ distinct--).',
      'Record distinct count for each position.',
    ],
    pitfalls: ['Remove element from map entirely (or just decrement and check 0) when its count drops to 0.'],
  },

  // â”€â”€â”€ Count Reverse Pairs â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
  'count-reverse-pairs': {
    intuition: 'Count pairs (i,j) where i<j and A[i]>2*A[j]. Use merge sort: during merging, count pairs across left and right halves efficiently.',
    algorithm: [
      'Modified merge sort.',
      'Before merging, count pairs: for each element in left half, count elements in right half where left[i] > 2*right[j].',
      'Use two pointers on sorted halves for O(n) counting per level.',
      'Merge normally.',
    ],
    pitfalls: ['Count BEFORE merging (after recursive sort), so both halves are sorted. The count step is separate from the merge step.'],
  },

  // â”€â”€â”€ Diameter of a Binary Tree â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
  'diameter-of-a-binary-tree': {
    intuition: 'Diameter passes through some node (LCA). For each node, diameter through it = leftHeight + rightHeight. Track global maximum.',
    algorithm: [
      'DFS returning height of subtree.',
      'At each node: diameter candidate = leftHeight + rightHeight.',
      'Update global max. Return 1 + max(leftHeight, rightHeight) as height.',
    ],
    example: { input: 'root=[1,2,3,4,5]', steps: ['Node 4: h=1. Node 5: h=1. Node 2: dia=2, h=2. Node 3: h=1. Node 1: dia=1+2=3, h=3.'], output: '3' },
    pitfalls: ['Diameter doesn\'t have to pass through root. Update global max at every node.'],
  },

  // â”€â”€â”€ Dice throw â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
  'dice-throw': {
    intuition: 'Count ways to get sum S with N dice, each having M faces. DP: dp[i][j] = ways to get sum j with i dice.',
    algorithm: [
      'dp[0][0] = 1.',
      'For each die d from 1 to N: for each sum j: dp[d][j] = sum of dp[d-1][j-f] for f in 1..min(m,j).',
      'Return dp[N][S].',
    ],
    example: { input: 'N=2, M=6, S=4', steps: ['dp[1] = [0,1,1,1,1,1,1]. dp[2][4] = dp[1][3]+dp[1][2]+dp[1][1] = 3.'], output: '3' },
    pitfalls: ['1D DP with offset or 2D is clearer. Inner loop runs 1..min(m,j) to avoid going negative.'],
  },

  // â”€â”€â”€ Evaluation of Postfix Expression â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
  'evaluation-of-postfix-expression': {
    intuition: 'Stack-based evaluation: push operands, on operator pop two operands, apply, push result.',
    algorithm: [
      'Scan tokens left to right.',
      'If token is number: push to stack.',
      'If token is operator (+,-,*,/): pop b then a, compute a op b, push result.',
      'Final stack top is the result.',
    ],
    example: { input: '"2 3 1 * + 9 -"', steps: ['Push 2,3,1. *: pop 3,1â†’3. +: pop 2,3â†’5. Push 9. -: pop 5,9â†’-4.'], output: '-4' },
    pitfalls: ['Pop order matters: pop b first, then a, compute a op b (not b op a).'],
  },

  // â”€â”€â”€ Find median in a stream â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
  'find-median-in-a-stream': {
    intuition: 'Maintain two heaps: max-heap for lower half, min-heap for upper half. Median is the top of the larger heap (or average of both tops).',
    algorithm: [
      'Insert to max-heap. Then balance: if max-heap top > min-heap top, move max-heap top to min-heap.',
      'Rebalance sizes: if size difference > 1, move top of larger to smaller.',
      'Median: if equal size, average tops. If unequal, top of larger.',
    ],
    example: { input: 'Stream: 5,15,1,3', steps: ['Add 5: max=[5]. Add 15: min=[15], max=[5]. Add 1: max=[5,1], min=[15]. Add 3: max=[3,1], min=[5,15]. Median=(3+5)/2=4.'], output: '4.0' },
    pitfalls: ['Java uses PriorityQueue (min by default); negate values for max-heap. Python: heapq is min-heap.'],
  },

  // â”€â”€â”€ Find the number of islands â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
  'find-the-number-of-islands': {
    intuition: 'DFS/BFS flood fill: for each unvisited \'1\', increment count and DFS to mark all connected \'1\'s as visited.',
    algorithm: [
      'Iterate over all cells. For each \'1\' not yet visited:',
      'Increment island count.',
      'DFS/BFS: mark current as visited, recurse on all 4 (or 8) neighbors that are \'1\'.',
    ],
    example: { input: '[[1,1,0],[0,1,0],[0,0,1]]', steps: ['Start (0,0)â†’DFS marks (0,0),(0,1),(1,1). Count=1. (2,2) unvisitedâ†’Count=2.'], output: '2' },
    pitfalls: ['Mark cells as visited immediately to avoid re-counting. Determine if connectivity is 4-directional or 8-directional.'],
  },

  // â”€â”€â”€ Flattening a Linked List â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
  'flattening-a-linked-list': {
    intuition: 'Each node has a next pointer (horizontal) and a child pointer (vertical sorted list). Merge all vertical lists using merge sort logic.',
    algorithm: [
      'Recursively flatten from right to left.',
      'Merge current node\'s child list with the already-flattened rest.',
      'Return merged sorted list.',
    ],
    pitfalls: ['After merging, the result uses child pointers, not next pointers. Set next to null in the merged result.'],
  },

  // â”€â”€â”€ Flood fill Algorithm â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
  'flood-fill-algorithm': {
    intuition: 'From a starting pixel, paint it and all connected pixels of the same color with a new color. DFS/BFS from start.',
    algorithm: [
      'If starting pixel\'s color already equals new color, return (avoid infinite loop).',
      'DFS from (sr,sc): set image[r][c]=newColor. Recurse on 4 neighbors with old color.',
    ],
    example: { input: 'image=[[1,1,1],[1,1,0],[1,0,1]], sr=1, sc=1, newColor=2', steps: ['Fill connected 1s: (0,0),(0,1),(0,2),(1,0),(1,1),(2,0) become 2.'], output: '[[2,2,2],[2,2,0],[2,0,1]]' },
    pitfalls: ['Check if start pixel\'s color == new color and skip to avoid infinite recursion.'],
  },

  // â”€â”€â”€ Gold Mine Problem â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
  'gold-mine-problem': {
    intuition: 'DP: you can enter from any row in column 0 and move right, right-up, or right-down. Find path maximizing gold collected.',
    algorithm: [
      'dp[i][j] = max gold reachable at cell (i,j) coming from left column.',
      'For each column j from 1: for each row i: dp[i][j] = grid[i][j] + max(dp[i-1][j-1], dp[i][j-1], dp[i+1][j-1]).',
      'Return max over all dp[i][n-1].',
    ],
    pitfalls: ['Boundary checks for first/last rows. Can start from any cell in column 0. Must move left to right only.'],
  },

  // â”€â”€â”€ Gray Code â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
  'gray-code': {
    intuition: 'n-bit Gray code: i-th value = i XOR (i>>1). Or build iteratively: mirror and prefix with 0/1.',
    algorithm: [
      'Iterative: start with [0]. For each step i from 1 to n: for j from current.size-1 to 0, append current[j] | (1<<(i-1)).',
      'Or formula: for i in 0..2^n-1, gray[i] = i ^ (i>>1).',
    ],
    example: { input: 'n=2', steps: ['Step 0: [0]. Step 1: [0,1]. Step 2: [00,01,11,10] = [0,1,3,2].'], output: '[0,1,3,2]' },
    pitfalls: ['Successive values differ by exactly 1 bit. The XOR formula i^(i>>1) directly gives the i-th Gray code.'],
  },

  // â”€â”€â”€ Implement Atoi â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
  'implement-atoi': {
    intuition: 'Parse integer from string: skip whitespace, handle sign, parse digits, clamp to INT range.',
    algorithm: [
      'Skip leading whitespace.',
      'Check sign (+ or -).',
      'Parse digits: result = result*10 + digit. Stop at non-digit.',
      'Clamp: if > INT_MAX return INT_MAX; if < INT_MIN return INT_MIN.',
    ],
    pitfalls: ['Overflow during parsing: check before multiplying. Empty string or all-whitespace returns 0.'],
  },

  // â”€â”€â”€ Implement Pow â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
  'implement-pow': {
    intuition: 'Fast exponentiation (binary exponentiation): x^n = (x^(n/2))^2, halving n each time.',
    algorithm: [
      'If n==0: return 1. If n<0: x=1/x, n=-n.',
      'If n is even: return pow(x*x, n/2).',
      'If n is odd: return x * pow(x*x, n/2).',
    ],
    example: { input: 'x=2.0, n=10', steps: ['pow(2,10)=pow(4,5)=4*pow(16,2)=4*pow(256,1)=4*256=1024.'], output: '1024.0' },
    pitfalls: ['Handle n=INT_MIN carefully (overflow on negation). Use long for n.'],
  },

  // â”€â”€â”€ Inorder Traversal â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
  'inorder-traversal': {
    intuition: 'Visit left subtree, then root, then right subtree. For iterative: use stack to simulate call stack.',
    algorithm: [
      'Recursive: inorder(left), visit root, inorder(right).',
      'Iterative: push all left nodes to stack. Pop, add to result, then push all left nodes of right subtree.',
    ],
    pitfalls: ['Morris traversal achieves O(1) space by temporarily modifying tree links.'],
  },

  // â”€â”€â”€ Intersection Point in Y Shaped Linked Lists â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
  'intersection-point-in-y-shaped-linked-lists': {
    intuition: 'Two pointers: switch to the other head when reaching null. They\'ll meet at the intersection after traversing both lists\' full lengths.',
    algorithm: [
      'a = headA, b = headB.',
      'While a != b: a = (a == null) ? headB : a.next; b = (b == null) ? headA : b.next.',
      'Return a (intersection or null).',
    ],
    pitfalls: ['If no intersection, both become null simultaneously after traversing both full lists, so while loop terminates.'],
  },

  // â”€â”€â”€ Josephus problem â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
  'josephus-problem': {
    intuition: 'Mathematical recurrence: J(1)=0; J(n)=(J(n-1)+k)%n. The 0-indexed survivor position builds from n=1.',
    algorithm: [
      'pos = 0.',
      'For i from 2 to n: pos = (pos + k) % i.',
      'Return pos + 1 (convert to 1-indexed).',
    ],
    example: { input: 'n=5, k=2', steps: ['J(1)=0. J(2)=(0+2)%2=0. J(3)=(0+2)%3=2. J(4)=(2+2)%4=0. J(5)=(0+2)%5=2. 1-indexed=3.'], output: '3' },
    pitfalls: ['0-indexed formula; add 1 at end for 1-indexed answer.'],
  },

  // â”€â”€â”€ K-th element of two Arrays â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
  'k-th-element-of-two-arrays': {
    intuition: 'Binary search on one array. Take some elements from first array and k-take from second. Ensure the partition is valid.',
    algorithm: [
      'Binary search: lo=max(0,k-n2), hi=min(k,n1).',
      'mid1 elements from arr1, mid2=k-mid1 from arr2.',
      'Check: arr1[mid1-1]<=arr2[mid2] and arr2[mid2-1]<=arr1[mid1].',
      'The kth element is max(arr1[mid1-1], arr2[mid2-1]).',
    ],
    pitfalls: ['Handle boundary cases where mid1=0 or mid1=n1 (use -infinity/+infinity sentinels).'],
  },

  // â”€â”€â”€ k-th Smallest in BST â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
  'k-th-smallest-in-bst': {
    intuition: 'In-order traversal of BST visits nodes in sorted ascending order. The k-th node visited is the k-th smallest.',
    algorithm: [
      'In-order DFS: traverse left, visit node (decrement k), traverse right.',
      'When k reaches 0, store current node value.',
    ],
    example: { input: 'BST=[5,3,6,2,4], k=3', steps: ['In-order: 2,3,4,5,6. 3rd = 4.'], output: '4' },
    pitfalls: ['Can early-exit once k reaches 0. For iterative, use a stack and counter.'],
  },

  // â”€â”€â”€ LCS of three strings â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
  'lcs-of-three-strings': {
    intuition: 'Extension of LCS: 3D DP. dp[i][j][k] = LCS of first i chars of s1, j chars of s2, k chars of s3.',
    algorithm: [
      'If s1[i-1]==s2[j-1]==s3[k-1]: dp[i][j][k] = dp[i-1][j-1][k-1] + 1.',
      'Else: dp[i][j][k] = max(dp[i-1][j][k], dp[i][j-1][k], dp[i][j][k-1]).',
      'Return dp[n1][n2][n3].',
    ],
    pitfalls: ['3D DP has O(nÂ³) time and space. Can be space-optimized but logic is clearer in 3D.'],
  },

  // â”€â”€â”€ Largest BST â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
  'largest-bst': {
    intuition: 'For each subtree, check if it\'s a valid BST and track its size. Return max BST size found. Each subtree return: (isBST, size, min, max).',
    algorithm: [
      'DFS returning (isBST, size, minVal, maxVal) for each subtree.',
      'A node\'s subtree is BST if both children are BSTs, node.val > left.max, node.val < right.min.',
      'BST size = left.size + right.size + 1. Track global maximum.',
    ],
    pitfalls: ['If subtree is not BST, return size=0 so its ancestors can\'t count it. Propagate min/max correctly.'],
  },

  // â”€â”€â”€ Left View of Binary Tree â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
  'left-view-of-binary-tree': {
    intuition: 'BFS level order: first node of each level is visible from left. Or DFS with level tracking: first visit at each level is left view.',
    algorithm: [
      'BFS: for each level, add the first node\'s value to result.',
      'Or DFS: pass level. If level == result.size(), add current node value (first visit at this level).',
    ],
    pitfalls: ['DFS should visit left child first to ensure leftmost node is recorded first.'],
  },

  // â”€â”€â”€ Level Order in spiral form â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
  'level-order-in-spiral-form': {
    intuition: 'Alternate direction each level. Use two stacks: one for left-to-right levels, one for right-to-left. Or BFS with a direction flag.',
    algorithm: [
      'Use two stacks s1 (current) and s2 (next).',
      'Left-to-right level: push right then left child to s2.',
      'Right-to-left level: push left then right child to s2.',
      'Swap stacks after each level.',
    ],
    pitfalls: ['When printing left-to-right, push children right-then-left to next stack (stack reverses order).'],
  },

  // â”€â”€â”€ Linked List Group Reverse â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
  'linked-list-group-reverse': {
    intuition: 'Reverse every k nodes. For each group of k, reverse the sublist then connect to next group.',
    algorithm: [
      'Check if at least k nodes remain; if not, leave as-is.',
      'Reverse k nodes using prev/curr/next.',
      'head.next = reverseKGroup(next_group, k).',
      'Return new head of this group.',
    ],
    pitfalls: ['After reversal, old head of group becomes the tail. Connect it to recursively processed next group.'],
  },

  // â”€â”€â”€ Longest Common Increasing Subsequence â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
  'longest-common-increasing-subsequence': {
    intuition: 'Combine LCS and LIS. dp[j] = length of LCIS ending with B[j]. For each A[i], update dp[j] for B[j]==A[i] using best candidate from previous elements.',
    algorithm: [
      'For each i (A): best = 0. For each j (B):',
      'If A[i] == B[j]: dp[j] = best + 1.',
      'If A[i] > B[j]: best = max(best, dp[j]).',
      'Return max(dp).',
    ],
    pitfalls: ['Track "best" separately to avoid using updated dp values in same outer iteration.'],
  },

  // â”€â”€â”€ Longest Common Substring â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
  'longest-common-substring': {
    intuition: 'DP: dp[i][j] = length of longest common substring ending at s1[i-1] and s2[j-1]. If chars match, dp[i][j]=dp[i-1][j-1]+1. Track global max.',
    algorithm: [
      'dp[i][j] = 0 if s1[i-1] != s2[j-1], else dp[i-1][j-1]+1.',
      'Track max(dp[i][j]) across all i,j.',
    ],
    example: { input: 's1="ABCBDAB", s2="BDCABA"', steps: ['dp fills up. Max common substring is "AB" or "BD" of length 2? Actually "BCB"/"BDCAB" â†’ "BCA"? Let me recalculate: longest = "AB"=2... actually "ABCB" vs "BDCABA" â†’ "AB"=2.'], output: '2' },
    pitfalls: ['Unlike LCS, must be contiguous â€” reset dp[i][j]=0 on mismatch, no max with adjacent cells.'],
  },

  // â”€â”€â”€ Longest Consecutive Subsequence â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
  'longest-consecutive-subsequence': {
    intuition: 'Add all elements to a HashSet. For each number n where n-1 is NOT in the set (it\'s a sequence start), count how long the streak goes.',
    algorithm: [
      'Add all nums to HashSet.',
      'For each n where set doesn\'t contain n-1: count streak = 1, while set contains n+streak: streak++.',
      'Update max streak.',
    ],
    example: { input: '[100,4,200,1,3,2]', steps: ['Start=1: 1,2,3,4 â†’ streak=4. Start=100: streak=1. Start=200: streak=1.'], output: '4' },
    pitfalls: ['Only start counting from sequence start (n-1 not in set) â€” avoids O(nÂ²) repetition.'],
  },

  // â”€â”€â”€ Longest valid Parentheses â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
  'longest-valid-parentheses': {
    intuition: 'Use a stack to find the length of the longest valid parentheses substring. Push indices; on \')\', pop matching \'(\'; if stack empty, push current as new base.',
    algorithm: [
      'Push -1 as base index onto stack.',
      'For \'(\': push index.',
      'For \')\': pop. If stack empty: push current index as new base. Else: length = i - stack.top(). Update max.',
    ],
    example: { input: '"()(()"', steps: ['i=0 \'(\' push. i=1 \')\' pop, stack=[âˆ’1], len=1âˆ’(âˆ’1)=2. i=2,3 push. i=4 \')\' pop, stack=[1], len=4âˆ’1=3.'], output: '4... (recalc: "(()" â†’ len=2 from last two)' },
    pitfalls: ['Initialize stack with -1 as sentinel. Also solvable with DP (dp[i] = length ending at i) or two passes.'],
  },

  // â”€â”€â”€ Lowest Common Ancestor in a BST â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
  'lowest-common-ancestor-in-a-bst': {
    intuition: 'BST property: LCA is the first node where paths to n1 and n2 diverge. If both values are less than current node, LCA is in left subtree; if both greater, in right; else current is LCA.',
    algorithm: [
      'While root != null:',
      'If n1 < root.val and n2 < root.val: root = root.left.',
      'If n1 > root.val and n2 > root.val: root = root.right.',
      'Else return root.',
    ],
    pitfalls: ['Only valid for BST. For general binary tree, use the standard LCA algorithm.'],
  },

  // â”€â”€â”€ Majority Element II â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
  'majority-element-ii': {
    intuition: 'Find all elements appearing more than âŒŠn/3âŒ‹ times. At most 2 such elements exist. Use Boyer-Moore voting with 2 candidates.',
    algorithm: [
      'Maintain two candidates and their counts.',
      'For each element: if it matches candidate1 or 2, increment their count. If a count is 0, replace. Else decrement both.',
      'Verify the two candidates by counting occurrences.',
    ],
    pitfalls: ['After voting, must verify â€” candidates might not actually exceed n/3 (voting finds the POTENTIAL candidates, not guaranteed majority).'],
  },

  // â”€â”€â”€ Max rectangle â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
  'max-rectangle': {
    intuition: 'Build histograms row by row and apply "largest rectangle in histogram" for each row.',
    algorithm: [
      'Maintain heights[] array. For each row: update heights (increment if cell=1, reset to 0 if cell=0).',
      'For each row\'s heights, compute largest rectangle using stack-based approach.',
    ],
    example: { input: '[[1,0,1,0,0],[1,0,1,1,1],[1,1,1,1,1],[1,0,0,1,0]]', steps: ['Row 0 heights=[1,0,1,0,0]â†’area=1. Row 1=[2,0,2,1,1]â†’area=3. Row 2=[3,1,3,2,2]â†’area=6.'], output: '6' },
    pitfalls: ['Use the histogram approach for each row. The largest rectangle in histogram uses a monotone stack.'],
  },

  // â”€â”€â”€ Maximum Product Subarray â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
  'maximum-product-subarray': {
    intuition: 'Track both maximum and minimum product ending at each position (negative Ã— negative = positive). Max at each step = max of: current element alone, max*current, min*current.',
    algorithm: [
      'maxProd = minProd = result = nums[0].',
      'For each num from index 1: tmp = maxProd. maxProd = max(num, maxProd*num, minProd*num). minProd = min(num, tmp*num, minProd*num).',
      'result = max(result, maxProd).',
    ],
    example: { input: '[2,3,-2,4]', steps: ['max=2,min=2. max=6,min=6. max=-2,min=-12. max=4,min=-48. Result=6.'], output: '6' },
    pitfalls: ['Must track minimum product because negative Ã— negative = positive. Save tmp before updating maxProd.'],
  },

  // â”€â”€â”€ Maximum path sum from any node â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
  'maximum-path-sum-from-any-node': {
    intuition: 'Path can go through any node, using both subtrees. DFS: at each node, best path = max(0, leftGain) + max(0, rightGain) + node.val. Track global max.',
    algorithm: [
      'DFS returns the maximum gain (single path down) from this node.',
      'At node: leftGain = max(0, dfs(left)). rightGain = max(0, dfs(right)).',
      'Candidate = leftGain + rightGain + val. Update global max.',
      'Return val + max(leftGain, rightGain) (can only choose one side for parent path).',
    ],
    pitfalls: ['Return val + max(left,right) to parent (can\'t split the path). Update global max with both sides locally.'],
  },

  // â”€â”€â”€ Maximum sum of Non-adjacent nodes â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
  'maximum-sum-of-non-adjacent-nodes': {
    intuition: 'Tree DP: for each node, two states â€” include node (can\'t include children) or exclude (take max of including/excluding each child).',
    algorithm: [
      'DFS returns (include, exclude) for each subtree.',
      'include = node.val + sum(exclude of each child).',
      'exclude = sum(max(include, exclude) for each child).',
      'For root: return max(include, exclude).',
    ],
    pitfalls: ['This is house-robber on a tree. Return a pair (take, skip) from each subtree.'],
  },

  // â”€â”€â”€ Median in a row-wise sorted Matrix â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
  'median-in-a-row-wise-sorted-matrix': {
    intuition: 'Binary search on value range [lo, hi]. For a given mid, count elements â‰¤ mid using binary search on each row. Median found when count == (m*n+1)/2.',
    algorithm: [
      'lo = matrix[0][0], hi = max last elements.',
      'Binary search: mid = (lo+hi)/2. Count = sum of upper_bound(mid) across all rows.',
      'If count < (m*n+1)/2: lo=mid+1. Else hi=mid.',
      'Return lo.',
    ],
    pitfalls: ['Integer median for odd total. Binary search on values, not indices. Count elements â‰¤ mid (not <).'],
  },

  // â”€â”€â”€ Median of two sorted arrays â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
  'median-of-two-sorted-arrays': {
    intuition: 'Binary search on the smaller array. Partition both arrays such that left half has (m+n)/2 elements and max(left) â‰¤ min(right).',
    algorithm: [
      'Ensure len(A) â‰¤ len(B). Binary search on A: lo=0, hi=len(A).',
      'partA=mid, partB=(m+n+1)/2 - partA.',
      'Check: maxLeftA â‰¤ minRightB and maxLeftB â‰¤ minRightA.',
      'If valid: median = max(maxLeft) for odd total, or (max(maxLeft)+min(minRight))/2 for even.',
    ],
    pitfalls: ['Use Â±infinity for boundary partitions (partA=0 or partA=len). Ensure binary search on shorter array.'],
  },

  // â”€â”€â”€ Merge Sort for Linked List â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
  'merge-sort-for-linked-list': {
    intuition: 'Split linked list in half (using slow/fast pointer), recursively sort each half, merge the two sorted halves.',
    algorithm: [
      'Find middle using slow/fast pointers.',
      'Split: mid.next = null.',
      'Recursively sort left and right halves.',
      'Merge two sorted lists.',
    ],
    pitfalls: ['For splitting, stop slow pointer one before middle (so splitting is correct). No random access, so must find middle each time.'],
  },

  // â”€â”€â”€ Merge two sorted linked lists â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
  'merge-two-sorted-linked-lists': {
    intuition: 'Use a dummy head. Compare heads of both lists, append smaller, advance that list\'s pointer.',
    algorithm: [
      'Create dummy node. curr = dummy.',
      'While both lists non-null: compare heads, append smaller to curr.next, advance pointer.',
      'Append remaining non-null list.',
      'Return dummy.next.',
    ],
    pitfalls: ['Don\'t forget to attach the remaining list after one list is exhausted.'],
  },

  // â”€â”€â”€ Middle of a Linked List â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
  'middle-of-a-linked-list': {
    intuition: 'Floyd\'s slow/fast pointer: slow advances one step, fast advances two. When fast reaches end, slow is at middle.',
    algorithm: [
      'slow = fast = head.',
      'While fast != null and fast.next != null: slow = slow.next; fast = fast.next.next.',
      'Return slow.',
    ],
    pitfalls: ['For even length lists, this returns the second middle. Adjust termination condition if first middle is needed.'],
  },

  'maximum-sum-rectangle': {
    intuition: 'Extend Kadane algorithm to 2D. Fix left and right column boundaries, compress rows into 1D array using prefix sums, then apply Kadane on the 1D array.',
    algorithm: [
      'Fix left col l from 0 to n-1.',
      'For each l, scan right col r from l to n-1: accumulate column sums into 1D temp array.',
      'Apply Kadane on temp to find max subarray sum.',
    ],
    example: { input: '4x5 matrix', steps: ['Fix l=1,r=3. Column sums form 1D array. Kadane finds max subarray.'], output: 'Max sum rectangle' },
    pitfalls: ['Time O(n^2 * m). Track row boundaries by storing start/end in Kadane.'],
  },

  'minimum-spanning-tree': {
    intuition: 'Find MST using Kruskal (sort edges, union-find) or Prim (greedy, min-heap). Minimum total edge weight connecting all vertices.',
    algorithm: [
      "Kruskal: sort edges by weight. For each edge: if endpoints in different components (Union-Find), add to MST.",
      "Prim: start from any node. Use min-heap to always extend with cheapest edge to unvisited node.",
    ],
    pitfalls: ['Kruskal needs sorted edges + union-find. Prim is better for dense graphs.'],
  },

  'number-of-distinct-islands': {
    intuition: 'BFS/DFS each island, normalize its shape by recording relative path from starting cell. Use a set of shapes to count distinct islands.',
    algorithm: [
      'DFS from each unvisited 1. Record path directions (UDLR) including backtracking steps.',
      'Normalize: subtract starting cell coordinates from all cell coordinates.',
      'Add normalized shape to a set.',
    ],
    pitfalls: ['Record backtrack steps in path to distinguish shapes that have same cells but different traversal. Or use relative coordinates.'],
  },

  'power-set': {
    intuition: 'Generate all 2^n subsets. Iterate from 0 to 2^n-1; each bit pattern represents inclusion/exclusion of elements.',
    algorithm: [
      'For mask from 0 to 2^n-1: build subset from bits set in mask.',
      'Or recursive: for each element, include or exclude in subset.',
    ],
    pitfalls: ['Result size is 2^n. Iterative bitmask approach is clean for small n.'],
  },

  'preorder-traversal': {
    intuition: 'Visit root, then left subtree, then right subtree. Iterative: use stack, push right child before left.',
    algorithm: [
      'Recursive: visit node, recurse left, recurse right.',
      'Iterative: stack. Push root. While stack non-empty: pop, visit, push right, push left.',
    ],
    pitfalls: ['Push right before left in stack so left is processed first.'],
  },

  'remove-loop-in-linked-list': {
    intuition: 'Detect loop with Floyd cycle detection. Find loop start, then carefully remove the link without losing the rest of the list.',
    algorithm: [
      'Floyd: slow and fast pointers. If they meet, loop exists.',
      'Find loop start: reset one pointer to head, advance both one step at a time until they meet.',
      'Remove: traverse loop from start to find the node just before start. Set its next to null.',
    ],
    pitfalls: ['When resetting to find loop start, both pointers move at same speed. The node just before start is found by traversing the loop.'],
  },

  'reverse-a-doubly-linked-list': {
    intuition: 'Swap prev and next pointers for every node. The old tail becomes the new head.',
    algorithm: [
      'Traverse: for each node, swap node.prev and node.next.',
      'Return the last node visited as new head.',
    ],
    pitfalls: ['Swap pointers, do not reassign values. The last processed node (old tail) is the new head.'],
  },

  'spiral-traversal-of-matrix': {
    intuition: 'Layer-by-layer traversal. Use four boundaries (top, bottom, left, right) and shrink them as layers are processed.',
    algorithm: [
      'top=0, bottom=m-1, left=0, right=n-1.',
      'While top<=bottom && left<=right: traverse top row, right col, bottom row, left col. Shrink boundaries.',
    ],
    pitfalls: ['Check boundaries before traversing bottom row and left column to avoid duplicates on single row/column cases.'],
  },

  'stock-buy-and-sell': {
    intuition: 'Multiple transactions allowed. Buy and sell greedily: capture every upward price movement.',
    algorithm: [
      'Scan prices: if prices[i] > prices[i-1], add the difference to profit.',
    ],
    pitfalls: ['This greedy equals sum of all positive consecutive differences. No cooldown or transaction limit.'],
  },

  'tree-boundary-traversal': {
    intuition: 'Three parts: left boundary (excluding leaves), all leaves (left to right), right boundary (excluding leaves, bottom to top).',
    algorithm: [
      'Left boundary: traverse left spine, add non-leaf nodes.',
      'Leaves: DFS in-order, add leaf nodes.',
      'Right boundary: traverse right spine, add non-leaf nodes in reverse.',
    ],
    pitfalls: ['Avoid double-counting root (if leaf) or leaf nodes in boundary traversal. Reverse right boundary before adding.'],
  },

  'vertical-order-traversal': {
    intuition: 'BFS/DFS with (column, row) coordinates. Group nodes by column. Within same column, sort by row then value.',
    algorithm: [
      'DFS or BFS, track (node, row, col).',
      'Map from col -> sorted list of (row, val).',
      'Output columns in sorted col order.',
    ],
    pitfalls: ['Multiple nodes at same (row,col) must be sorted by value. Sort within column by row then value.'],
  },

  'word-search': {
    intuition: 'DFS/backtracking from each cell. Mark cells visited to avoid reuse. Unmark on backtrack.',
    algorithm: [
      'For each cell (i,j): DFS with index into word.',
      'At each step: check bounds, match, not visited. Mark visited. Recurse in 4 directions. Unmark.',
    ],
    pitfalls: ['Mark cell as visited during recursion, unmark after. Check character match before recursing.'],
  },

  'zero-sum-subarrays': {
    intuition: 'Use prefix sums. If prefix[i] == prefix[j], subarray i+1..j has sum 0. Count pairs with same prefix sum.',
    algorithm: [
      'Compute prefix sums.',
      'Map from sum -> count of occurrences. Count += freq[prefix[i]] before incrementing.',
      'Include 0 in map initially (empty prefix).',
    ],
    pitfalls: ['Include prefix sum 0 in initial map to count subarrays starting from index 0.'],
  },

  'form-the-largest-number': {
    intuition: 'Custom sort: compare pairs of numbers by which concatenation is larger (ab vs ba as strings).',
    algorithm: [
      'Convert numbers to strings.',
      'Sort with comparator: a+b vs b+a (string concatenation comparison).',
      'Concatenate. Edge case: if result starts with 0, return "0".',
    ],
    pitfalls: ['Edge case: all zeros -> return "0". Comparator must compare concatenation strings, not individual values.'],
  },

  'generate-binary-numbers': {
    intuition: 'BFS: start with "1". For each number, append "0" and "1" to get next numbers. Queue-based generation.',
    algorithm: [
      'Queue with "1".',
      'For i from 1 to n: dequeue s, add to result, enqueue s+"0" and s+"1".',
    ],
    pitfalls: ['This generates binary representations in order 1,10,11,100,101,...'],
  },

  'smallest-distinct-window': {
    intuition: 'Find smallest window containing all distinct characters of the string. Sliding window.',
    algorithm: [
      'Count distinct chars total. Sliding window maintaining frequency map.',
      'Expand right until all distinct chars covered. Shrink left while maintaining coverage. Track minimum window.',
    ],
    pitfalls: ['Window must contain all distinct characters of the original string, not just some.'],
  },

  'interleaved-strings': {
    intuition: 'DP: dp[i][j] = true if s1[0..i-1] and s2[0..j-1] can interleave to form s3[0..i+j-1].',
    algorithm: [
      'dp[0][0]=true.',
      'dp[i][j] = (dp[i-1][j] && s1[i-1]==s3[i+j-1]) || (dp[i][j-1] && s2[j-1]==s3[i+j-1]).',
    ],
    pitfalls: ['Length check: |s1|+|s2| must equal |s3|. 2D DP, not greedy.'],
  },

  'insert-interval': {
    intuition: 'Insert new interval and merge overlapping. Process existing intervals: add non-overlapping, merge overlapping with new interval.',
    algorithm: [
      'Add all intervals that end before newInterval starts.',
      'Merge all overlapping: newInterval = [min(starts), max(ends)].',
      'Add remaining intervals.',
    ],
    pitfalls: ['Overlapping condition: interval.start <= newInterval.end. Merge updates newInterval boundaries.'],
  },

  'fixing-two-nodes-of-a-bst': {
    intuition: 'Find two swapped nodes in BST in-order traversal. In sorted in-order, swapped nodes appear as violations. First violation: first > second. Second violation: third > fourth (or same pair).',
    algorithm: [
      'In-order traversal, track previous node.',
      'First violation (prev > curr): first = prev, second = curr.',
      'Second violation (prev > curr): second = curr (update second only).',
      'Swap values of first and second.',
    ],
    pitfalls: ['If only one violation, nodes are adjacent in in-order. If two violations, first was from first violation, second from second.'],
  },

  'k-sum-paths': {
    intuition: 'Count paths from any node to any descendant with sum k. Use prefix sum map (similar to subarray sum = k).',
    algorithm: [
      'DFS with current prefix sum and a map of prefix sum counts.',
      'At each node: check if (currentSum - k) is in map. Add currentSum to map. Recurse. Remove from map.',
    ],
    pitfalls: ['Paths go downward only (parent to child). Remove from map on backtrack to avoid counting across branches.'],
  },

  'largest-square-formed-in-a-matrix': {
    intuition: 'DP: dp[i][j] = side length of largest square with bottom-right corner at (i,j). Recurrence: min(left, top, top-left)+1 if cell is 1.',
    algorithm: [
      'dp[i][j] = 0 if mat[i][j]==0.',
      'dp[i][j] = min(dp[i-1][j], dp[i][j-1], dp[i-1][j-1]) + 1 if mat[i][j]==1.',
      'Answer = max(dp[i][j]).',
    ],
    pitfalls: ['Same as Maximal Square (LC 221). Answer is max side length, not area.'],
  },

  'merge-without-extra-space': {
    intuition: 'Merge two sorted arrays without extra space. Use gap method: compare elements gap apart, swap if out of order. Reduce gap each iteration.',
    algorithm: [
      'gap = ceil((m+n)/2).',
      'While gap > 0: compare pairs (i, i+gap) across both arrays, swap if out of order. gap = ceil(gap/2). Stop when gap=0.',
    ],
    pitfalls: ['Gap halves each iteration (Shell sort inspired). Handle indices carefully when gap crosses array boundary.'],
  },

  'maximum-sum-combination': {
    intuition: 'Find top k maximum sums where each sum uses one element from each of two arrays. Use a max-heap with already-seen pair tracking.',
    algorithm: [
      'Sort both arrays descending.',
      'Max-heap starting with (A[0]+B[0], 0, 0).',
      'Pop max, add to result, push (i+1,j) and (i,j+1) if not seen.',
    ],
    pitfalls: ['Use a visited set to avoid duplicate pairs. K iterations yields top K sums.'],
  },

  'search-in-a-rotated-sorted-array': {
    intuition: 'Binary search on rotated array. At each step, one half is always sorted. Determine which half and whether target is in it.',
    algorithm: [
      'lo=0, hi=n-1.',
      'If A[mid]==target: return mid.',
      'If left half sorted (A[lo]<=A[mid]): if target in [A[lo],A[mid]], hi=mid-1 else lo=mid+1.',
      'Else right half sorted: if target in [A[mid],A[hi]], lo=mid+1 else hi=mid-1.',
    ],
    pitfalls: ['Handle equal elements edge case (duplicates variant needs different approach). Always determine which half is sorted first.'],
  },

  'duplicate-subtrees': {
    intuition: 'Serialize each subtree to a string. Use a frequency map; when a serialization is seen twice, add the root to result.',
    algorithm: [
      'Post-order DFS: serialize = left_serial + "," + right_serial + "," + root.val.',
      'Map of serialization -> count. If count becomes 2: add root to result.',
    ],
    pitfalls: ['Add to result only when count == 2 (not 3,4,...) to avoid duplicates in output.'],
  },

  'is-binary-tree-heap': {
    intuition: 'Check two properties: complete binary tree (all levels full except last, last filled left to right) and max-heap property (parent >= children).',
    algorithm: [
      'BFS level order. Once a non-full node is seen, all subsequent nodes must be leaves (completeness check).',
      'For each node: check node.val >= children values (max-heap property).',
    ],
    pitfalls: ['Both conditions must hold simultaneously. Completeness check: after first missing child, no more children should appear.'],
  },

  'postorder-traversal': {
    intuition: 'Visit left, right, then root. Iterative: two-stack method or reverse pre-order trick.',
    algorithm: [
      'Iterative two-stack: stack1 starts with root. Pop to stack2, push left then right child to stack1. Drain stack2.',
      'Or: modified pre-order (root, right, left), reverse result.',
    ],
    pitfalls: ['Two-stack method is intuitive. Reverse-preorder trick is clever but less obvious.'],
  },

  'number-of-ways-to-arrive-at-destination': {
    intuition: 'Dijkstra with count tracking. Along with shortest distance, track number of ways to reach each node with that distance.',
    algorithm: [
      'Dijkstra: dist[], ways[] arrays. ways[0]=1, dist[0]=0.',
      'When relaxing edge: if new dist < dist[v]: update dist[v], ways[v]=ways[u].',
      'If new dist == dist[v]: ways[v] += ways[u].',
      'Return ways[n-1] % MOD.',
    ],
    pitfalls: ['Count updates only when relaxation succeeds or equals current best. MOD required since count can be large.'],
  },

  'find-kth-rotation': {
    intuition: 'In a sorted rotated array, the minimum element is at index k (rotation count). Binary search for minimum element position.',
    algorithm: [
      'Binary search for the pivot (minimum element).',
      'If A[mid] > A[hi]: pivot is in right half. lo=mid+1.',
      'Else pivot in left half. hi=mid.',
      'Return lo (index of minimum = rotation count).',
    ],
    pitfalls: ['For sorted rotated array [3,4,5,1,2], rotation count = index of minimum = 3.'],
  },

  'check-if-array-is-sorted-and-rotated': {
    intuition: 'A sorted rotated array has at most one "drop" (where arr[i] > arr[i+1]). Count drops; if <= 1 (including wrap-around), return true.',
    algorithm: [
      'Count positions where arr[i] > arr[(i+1)%n].',
      'If count <= 1: return true.',
    ],
    pitfalls: ['Check wrap-around: arr[n-1] > arr[0] is also a potential drop. Only one drop allowed.'],
  },

  'k-sized-subarray-maximum': {
    intuition: 'Sliding window maximum. Monotone deque maintains candidates for maximum in decreasing order.',
    algorithm: [
      'Deque of indices (decreasing values). For each element: remove indices out of window from front. Remove elements smaller than current from back. Add current index.',
      'Front of deque is max of current window.',
    ],
    pitfalls: ['Remove from front if index out of window range. Deque stores indices, not values.'],
  },

  'distance-of-nearest-cell-having-1': {
    intuition: 'Multi-source BFS from all cells with value 1 simultaneously. BFS naturally gives shortest distances.',
    algorithm: [
      'Add all cells with value 1 to queue with distance 0.',
      'BFS: expand to 4 neighbors, distance = parent distance + 1.',
    ],
    pitfalls: ['Multi-source BFS from all 1-cells simultaneously gives minimum distance to nearest 1 for each cell.'],
  },

  'smallest-positive-missing': {
    intuition: 'Rearrange: place each number i at index i-1 if 1<=i<=n. Then scan for first index where arr[i]!=i+1.',
    algorithm: [
      'Cyclic sort: while arr[i] != i+1 and arr[i] in [1,n] and arr[i] != arr[arr[i]-1]: swap arr[i] with arr[arr[i]-1].',
      'Scan: first i where arr[i] != i+1, return i+1. If all placed: return n+1.',
    ],
    pitfalls: ['Ignore duplicates during cyclic sort (check arr[i]!=arr[arr[i]-1] before swap). Answer in range [1,n+1].'],
  },

  'longest-subarray-with-sum-k': {
    intuition: 'Find longest subarray with sum exactly k. Use prefix sum hash map: if prefix[i]-k seen before, subarray from that index+1 to i has sum k.',
    algorithm: [
      'Map: prefix_sum -> first index. Initialize {0: -1}.',
      'For each i: if (prefix[i]-k) in map: candidate length = i - map[prefix[i]-k]. Update max.',
      'If prefix[i] not in map: map[prefix[i]] = i.',
    ],
    pitfalls: ['Store first occurrence of each prefix sum (don\'t overwrite). Works for both positive and negative integers.'],
  },

  'next-greater-element-in-circular-array': {
    intuition: 'Extend the array conceptually by doubling it. Use monotone stack. For circular array, simulate double traversal.',
    algorithm: [
      'Traverse array twice (0 to 2n-1) using index % n.',
      'Monotone stack. For i in second pass: pop stack elements smaller than current, assign result.',
      'First pass builds stack; second pass resolves remaining.',
    ],
    pitfalls: ['Only assign result on first n elements. Traverse 2n times to handle circular wrap.'],
  },

  'stock-buy-and-sell-max-one-transaction-allowed': {
    intuition: 'Track minimum price seen so far. At each day, profit = price - min_so_far. Track maximum profit.',
    algorithm: [
      'min_price = prices[0], max_profit = 0.',
      'For each price: max_profit = max(max_profit, price - min_price). min_price = min(min_price, price).',
    ],
    pitfalls: ['Must buy before selling. Update min_price at the end (or in same step since profit uses current price).'],
  },

  'stock-buy-and-sell-max-2-transactions-allowed': {
    intuition: 'DP with states. Track best profit with at most 2 transactions. Two passes: forward for best single transaction up to day i, backward for best single transaction from day i.',
    algorithm: [
      'Forward pass: best1[i] = max profit from single transaction in prices[0..i].',
      'Backward pass: best2[i] = max profit from single transaction in prices[i..n-1].',
      'Answer = max(best1[i] + best2[i+1]) for all i.',
    ],
    pitfalls: ['Two transactions can share a day boundary. DP states: buy1, sell1, buy2, sell2.'],
  },

  'stock-buy-and-sell-with-cooldown': {
    intuition: 'DP: after selling, must wait one day. States: held (own stock), sold (just sold today), rest (cooldown passed).',
    algorithm: [
      'held = -infinity, sold = 0, rest = 0.',
      'For each price: new_held = max(held, rest - price). new_sold = held + price. new_rest = max(rest, sold).',
      'Return max(sold, rest) at end.',
    ],
    pitfalls: ['After selling (sold state), next day must be rest (cannot buy). After rest, can buy or rest.'],
  },

  'stock-span-problem': {
    intuition: 'Span = number of consecutive days <= current price ending at today. Use monotone stack of (price, span) pairs.',
    algorithm: [
      'Stack of (price, span). For each price p: span = 1. While stack not empty and stack.top.price <= p: span += stack.top.span. Pop.',
      'Push (p, span). Record span.',
    ],
    pitfalls: ['Store span in stack entry to avoid recomputing. Each element is processed at most twice.'],
  },

  'optimal-strategy-for-a-game': {
    intuition: 'DP: both players play optimally. dp[i][j] = max coins first player can collect from coins[i..j].',
    algorithm: [
      'dp[i][j]: if player takes coins[i], opponent plays optimally on [i+1,j]: dp[i+1][j] gives opponent max, player gets sum[i..j]-dp[i+1][j].',
      'If player takes coins[j]: similarly dp[i][j-1].',
      'dp[i][j] = max(coins[i] + sum[i+1][j] - dp[i+1][j], coins[j] + sum[i][j-1] - dp[i][j-1]).',
    ],
    pitfalls: ['dp[i][j] = what first player gets. Use range sum to compute what remains. Both pick optimally.'],
  },

  'wildcard-pattern-matching': {
    intuition: 'DP: dp[i][j] = true if pattern[0..i-1] matches string[0..j-1]. Handle * (matches any sequence) and ? (matches single char).',
    algorithm: [
      'dp[0][0] = true. dp[i][0] = dp[i-1][0] && pattern[i-1]==\'*\'.',
      'If pattern[i-1] is \'?\' or equal: dp[i][j] = dp[i-1][j-1].',
      'If pattern[i-1] is \'*\': dp[i][j] = dp[i-1][j] (match 0 chars) || dp[i][j-1] (match more chars).',
    ],
    pitfalls: ['\'*\' can match empty string. dp[i-1][j] = * matches empty. dp[i][j-1] = * absorbs one more char.'],
  },

  'shortest-path-in-weighted-undirected-graph': {
    intuition: 'Dijkstra on weighted undirected graph. Standard shortest path from source to all vertices.',
    algorithm: [
      'Min-heap with (dist, node). dist[] = infinity. dist[src] = 0.',
      'Process: pop min, relax all neighbors. Update dist if shorter path found.',
    ],
    pitfalls: ['Mark visited or check if dist[u] > current dist when popping to avoid redundant processing.'],
  },

  'safe-states': {
    intuition: 'A node is safe if all paths from it eventually lead to a terminal node (no cycle reachable). Use reverse graph + topological sort or DFS coloring.',
    algorithm: [
      'DFS with colors: white(0), gray(in-progress), black(safe).',
      'If node is gray when revisited: cycle ? not safe. If black: safe.',
      'Color each node after DFS as black (safe) if no cycle found.',
    ],
    pitfalls: ['A node is safe if it\'s not on a cycle and doesn\'t lead to a cycle. Coloring: gray=visiting, black=confirmed safe.'],
  },

  'longest-substring-with-distinct-characters': {
    intuition: 'Sliding window with at most k distinct characters (or all distinct). HashSet tracks current window characters.',
    algorithm: [
      'Window [l,r] with set of characters.',
      'Expand r. If duplicate: shrink l until unique.',
      'Track max window size.',
    ],
    pitfalls: ['Set vs frequency map: set suffices if all distinct; map needed for generic k distinct.'],
  },

  'koko-eating-bananas': {
    intuition: 'Binary search on eating speed k. At speed k, hours needed = sum(ceil(pile/k)). Find minimum k where hours <= H.',
    algorithm: [
      'lo=1, hi=max(piles).',
      'Feasibility(k): sum(ceil(pile/k)) <= H.',
      'Return minimum feasible k.',
    ],
    pitfalls: ['ceil(pile/k) = (pile+k-1)/k in integer arithmetic. Binary search on speed, not on hours.'],
  },

  'path-with-minimum-effort': {
    intuition: 'Binary search on maximum effort. Or Dijkstra where edge weight = abs(height difference) and we minimize the maximum edge on the path.',
    algorithm: [
      'Dijkstra with effort[i][j] = min effort to reach (i,j). effort = max(current_effort, abs(height diff)).',
      'Min-heap by effort. Return effort[m-1][n-1].',
    ],
    pitfalls: ['Minimize the maximum difference, not sum of differences. Use modified Dijkstra with max as combination operator.'],
  },

  'split-array-largest-sum': {
    intuition: 'Binary search on the largest sum. Check if we can split array into at most k subarrays where each sum <= mid.',
    algorithm: [
      'lo=max(nums), hi=sum(nums).',
      'Feasibility(mid): greedily fill subarrays, count splits. If splits <= k, feasible.',
      'Return minimum feasible mid.',
    ],
    pitfalls: ['Greedy: keep adding to current subarray until exceeds mid, then start new subarray. Count total subarrays needed.'],
  },

  'minimum-cost-of-ropes': {
    intuition: 'Greedy: always merge two smallest ropes. Use a min-heap. Total cost = sum of all intermediate merge costs.',
    algorithm: [
      'Add all lengths to min-heap.',
      'While heap size > 1: pop two smallest, merge cost = sum, push back. Add cost to total.',
    ],
    pitfalls: ['Same as Huffman encoding / minimum cost to combine. Greedy with min-heap gives optimal solution.'],
  },

  'target-sum': {
    intuition: 'Assign + or - to each number to reach target. DP on subset sums. Let P = set with +, total - P = negative set. Then 2P - total = target ? P = (target+total)/2.',
    algorithm: [
      'If (target+total) is odd or |target| > total: return 0.',
      'Count subsets with sum = (target+total)/2.',
    ],
    pitfalls: ['Transform to subset count problem. (target+total) must be even. Handle negative target by taking absolute value check.'],
  },

  'the-celebrity-problem': {
    intuition: 'A celebrity knows nobody but everyone knows them. Find such a person in O(n). Eliminate non-celebrities using two-pointer.',
    algorithm: [
      'Start with candidate=0. For each i from 1 to n-1: if knows(candidate, i), candidate=i.',
      'Verify: candidate knows no one (except self) and everyone knows candidate.',
    ],
    pitfalls: ['One pass to find candidate, one pass to verify. Candidate can only be the person who was never "known by no one".'],
  },

  'travelling-salesman-problem': {
    intuition: 'TSP: find minimum cost Hamiltonian cycle. DP with bitmask states: dp[mask][i] = min cost to visit exactly the nodes in mask, ending at node i.',
    algorithm: [
      'dp[1][0] = 0 (starting at node 0, visited only node 0).',
      'For each mask, for each node i in mask: for each j not in mask: dp[mask|(1<<j)][j] = min(dp[mask][j], dp[mask][i] + dist[i][j]).',
      'Answer = min(dp[(1<<n)-1][i] + dist[i][0]) for all i.',
    ],
    pitfalls: ['Time O(2^n * n^2). Feasible only for n <= 20. Final step: return to start node.'],
  },

  'unique-paths-in-a-grid': {
    intuition: 'Count paths from top-left to bottom-right in a grid with obstacles. DP: dp[i][j] = paths to reach (i,j).',
    algorithm: [
      'dp[0][0]=1 if not obstacle. dp[i][j] = dp[i-1][j] + dp[i][j-1] if not obstacle, else 0.',
    ],
    pitfalls: ['If start or end is obstacle: return 0. Check cell is open before adding paths.'],
  },

  'ways-to-reach-the-nth-stair': {
    intuition: 'Climb 1 or 2 stairs at a time. dp[n] = dp[n-1] + dp[n-2]. Fibonacci sequence with dp[1]=1, dp[2]=2.',
    algorithm: [
      'dp[0]=1, dp[1]=1. dp[i] = dp[i-1] + dp[i-2].',
    ],
    pitfalls: ['Base cases: 0 stairs = 1 way (empty), 1 stair = 1 way, 2 stairs = 2 ways. Can also generalize to k steps.'],
  },

  'print-anagrams-together': {
    intuition: 'Group strings that are anagrams of each other. Use sorted string as key.',
    algorithm: [
      'For each string: sort its characters to get key.',
      'Group by key using a map. Return groups.',
    ],
    pitfalls: ['Maintain insertion order for group stability. Sort each string O(L*logL) where L is max length.'],
  },

  'huffman-encoding': {
    intuition: 'Build optimal prefix-free code using a min-heap. Combine two least frequent symbols repeatedly.',
    algorithm: [
      'Min-heap of (frequency, node). While size > 1: pop two, create parent with sum frequency, push back.',
      'Assign codes by traversing tree: left=0, right=1.',
    ],
    pitfalls: ['Huffman tree can be non-unique if frequencies are equal. Output the codes for each character.'],
  },

  'construct-tree-from-inorder-preorder': {
    intuition: 'Preorder[0] is root. Find it in inorder to split left and right subtrees. Recurse.',
    algorithm: [
      'Root = preorder[0]. Index in inorder = k. Left subtree size = k.',
      'Recurse: left = (preorder[1..k], inorder[0..k-1]). Right = (preorder[k+1..], inorder[k+1..]).',
    ],
    pitfalls: ['Use a hash map for O(1) inorder lookups. Pass index ranges instead of slices.'],
  },

  'row-with-max-1s': {
    intuition: 'Find row with maximum 1s in a binary matrix where each row is sorted. Start from top-right corner, move left (1s) or down (0s).',
    algorithm: [
      'Start at (0, n-1). If cell is 1: move left (col--), update max row. If 0: move down (row++).',
    ],
    pitfalls: ['O(m+n) algorithm. Since rows are sorted, once you find a 1, all elements to the left are also 1.'],
  },

  'peak-element': {
    intuition: 'Binary search. A peak exists where arr[mid] > arr[mid-1] and arr[mid+1]. If arr[mid] < arr[mid+1]: peak is on right. Else: peak is on left or at mid.',
    algorithm: [
      'lo=0, hi=n-1.',
      'If arr[mid] < arr[mid+1]: lo=mid+1 (ascending, peak on right).',
      'Else: hi=mid (peak at mid or left).',
      'Return lo.',
    ],
    pitfalls: ['Assume arr[-1]=arr[n]=-infinity. A peak always exists. Binary search converges to a peak.'],
  },

  'count-subarrays-with-given-xor': {
    intuition: 'Prefix XOR. If prefix[r] XOR prefix[l-1] = k, then XOR of subarray [l,r] = k. Count pairs.',
    algorithm: [
      'Map from prefix_xor -> count. Initialize {0: 1}.',
      'For each element: prefix_xor ^= element. Count += map[prefix_xor ^ k]. Map[prefix_xor]++.',
    ],
    pitfalls: ['Initialize map with {0:1} for empty prefix. For each position, check if (current_xor ^ k) was seen before.'],
  },

  'longest-alternating-subsequence': {
    intuition: 'Greedy: count transitions between increases and decreases. Track last direction.',
    algorithm: [
      'If n==0: return 0. result=1, dir=0 (none yet).',
      'For each consecutive pair: if up and dir!=up: result++, dir=up. If down and dir!=down: result++, dir=down.',
    ],
    pitfalls: ['Just count direction changes. Equal elements don\'t contribute. DP also works: up[i] and down[i] arrays.'],
  },

  'permutations-of-a-string': {
    intuition: 'Backtracking: fix each character at the current position, recurse for remaining. Use swap-based or selection approach.',
    algorithm: [
      'For each index i from current to end: swap str[i] with str[current]. Recurse on current+1. Swap back.',
      'When current == end: add to result.',
    ],
    pitfalls: ['For distinct permutations: use a set to avoid duplicates, or sort and skip duplicates.'],
  },

  'weighted-job-scheduling': {
    intuition: 'DP on jobs sorted by end time. dp[i] = max profit using jobs from 1..i. Either take job i (binary search for last compatible job) or skip.',
    algorithm: [
      'Sort jobs by end time.',
      'dp[i] = max(dp[i-1], profit[i] + dp[last_compatible_job]).',
      'Binary search for last job ending <= start[i].',
    ],
    pitfalls: ['Job i is compatible with job j if end[j] <= start[i]. Binary search on sorted end times.'],
  },

  'find-all-triplets-with-zero-sum': {
    intuition: 'Sort array. For each element, use two pointers to find pairs summing to negation of that element.',
    algorithm: [
      'Sort. For each i from 0 to n-3: lo=i+1, hi=n-1.',
      'While lo<hi: if sum==0 record, lo++, hi--. Skip duplicates. If sum<0: lo++. If sum>0: hi--.',
    ],
    pitfalls: ['Skip duplicates to avoid repeated triplets. Same as 3Sum (LC 15).'],
  },

  'the-painters-partition-problemii': {
    intuition: 'Same as Capacity to Ship / Split Array Largest Sum. Binary search on maximum length any one painter paints.',
    algorithm: [
      'lo=max(boards), hi=sum(boards).',
      'Feasibility(mid): greedily assign boards, count painters needed <= k.',
      'Return minimum feasible mid.',
    ],
    pitfalls: ['Greedy: fill each painter as much as possible without exceeding mid. Count total painters needed.'],
  },

  'shortest-common-supersequence': {
    intuition: 'Build SCS from LCS DP table. LCS characters appear once; non-LCS characters from both strings each appear once.',
    algorithm: [
      'Build LCS DP table. Trace from (m,n) to (0,0).',
      'If s1[i]==s2[j]: take char, go diagonal. If from top: take s2[j]. If from left: take s1[i].',
      'Append remaining chars. Reverse.',
    ],
    pitfalls: ['Trace DP table carefully. Characters not in LCS must still appear in SCS.'],
  },

  'minimum-days-to-make-m-bouquets': {
    intuition: 'Binary search on number of days. At d days, count bouquets possible = sum of floor(consecutive_bloomed / k). Find minimum d.',
    algorithm: [
      'lo=min(bloomDay), hi=max(bloomDay).',
      'Feasibility(d): count bouquets. If >= m: feasible.',
    ],
    pitfalls: ['If n < m*k: impossible, return -1. Reset streak when flower not yet bloomed.'],
  },

  'nonoverlapping-intervals': {
    intuition: 'Minimum removals = n - max non-overlapping intervals. Greedy: sort by end time. Keep intervals with earliest end that don\'t overlap.',
    algorithm: [
      'Sort by end time. Track last end.',
      'If start >= last_end: keep it, update last_end.',
      'Else: remove it (count removal).',
    ],
    pitfalls: ['Sort by END time for greedy. This maximizes kept intervals, minimizing removals.'],
  },

  'number-of-distinct-subsequences': {
    intuition: 'DP: dp[i][j] = distinct subsequences of t[0..j-1] in s[0..i-1].',
    algorithm: [
      'dp[i][0] = 1 (empty subsequence). dp[0][j] = 0 for j>0.',
      'If s[i-1]==t[j-1]: dp[i][j] = dp[i-1][j-1] + dp[i-1][j].',
      'Else: dp[i][j] = dp[i-1][j].',
    ],
    pitfalls: ['Can match with current char or skip it. Optimize to O(n) space with 1D array.'],
  },

  'subarrays-with-sum-k': {
    intuition: 'Count subarrays with sum equal to k. Prefix sum + hashmap: count of prefix sums seen so far.',
    algorithm: [
      'Map {0:1}. running_sum=0, count=0.',
      'For each num: running_sum += num. count += map[running_sum-k]. map[running_sum]++.',
    ],
    pitfalls: ['Works for negative numbers too. Initialize map with {0:1} for subarrays starting at index 0.'],
  },

  'majority-vote': {
    intuition: 'Boyer-Moore Voting Algorithm. Find element appearing more than n/2 times.',
    algorithm: [
      'candidate=None, count=0.',
      'For each num: if count==0, candidate=num. if num==candidate, count++ else count--.',
      'Verify candidate (count passes are needed if majority not guaranteed).',
    ],
    pitfalls: ['Algorithm finds candidate for majority. If majority not guaranteed, verify in second pass.'],
  },

  'optimal-binary-search-tree': {
    intuition: 'Interval DP. dp[i][j] = minimum cost BST for keys i..j. Cost = sum of frequencies * depth.',
    algorithm: [
      'dp[i][j] = min over k in i..j: dp[i][k-1] + dp[k+1][j] + sum(freq[i..j]).',
      'Build for increasing interval lengths.',
    ],
    pitfalls: ['Key insight: adding a root k adds sum(freq[i..j]) to all nodes (depth increases by 1). Use precomputed prefix sums.'],
  },

  'count-derangements': {
    intuition: 'Derangement = permutation where no element appears in original position. D(n) = (n-1)*(D(n-1)+D(n-2)). DP.',
    algorithm: [
      'D(1)=0, D(2)=1.',
      'D(n) = (n-1) * (D(n-1) + D(n-2)).',
    ],
    pitfalls: ['Recurrence: place element i either in position of element j or element that was in j\'s position. Modular arithmetic needed for large n.'],
  },

  'anagram-palindrome': {
    intuition: 'A string can form a palindrome if at most one character has odd frequency.',
    algorithm: [
      'Count character frequencies.',
      'Count characters with odd frequency. If count <= 1: return true.',
    ],
    pitfalls: ['Even-length strings: all frequencies must be even. Odd-length: exactly one odd frequency allowed.'],
  },

  'flip-to-maximize-1s': {
    intuition: 'Find the longest subarray of 1s if you can flip one 0. Equivalent to longest subarray with at most one 0.',
    algorithm: [
      'Sliding window with at most one 0. Track last position of 0.',
      'When second 0 found: move left pointer past previous 0.',
    ],
    pitfalls: ['If no 0 exists: return n (all 1s already). Track previous 0 position for correct left pointer update.'],
  },

  'largest-number-in-k-swaps': {
    intuition: 'Greedy: find maximum digit in the remaining string, swap it to current position. Repeat for k swaps.',
    algorithm: [
      'For each position from left: find max digit in remaining str. If larger than current: swap, k--.',
      'If multiple max positions, swap rightmost to preserve future swaps.',
    ],
    pitfalls: ['Backtracking needed for optimal result. Greedy may not always be optimal without exhaustive search.'],
  },

  'sum-of-subarray-minimum': {
    intuition: 'For each element, find how many subarrays have it as minimum using monotone stack. Count subarrays where arr[i] is minimum = left_count * right_count.',
    algorithm: [
      'For each i: left[i] = distance to previous smaller (or equal) element. right[i] = distance to next smaller element.',
      'Contribution of arr[i] = arr[i] * left[i] * right[i].',
    ],
    pitfalls: ['Handle equal elements: use strictly less on one side to avoid double counting. Result mod 10^9+7.'],
  },

  'mobile-numeric-keypad': {
    intuition: 'Count N-digit sequences on phone keypad where consecutive digits are adjacent (including same). DP.',
    algorithm: [
      'adjacency: 0->[0,8], 1->[1,2,4], 2->[2,1,3,5], etc.',
      'dp[digit][len] = count of sequences of length len ending at digit.',
      'dp[d][l] = sum of dp[adj][l-1] for adj in adjacency[d].',
    ],
    pitfalls: ['0 is adjacent to 0 and 8. * and # are not used. Base: dp[d][1]=1 for all digits 0-9.'],
  },

  'painting-the-fence': {
    intuition: 'Count ways to paint n fences with k colors where no more than 2 consecutive fences have the same color.',
    algorithm: [
      'same[i] = ways where last two have same color.',
      'diff[i] = ways where last two have different color.',
      'same[i] = diff[i-1]. diff[i] = (same[i-1] + diff[i-1]) * (k-1).',
      'Answer = same[n] + diff[n].',
    ],
    pitfalls: ['No 3 consecutive same. After same, must differ. After diff, can either (but not 3rd same).'],
  },

  'stock-buy-and-sell-max-k-transactions-allowed': {
    intuition: 'DP: dp[i][j] = max profit with at most i transactions up to day j.',
    algorithm: [
      'dp[i][j] = max(dp[i][j-1], max over m < j of (dp[i-1][m] + prices[j] - prices[m])).',
      'Optimize: track max(dp[i-1][m] - prices[m]) as we scan j.',
    ],
    pitfalls: ['O(k*n) with optimization. If 2k >= n: unlimited transactions (same as problem II).'],
  },

  'count-all-triplets-with-given-sum-in-sorted-array': {
    intuition: 'Sort array. For each element, use two pointers on the rest. Count pairs summing to target-arr[i].',
    algorithm: [
      'For each i: lo=i+1, hi=n-1.',
      'If arr[lo]+arr[hi] < target-arr[i]: lo++. If > target: hi--. If ==: count pairs (handle duplicates).',
    ],
    pitfalls: ['When sum matches, count all valid (lo,hi) pairs with those values (use while loops to count duplicates).'],
  },

  'generate-all-binary-strings': {
    intuition: 'Backtracking: generate all 2^n binary strings recursively.',
    algorithm: [
      'DFS with current string. At each step: append 0 or 1, recurse to length n, backtrack.',
    ],
    pitfalls: ['Total 2^n strings. Use StringBuilder for efficiency.'],
  },

  'container-with-most-water': {
    intuition: 'Two pointers from both ends. Area = min(height[l], height[r]) * (r-l). Move the shorter side inward.',
    algorithm: [
      'l=0, r=n-1. max_area=0.',
      'While l<r: area = min(height[l],height[r])*(r-l). max_area = max. Move shorter side.',
    ],
    pitfalls: ['Moving shorter side can only increase area. Moving taller side can only decrease width without gain.'],
  },

  'longest-prefix-suffix': {
    intuition: 'Find length of longest proper prefix of s that is also a suffix. This is the last value in the KMP failure function.',
    algorithm: [
      'Compute KMP failure function (partial match table).',
      'Return lps[n-1] where lps is the prefix function array.',
    ],
    pitfalls: ['Must be proper prefix/suffix (not the whole string). KMP preprocessing gives this directly.'],
  },

  'search-pattern-kmpalgorithm': {
    intuition: 'KMP: precompute failure function for pattern. Use it to skip unnecessary comparisons in text.',
    algorithm: [
      'Compute lps[] (longest proper prefix-suffix) for pattern.',
      'Scan text with two pointers. On mismatch: use lps to skip back in pattern.',
    ],
    pitfalls: ['lps[i] = length of longest prefix of pattern[0..i] that is also a suffix. O(m+n) total.'],
  },

  'shortest-path-in-undirected-graph': {
    intuition: 'BFS on unweighted graph gives shortest path in terms of edge count.',
    algorithm: [
      'BFS from source. dist[] = -1 initially. dist[src]=0.',
      'BFS level by level. Return dist[].',
    ],
    pitfalls: ['BFS guarantees shortest path in unweighted graph. Returns -1 for unreachable nodes.'],
  },

  'minimum-window-subsequence': {
    intuition: 'Find smallest window in S that contains T as a subsequence. DP: dp[i][j] = start index of smallest window in S[0..i] containing T[0..j].',
    algorithm: [
      'Two-pointer: for each occurrence of T[0] in S, extend to find full T match, then shrink from start.',
      'Forward: find first index where S[i..] contains T. Backward: from that end, find last occurrence of T match.',
    ],
    pitfalls: ['Not substring but subsequence. Forward-backward two-pass approach is O(n*m).'],
  },

  'clone-an-undirected-graph': {
    intuition: 'BFS/DFS with a HashMap from original node to clone. For each original node, create clone and process its neighbors.',
    algorithm: [
      'Map: original -> clone. BFS queue.',
      'For each neighbor of original: if not in map, create clone and add to queue. Add clone to cloneNode.neighbors.',
    ],
    pitfalls: ['Use visited map to avoid infinite loops in cyclic graphs.'],
  },
  'nth-fibonacci-number': {
    intuition: 'Fibonacci: F(n) = F(n-1) + F(n-2). Use DP or matrix exponentiation for large n.',
    algorithm: [
      'Iterative: a=0, b=1. For i in 2..n: c=a+b, a=b, b=c. Return b.',
    ],
    pitfalls: ['Large n needs modular arithmetic. Matrix exponentiation gives O(log n).'],
  },

  'implementing-dijkstra-set-1-adjacency-matrix': {
    intuition: 'Dijkstra shortest path from source. Min-heap + relaxation.',
    algorithm: [
      'dist[] = Infinity. dist[src]=0. Min-heap. Relax edges greedily.',
    ],
    pitfalls: ['Works for non-negative weights. Use priority queue for O((V+E) log V).'],
  },

  'strongly-connected-components': {
    intuition: "Kosaraju's algorithm: two DFS passes. First on original graph, second on reversed graph in finish order.",
    algorithm: [
      'DFS on original, push finish order to stack.',
      'Transpose graph. DFS in reverse finish order. Each DFS = one SCC.',
    ],
    pitfalls: ['Or use Tarjan algorithm (one DFS, low-link values).'],
  },

  'check-for-balanced-tree': {
    intuition: 'Height-balanced: for every node, |height(left) - height(right)| <= 1. Post-order DFS returning -1 if unbalanced.',
    algorithm: [
      'DFS returns height. If |leftH - rightH| > 1: propagate -1 upward.',
    ],
    pitfalls: ['Bottom-up check avoids redundant computation. Return -1 as sentinel for unbalanced.'],
  },

  'shortest-source-to-destination-path': {
    intuition: 'BFS on grid from source. First time reaching destination = shortest path.',
    algorithm: [
      'BFS from (0,0). Return steps when reaching (n-1,m-1).',
    ],
    pitfalls: ['BFS guarantees shortest path in unweighted grid. Return -1 if unreachable.'],
  },

  'rat-in-a-maze-problem': {
    intuition: 'Find all paths from (0,0) to (n-1,n-1). Backtracking: try all 4 directions.',
    algorithm: [
      'DFS with visited array. At each cell: try D/L/R/U. Add path char. Backtrack if stuck.',
    ],
    pitfalls: ['Sort directions for lexicographically smallest paths. Mark visited to avoid cycles.'],
  },

  'word-boggle': {
    intuition: 'Find all dictionary words in grid using DFS from each cell. Trie for efficient prefix checking.',
    algorithm: [
      'Build Trie from dictionary. DFS from each cell: explore all 8 directions, check Trie prefix.',
      'When complete word found: add to result.',
    ],
    pitfalls: ['Mark visited cells during DFS, unmark on backtrack. Use Trie to prune dead-end prefixes.'],
  },

  'ways-to-tile-a-floor': {
    intuition: 'Count ways to tile 2xN floor with 1x2 tiles. Classic DP: dp[n] = dp[n-1] + dp[n-2] (Fibonacci-like).',
    algorithm: [
      'dp[0]=1, dp[1]=1. dp[n] = dp[n-1] + dp[n-2].',
    ],
    pitfalls: ['Tile horizontally (1 way for last 2 cols) or vertically (1 way for last col). Fibonacci recurrence.'],
  },

  'longest-k-unique-characters-substring': {
    intuition: 'Longest substring with exactly k unique characters. Sliding window with character frequency map.',
    algorithm: [
      'Window [l,r]. Frequency map. Expand r. If distinct > k: shrink l. If distinct == k: update max.',
    ],
    pitfalls: ['Exactly k distinct (not at most). Keep window with exactly k unique chars.'],
  },

  'sudoku-solver': {
    intuition: 'Fill empty cells (.) satisfying Sudoku constraints. Backtracking with row/col/box tracking.',
    algorithm: [
      'Find next empty cell. Try digits 1-9. If valid: place and recurse. Backtrack on failure.',
    ],
    pitfalls: ['Box index = (r/3)*3 + c/3. Check row, column, and 3x3 box for each digit.'],
  },

  'spirally-traversing-a-matrix': {
    intuition: 'Traverse matrix in spiral order: right, down, left, up, shrinking boundaries.',
    algorithm: [
      'top=0, bottom=m-1, left=0, right=n-1. Process each boundary layer inward.',
    ],
    pitfalls: ['Check boundaries after each direction to avoid double-counting single rows/columns.'],
  },

  'rotate-by-90-degree': {
    intuition: 'Rotate matrix 90 degrees clockwise: transpose then reverse each row.',
    algorithm: [
      'Transpose: swap matrix[i][j] and matrix[j][i]. Reverse each row.',
    ],
    pitfalls: ['For counter-clockwise: reverse each row then transpose. Or transpose and reverse each column.'],
  },

  'search-a-2d-matrix': {
    intuition: 'Search in matrix where rows and columns are sorted. Start at top-right corner: move left if too large, down if too small.',
    algorithm: [
      'Start at (0, n-1). While in bounds: if match: true. If too large: col--. If too small: row++.',
    ],
    pitfalls: ['O(m+n) staircase search. Start at top-right or bottom-left.'],
  },

  'minimum-cost-to-connect-all-points': {
    intuition: 'Minimum spanning tree on points using Manhattan distance. Prim or Kruskal.',
    algorithm: [
      'Prim: start from point 0. For each step: add closest unvisited point. Update distances.',
    ],
    pitfalls: ['Manhattan distance = |x1-x2| + |y1-y2|. Prim with array is O(n^2), acceptable for n<=1000.'],
  },

  'construct-binary-tree-from-parent-array': {
    intuition: 'Build binary tree from parent array where parent[i] = parent of node i (-1 for root).',
    algorithm: [
      'Create all nodes. For each i: if parent[i] == -1: root = i. Else: attach i as left or right child of parent[i].',
    ],
    pitfalls: ['Create nodes first, then link. Root has parent = -1.'],
  },

  'array-to-bst': {
    intuition: 'Convert sorted array to height-balanced BST. Recursively use middle element as root.',
    algorithm: [
      'mid = (lo + hi) / 2. root = arr[mid]. root.left = build(lo, mid-1). root.right = build(mid+1, hi).',
    ],
    pitfalls: ['Same as LC 108. Middle element as root ensures balance.'],
  },

  'count-pairs-whose-sum-is-less-than-target': {
    intuition: 'Count pairs with sum < target. Sort + two pointers.',
    algorithm: [
      'Sort. l=0, r=n-1. If nums[l]+nums[r] < target: count += r-l, l++. Else: r--.',
    ],
    pitfalls: ['When sum < target: all pairs with r fixed from l to r-1 also qualify. Count += r-l.'],
  },

  'boolean-matrix': {
    intuition: 'Set entire row and column to 1 if any 1 found. Two-pass with row/col markers.',
    algorithm: [
      'First pass: mark rows and cols that have 1. Second pass: set entire marked rows/cols to 1.',
    ],
    pitfalls: ['Use extra O(m+n) space for markers. Or use first row/col as markers (O(1) space).'],
  },

  'set-matrix-zeroes': {
    intuition: 'Set entire row and column to 0 if element is 0. Mark rows/cols first, then zero them.',
    algorithm: [
      'Find all (r,c) with 0. Collect rows and cols to zero. Zero them in second pass.',
    ],
    pitfalls: ['Do not zero while scanning (would create false zeros). Mark first, zero second.'],
  },

  'minimum-number-of-platforms-required-for-a-railway-station': {
    intuition: 'Maximum trains at station simultaneously. Sort arrivals and departures, two-pointer count overlapping intervals.',
    algorithm: [
      'Sort arrivals[], departures[]. Two pointers i (arrivals), j (departures).',
      'If arrivals[i] <= departures[j]: platform++, i++. Else: platform--, j++. Track max.',
    ],
    pitfalls: ['Classic interval scheduling. Minimum platforms = maximum overlap at any time.'],
  },

  'maximum-index': {
    intuition: 'Find max j-i where arr[j] >= arr[i]. Precompute left min array and right max array.',
    algorithm: [
      'leftMin[i] = min of arr[0..i]. rightMax[i] = max of arr[i..n-1].',
      'Two pointers on leftMin and rightMax. When leftMin[i] <= rightMax[j]: update ans, j++. Else i++.',
    ],
    pitfalls: ['Brute force O(n^2). Optimal: precompute + two pointers O(n).'],
  },

  'minimum-sum-partition': {
    intuition: 'Partition set into two subsets with minimum absolute difference. Subset sum DP.',
    algorithm: [
      'dp[i] = can we form sum i from the array. Find achievable sums closest to total/2.',
      'Answer = min(|total - 2*s|) for achievable s.',
    ],
    pitfalls: ['Standard subset sum DP. Target = total/2. Find closest achievable sum.'],
  },

  'leaders-in-an-array': {
    intuition: 'An element is a leader if it is greater than all elements to its right. Scan right to left.',
    algorithm: [
      'maxRight = arr[n-1]. Last element is always leader. Scan right to left: if arr[i] >= maxRight: leader, update maxRight.',
    ],
    pitfalls: ['Rightmost element is always a leader. Track running max from right.'],
  },

  'add-binary-strings': {
    intuition: 'Add two binary strings. Simulate binary addition with carry, right to left.',
    algorithm: [
      'Traverse both strings from right. Add digits + carry. Append result%2, carry = result/2.',
      'If lengths differ, continue with remaining digits. Append final carry if non-zero.',
    ],
    pitfalls: ['Use character arithmetic: digit = char - 48. Reverse result at end.'],
  },

  'ancestors-in-binary-tree': {
    intuition: 'Print all ancestors of a given node in binary tree. DFS that returns true when target found; nodes on return path are ancestors.',
    algorithm: [
      'Recursive DFS. If found in left or right subtree: print current node and return true.',
    ],
    pitfalls: ['Post-order DFS. Print node only after confirming target is in its subtree.'],
  },

  'array-duplicates': {
    intuition: 'Find all duplicates in an array of integers 1..n. Mark visited by negating at index nums[i]-1.',
    algorithm: [
      'For each num: idx = abs(num)-1. If nums[idx] < 0: it is a duplicate. Else: negate nums[idx].',
    ],
    pitfalls: ['Classic O(n) time O(1) space using sign-flip trick. Restore if needed after.'],
  },

  'articulation-point-ii': {
    intuition: 'Find all articulation points (cut vertices) in undirected graph. DFS with disc/low arrays.',
    algorithm: [
      'DFS tracking discovery time disc[] and low[] (earliest reachable ancestor).',
      'Node u is AP if: (1) root with 2+ children, or (2) non-root with child v where low[v] >= disc[u].',
    ],
    pitfalls: ['Root special case: it is AP iff it has 2+ DFS children. Track parent to avoid parent edge as back edge.'],
  },

  'bitonic-point': {
    intuition: 'Find the peak element in a bitonic (first increasing then decreasing) array. Binary search.',
    algorithm: [
      'Binary search: if arr[mid] > arr[mid+1]: peak in left half (inclusive). Else: in right half.',
    ],
    pitfalls: ['Guaranteed single peak. Binary search on the inflection point. Edge: first or last element.'],
  },

  'bst-with-dead-end': {
    intuition: 'Check if BST has a dead end: a leaf node where we cannot insert any new node. Track valid insertion range at each node.',
    algorithm: [
      'DFS passing [minVal, maxVal] range. At leaf: dead end if maxVal - minVal == 1.',
    ],
    pitfalls: ['Start range [1, INF] (positive integers only). Dead end when no integer fits between min and max.'],
  },

  'candy': {
    intuition: 'Distribute minimum candies so each child gets at least 1 and children with higher rating than neighbor get more. Two-pass greedy.',
    algorithm: [
      'Left pass: if ratings[i] > ratings[i-1]: candies[i] = candies[i-1]+1. Else: candies[i]=1.',
      'Right pass: if ratings[i] > ratings[i+1]: candies[i] = max(candies[i], candies[i+1]+1).',
    ],
    pitfalls: ['Same as LC 135. Two passes (left-to-right then right-to-left). Answer = sum of candies array.'],
  },

  'circle-of-strings': {
    intuition: 'Check if strings can be chained in a circle (each string starts with last char of previous). Eulerian circuit in directed graph.',
    algorithm: [
      'Build directed graph: edge from first char to last char of each string.',
      'Check: (1) all nodes with non-zero degree are connected (ignore zero-degree), (2) in-degree == out-degree for all nodes.',
    ],
    pitfalls: ['Eulerian circuit exists iff graph is connected (among used nodes) and all in-degrees equal out-degrees.'],
  },

  'count-set-bits': {
    intuition: 'Count total set bits from 1 to n. Use pattern: bits in range [0, 2^k-1] = k * 2^(k-1).',
    algorithm: [
      'Find highest bit k. Count contribution of each bit position separately.',
      'For bit i: count = (n/(2^(i+1))) * 2^i + max(0, n%(2^(i+1)) - 2^i + 1).',
    ],
    pitfalls: ['O(log n) solution. Or Brian Kernighan per number: O(n log n). Use mathematical approach for large n.'],
  },

  'count-the-number-of-possible-triangles': {
    intuition: 'Count triplets forming valid triangles. Sort + two pointers: for each largest side, count valid pairs.',
    algorithm: [
      'Sort array. For each k (largest side) from n-1 down to 2: two pointers i=0, j=k-1.',
      'If arr[i]+arr[j] > arr[k]: all pairs (i, i+1..j-1, k) valid, count += j-i, j--. Else i++.',
    ],
    pitfalls: ['Triangle inequality: sum of two smaller sides > largest. Sort first; largest side is arr[k].'],
  },

  'decode-the-string': {
    intuition: 'Decode run-length encoded string like "3[b2[ca]]". Stack-based decoding for nested encodings.',
    algorithm: [
      'Use two stacks: one for strings, one for numbers.',
      'On digit: build number. On "[": push current string and number. On "]": repeat top string by top number, append to previous.',
    ],
    pitfalls: ['Same as LC 394. Handle multi-digit numbers. Build current string char by char between brackets.'],
  },

  'frog-jump': {
    intuition: 'Frog jumps on stones; can jump k-1, k, or k+1 from current position. DP to check if last stone reachable.',
    algorithm: [
      'HashMap: stone -> set of valid jump sizes to reach it.',
      'For each jump k from current stone: if stone+k-1, stone+k, stone+k+1 exist: add to their sets.',
    ],
    pitfalls: ['Same as LC 403. Use HashMap<stone, Set<jump>>. Only works if first jump is exactly 1.'],
  },

  'generate-ip-addresses': {
    intuition: 'Generate all valid IPv4 addresses from a string of digits. Backtracking with 4 parts.',
    algorithm: [
      'Backtrack: place 3 dots. Each segment must be valid (0-255, no leading zeros except "0" itself).',
    ],
    pitfalls: ['Same as LC 93. Prune: segment > 255 or has leading zero. Exactly 4 segments, all digits used.'],
  },

  'get-min-from-stack': {
    intuition: 'Stack that supports getMin() in O(1). Maintain auxiliary min stack.',
    algorithm: [
      'Push: push to main stack; push min(val, minStack.top()) to minStack.',
      'Pop: pop both stacks. GetMin: return minStack.top().',
    ],
    pitfalls: ['Same as LC 155. Min stack always has current minimum at top. Both stacks stay in sync.'],
  },

  'k-closest-points-to-origin': {
    intuition: 'Find k closest points to origin by Euclidean distance. Max-heap of size k, or quickselect.',
    algorithm: [
      'Max-heap of size k on distance. For each point: if heap.size < k or dist < heap.top: add, pop if > k.',
      'Or quickselect: partial sort to find k smallest.',
    ],
    pitfalls: ['Compare dist^2 to avoid sqrt. Same as LC 973. O(n log k) with heap, O(n) with quickselect.'],
  },

  'k-largest-elements': {
    intuition: 'Find k largest elements in an array. Min-heap of size k.',
    algorithm: [
      'Maintain min-heap of size k. For each element: if > heap.top or heap.size < k: add, pop if > k.',
      'Result = heap contents.',
    ],
    pitfalls: ['Min-heap (not max-heap) for efficiency. O(n log k). Or sort descending, take first k.'],
  },

  'kth-smallest': {
    intuition: 'Find kth smallest element in unsorted array. Quickselect or min-heap.',
    algorithm: [
      'Quickselect: partition around pivot. If pivot index == k-1: return. Else recurse left or right.',
    ],
    pitfalls: ['Quickselect O(n) average, O(n^2) worst. For guaranteed O(n log k): use max-heap of size k.'],
  },

  'largest-divisible-subset': {
    intuition: 'Find largest subset where every pair (i,j) satisfies subset[i] % subset[j] == 0 or vice versa. Sort + LIS-style DP.',
    algorithm: [
      'Sort array. dp[i] = length of largest divisible subset ending at i.',
      'dp[i] = max(dp[j]+1) for all j < i where nums[i] % nums[j] == 0. Track parent pointers to reconstruct.',
    ],
    pitfalls: ['Same as LC 368. Sort first so divisibility is transitive downward. O(n^2) DP.'],
  },

  'largest-number-in-one-swap': {
    intuition: 'Make the largest number by performing at most one swap of two digits.',
    algorithm: [
      'From right to left: track the max digit seen so far and its position.',
      'From left to right: find first digit smaller than max digit to its right. Swap. Return result.',
    ],
    pitfalls: ['Same as LC 670. Scan right-to-left for max. Then left-to-right for first improvement opportunity.'],
  },

  'max-sum-increasing-subsequence': {
    intuition: 'Find maximum sum of increasing subsequence. LIS-style DP on sums.',
    algorithm: [
      'dp[i] = max sum of increasing subsequence ending at i.',
      'dp[i] = max(dp[j] + nums[i]) for all j < i where nums[j] < nums[i]. Base: dp[i] = nums[i].',
    ],
    pitfalls: ['Track sum, not length. O(n^2) DP. Answer = max(dp[]).'],
  },

  'missing-in-array': {
    intuition: 'Find missing number in array of 1..n. XOR approach: XOR all 1..n with all array elements.',
    algorithm: [
      'XOR all elements from 1 to n, then XOR all array elements. Result is the missing number.',
    ],
    pitfalls: ['Alternative: sum = n*(n+1)/2 - sum(array). XOR approach avoids overflow.'],
  },

  'non-repeating-character': {
    intuition: 'Find first non-repeating character in a string. Frequency array + second pass.',
    algorithm: [
      'Count frequency of each character. Scan string left to right: return first char with freq == 1.',
    ],
    pitfalls: ['Two passes: first count, then find. O(n) time. Return -1 if all repeat.'],
  },

  'number-of-occurrence': {
    intuition: 'Count occurrences of a target in sorted array. Binary search for leftmost and rightmost positions.',
    algorithm: [
      'Find first occurrence (lower_bound). Find last occurrence (upper_bound - 1).',
      'Count = last - first + 1 if first <= last.',
    ],
    pitfalls: ['Two binary searches. Same as LC 34. Check if target exists before computing count.'],
  },

  'palindrome-sentence': {
    intuition: 'Check if a sentence is a palindrome ignoring non-alphanumeric characters and case.',
    algorithm: [
      'Two pointers l=0, r=len-1. Skip non-alphanumeric. Compare lowercased. If mismatch: false.',
    ],
    pitfalls: ['Same as LC 125. Filter and compare. toLowerCase for case-insensitive check.'],
  },

  'pascal-triangle': {
    intuition: 'Generate Pascal triangle up to n rows. Each element = sum of two above.',
    algorithm: [
      'row[0] = row[end] = 1. For i in 1..end-1: row[i] = prevRow[i-1] + prevRow[i].',
    ],
    pitfalls: ['Same as LC 118. Build row by row. Each row has one more element than previous.'],
  },

  'predecessor-and-successor': {
    intuition: 'Find in-order predecessor and successor of a key in BST.',
    algorithm: [
      'BST search: if key < root: successor = root, recurse left. If key > root: predecessor = root, recurse right.',
      'If key == root: predecessor = rightmost of left subtree; successor = leftmost of right subtree.',
    ],
    pitfalls: ['Track predecessor and successor during BST traversal, not just at exact match.'],
  },

  'product-array-puzzle': {
    intuition: 'For each index i, product of all elements except nums[i]. No division, O(1) extra space.',
    algorithm: [
      'Left pass: result[i] = product of all elements left of i.',
      'Right pass: multiply result[i] by running product of all elements right of i.',
    ],
    pitfalls: ['Same as LC 238. Two passes. result[0]=1 (no elements left), result[n-1]=1 (no elements right).'],
  },

  'pythagorean-triplet': {
    intuition: 'Check if array contains a Pythagorean triplet (a^2 + b^2 = c^2). Square elements, sort, two-pointer.',
    algorithm: [
      'Square all elements and sort. For each c (largest), two pointers a=0, b=c-1.',
      'If a^2 + b^2 == c^2: true. If <: a++. If >: b--.',
    ],
    pitfalls: ['After squaring, problem reduces to: find triplet where largest = sum of other two. Standard two-pointer.'],
  },

  'queue-reversal': {
    intuition: 'Reverse a queue using a stack. Push all elements to stack, then pop back to queue.',
    algorithm: [
      'Dequeue all into stack. Then pop from stack back into queue.',
    ],
    pitfalls: ['Stack reverses order. Alternative: recursive approach using call stack.'],
  },

  'reverse-words': {
    intuition: 'Reverse the words in a sentence. Split by spaces, reverse word list, join.',
    algorithm: [
      'Split on whitespace. Reverse array of words. Join with single space.',
    ],
    pitfalls: ['Handle multiple spaces and leading/trailing spaces. Same as LC 151.'],
  },

  'root-to-leaf-paths': {
    intuition: 'Print all root-to-leaf paths in a binary tree. DFS tracking current path.',
    algorithm: [
      'DFS. Append current node to path. At leaf: print/store path. Backtrack by removing last node.',
    ],
    pitfalls: ['Use list to track path. Backtrack: remove last element after both recursive calls return.'],
  },

}

export default gfgExplanations
