import { readFileSync, readdirSync } from 'fs'
import path from 'path'
import { fileURLToPath } from 'url'

const __dirname = path.dirname(fileURLToPath(import.meta.url))

const content = readFileSync(path.join(__dirname, '../lib/tags.ts'), 'utf-8')
const matches = content.matchAll(/^\s+(\d+):/gm)
const taggedNums = new Set([...matches].map(m => parseInt(m[1])))

const solutionsDir = path.join(__dirname, '../../solutions')
const folders = readdirSync(solutionsDir).filter(f => /^\d+\./.test(f))
const allNums = folders.map(f => parseInt(f.match(/^(\d+)/)[1])).sort((a, b) => a - b)

const missing = allNums.filter(n => !taggedNums.has(n))
console.log(`Total problems: ${allNums.length}`)
console.log(`Tagged: ${taggedNums.size}`)
console.log(`Missing tags: ${missing.length}`)
console.log('Missing:', missing.join(', '))
