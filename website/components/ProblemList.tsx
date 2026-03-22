'use client'

import Link from 'next/link'
import { useMemo, useState } from 'react'
import type { ProblemMeta, Difficulty } from '@/lib/problems'
import DifficultyBadge from './DifficultyBadge'
import AdUnit from './AdUnit'

type Filter = 'All' | Difficulty

const FILTERS: Filter[] = ['All', 'Easy', 'Medium', 'Hard']

export default function ProblemList({
  problems,
  initialQuery = '',
}: {
  problems: ProblemMeta[]
  initialQuery?: string
}) {
  const [search, setSearch] = useState(initialQuery)
  const [filter, setFilter] = useState<Filter>('All')

  const { easy, medium, hard } = useMemo(() => ({
    easy:   problems.filter(p => p.difficulty === 'Easy').length,
    medium: problems.filter(p => p.difficulty === 'Medium').length,
    hard:   problems.filter(p => p.difficulty === 'Hard').length,
  }), [problems])

  const filtered = useMemo(() => {
    const term = search.trim().toLowerCase()
    return problems.filter(p => {
      const matchSearch =
        !term ||
        p.title.toLowerCase().includes(term) ||
        String(p.number).includes(term)
      const matchFilter = filter === 'All' || p.difficulty === filter
      return matchSearch && matchFilter
    })
  }, [problems, search, filter])

  return (
    <>
      {/* Hero */}
      <section className="text-center py-10">
        <h1 className="text-3xl sm:text-4xl font-extrabold tracking-tight mb-2">
          LeetCode <span className="text-blue-600">C#</span> Solutions
        </h1>
        <p className="text-slate-500 mb-8">
          Clean, readable C# solutions — built for .NET developers cracking the coding interview.
        </p>
        <div className="flex justify-center gap-10 flex-wrap">
          <Stat value={problems.length} label="Solved" color="text-blue-600" />
          <Stat value={easy}            label="Easy"   color="text-green-600" />
          <Stat value={medium}          label="Medium" color="text-yellow-600" />
          <Stat value={hard}            label="Hard"   color="text-red-600" />
        </div>
      </section>

      {/* AdSense — replace slot with your real ad unit ID after approval */}
      <AdUnit slot="YOUR_AD_SLOT" style="leaderboard" className="mb-6" />

      {/* Search + Filters */}
      <div className="flex flex-wrap items-center gap-3 mb-4">
        <input
          type="text"
          value={search}
          onChange={e => setSearch(e.target.value)}
          placeholder="Search by number or title…"
          className="flex-1 min-w-[180px] max-w-sm px-3 py-1.5 text-sm border border-slate-200 rounded-md focus:outline-none focus:border-blue-500 bg-slate-50 focus:bg-white transition-colors"
        />
        <div className="flex gap-2 flex-wrap">
          {FILTERS.map(f => (
            <button
              key={f}
              onClick={() => setFilter(f)}
              className={`px-4 py-1 rounded-full text-sm border transition-colors ${
                filter === f
                  ? 'border-blue-600 text-blue-600 bg-blue-50'
                  : 'border-slate-200 text-slate-500 hover:border-blue-400 hover:text-blue-500'
              }`}
            >
              {f}
            </button>
          ))}
        </div>
      </div>

      <p className="text-sm text-slate-400 mb-3">
        Showing {filtered.length} problem{filtered.length !== 1 ? 's' : ''}
      </p>

      {/* Problem table */}
      {filtered.length === 0 ? (
        <div className="text-center py-20 text-slate-400">No problems match your search.</div>
      ) : (
        <div className="overflow-x-auto rounded-lg border border-slate-200">
          <table className="w-full text-sm">
            <thead className="bg-slate-50 text-xs uppercase text-slate-400 tracking-wide">
              <tr>
                <th className="px-4 py-3 text-left w-16">#</th>
                <th className="px-4 py-3 text-left">Title</th>
                <th className="px-4 py-3 text-left w-28">Difficulty</th>
              </tr>
            </thead>
            <tbody className="divide-y divide-slate-100">
              {filtered.map(p => (
                <tr key={p.slug} className="hover:bg-slate-50 transition-colors">
                  <td className="px-4 py-2.5 text-slate-400">{p.number}</td>
                  <td className="px-4 py-2.5">
                    <Link
                      href={`/problems/${p.slug}`}
                      className="font-medium text-slate-800 hover:text-blue-600 transition-colors"
                    >
                      {p.title}
                    </Link>
                  </td>
                  <td className="px-4 py-2.5">
                    <DifficultyBadge difficulty={p.difficulty} />
                  </td>
                </tr>
              ))}
            </tbody>
          </table>
        </div>
      )}
    </>
  )
}

function Stat({ value, label, color }: { value: number; label: string; color: string }) {
  return (
    <div className="text-center">
      <div className={`text-3xl font-bold ${color}`}>{value}</div>
      <div className="text-xs text-slate-400 uppercase tracking-widest mt-1">{label}</div>
    </div>
  )
}
