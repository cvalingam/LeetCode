# 3742. Maximum Path Score in a Grid

## Problem

Given an `m x n` integer grid, find the **maximum path score** from the **top-left** `(0, 0)` to the **bottom-right** `(m-1, n-1)`, moving only **right** or **down**.

You can pass through **at most `k` positive cells** (cells with `grid[i][j] > 0`). Every cell you step on contributes its value to your score (negative or positive). If no valid path exists, return `-1`.

---

## Approach — Top-Down DFS with Memoization

### Key Observations

1. You can only move **right** or **down**, so the path always has exactly `(m-1) + (n-1)` moves.
2. The constraint is the **budget of positive cells** you're allowed to pass through (`k`). Passing through a positive cell costs 1 from the budget.
3. We want to **maximize** the total score while keeping the number of positive cells visited ≤ `k`.

### Strategy

- Recurse backwards from the destination `(m-1, n-1)` to the source `(0, 0)`.
- State: `Dfs(i, j, k)` = maximum score to reach `(m-1, n-1)` starting from cell `(i, j)` with `k` remaining positive-cell budget.
- **Base case:** `(0, 0)` → score contribution is 0 (we add values as we leave cells, not when we arrive at `(0,0)`).
- **Out-of-bounds or budget exhausted:** return `-∞` (sentinel for "impossible").
- **Transition:**
  - If `grid[i][j] > 0`, decrement the budget `k → k-1` before exploring predecessors.
  - Score at `(i, j)` = `grid[i][j]` + `max(Dfs(i-1, j, nk), Dfs(i, j-1, nk))`.
- Cache results in a 3D array `f[i][j][k]` to avoid recomputation.

### Why Recurse Backwards?

Starting from the destination lets us define "score from here to the end" cleanly. The budget `k` decreases as we consume positive cells, and both "go up" `(i-1, j)` and "go left" `(i, j-1)` are the only predecessors in a right/down-only path.

---

## Complexity

| | Value |
|---|---|
| **Time** | `O(m × n × k)` — each state `(i, j, k)` is computed once |
| **Space** | `O(m × n × k)` — memoization table + recursion stack depth `O(m + n)` |

---

## Walkthrough Example

```
grid = [[0, -1, 3],
        [2,  4, 0]]
k = 1
```

Path options (right/down only from (0,0) to (1,2)):

- `(0,0) → (0,1) → (0,2) → (1,2)`: values `0, -1, 3, 0` → positive cells: `{3}` = 1 ✓ → score = **2**
- `(0,0) → (1,0) → (1,1) → (1,2)`: values `0, 2, 4, 0` → positive cells: `{2, 4}` = 2 ✗ (exceeds k=1)
- `(0,0) → (0,1) → (1,1) → (1,2)`: values `0, -1, 4, 0` → positive cells: `{4}` = 1 ✓ → score = **3**

Maximum valid score = **3**.

---

## Code Highlights

```csharp
// Budget decreases only when stepping onto a positive cell
if (grid[i][j] > 0)
    --nk;

// Explore both predecessors (up and left), take the best
int a = Dfs(i - 1, j, nk);
int b = Dfs(i, j - 1, nk);
res += Math.Max(a, b);
```

The sentinel `-∞` (`-(1 << 30)`) propagates through `Math.Max` to block impossible paths. After DFS completes, if the result is negative (`< 0`), return `-1`.

---

## Edge Cases

- If `k = 0` and the path forces going through a positive cell → return `-1`.
- All-negative grid → score will be negative (but still valid if ≤ k positive cells touched).
- Single cell `grid = [[x]]` → returns `0` (start == end, base case).
