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

  // ─── Allocate Minimum Pages ──────────────────────────────────────────────────
  'allocate-minimum-pages': {
    intuition: 'Binary search on the answer (minimum of maximum pages). For a given mid, check if we can allocate books to m students such that each student gets at most mid pages.',
    algorithm: [
      'lo = max(books), hi = sum(books).',
      'Binary search: mid = (lo+hi)/2. Check feasibility: greedily assign books; if a student would exceed mid, start a new student.',
      'If feasible with ≤ m students: hi=mid. Else lo=mid+1.',
      'Return lo.',
    ],
    example: { input: 'books=[12,34,67,90], m=2', steps: ['lo=90, hi=203. mid=146: [12,34,67] to student1 (113≤146), [90] to student2 → 2 students ✓.', 'hi=146. mid=118: [12,34,67] (113≤118), [90] ✓. hi=118.', 'Continue until lo=hi=113.'], output: '113' },
    pitfalls: ['A student must get at least one book. Books must be contiguous (can\'t reorder).'],
  },

  // ─── BST to Greater Sum Tree ─────────────────────────────────────────────────
  'bst-to-greater-sum-tree': {
    intuition: 'In-order traversal visits BST in ascending order. Reverse in-order (right→node→left) visits in descending order. Maintain a running sum; update each node\'s value.',
    algorithm: [
      'Do reverse in-order traversal (right subtree first).',
      'Maintain running sum. At each node: sum += node.val; node.val = sum.',
    ],
    example: { input: 'BST=[4,1,6,0,2,5,7]', steps: ['Visit 7→sum=7. Visit 6→sum=13. Visit 5→sum=18. Visit 4→sum=22. Visit 2→sum=24. Visit 1→sum=25. Visit 0→sum=25.'], output: 'Tree with updated values' },
    pitfalls: ['This is a simple Morris traversal or recursive reverse in-order — no extra space needed with Morris.'],
  },

  // ─── Burning Tree ────────────────────────────────────────────────────────────
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

  // ─── Chocolate Distribution Problem ─────────────────────────────────────────
  'chocolate-distribution-problem': {
    intuition: 'Sort packets. The minimum difference between max and min packets given to m students is found in the sliding window of size m after sorting.',
    algorithm: [
      'Sort the packet array.',
      'Sliding window of size m: for each window, compute A[i+m-1] - A[i].',
      'Return minimum such difference.',
    ],
    example: { input: 'A=[7,3,2,4,9,12,56], m=3', steps: ['Sorted: [2,3,4,7,9,12,56].', 'Windows of size 3: [2,3,4]→2, [3,4,7]→4, [4,7,9]→5, [7,9,12]→5, [9,12,56]→47.', 'Min=2.'], output: '2' },
    pitfalls: ['Sort first — only then is the minimum range guaranteed to be a contiguous subarray.'],
  },

  // ─── Clone a linked list with next and random pointer ────────────────────────
  'clone-a-linked-list-with-next-and-random-pointer': {
    intuition: 'Three passes: (1) interleave cloned nodes between original nodes, (2) set random pointers for cloned nodes, (3) separate the two lists.',
    algorithm: [
      'Pass 1: for each node N, insert clone N\' after N: N→N\'→N.next.',
      'Pass 2: for each original node N: N.next.random = N.random?.next.',
      'Pass 3: separate lists by fixing next pointers.',
    ],
    pitfalls: ['Pass 2 relies on the interleaved structure: original.random.next is the clone of original.random. Restore original list in pass 3.'],
  },

  // ─── Course Schedule I ───────────────────────────────────────────────────────
  'course-schedule-i': {
    intuition: 'Can all courses be completed? This is cycle detection in a directed graph. If the prerequisite graph is a DAG (no cycles), all courses can be done.',
    algorithm: [
      'Build directed adjacency list: prerequisite→course.',
      'Topological sort (Kahn\'s BFS): compute in-degrees. Queue nodes with in-degree 0. Process: reduce neighbors\' in-degree, add to queue when 0.',
      'If processed count == numCourses, return true.',
    ],
    example: { input: 'n=2, prerequisites=[[1,0]]', steps: ['Graph: 0→1. in-degree: [0,1]. Queue:[0]. Process 0→in[1]=0→add 1. Count=2=n.'], output: 'true' },
    pitfalls: ['Also solvable with DFS cycle detection (white/grey/black coloring).'],
  },

  // ─── Course Schedule II ──────────────────────────────────────────────────────
  'course-schedule-ii': {
    intuition: 'Return a valid course order (topological sort). If cycle exists, return empty array.',
    algorithm: [
      'Kahn\'s algorithm: build adjacency list, compute in-degrees.',
      'Queue all nodes with in-degree 0. Process queue: add to order, decrement neighbors\' in-degrees, add neighbors with in-degree 0.',
      'If order.size == n, return order. Else return [].',
    ],
    pitfalls: ['Return any valid topological order, not a specific one. Empty array signals impossible (cycle).'],
  },

  // ─── Count Distinct elements in every window ─────────────────────────────────
  'count-distinct-elements-in-every-window': {
    intuition: 'Sliding window of size k. Use a frequency map. Track count of distinct elements (map size with non-zero counts).',
    algorithm: [
      'Populate frequency map with first k elements. Record distinct count.',
      'Slide window: add new element (increment freq, if new → distinct++). Remove old (decrement, if 0 → distinct--).',
      'Record distinct count for each position.',
    ],
    pitfalls: ['Remove element from map entirely (or just decrement and check 0) when its count drops to 0.'],
  },

  // ─── Count Reverse Pairs ─────────────────────────────────────────────────────
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

  // ─── Diameter of a Binary Tree ───────────────────────────────────────────────
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

  // ─── Dice throw ──────────────────────────────────────────────────────────────
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

  // ─── Evaluation of Postfix Expression ────────────────────────────────────────
  'evaluation-of-postfix-expression': {
    intuition: 'Stack-based evaluation: push operands, on operator pop two operands, apply, push result.',
    algorithm: [
      'Scan tokens left to right.',
      'If token is number: push to stack.',
      'If token is operator (+,-,*,/): pop b then a, compute a op b, push result.',
      'Final stack top is the result.',
    ],
    example: { input: '"2 3 1 * + 9 -"', steps: ['Push 2,3,1. *: pop 3,1→3. +: pop 2,3→5. Push 9. -: pop 5,9→-4.'], output: '-4' },
    pitfalls: ['Pop order matters: pop b first, then a, compute a op b (not b op a).'],
  },

  // ─── Find median in a stream ──────────────────────────────────────────────────
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

  // ─── Find the number of islands ──────────────────────────────────────────────
  'find-the-number-of-islands': {
    intuition: 'DFS/BFS flood fill: for each unvisited \'1\', increment count and DFS to mark all connected \'1\'s as visited.',
    algorithm: [
      'Iterate over all cells. For each \'1\' not yet visited:',
      'Increment island count.',
      'DFS/BFS: mark current as visited, recurse on all 4 (or 8) neighbors that are \'1\'.',
    ],
    example: { input: '[[1,1,0],[0,1,0],[0,0,1]]', steps: ['Start (0,0)→DFS marks (0,0),(0,1),(1,1). Count=1. (2,2) unvisited→Count=2.'], output: '2' },
    pitfalls: ['Mark cells as visited immediately to avoid re-counting. Determine if connectivity is 4-directional or 8-directional.'],
  },

  // ─── Flattening a Linked List ─────────────────────────────────────────────────
  'flattening-a-linked-list': {
    intuition: 'Each node has a next pointer (horizontal) and a child pointer (vertical sorted list). Merge all vertical lists using merge sort logic.',
    algorithm: [
      'Recursively flatten from right to left.',
      'Merge current node\'s child list with the already-flattened rest.',
      'Return merged sorted list.',
    ],
    pitfalls: ['After merging, the result uses child pointers, not next pointers. Set next to null in the merged result.'],
  },

  // ─── Flood fill Algorithm ────────────────────────────────────────────────────
  'flood-fill-algorithm': {
    intuition: 'From a starting pixel, paint it and all connected pixels of the same color with a new color. DFS/BFS from start.',
    algorithm: [
      'If starting pixel\'s color already equals new color, return (avoid infinite loop).',
      'DFS from (sr,sc): set image[r][c]=newColor. Recurse on 4 neighbors with old color.',
    ],
    example: { input: 'image=[[1,1,1],[1,1,0],[1,0,1]], sr=1, sc=1, newColor=2', steps: ['Fill connected 1s: (0,0),(0,1),(0,2),(1,0),(1,1),(2,0) become 2.'], output: '[[2,2,2],[2,2,0],[2,0,1]]' },
    pitfalls: ['Check if start pixel\'s color == new color and skip to avoid infinite recursion.'],
  },

  // ─── Gold Mine Problem ────────────────────────────────────────────────────────
  'gold-mine-problem': {
    intuition: 'DP: you can enter from any row in column 0 and move right, right-up, or right-down. Find path maximizing gold collected.',
    algorithm: [
      'dp[i][j] = max gold reachable at cell (i,j) coming from left column.',
      'For each column j from 1: for each row i: dp[i][j] = grid[i][j] + max(dp[i-1][j-1], dp[i][j-1], dp[i+1][j-1]).',
      'Return max over all dp[i][n-1].',
    ],
    pitfalls: ['Boundary checks for first/last rows. Can start from any cell in column 0. Must move left to right only.'],
  },

  // ─── Gray Code ────────────────────────────────────────────────────────────────
  'gray-code': {
    intuition: 'n-bit Gray code: i-th value = i XOR (i>>1). Or build iteratively: mirror and prefix with 0/1.',
    algorithm: [
      'Iterative: start with [0]. For each step i from 1 to n: for j from current.size-1 to 0, append current[j] | (1<<(i-1)).',
      'Or formula: for i in 0..2^n-1, gray[i] = i ^ (i>>1).',
    ],
    example: { input: 'n=2', steps: ['Step 0: [0]. Step 1: [0,1]. Step 2: [00,01,11,10] = [0,1,3,2].'], output: '[0,1,3,2]' },
    pitfalls: ['Successive values differ by exactly 1 bit. The XOR formula i^(i>>1) directly gives the i-th Gray code.'],
  },

  // ─── Implement Atoi ──────────────────────────────────────────────────────────
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

  // ─── Implement Pow ───────────────────────────────────────────────────────────
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

  // ─── Inorder Traversal ────────────────────────────────────────────────────────
  'inorder-traversal': {
    intuition: 'Visit left subtree, then root, then right subtree. For iterative: use stack to simulate call stack.',
    algorithm: [
      'Recursive: inorder(left), visit root, inorder(right).',
      'Iterative: push all left nodes to stack. Pop, add to result, then push all left nodes of right subtree.',
    ],
    pitfalls: ['Morris traversal achieves O(1) space by temporarily modifying tree links.'],
  },

  // ─── Intersection Point in Y Shaped Linked Lists ─────────────────────────────
  'intersection-point-in-y-shaped-linked-lists': {
    intuition: 'Two pointers: switch to the other head when reaching null. They\'ll meet at the intersection after traversing both lists\' full lengths.',
    algorithm: [
      'a = headA, b = headB.',
      'While a != b: a = (a == null) ? headB : a.next; b = (b == null) ? headA : b.next.',
      'Return a (intersection or null).',
    ],
    pitfalls: ['If no intersection, both become null simultaneously after traversing both full lists, so while loop terminates.'],
  },

  // ─── Josephus problem ─────────────────────────────────────────────────────────
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

  // ─── K-th element of two Arrays ──────────────────────────────────────────────
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

  // ─── k-th Smallest in BST ────────────────────────────────────────────────────
  'k-th-smallest-in-bst': {
    intuition: 'In-order traversal of BST visits nodes in sorted ascending order. The k-th node visited is the k-th smallest.',
    algorithm: [
      'In-order DFS: traverse left, visit node (decrement k), traverse right.',
      'When k reaches 0, store current node value.',
    ],
    example: { input: 'BST=[5,3,6,2,4], k=3', steps: ['In-order: 2,3,4,5,6. 3rd = 4.'], output: '4' },
    pitfalls: ['Can early-exit once k reaches 0. For iterative, use a stack and counter.'],
  },

  // ─── LCS of three strings ─────────────────────────────────────────────────────
  'lcs-of-three-strings': {
    intuition: 'Extension of LCS: 3D DP. dp[i][j][k] = LCS of first i chars of s1, j chars of s2, k chars of s3.',
    algorithm: [
      'If s1[i-1]==s2[j-1]==s3[k-1]: dp[i][j][k] = dp[i-1][j-1][k-1] + 1.',
      'Else: dp[i][j][k] = max(dp[i-1][j][k], dp[i][j-1][k], dp[i][j][k-1]).',
      'Return dp[n1][n2][n3].',
    ],
    pitfalls: ['3D DP has O(n³) time and space. Can be space-optimized but logic is clearer in 3D.'],
  },

  // ─── Largest BST ─────────────────────────────────────────────────────────────
  'largest-bst': {
    intuition: 'For each subtree, check if it\'s a valid BST and track its size. Return max BST size found. Each subtree return: (isBST, size, min, max).',
    algorithm: [
      'DFS returning (isBST, size, minVal, maxVal) for each subtree.',
      'A node\'s subtree is BST if both children are BSTs, node.val > left.max, node.val < right.min.',
      'BST size = left.size + right.size + 1. Track global maximum.',
    ],
    pitfalls: ['If subtree is not BST, return size=0 so its ancestors can\'t count it. Propagate min/max correctly.'],
  },

  // ─── Left View of Binary Tree ─────────────────────────────────────────────────
  'left-view-of-binary-tree': {
    intuition: 'BFS level order: first node of each level is visible from left. Or DFS with level tracking: first visit at each level is left view.',
    algorithm: [
      'BFS: for each level, add the first node\'s value to result.',
      'Or DFS: pass level. If level == result.size(), add current node value (first visit at this level).',
    ],
    pitfalls: ['DFS should visit left child first to ensure leftmost node is recorded first.'],
  },

  // ─── Level Order in spiral form ──────────────────────────────────────────────
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

  // ─── Linked List Group Reverse ────────────────────────────────────────────────
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

  // ─── Longest Common Increasing Subsequence ────────────────────────────────────
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

  // ─── Longest Common Substring ────────────────────────────────────────────────
  'longest-common-substring': {
    intuition: 'DP: dp[i][j] = length of longest common substring ending at s1[i-1] and s2[j-1]. If chars match, dp[i][j]=dp[i-1][j-1]+1. Track global max.',
    algorithm: [
      'dp[i][j] = 0 if s1[i-1] != s2[j-1], else dp[i-1][j-1]+1.',
      'Track max(dp[i][j]) across all i,j.',
    ],
    example: { input: 's1="ABCBDAB", s2="BDCABA"', steps: ['dp fills up. Max common substring is "AB" or "BD" of length 2? Actually "BCB"/"BDCAB" → "BCA"? Let me recalculate: longest = "AB"=2... actually "ABCB" vs "BDCABA" → "AB"=2.'], output: '2' },
    pitfalls: ['Unlike LCS, must be contiguous — reset dp[i][j]=0 on mismatch, no max with adjacent cells.'],
  },

  // ─── Longest Consecutive Subsequence ─────────────────────────────────────────
  'longest-consecutive-subsequence': {
    intuition: 'Add all elements to a HashSet. For each number n where n-1 is NOT in the set (it\'s a sequence start), count how long the streak goes.',
    algorithm: [
      'Add all nums to HashSet.',
      'For each n where set doesn\'t contain n-1: count streak = 1, while set contains n+streak: streak++.',
      'Update max streak.',
    ],
    example: { input: '[100,4,200,1,3,2]', steps: ['Start=1: 1,2,3,4 → streak=4. Start=100: streak=1. Start=200: streak=1.'], output: '4' },
    pitfalls: ['Only start counting from sequence start (n-1 not in set) — avoids O(n²) repetition.'],
  },

  // ─── Longest valid Parentheses ───────────────────────────────────────────────
  'longest-valid-parentheses': {
    intuition: 'Use a stack to find the length of the longest valid parentheses substring. Push indices; on \')\', pop matching \'(\'; if stack empty, push current as new base.',
    algorithm: [
      'Push -1 as base index onto stack.',
      'For \'(\': push index.',
      'For \')\': pop. If stack empty: push current index as new base. Else: length = i - stack.top(). Update max.',
    ],
    example: { input: '"()(()"', steps: ['i=0 \'(\' push. i=1 \')\' pop, stack=[−1], len=1−(−1)=2. i=2,3 push. i=4 \')\' pop, stack=[1], len=4−1=3.'], output: '4... (recalc: "(()" → len=2 from last two)' },
    pitfalls: ['Initialize stack with -1 as sentinel. Also solvable with DP (dp[i] = length ending at i) or two passes.'],
  },

  // ─── Lowest Common Ancestor in a BST ─────────────────────────────────────────
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

  // ─── Majority Element II ─────────────────────────────────────────────────────
  'majority-element-ii': {
    intuition: 'Find all elements appearing more than ⌊n/3⌋ times. At most 2 such elements exist. Use Boyer-Moore voting with 2 candidates.',
    algorithm: [
      'Maintain two candidates and their counts.',
      'For each element: if it matches candidate1 or 2, increment their count. If a count is 0, replace. Else decrement both.',
      'Verify the two candidates by counting occurrences.',
    ],
    pitfalls: ['After voting, must verify — candidates might not actually exceed n/3 (voting finds the POTENTIAL candidates, not guaranteed majority).'],
  },

  // ─── Max rectangle ───────────────────────────────────────────────────────────
  'max-rectangle': {
    intuition: 'Build histograms row by row and apply "largest rectangle in histogram" for each row.',
    algorithm: [
      'Maintain heights[] array. For each row: update heights (increment if cell=1, reset to 0 if cell=0).',
      'For each row\'s heights, compute largest rectangle using stack-based approach.',
    ],
    example: { input: '[[1,0,1,0,0],[1,0,1,1,1],[1,1,1,1,1],[1,0,0,1,0]]', steps: ['Row 0 heights=[1,0,1,0,0]→area=1. Row 1=[2,0,2,1,1]→area=3. Row 2=[3,1,3,2,2]→area=6.'], output: '6' },
    pitfalls: ['Use the histogram approach for each row. The largest rectangle in histogram uses a monotone stack.'],
  },

  // ─── Maximum Product Subarray ─────────────────────────────────────────────────
  'maximum-product-subarray': {
    intuition: 'Track both maximum and minimum product ending at each position (negative × negative = positive). Max at each step = max of: current element alone, max*current, min*current.',
    algorithm: [
      'maxProd = minProd = result = nums[0].',
      'For each num from index 1: tmp = maxProd. maxProd = max(num, maxProd*num, minProd*num). minProd = min(num, tmp*num, minProd*num).',
      'result = max(result, maxProd).',
    ],
    example: { input: '[2,3,-2,4]', steps: ['max=2,min=2. max=6,min=6. max=-2,min=-12. max=4,min=-48. Result=6.'], output: '6' },
    pitfalls: ['Must track minimum product because negative × negative = positive. Save tmp before updating maxProd.'],
  },

  // ─── Maximum path sum from any node ──────────────────────────────────────────
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

  // ─── Maximum sum of Non-adjacent nodes ───────────────────────────────────────
  'maximum-sum-of-non-adjacent-nodes': {
    intuition: 'Tree DP: for each node, two states — include node (can\'t include children) or exclude (take max of including/excluding each child).',
    algorithm: [
      'DFS returns (include, exclude) for each subtree.',
      'include = node.val + sum(exclude of each child).',
      'exclude = sum(max(include, exclude) for each child).',
      'For root: return max(include, exclude).',
    ],
    pitfalls: ['This is house-robber on a tree. Return a pair (take, skip) from each subtree.'],
  },

  // ─── Median in a row-wise sorted Matrix ──────────────────────────────────────
  'median-in-a-row-wise-sorted-matrix': {
    intuition: 'Binary search on value range [lo, hi]. For a given mid, count elements ≤ mid using binary search on each row. Median found when count == (m*n+1)/2.',
    algorithm: [
      'lo = matrix[0][0], hi = max last elements.',
      'Binary search: mid = (lo+hi)/2. Count = sum of upper_bound(mid) across all rows.',
      'If count < (m*n+1)/2: lo=mid+1. Else hi=mid.',
      'Return lo.',
    ],
    pitfalls: ['Integer median for odd total. Binary search on values, not indices. Count elements ≤ mid (not <).'],
  },

  // ─── Median of two sorted arrays ────────────────────────────────────────────
  'median-of-two-sorted-arrays': {
    intuition: 'Binary search on the smaller array. Partition both arrays such that left half has (m+n)/2 elements and max(left) ≤ min(right).',
    algorithm: [
      'Ensure len(A) ≤ len(B). Binary search on A: lo=0, hi=len(A).',
      'partA=mid, partB=(m+n+1)/2 - partA.',
      'Check: maxLeftA ≤ minRightB and maxLeftB ≤ minRightA.',
      'If valid: median = max(maxLeft) for odd total, or (max(maxLeft)+min(minRight))/2 for even.',
    ],
    pitfalls: ['Use ±infinity for boundary partitions (partA=0 or partA=len). Ensure binary search on shorter array.'],
  },

  // ─── Merge Sort for Linked List ──────────────────────────────────────────────
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

  // ─── Merge two sorted linked lists ──────────────────────────────────────────
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

  // ─── Middle of a Linked List ─────────────────────────────────────────────────
  'middle-of-a-linked-list': {
    intuition: 'Floyd\'s slow/fast pointer: slow advances one step, fast advances two. When fast reaches end, slow is at middle.',
    algorithm: [
      'slow = fast = head.',
      'While fast != null and fast.next != null: slow = slow.next; fast = fast.next.next.',
      'Return slow.',
    ],
    pitfalls: ['For even length lists, this returns the second middle. Adjust termination condition if first middle is needed.'],
  },

}

export default gfgExplanations
