import fs from 'fs'
import path from 'path'
import { getDifficulty } from './difficulty'
import { getTagsForProblem, type Tag } from './tags'

// solutions/ lives one level above the website/ folder
const SOLUTIONS_DIR = path.join(process.cwd(), '..', 'solutions')

export type Difficulty = 'Easy' | 'Medium' | 'Hard' | 'Unknown'

export interface Problem {
  number: number
  title: string
  slug: string        // e.g. "100-same-tree"
  difficulty: Difficulty
  tags: Tag[]
  code: string
  extraCodes?: Record<string, string>  // extension → code, e.g. { java: '...', sql: '...' }
}

export interface ProblemMeta {
  number: number
  title: string
  slug: string
  difficulty: Difficulty
  tags: Tag[]
}

export function toSlug(number: number, title: string): string {
  const clean = title
    .toLowerCase()
    .replace(/[^a-z0-9\s]/g, '')
    .replace(/\s+/g, '-')
    .replace(/-+/g, '-')
    .trim()
  return `${number}-${clean}`
}

// Module-level cache — built once per build process
let _problems: Problem[] | null = null

export function getAllProblems(): Problem[] {
  if (_problems) return _problems

  if (!fs.existsSync(SOLUTIONS_DIR)) {
    console.warn(`[problems] solutions directory not found: ${SOLUTIONS_DIR}`)
    return []
  }

  const folders = fs.readdirSync(SOLUTIONS_DIR, { withFileTypes: true })
    .filter(d => d.isDirectory())
    .map(d => d.name)
    .filter(name => /^\d+\.\s+/.test(name))
    .sort((a, b) => {
      const na = parseInt(a.match(/^(\d+)/)![1])
      const nb = parseInt(b.match(/^(\d+)/)![1])
      return na - nb
    })

  const result: Problem[] = []

  for (const folder of folders) {
    const m = folder.match(/^(\d+)\.\s+(.+)$/)
    if (!m) continue

    const number = parseInt(m[1])
    const title = m[2].trim()
    const folderPath = path.join(SOLUTIONS_DIR, folder)

    const csFile = fs.readdirSync(folderPath).find(f => f.endsWith('.cs'))
    if (!csFile) continue

    const code = fs.readFileSync(path.join(folderPath, csFile), 'utf-8')

    // Read any other language files in the same folder
    const EXTRA_EXTS = ['java', 'sql', 'ts', 'go', 'cpp', 'py', 'sh']
    const extraCodes: Record<string, string> = {}
    for (const file of fs.readdirSync(folderPath)) {
      const ext = path.extname(file).slice(1)
      if (EXTRA_EXTS.includes(ext)) {
        extraCodes[ext] = fs.readFileSync(path.join(folderPath, file), 'utf-8')
      }
    }

    result.push({
      number,
      title,
      slug: toSlug(number, title),
      difficulty: getDifficulty(number),
      tags: getTagsForProblem(number),
      code,
      ...(Object.keys(extraCodes).length > 0 ? { extraCodes } : {}),
    })
  }

  _problems = result
  return result
}

export function getAllProblemsMeta(): ProblemMeta[] {
  return getAllProblems().map(({ number, title, slug, difficulty, tags }) => ({
    number, title, slug, difficulty, tags,
  }))
}

export function getProblemBySlug(slug: string): Problem | undefined {
  return getAllProblems().find(p => p.slug === slug)
}

export function getAdjacentProblems(slug: string): {
  prev: ProblemMeta | null
  next: ProblemMeta | null
} {
  const all = getAllProblems()
  const idx = all.findIndex(p => p.slug === slug)
  return {
    prev: idx > 0 ? all[idx - 1] : null,
    next: idx < all.length - 1 ? all[idx + 1] : null,
  }
}
