'use client'

import Link from 'next/link'
import { useEffect, useMemo, useState } from 'react'
import { useSearchParams } from 'next/navigation'
import type { ProblemMeta, Difficulty } from '@/lib/problems'
import DifficultyBadge from './DifficultyBadge'
import AdUnit from './AdUnit'

type Filter = 'All' | Difficulty

const FILTERS: Filter[] = ['All', 'Easy', 'Medium', 'Hard']

const filterActive: Record<Filter, string> = {
  All:     'bg-indigo-600   border-indigo-600   text-white',
  Easy:    'bg-emerald-500  border-emerald-500  text-white',
  Medium:  'bg-amber-500    border-amber-500    text-white',
  Hard:    'bg-red-500      border-red-500      text-white',
  Unknown: 'bg-gray-500     border-gray-500     text-white',
}

export default function ProblemList({
  problems,
}: {
  problems: ProblemMeta[]
}) {
  const searchParams = useSearchParams()
  const initialQuery = searchParams.get('q') ?? ''
  const [search, setSearch] = useState(initialQuery)
  const [filter, setFilter] = useState<Filter>('All')

  useEffect(() => { setSearch(initialQuery) }, [initialQuery])

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
      <section className="relative overflow-hidden rounded-2xl bg-gradient-to-br from-indigo-600 via-indigo-700 to-violet-700 px-6 py-10 mb-8 text-white shadow-lg">
        <div className="absolute inset-0 bg-[radial-gradient(ellipse_at_top_right,_rgba(255,255,255,0.1)_0%,_transparent_55%)] pointer-events-none" />
        <div className="relative">
          <div className="inline-flex items-center gap-2 bg-white/10 backdrop-blur-sm rounded-full px-3 py-1 text-xs font-medium mb-4">
            <span className="w-1.5 h-1.5 rounded-full bg-emerald-400 animate-pulse" />
            Updated daily
          </div>
          <h1 className="text-3xl sm:text-4xl font-extrabold tracking-tight mb-2">
            LeetCode <span className="text-indigo-200">C# Solutions</span>
          </h1>
          <p className="text-indigo-200 text-sm sm:text-base mb-8 max-w-xl">
            Clean, readable C# solutions — built for .NET developers cracking the coding interview.
          </p>
          <div className="flex gap-8 flex-wrap">
            <Stat value={problems.length} label="Solved"  />
            <Stat value={easy}            label="Easy"    dim />
            <Stat value={medium}          label="Medium"  dim />
            <Stat value={hard}            label="Hard"    dim />
          </div>
        </div>
      </section>

      {/* AdSense */}
      <AdUnit slot="YOUR_AD_SLOT" style="leaderboard" className="mb-6" />

      {/* Search + Filters */}
      <div className="flex flex-wrap items-center gap-3 mb-4">
        <div className="relative flex-1 min-w-[200px] max-w-sm">
          <svg
            className="absolute left-3 top-1/2 -translate-y-1/2 w-3.5 h-3.5 text-gray-400 pointer-events-none"
            fill="none" viewBox="0 0 24 24" stroke="currentColor" strokeWidth={2.5}
          >
            <path strokeLinecap="round" strokeLinejoin="round" d="M21 21l-4.35-4.35M17 11A6 6 0 1 1 5 11a6 6 0 0 1 12 0z" />
          </svg>
          <input
            type="text"
            value={search}
            onChange={e => setSearch(e.target.value)}
            placeholder="Search by number or title…"
            className="w-full pl-8 pr-3 py-2 text-sm border border-gray-200 rounded-lg bg-white focus:outline-none focus:border-indigo-400 focus:ring-2 focus:ring-indigo-100 transition-all shadow-sm"
          />
        </div>
        <div className="flex gap-1.5 flex-wrap">
          {FILTERS.map(f => (
            <button
              key={f}
              onClick={() => setFilter(f)}
              className={`px-3.5 py-1.5 rounded-lg text-xs font-semibold border transition-all ${
                filter === f
                  ? filterActive[f]
                  : 'border-gray-200 text-gray-500 bg-white hover:border-gray-300 hover:bg-gray-50'
              }`}
            >
              {f}
            </button>
          ))}
        </div>
      </div>

      <p className="text-xs text-gray-400 mb-3 tabular-nums">
        {filtered.length} problem{filtered.length !== 1 ? 's' : ''}
      </p>

      {/* Problem table */}
      {filtered.length === 0 ? (
        <div className="text-center py-20 text-gray-400">
          <div className="text-4xl mb-3">🔍</div>
          <p>No problems match your search.</p>
        </div>
      ) : (
        <div className="overflow-hidden rounded-xl border border-gray-200 shadow-sm bg-white">
          <table className="w-full text-sm">
            <thead>
              <tr className="border-b border-gray-100 bg-gray-50/80">
                <th className="px-4 py-3 text-left text-[11px] font-semibold text-gray-400 uppercase tracking-wider w-14">#</th>
                <th className="px-4 py-3 text-left text-[11px] font-semibold text-gray-400 uppercase tracking-wider">Title</th>
                <th className="px-4 py-3 text-left text-[11px] font-semibold text-gray-400 uppercase tracking-wider w-28">Difficulty</th>
              </tr>
            </thead>
            <tbody className="divide-y divide-gray-50">
              {filtered.map(p => (
                <tr key={p.slug} className="hover:bg-indigo-50/30 transition-colors group">
                  <td className="px-4 py-3 text-gray-400 tabular-nums font-mono text-xs">{p.number}</td>
                  <td className="px-4 py-3">
                    <Link
                      href={`/problems/${p.slug}`}
                      className="font-medium text-gray-800 group-hover:text-indigo-600 transition-colors"
                    >
                      {p.title}
                    </Link>
                  </td>
                  <td className="px-4 py-3">
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

function Stat({ value, label, dim }: { value: number; label: string; dim?: boolean }) {
  return (
    <div>
      <div className={`text-2xl font-bold tabular-nums ${dim ? 'text-white/70' : 'text-white'}`}>{value}</div>
      <div className={`text-[11px] uppercase tracking-widest mt-0.5 ${dim ? 'text-white/40' : 'text-white/60'}`}>{label}</div>
    </div>
  )
}
