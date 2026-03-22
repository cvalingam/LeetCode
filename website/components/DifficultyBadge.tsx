import type { Difficulty } from '@/lib/problems'

const styles: Record<Difficulty, string> = {
  Easy:    'bg-green-100 text-green-700',
  Medium:  'bg-yellow-100 text-yellow-700',
  Hard:    'bg-red-100   text-red-700',
  Unknown: 'bg-slate-100 text-slate-500',
}

export default function DifficultyBadge({ difficulty }: { difficulty: Difficulty }) {
  return (
    <span className={`inline-block px-2.5 py-0.5 rounded text-xs font-bold ${styles[difficulty]}`}>
      {difficulty}
    </span>
  )
}
