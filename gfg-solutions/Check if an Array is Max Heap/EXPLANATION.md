# Check if an Array is Max Heap

## Problem

Given an integer array `arr`, determine whether it represents a **valid Max Heap**.

In a **Max Heap**:
- Every parent node is **greater than or equal to** both its children.
- The array uses 0-based indexing where:
  - Node at index `i` has children at indices `2i + 1` and `2i + 2`.
  - Node at index `i` has parent at index `(i - 1) / 2`.

Return `true` if the array is a valid max heap, `false` otherwise.

---

## Approach — Linear Scan of Child-Parent Relationships

### Key Insight

Instead of checking each parent against its children (which requires computing child indices), we can **iterate over all non-root nodes** (indices `1` to `n-1`) and verify that each node is **not greater than its parent**.

- For any node at index `i`, its parent is at index `(i - 1) / 2`.
- A violation occurs if `arr[i] > arr[(i-1)/2]`.

This single loop covers **every parent-child relationship** in the heap exactly once.

### Why This Works

A binary heap stored as an array has the property that every child's parent index is deterministic: `parent(i) = (i-1) / 2`. By scanning children (not parents), we avoid having to handle the edge case of a leaf node with only one child — because we're always looking **up** at a guaranteed parent.

### Algorithm

```
for i from (n-1) down to 1:
    if arr[i] > arr[(i-1) / 2]:
        return false
return true
```

Iterating from the end to index 1 is equivalent to iterating forward — order doesn't matter since each check is independent.

---

## Complexity

| | Value |
|---|---|
| **Time** | `O(n)` — single pass over all `n-1` non-root nodes |
| **Space** | `O(1)` — no extra data structures |

---

## Walkthrough Examples

### Example 1: Valid Max Heap

```
arr = [90, 15, 10, 7, 12, 2]
```

Tree representation:
```
        90
       /  \
      15   10
     / \   /
    7   12 2
```

Checks:
- `arr[1]=15` ≤ `arr[0]=90` ✓
- `arr[2]=10` ≤ `arr[0]=90` ✓
- `arr[3]=7`  ≤ `arr[1]=15` ✓
- `arr[4]=12` ≤ `arr[1]=15` ✓
- `arr[5]=2`  ≤ `arr[2]=10` ✓

Result: **true**

---

### Example 2: Not a Max Heap

```
arr = [90, 15, 10, 7, 12, 100]
```

Tree representation:
```
        90
       /  \
      15   10
     / \   /
    7   12 100  ← 100 > parent 10 — VIOLATION
```

Check at `i=5`: `arr[5]=100` > `arr[2]=10` ✗

Result: **false**

---

## Code Walkthrough

```java
public boolean isMaxHeap(int[] arr) {
    for (int i = arr.length - 1; i >= 1; i--) {
        // Every child must be <= its parent
        if (arr[i] > arr[(i - 1) / 2]) {
            return false;
        }
    }
    return true;
}
```

- Loop starts at the **last element** and goes down to index **1** (skipping index 0 = root, which has no parent).
- `(i - 1) / 2` is integer division — correctly maps to the parent index in a 0-indexed binary heap.
- Early return on the first violation for efficiency.

---

## Edge Cases

| Input | Output | Reason |
|---|---|---|
| `[1]` | `true` | Single element is trivially a max heap |
| `[5, 5, 5]` | `true` | Equal values satisfy `≥` condition |
| `[1, 2]` | `false` | Child (2) > parent (1) — violates max heap |
| `[]` | `true` | Empty array is vacuously a valid heap |
