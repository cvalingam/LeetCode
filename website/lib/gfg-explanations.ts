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

  // ─── 0-1 Knapsack Problem ────────────────────────────────────────────────────
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

  // ─── Activity Selection ──────────────────────────────────────────────────────
  'activity-selection': {
    intuition:
      'Greedy: among all activities compatible with the last selected one, always pick the one that finishes earliest. This leaves maximum room for future activities. Sort by end time first.',
    algorithm: [
      'Sort activities by end time.',
      'Select activity 0. lastEnd = end[0], count = 1.',
      'For i from 1 to n−1: if start[i] >= lastEnd: select it, count++, lastEnd = end[i].',
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
    pitfalls: ['Sort by END time, not start time — a greedy on start times is incorrect.'],
  },

  // ─── Aggressive Cows ─────────────────────────────────────────────────────────
  'aggressive-cows': {
    intuition:
      'Binary search on the minimum distance between any two cows. For a given minimum distance d, greedily check if k cows can be placed: place first cow at stall 0, then each next cow at the first stall at distance ≥ d from the previous.',
    algorithm: [
      'Sort stalls.',
      'Binary search lo=1, hi=stalls[n-1]−stalls[0].',
      'For each mid: check if k cows can be placed with min distance mid.',
      'Canplace(d): place first cow at stalls[0]. For each stall: if gap ≥ d, place cow here, count++. Return count >= k.',
      'If canplace(mid): lo=mid+1 (try larger). Else: hi=mid−1.',
      'Return lo−1.',
    ],
    example: {
      input: 'stalls=[1,2,4,8,9], k=3',
      steps: [
        'lo=1,hi=8. mid=4: place at 1,4? gap=3<4. mid=3: place at 1,4,8. 3 cows ✓ → lo=4.',
        'mid=6: can we? 1,8(gap=7≥6),next? No more. Only 2 → hi=5.',
        'mid=4: same → lo=5. lo>hi. Answer=4.',
      ],
      output: '3 (minimum distance = 3)',
    },
    pitfalls: ['Sort stalls first. Binary search on the ANSWER (distance), not the index.'],
  },

  // ─── Alien Dictionary ────────────────────────────────────────────────────────
  'alien-dictionary': {
    intuition:
      'Build a directed graph of character ordering by comparing adjacent words in the dictionary. Topological sort (Kahn\'s) on this graph gives the alien character order. If a cycle exists, no valid ordering exists.',
    algorithm: [
      'For each pair of adjacent words: find the first differing character. Add edge char1 → char2.',
      'Topological sort via BFS (Kahn\'s). Start with in-degree-0 characters.',
      'If all characters are processed, return order. If cycle detected, return "".',
    ],
    example: {
      input: 'words = ["wrt","wrf","er","ett","rftt"]',
      steps: [
        'wrt vs wrf: t→f. wrf vs er: w→e. er vs ett: r→t. ett vs rftt: e→r.',
        'Topo order: w,e,r,t,f.',
      ],
      output: '"wertf"',
    },
    pitfalls: [
      'Only compare the first differing character between adjacent words.',
      'If word1 is a prefix of word2 but comes after it, that\'s invalid — return "" immediately.',
    ],
  },

  // ─── Anagram ─────────────────────────────────────────────────────────────────
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
    pitfalls: ['Use a char frequency array, not sort — sort is O(n log n) vs O(n).'],
  },

  // ─── Bellman-Ford ────────────────────────────────────────────────────────────
  'bellman-ford': {
    intuition:
      'Relax all edges V−1 times. After V−1 iterations, shortest paths are found (a shortest path has at most V−1 edges). A V-th relaxation that still reduces any distance indicates a negative cycle.',
    algorithm: [
      'dist[src]=0, all others=INF.',
      'Repeat V−1 times: for each edge (u,v,w): if dist[u]+w < dist[v], dist[v]=dist[u]+w.',
      'Check negative cycle: if any edge (u,v,w) has dist[u]+w < dist[v], report negative cycle.',
    ],
    example: {
      input: 'V=5, edges: 0→1(2),0→2(4),1→2(1),1→3(7),2→4(3)',
      steps: [
        'Iter 1: dist=[0,2,3,9,6]. Iter 2–4: no further relaxations.',
      ],
      output: 'dist = [0,2,3,9,6]',
    },
    pitfalls: ['Bellman-Ford handles negative weights; Dijkstra does not. Use Bellman-Ford when negative weights are present.'],
  },

  // ─── BFS of Graph ────────────────────────────────────────────────────────────
  'bfs-of-graph': {
    intuition:
      'BFS explores nodes level by level using a queue. Start from source, enqueue all unvisited neighbors, mark them visited when enqueued (not when dequeued) to avoid duplicate processing.',
    algorithm: [
      'visited[src]=true. Enqueue src.',
      'While queue not empty: dequeue u. Add u to result.',
      'For each neighbor v of u: if not visited: visited[v]=true, enqueue v.',
    ],
    example: {
      input: 'Graph: 0→[1,2], 1→[3], 2→[3], 3→[]',
      steps: [
        'Queue:[0]. Dequeue 0 → result=[0]. Enqueue 1,2.',
        'Dequeue 1 → result=[0,1]. Enqueue 3. Dequeue 2 → result=[0,1,2]. Dequeue 3 → result=[0,1,2,3].',
      ],
      output: '[0,1,2,3]',
    },
    pitfalls: ['Mark visited when ENQUEUING, not when dequeuing — prevents the same node being enqueued multiple times.'],
  },

  // ─── Binary Tree to DLL ──────────────────────────────────────────────────────
  'binary-tree-to-dll': {
    intuition:
      'In-order traversal (left→root→right) of a BST gives sorted order. Convert by linking each node\'s left pointer to the previous node and right pointer to the next node during in-order traversal. Track the last processed node (prev).',
    algorithm: [
      'In-order traversal. Maintain prev node.',
      'For each node: node.left = prev. If prev != null: prev.right = node.',
      'Track head (first node). Update prev = node.',
      'Return head.',
    ],
    example: {
      input: 'BST: 10, left=12, right=15, 12\'s right=25, 15\'s left=36',
      steps: [
        'In-order: 12→25→10→36→15. Link each: 12←→25←→10←→36←→15.',
      ],
      output: 'DLL: 12↔25↔10↔36↔15',
    },
    pitfalls: ['Link prev→curr before updating prev = curr, otherwise you lose the predecessor.'],
  },

  // ─── Boolean Parenthesization ─────────────────────────────────────────────────
  'boolean-parenthesization': {
    intuition:
      'DP on sub-expressions: dp_true[i][j] = number of ways substring [i,j] evaluates to TRUE; dp_false[i][j] = FALSE. Split at each operator k. Combine left and right using truth-table rules for AND, OR, XOR.',
    algorithm: [
      'Base: dp_true[i][i] = (sym[i]=="T") ? 1 : 0. dp_false[i][i] = 1 − dp_true[i][i].',
      'For length l from 2 to n: for each (i,j): for each operator at k between i and j:',
      '  Compute lt,lf,rt,rf (left/right true/false counts).',
      '  AND: true += lt*rt. OR: true += lt*rt+lt*rf+lf*rt. XOR: true += lt*rf+lf*rt.',
      '  false = totalWays − true.',
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
    pitfalls: ['Total ways for a substring of length n = Catalan(n-1). Use it to compute false = total − true.'],
  },

  // ─── Bottom View of Binary Tree ──────────────────────────────────────────────
  'bottom-view-of-binary-tree': {
    intuition:
      'Level-order traversal with horizontal distance (HD): root=0, left child=HD−1, right child=HD+1. For each HD, the LAST node seen at that HD (deepest level) is the bottom view.',
    algorithm: [
      'BFS with (node, HD) pairs. HashMap: HD → last seen node value.',
      'Process each (node, hd): map[hd] = node.val (overwrite — last wins).',
      'Enqueue (left, hd−1) and (right, hd+1) if non-null.',
      'Return map values sorted by HD.',
    ],
    example: {
      input: 'Tree: 20(root), left=8[left=5,right=3], right=22[right=25], 3 has left=10,right=14',
      steps: ['HD: 5→-2, 8→-1, 10→0, 20→0, 3→0, 14→1, 22→1, 25→2. Bottom: 5,10,3,14,25.'],
      output: '[5,10,3,14,25]',
    },
    pitfalls: ['BFS ensures we process level by level — map[hd] is always overwritten by deeper nodes.'],
  },

  // ─── Check for BST ────────────────────────────────────────────────────────────
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
        'Node 2: range (−∞,+∞) ✓. Node 1: range (−∞,2) ✓. Node 3: range (2,+∞) ✓.',
      ],
      output: 'true',
    },
    pitfalls: ['Use long.MinValue/MaxValue (or null) as initial bounds — int bounds fail on equal-value edge cases.'],
  },

  // ─── Coin Change (Count Ways) ─────────────────────────────────────────────────
  'coin-change-count-ways': {
    intuition:
      'Unbounded knapsack: dp[i] = number of ways to make sum i using the given coins (each coin can be used any number of times). For each coin, iterate forward through the dp array.',
    algorithm: [
      'dp[0]=1, dp[1..sum]=0.',
      'For each coin c: for w from c to sum: dp[w] += dp[w−c].',
      'Return dp[sum].',
    ],
    example: {
      input: 'coins=[1,2,3], sum=4',
      steps: [
        'coin=1: dp=[1,1,1,1,1]. coin=2: dp[2]+=dp[0]=2, dp[3]+=dp[1]=2, dp[4]+=dp[2]=3. → dp=[1,1,2,2,3].',
        'coin=3: dp[3]+=dp[0]=3, dp[4]+=dp[1]=4. → dp[4]=4.',
      ],
      output: '4',
    },
    pitfalls: ['Outer loop over coins, inner loop over amounts — this counts combinations (not permutations). Swap loops for permutations.'],
  },

  // ─── Coin Change (Minimum Coins) ─────────────────────────────────────────────
  'coin-change-minimum-coins': {
    intuition:
      'dp[i] = minimum coins to make sum i. For each coin c and each amount w >= c: dp[w] = min(dp[w], dp[w-c]+1). Initialize dp[1..sum] = INF.',
    algorithm: [
      'dp[0]=0, dp[1..sum]=INF.',
      'For each coin c: for w from c to sum: if dp[w-c] != INF: dp[w]=min(dp[w], dp[w-c]+1).',
      'Return dp[sum] if not INF, else −1.',
    ],
    example: {
      input: 'coins=[1,5,6,9], sum=11',
      steps: [
        'dp[5]=1, dp[6]=1, dp[9]=1. dp[10]=2(5+5 or 4+6...). dp[11]=2 (5+6).',
      ],
      output: '2',
    },
    pitfalls: ['Return −1 if dp[sum] remains INF — the sum is unreachable.'],
  },

  // ─── Count Inversions ────────────────────────────────────────────────────────
  'count-inversions': {
    intuition:
      'An inversion is a pair (i, j) where i < j but arr[i] > arr[j]. Merge sort counts inversions during the merge step: when an element from the right half is placed before elements from the left half, each of those left-half elements forms an inversion with it.',
    algorithm: [
      'Merge sort recursively. Count inversions during merge.',
      'During merge: whenever right[j] < left[i], all elements left[i..mid] are inversions with right[j]. inv_count += (mid − i + 1).',
    ],
    example: {
      input: 'arr = [2,4,1,3,5]',
      steps: [
        'Merge [2,4] and [1,3]: 1<2 → 2 inversions. 3>2, 3>4: 0.',
        'Merge [2,4,1,3] and [5]: 0 inversions.',
        'Total = 3 (pairs: (2,1),(4,1),(4,3)).',
      ],
      output: '3',
    },
    pitfalls: ['Count inversions during merge (not during split) — only then do you know the relative positions.'],
  },

  // ─── DFS of Graph ────────────────────────────────────────────────────────────
  'dfs-of-graph': {
    intuition:
      'DFS explores as deep as possible along each branch before backtracking. Use a stack (or recursion): visit a node, mark it, then recursively visit all unvisited neighbors.',
    algorithm: [
      'visited[src]=true. DFS(src).',
      'DFS(u): add u to result. For each neighbor v: if not visited: visited[v]=true. DFS(v).',
    ],
    example: {
      input: 'Graph: 0→[1,2,3], 1→[4], 2→[], 3→[], 4→[]',
      steps: [
        'DFS(0): visit 0. Go to 1: visit 1. Go to 4: visit 4. Backtrack. Go to 2: visit 2. Go to 3: visit 3.',
        'Result: [0,1,4,2,3].',
      ],
      output: '[0,1,4,2,3]',
    },
    pitfalls: ['Mark as visited BEFORE recursing — not after — to prevent revisiting in undirected graphs.'],
  },

  // ─── Detect Loop in linked list ───────────────────────────────────────────────
  'detect-loop-in-linked-list': {
    intuition:
      'Floyd\'s cycle detection: slow pointer moves one step, fast moves two. If they meet, a cycle exists. If fast reaches null, no cycle.',
    algorithm: [
      'slow = fast = head.',
      'While fast != null and fast.next != null: slow = slow.next. fast = fast.next.next.',
      'If slow == fast: return true (cycle). Return false.',
    ],
    example: {
      input: '1→2→3→4→5→(back to 3)',
      steps: [
        'Step 1: slow=2, fast=3. Step 2: slow=3, fast=5. Step 3: slow=4, fast=4. Meet at 4. Cycle!',
      ],
      output: 'true',
    },
    pitfalls: ['Check fast != null AND fast.next != null before each step to avoid NullPointerException.'],
  },

  // ─── Dijkstra Algorithm ──────────────────────────────────────────────────────
  'dijkstra-algorithm': {
    intuition:
      'Greedy shortest path: always extend the unvisited node with the smallest current distance. Use a min-heap (priority queue) to efficiently get the next minimum. Only works with non-negative edge weights.',
    algorithm: [
      'dist[src]=0, all others=INF. Add (0,src) to min-heap.',
      'While heap not empty: extract (d,u). If d > dist[u], skip (stale entry).',
      'For each neighbor (v,w): if dist[u]+w < dist[v]: dist[v]=dist[u]+w. Push (dist[v],v).',
    ],
    example: {
      input: 'V=5, edges: 0→1(4),0→2(1),2→1(2),1→3(1),2→3(5)',
      steps: [
        'dist=[0,∞,∞,∞,∞]. Process 0: dist[1]=4, dist[2]=1.',
        'Process 2(d=1): dist[1]=min(4,3)=3, dist[3]=6.',
        'Process 1(d=3): dist[3]=min(6,4)=4.',
      ],
      output: 'dist=[0,3,1,4,∞]',
    },
    pitfalls: ['Skip stale heap entries by checking if extracted distance > dist[u].'],
  },

  // ─── Directed Graph Cycle ─────────────────────────────────────────────────────
  'directed-graph-cycle': {
    intuition:
      'A directed cycle exists iff DFS finds a back edge — an edge pointing to an ancestor in the current DFS stack. Use two states: "in-stack" (currently being explored) and "visited" (fully explored). A back edge leads to an "in-stack" node.',
    algorithm: [
      'visited[n]=false, inStack[n]=false.',
      'DFS(u): visited[u]=inStack[u]=true.',
      'For each neighbor v: if !visited: DFS(v). If cycle found, return true.',
      'Else if inStack[v]: return true (back edge → cycle).',
      'inStack[u]=false. Return false.',
    ],
    example: {
      input: 'Graph: 0→1→2→0 (cycle)',
      steps: [
        'DFS(0): mark. DFS(1): mark. DFS(2): neighbor 0 is inStack → cycle!',
      ],
      output: 'true',
    },
    pitfalls: ['For directed graphs, use inStack (recursion stack). For undirected graphs, just use visited + parent tracking.'],
  },

  // ─── Edit Distance ───────────────────────────────────────────────────────────
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

  // ─── Equilibrium Point ───────────────────────────────────────────────────────
  'equilibrium-point': {
    intuition:
      'An equilibrium point is where the sum of elements to the left equals the sum to the right. Compute total sum first. Then traverse left to right: subtract current element from right sum after checking equality.',
    algorithm: [
      'total = sum(arr). leftSum = 0.',
      'For each index i: total -= arr[i] (now total = rightSum).',
      'If leftSum == total: return i+1 (1-indexed).',
      'leftSum += arr[i].',
      'Return −1.',
    ],
    example: {
      input: 'arr = [-7,1,5,2,-4,3,0]',
      steps: [
        'total=0. leftSum=0. i=0: total=7≠leftSum. i=1: total=6≠-7. ... i=3: total=-1,leftSum=-1 ✓. Return 4.',
      ],
      output: '4',
    },
    pitfalls: ['Subtract the current element from rightSum BEFORE comparing (the current element belongs to neither side).'],
  },

  // ─── Floyd Warshall ───────────────────────────────────────────────────────────
  'floyd-warshall': {
    intuition:
      'All-pairs shortest paths using dynamic programming over intermediate nodes. dist[i][j] = shortest path from i to j. For each intermediate node k: if going through k is shorter, update. Three nested loops: k (intermediate), i (source), j (destination).',
    algorithm: [
      'Initialise dist from adjacency matrix. dist[i][i]=0.',
      'For k from 0 to V-1: for i,j: dist[i][j] = min(dist[i][j], dist[i][k]+dist[k][j]).',
      'Return dist matrix.',
    ],
    example: {
      input: 'V=4, edges: 0→1(5),0→3(10),1→2(3),2→3(1)',
      steps: [
        'k=0: no improvement. k=1: dist[0][2]=min(∞,5+3)=8. k=2: dist[0][3]=min(10,8+1)=9.',
      ],
      output: 'Shortest paths: 0→3=9',
    },
    pitfalls: ['k must be the OUTER loop — intermediate nodes are added one at a time.'],
  },

  // ─── Gas Station ─────────────────────────────────────────────────────────────
  'gas-station': {
    intuition:
      'If total gas >= total cost, a solution exists and is unique. Use a greedy scan: track running surplus; when it goes negative, the current starting station is impossible — reset to the next station.',
    algorithm: [
      'totalGas=0, currentGas=0, start=0.',
      'For i from 0 to n−1: totalGas += gas[i]−cost[i]. currentGas += gas[i]−cost[i].',
      'If currentGas < 0: start=i+1. currentGas=0.',
      'Return (totalGas >= 0) ? start : −1.',
    ],
    example: {
      input: 'gas=[1,2,3,4,5], cost=[3,4,5,1,2]',
      steps: [
        'i=0: cur=-2 < 0 → start=1. i=1: cur=-2 < 0 → start=2. i=2: cur=-2 < 0 → start=3.',
        'i=3: cur=3. i=4: cur=6. Total=2≥0. Return start=3.',
      ],
      output: '3',
    },
    pitfalls: ['The existence of a solution is guaranteed when total gas >= total cost — only one valid start exists.'],
  },

  // ─── Height of Binary Tree ───────────────────────────────────────────────────
  'height-of-binary-tree': {
    intuition:
      'The height is the number of nodes on the longest path from root to a leaf. Recursively: height = 1 + max(height(left), height(right)). Base: null node has height 0.',
    algorithm: [
      'If node is null, return 0.',
      'Return 1 + max(Height(node.left), Height(node.right)).',
    ],
    example: {
      input: 'Tree: 1→(2→4, 3)',
      steps: [
        'Height(4)=1. Height(2)=2. Height(3)=1. Height(1)=3.',
      ],
      output: '3',
    },
    pitfalls: ['Height of a single node is 1 (not 0). Height of empty tree is 0.'],
  },

  // ─── Histogram Max Rectangular Area ─────────────────────────────────────────
  'histogram-max-rectangular-area': {
    intuition:
      'For each bar, find how far left and right it extends as the minimum bar. Use a monotonic increasing stack: when a shorter bar is found, the popped bar is bounded on the right by the current bar and on the left by the new stack top.',
    algorithm: [
      'Stack of indices. Append heights[n]=0 as sentinel.',
      'For i from 0 to n: while stack not empty and heights[i] < heights[stack.top]:',
      '  h = heights[stack.pop()]. w = (stack empty) ? i : i−stack.top−1.',
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

  // ─── Implement Trie ──────────────────────────────────────────────────────────
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
        'Insert: a→p→p→l→e (isEnd=true). Search "apple": reach isEnd=true ✓. Search "app": reach e node, isEnd=false → false.',
      ],
      output: 'true, false',
    },
    pitfalls: ['isEnd marks a complete word — do not confuse with "has children" (which indicates a prefix).'],
  },

  // ─── Job Sequencing Problem ──────────────────────────────────────────────────
  'job-sequencing-problem': {
    intuition:
      'Greedy: sort jobs by profit (descending). For each job, schedule it in the latest available time slot before its deadline. Use a boolean array of time slots; greedily pick the latest available slot ≤ deadline.',
    algorithm: [
      'Sort jobs by profit descending.',
      'result[maxDeadline], slot[maxDeadline]=false.',
      'For each job (id,deadline,profit): for t from min(maxDeadline,deadline)-1 down to 0: if !slot[t]: slot[t]=true, result[t]=job, break.',
      'Count filled slots and sum profits.',
    ],
    example: {
      input: 'jobs=[(a,2,100),(b,1,19),(c,2,27),(d,1,25),(e,3,15)]',
      steps: [
        'Sort: a(100),c(27),d(25),b(19),e(15). a→slot[1]. c→slot[0]. e→slot[2]. Maxprofit=100+27+15=142.',
      ],
      output: 'Max profit = 142, 3 jobs',
    },
    pitfalls: ['Fill slots from right to left (latest available) — filling from the start wastes slots for earlier-deadline jobs.'],
  },

  // ─── Kadane\'s Algorithm ───────────────────────────────────────────────────────
  'kadanes-algorithm': {
    intuition:
      'Maximum subarray sum. At each position, decide: extend the current subarray or start fresh. If the running sum becomes negative, starting fresh is always better. dp[i] = max(nums[i], dp[i-1]+nums[i]).',
    algorithm: [
      'maxSum = currentSum = arr[0].',
      'For i from 1 to n−1: currentSum = max(arr[i], currentSum+arr[i]).',
      'maxSum = max(maxSum, currentSum).',
      'Return maxSum.',
    ],
    example: {
      input: 'arr = [-2,1,-3,4,-1,2,1,-5,4]',
      steps: [
        'cur: -2→1→-2→4→3→5→6→1→5. maxSum=6.',
      ],
      output: '6',
    },
    pitfalls: ['Initialize both maxSum and currentSum to arr[0] to handle all-negative arrays correctly.'],
  },

  // ─── Level order traversal ────────────────────────────────────────────────────
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

  // ─── Longest Common Subsequence ───────────────────────────────────────────────
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
    pitfalls: ['LCS counts non-contiguous characters in order — not the same as Longest Common Substring.'],
  },

  // ─── Longest Increasing Subsequence ───────────────────────────────────────────
  'longest-increasing-subsequence': {
    intuition:
      'Two approaches: O(n²) DP where dp[i]=LIS ending at index i, or O(n log n) using patience sorting with a "tails" array. In the patience approach, tails[i] = smallest tail element of all increasing subsequences of length i+1.',
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
    pitfalls: ['The tails array does not represent the actual LIS — only its length is meaningful. Reconstruct using parent pointers from the O(n²) approach if needed.'],
  },

  // ─── Longest Palindrome in a String ──────────────────────────────────────────
  'longest-palindrome-in-a-string': {
    intuition:
      'Expand around each center. For each character (and each gap between characters), expand outward as long as characters match. Track the maximum expansion. O(n²) time, O(1) space.',
    algorithm: [
      'For each center (2n-1 centers for odd + even): expand while valid.',
      'ExpandAroundCenter(left, right): while left>=0 and right<n and s[left]==s[right]: left--, right++.',
      'Track max length and start index.',
    ],
    example: {
      input: 's = "babad"',
      steps: [
        'Center at i=1("a"): expand → "bab"(len=3). Center at i=2("b"): expand → "aba"(len=3).',
        'Return "bab" (first found).',
      ],
      output: '"bab"',
    },
    pitfalls: ['Check both odd (single-char center) and even (between-char center) palindromes.'],
  },

  // ─── Longest Palindromic Subsequence ─────────────────────────────────────────
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

  // ─── LRU Cache ───────────────────────────────────────────────────────────────
  'lru-cache': {
    intuition:
      'Same as LeetCode 146: HashMap + doubly linked list. O(1) get and put. HashMap maps key to node; DLL maintains recency order.',
    algorithm: [
      'See LeetCode 146 explanation — identical structure.',
    ],
    example: {
      input: 'capacity=2, put(1,1),put(2,2),get(1),put(3,3),get(2)',
      steps: ['get(1)=1. After put(3): evicts key 2. get(2)=-1.'],
      output: 'get(1)=1, get(2)=-1',
    },
    pitfalls: ['Evict the LEAST recently used (tail node), not the least frequently used.'],
  },

  // ─── Majority Element ────────────────────────────────────────────────────────
  'majority-element': {
    intuition:
      'Boyer-Moore Voting Algorithm: the majority element (appears > n/2 times) will survive cancellation. Maintain a candidate and counter; increment for matching, decrement for non-matching; when counter reaches 0, switch candidate.',
    algorithm: [
      'candidate = arr[0], count = 1.',
      'For i from 1 to n−1: if arr[i]==candidate: count++. Else: count--. If count==0: candidate=arr[i], count=1.',
      'Return candidate.',
    ],
    example: {
      input: 'arr = [3,3,4,2,4,4,2,4,4]',
      steps: [
        '3(1),3(2),4(1),2(0)→4(1),4(2),2(1),4(2),4(3). Candidate=4.',
      ],
      output: '4',
    },
    pitfalls: ['The problem guarantees a majority element exists — no verification step needed. If not guaranteed, verify by counting.'],
  },

  // ─── Matrix Chain Multiplication ─────────────────────────────────────────────
  'matrix-chain-multiplication': {
    intuition:
      'dp[i][j] = minimum number of scalar multiplications to compute the product of matrices i through j. Split at every position k between i and j; the cost is dp[i][k] + dp[k+1][j] + p[i-1]*p[k]*p[j].',
    algorithm: [
      'dp[i][i]=0. Fill for increasing chain lengths.',
      'For l from 2 to n: for i from 1 to n-l+1: j=i+l-1. dp[i][j]=INF.',
      'For k from i to j-1: cost=dp[i][k]+dp[k+1][j]+p[i-1]*p[k]*p[j]. dp[i][j]=min.',
    ],
    example: {
      input: 'p=[1,2,3,4] (3 matrices: 1×2, 2×3, 3×4)',
      steps: [
        'dp[1][2]=1*2*3=6. dp[2][3]=2*3*4=24. dp[1][3]=min(dp[1][1]+dp[2][3]+1*2*4, dp[1][2]+dp[3][3]+1*3*4)=min(0+24+8,6+0+12)=min(32,18)=18.',
      ],
      output: '18',
    },
    pitfalls: ['p[i] is the number of ROWS of matrix i and COLUMNS of matrix i-1. Use 1-indexed arrays carefully.'],
  },

  // ─── Max Circular Subarray Sum ────────────────────────────────────────────────
  'max-circular-subarray-sum': {
    intuition:
      'Two cases: (1) the max subarray does NOT wrap around → Kadane\'s algorithm. (2) The max subarray WRAPS → total sum minus the minimum subarray (non-wrapping). Answer = max(case1, totalSum − minSubarray). Handle all-negative edge case.',
    algorithm: [
      'Case 1: maxSum = Kadane(arr).',
      'totalSum = sum(arr). Case 2: minSum = Kadane(−arr) negated = minimum subarray sum. circularMax = totalSum − minSum.',
      'If maxSum < 0 (all negative): return maxSum.',
      'Return max(maxSum, circularMax).',
    ],
    example: {
      input: 'arr = [8,-8,9,-9,10,-11,12]',
      steps: [
        'Kadane: maxSum=22. totalSum=11. minKadane=-19 → circularMax=30.',
        'Return max(22,30)=30.',
      ],
      output: '30',
    },
    pitfalls: ['If all elements are negative, circularMax = totalSum − minSum = 0, which is wrong — return maxSum directly.'],
  },

  // ─── Merge K sorted linked lists ─────────────────────────────────────────────
  'merge-k-sorted-linked-lists': {
    intuition:
      'Use a min-heap of size k: initialise with the head of each list. Repeatedly extract the minimum node, add it to the result, and push its successor (if any) back into the heap.',
    algorithm: [
      'Min-heap of (node.val, node). Insert head of each non-null list.',
      'While heap not empty: extract (val, node). Append to result. If node.next != null: push (node.next.val, node.next).',
      'Return result head.',
    ],
    example: {
      input: 'lists = [1→4→5, 1→3→4, 2→6]',
      steps: [
        'Heap: [(1,L1),(1,L2),(2,L3)]. Extract 1→push 4. Extract 1→push 3. Extract 2→push 6. ...continue...',
        'Result: 1→1→2→3→4→4→5→6.',
      ],
      output: '[1,1,2,3,4,4,5,6]',
    },
    pitfalls: ['For C# PriorityQueue, compare by node.val to maintain min-heap property.'],
  },

  // ─── Minimum Cost Path ────────────────────────────────────────────────────────
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

  // ─── Minimum Jumps ────────────────────────────────────────────────────────────
  'minimum-jumps': {
    intuition:
      'Greedy BFS: at each step, track the farthest reachable position (currentEnd) and the farthest position reachable in the next step (farthestReach). When we reach currentEnd, we must take a jump; increment jumps and update currentEnd to farthestReach.',
    algorithm: [
      'jumps=0, currentEnd=0, farthest=0.',
      'For i from 0 to n−2: farthest = max(farthest, i+arr[i]).',
      'If i == currentEnd: jumps++. currentEnd=farthest. If currentEnd >= n-1: break.',
      'Return jumps if reachable, else -1.',
    ],
    example: {
      input: 'arr = [2,3,1,1,4]',
      steps: [
        'i=0: farthest=2. currentEnd=0 → jump, currentEnd=2, jumps=1.',
        'i=1: farthest=4. i=2: farthest=4. currentEnd=2 → jump, currentEnd=4≥4, jumps=2. Break.',
      ],
      output: '2',
    },
    pitfalls: ['Iterate only to n−2 (not n−1) — you don\'t need a jump from the last position.'],
  },

  // ─── Minimum Platforms ────────────────────────────────────────────────────────
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
    pitfalls: ['Sort BOTH arrays independently — the i-th arrival does not correspond to the i-th departure after sorting.'],
  },

  // ─── Missing And Repeating ────────────────────────────────────────────────────
  'missing-and-repeating': {
    intuition:
      'Two equations: let x=missing, y=repeating. Sum difference: S−S_expected = y−x. Sum of squares difference: S2−S2_expected = y²−x² = (y−x)(y+x). Solve for x and y.',
    algorithm: [
      'S=sum(arr), S_exp=n(n+1)/2. sumDiff=S−S_exp = y−x.',
      'S2=sum(arr[i]²), S2_exp=n(n+1)(2n+1)/6. sq_diff=S2−S2_exp = y²−x².',
      'y+x = sq_diff/(y-x). Solve: y=(sumDiff+(y+x))/2, x=y−sumDiff.',
    ],
    example: {
      input: 'arr=[3,1,3,4,5] (n=5)',
      steps: [
        'S=16, S_exp=15. sumDiff=1=y−x.',
        'S2=60, S2_exp=55. sqDiff=5=(y−x)(y+x)=1*(y+x) → y+x=5.',
        'y=3, x=2.',
      ],
      output: 'Missing=2, Repeating=3',
    },
    pitfalls: ['Use long arithmetic to avoid overflow in sum of squares.'],
  },

  // ─── N-Queen Problem ─────────────────────────────────────────────────────────
  'n-queen-problem': {
    intuition:
      'Same as LeetCode 51. Backtracking row by row with three HashSets tracking occupied columns, positive diagonals (row-col), and negative diagonals (row+col).',
    algorithm: [
      'See LeetCode 51 explanation — identical approach.',
    ],
    example: {
      input: 'n = 4',
      steps: ['Two valid placements for 4-Queens.'],
      output: '2 solutions',
    },
    pitfalls: ['Track row+col and row-col as diagonal identifiers — not the actual diagonal position.'],
  },

  // ─── Next Greater Element ─────────────────────────────────────────────────────
  'next-greater-element': {
    intuition:
      'Monotonic stack: maintain a decreasing stack. For each element, pop all elements smaller than it — the current element is their "next greater". Elements left in the stack have no next greater → assign -1.',
    algorithm: [
      'Stack of indices. result[n]=-1.',
      'For i from 0 to n-1: while stack not empty and arr[stack.top] < arr[i]: result[stack.pop()] = arr[i].',
      'Push i.',
    ],
    example: {
      input: 'arr = [4,5,2,25]',
      steps: [
        'i=0: push 0. i=1: 4<5 → result[0]=5. Push 1.',
        'i=2: push 2. i=3: 2<25 → result[2]=25. 5<25 → result[1]=25. Push 3.',
        'result=[5,25,25,-1].',
      ],
      output: '[5,25,25,-1]',
    },
    pitfalls: ['The stack stores INDICES, not values — you need the index to update result[].'],
  },

  // ─── Next Permutation ─────────────────────────────────────────────────────────
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
        'i=1 (arr[1]=2 < arr[2]=3). j=2 (arr[2]=3 > 2). Swap: [1,3,2]. Reverse suffix: [1,3,2]. → [1,3,2].',
      ],
      output: '[1,3,2]',
    },
    pitfalls: ['Reverse the suffix, do not sort it — the suffix is already in descending order so reversing achieves ascending order in O(n).'],
  },

  // ─── Palindrome Linked List ───────────────────────────────────────────────────
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
      input: '1→2→2→1',
      steps: [
        'Mid = node(2) at index 1. Reverse second half: 1→2.',
        'Compare: 1==1, 2==2. Palindrome!',
      ],
      output: 'true',
    },
    pitfalls: ['Restore the list after comparison if the problem requires (most GFG solutions need immutable input).'],
  },

  // ─── Parenthesis Checker ─────────────────────────────────────────────────────
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
        '{ push. ( push. ) matches ( → pop. [ push. { push. ( push. ) → pop. } → pop. ] → pop. } → pop. Stack empty → true.',
      ],
      output: 'true',
    },
    pitfalls: ['Check stack is non-empty before comparing top — an extra closing bracket crashes a stack-empty check.'],
  },

  // ─── Partition Equal Subset Sum ───────────────────────────────────────────────
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

  // ─── Rat in a Maze Problem - I ────────────────────────────────────────────────
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
        'Path DDRDRR: (0,0)→(1,0)→(2,0)→(2,1)→(3,1)→(3,2)→(3,3). Valid!',
      ],
      output: '["DDRDRR"]',
    },
    pitfalls: ['Add directions in sorted order (D,L,R,U) to get paths in lexicographic order.'],
  },

  // ─── Reverse a linked list ────────────────────────────────────────────────────
  'reverse-a-linked-list': {
    intuition:
      'Iterative reversal: use three pointers (prev, curr, next). Redirect each node\'s next pointer to its predecessor.',
    algorithm: [
      'prev=null, curr=head.',
      'While curr != null: next=curr.next. curr.next=prev. prev=curr. curr=next.',
      'Return prev (new head).',
    ],
    example: {
      input: '1→2→3→4→5',
      steps: [
        'null←1  2→3→4→5. null←1←2  3→4→5. ... null←1←2←3←4←5. prev=5.',
      ],
      output: '5→4→3→2→1',
    },
    pitfalls: ['Save curr.next BEFORE redirecting curr.next=prev, or you lose the rest of the list.'],
  },

  // ─── Rotten Oranges ───────────────────────────────────────────────────────────
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
    pitfalls: ['Start BFS with ALL rotten oranges simultaneously — not from just one source.'],
  },

  // ─── Serialize and deserialize a binary tree ──────────────────────────────────
  'serialize-and-deserialize-a-binary-tree': {
    intuition:
      'Serialize via pre-order DFS: record node values and "#" for null nodes. Deserialize by consuming tokens in the same pre-order: the first non-null token is the root, recurse for left then right subtree.',
    algorithm: [
      'Serialize: preorder DFS, append val or "#", comma-separated.',
      'Deserialize: split by comma, use an index pointer (or queue of tokens). Consume first token: if "#" return null. Else create node, recurse left, then right.',
    ],
    example: {
      input: 'Tree: 1→(2, 3→(4,5))',
      steps: [
        'Serialize: "1,2,#,#,3,4,#,#,5,#,#".',
        'Deserialize: read 1→root, read 2→left, read #→left.left=null, read #→left.right=null, ...',
      ],
      output: 'Reconstructed tree = original tree',
    },
    pitfalls: ['Use pre-order (not in-order) for serialization — in-order requires extra information to determine root.'],
  },

  // ─── Sort 0s, 1s and 2s ──────────────────────────────────────────────────────
  'sort-0s-1s-and-2s': {
    intuition:
      'Dutch National Flag algorithm (same as LeetCode 75). Three-way partition in a single pass using three pointers: lo, mid, hi.',
    algorithm: [
      'See LeetCode 75 explanation — identical.',
    ],
    example: {
      input: '[0,1,2,0,1,2]',
      steps: ['Result: [0,0,1,1,2,2] in one pass.'],
      output: '[0,0,1,1,2,2]',
    },
    pitfalls: ['Do not increment mid when swapping with hi — the swapped element is unexamined.'],
  },

  // ─── Subset Sum Problem ────────────────────────────────────────────────────────
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

  // ─── Topological sort ────────────────────────────────────────────────────────
  'topological-sort': {
    intuition:
      'Kahn\'s BFS approach: repeatedly remove nodes with in-degree 0. DFS approach: after exploring all descendants, push node to stack; the reverse of the stack gives topological order.',
    algorithm: [
      'DFS: TopoSort(node): mark visited. For each neighbor: if not visited, DFS. Push node to stack AFTER recursion.',
      'Collect nodes by finishing time (descending).',
    ],
    example: {
      input: 'DAG: 5→0, 5→2, 4→0, 4→1, 2→3, 3→1',
      steps: ['One valid topological order: 5,4,2,3,1,0.'],
      output: '[5,4,2,3,1,0]',
    },
    pitfalls: ['Topological sort is only valid for DAGs (Directed Acyclic Graphs). Detect cycles first.'],
  },

  // ─── Top View of Binary Tree ──────────────────────────────────────────────────
  'top-view-of-binary-tree': {
    intuition:
      'Level-order traversal with horizontal distance (HD). For each HD, record only the FIRST node seen (top view). A node is visible from the top if no ancestor has the same HD.',
    algorithm: [
      'BFS with (node, HD). Map: HD → first seen value (only set if HD not already in map).',
      'Enqueue (left, hd−1) and (right, hd+1).',
      'Return map values sorted by HD.',
    ],
    example: {
      input: 'Tree: 1→(2→(4,5),3)',
      steps: ['HD: 4→-2, 2→-1, 5→0, 1→0, 3→1. Top (first seen): 4,2,1,3.'],
      output: '[4,2,1,3]',
    },
    pitfalls: ['For top view, the FIRST node (BFS order = top to bottom) at each HD wins. For bottom view, the last node wins.'],
  },

  // ─── Trapping Rain Water ──────────────────────────────────────────────────────
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
    pitfalls: ['Process the shorter side — the shorter boundary determines how much water is trapped.'],
  },

  // ─── Two Sum - Pair with Given Sum ───────────────────────────────────────────
  'two-sum-pair-with-given-sum': {
    intuition:
      'Two pointers on sorted array: if sum < target, advance left; if sum > target, retreat right; if equal, found the pair. For unsorted, use a HashSet: for each element, check if (target−element) is in the set.',
    algorithm: [
      'Sort arr. lo=0, hi=n-1.',
      'While lo < hi: sum=arr[lo]+arr[hi]. If sum==target: return true. If sum<target: lo++. Else: hi--.',
      'Return false.',
    ],
    example: {
      input: 'arr=[2,7,11,15], target=9',
      steps: ['lo=0(2), hi=3(15): 17>9→hi--. hi=2(11): 13>9→hi--. hi=1(7): 9==9 ✓.'],
      output: 'true',
    },
    pitfalls: ['Sorting changes indices — if you need to return original indices, use a HashMap approach instead.'],
  },

  // ─── Undirected Graph Cycle ───────────────────────────────────────────────────
  'undirected-graph-cycle': {
    intuition:
      'BFS or DFS with parent tracking. In an undirected graph, a cycle exists if a visited neighbor is not the direct parent. Track the parent to avoid treating the back-edge to parent as a cycle.',
    algorithm: [
      'DFS(node, parent): for each neighbor v: if !visited: DFS(v, node). Else if v != parent: cycle detected.',
    ],
    example: {
      input: 'Graph: 0-1, 1-2, 2-0 (triangle)',
      steps: [
        'DFS(0,−1)→DFS(1,0)→DFS(2,1): neighbor 0 is visited and ≠ parent(1) → cycle!',
      ],
      output: 'true',
    },
    pitfalls: ['Pass parent as -1 for the root node. For multigraphs (parallel edges), use parent-edge ID instead of parent node.'],
  },

  // ─── Word Break ───────────────────────────────────────────────────────────────
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
        'dp[0]=true. i=4: j=0, dp[0]=true, "leet" in dict → dp[4]=true.',
        'i=8: j=4, dp[4]=true, "code" in dict → dp[8]=true.',
      ],
      output: 'true',
    },
    pitfalls: ['Use a HashSet for O(1) dictionary lookups — do not iterate the dictionary for each check.'],
  },

  // ─── ZigZag Tree Traversal ────────────────────────────────────────────────────
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

}

export default gfgExplanations
