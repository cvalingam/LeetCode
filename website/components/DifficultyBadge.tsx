import type { Difficulty } from '@/lib/problems'

const config: Record<Difficulty, { dot: string; text: string; bg: string }> = {
  Easy:    { dot: 'bg-emerald-500', text: 'text-emerald-700 dark:text-emerald-400', bg: 'bg-emerald-50 dark:bg-emerald-950/60' },
  Medium:  { dot: 'bg-amber-500',   text: 'text-amber-700 dark:text-amber-400',   bg: 'bg-amber-50 dark:bg-amber-950/60'   },
  Hard:    { dot: 'bg-red-500',     text: 'text-red-700 dark:text-red-400',     bg: 'bg-red-50 dark:bg-red-950/60'     },
  Unknown: { dot: 'bg-gray-400',    text: 'text-gray-500 dark:text-gray-400',    bg: 'bg-gray-50 dark:bg-gray-800'    },
}

export default function DifficultyBadge({ difficulty }: { difficulty: Difficulty }) {
  const c = config[difficulty]
  return (
    <span className={`inline-flex items-center gap-1.5 px-2.5 py-0.5 rounded-full text-xs font-medium ${c.text} ${c.bg}`}>
      <span className={`w-1.5 h-1.5 rounded-full shrink-0 ${c.dot}`} />
      {difficulty}
    </span>
  )
}
