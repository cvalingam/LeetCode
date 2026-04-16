import fs from 'fs'
import path from 'path'

// gfg-solutions/ lives one level above the website/ folder
const GFG_DIR = process.env.GFG_SOLUTIONS_DIR
  ? path.resolve(process.env.GFG_SOLUTIONS_DIR)
  : path.join(process.cwd(), '..', 'gfg-solutions')

export interface GfgProblem {
  title: string
  slug: string  // e.g. "two-sum-pair-with-given-sum"
  code: string
  approach?: string  // parsed from "// Approach: ..." multi-line comment block
  complexity?: { time: string; space: string }
}

export interface GfgProblemMeta {
  title: string
  slug: string
}

function toSlug(title: string): string {
  return title
    .toLowerCase()
    .replace(/[^a-z0-9\s]/g, '')
    .replace(/\s+/g, '-')
    .replace(/-+/g, '-')
    .trim()
}

let _problems: GfgProblem[] | null = null

export function getAllGfgProblems(): GfgProblem[] {
  if (_problems) return _problems

  if (!fs.existsSync(GFG_DIR)) {
    console.warn(`[gfg-problems] solutions directory not found: ${GFG_DIR}`)
    return []
  }

  const folders = fs.readdirSync(GFG_DIR, { withFileTypes: true })
    .filter(d => d.isDirectory())
    .map(d => d.name)
    .sort((a, b) => a.localeCompare(b))

  const result: GfgProblem[] = []

  for (const folder of folders) {
    const folderPath = path.join(GFG_DIR, folder)
    const javaFile = fs.readdirSync(folderPath).find(f => f.endsWith('.java'))
    if (!javaFile) continue

    const code = fs.readFileSync(path.join(folderPath, javaFile), 'utf-8')

    // Parse approach + complexity from comment block starting with "// Approach:"
    const approachLines: string[] = []
    let complexityResult: { time: string; space: string } | undefined
    let inApproach = false
    for (const line of code.split('\n')) {
      const t = line.trim()
      if (!inApproach) {
        const m = t.match(/^\/\/\s*Approach:\s*(.*)/)
        if (m) { inApproach = true; if (m[1].trim()) approachLines.push(m[1].trim()) }
      } else {
        if (t.match(/^\/\/\s*Time:/i)) {
          const cm = t.match(/^\/\/\s*Time:\s*(\S+)\s+Space:\s*(\S+)/i)
          if (cm) complexityResult = { time: cm[1].trim(), space: cm[2].trim() }
          break
        }
        const cm = t.match(/^\/\/\s*(.+)/)
        if (cm) approachLines.push(cm[1].trim())
        else break
      }
    }
    const approach = approachLines.length > 0 ? approachLines.join('\n') : undefined

    result.push({
      title: folder,
      slug: toSlug(folder),
      code,
      ...(approach ? { approach } : {}),
      ...(complexityResult ? { complexity: complexityResult } : {}),
    })
  }

  _problems = result
  return result
}

export function getAllGfgProblemsMeta(): GfgProblemMeta[] {
  return getAllGfgProblems().map(({ title, slug }) => ({ title, slug }))
}

export function getGfgProblemBySlug(slug: string): GfgProblem | undefined {
  return getAllGfgProblems().find(p => p.slug === slug)
}

export function getAdjacentGfgProblems(slug: string): {
  prev: GfgProblemMeta | null
  next: GfgProblemMeta | null
} {
  const all = getAllGfgProblems()
  const idx = all.findIndex(p => p.slug === slug)
  return {
    prev: idx > 0 ? all[idx - 1] : null,
    next: idx < all.length - 1 ? all[idx + 1] : null,
  }
}
