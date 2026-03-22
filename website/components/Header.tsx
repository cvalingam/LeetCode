'use client'

import Link from 'next/link'
import { useRouter } from 'next/navigation'
import { useState } from 'react'

export default function Header() {
  const router = useRouter()
  const [query, setQuery] = useState('')

  function handleSearch(e: React.KeyboardEvent<HTMLInputElement>) {
    if (e.key === 'Enter' && query.trim()) {
      router.push(`/?q=${encodeURIComponent(query.trim())}`)
    }
    if (e.key === 'Escape') {
      setQuery('')
    }
  }

  return (
    <header className="fixed top-0 left-0 right-0 z-50 h-14 bg-white border-b border-slate-200 flex items-center gap-4 px-4 sm:px-6">
      <Link href="/" className="font-extrabold text-slate-900 tracking-tight shrink-0">
        DSA <span className="text-blue-600">Solutions</span>
      </Link>

      <div className="relative max-w-xs w-full">
        <span className="absolute left-3 top-1/2 -translate-y-1/2 text-slate-400 text-sm pointer-events-none">
          &#128269;
        </span>
        <input
          type="text"
          value={query}
          onChange={e => setQuery(e.target.value)}
          onKeyDown={handleSearch}
          placeholder="Search problems…"
          autoComplete="off"
          className="w-full pl-8 pr-3 py-1.5 text-sm border border-slate-200 rounded-md bg-slate-50 focus:outline-none focus:border-blue-500 focus:bg-white transition-colors"
        />
      </div>

      <nav className="ml-auto flex items-center gap-5 text-sm text-slate-500">
        <Link href="/" className="hover:text-blue-600 transition-colors">LeetCode</Link>
        <Link href="/gfg" className="hover:text-green-600 transition-colors hidden sm:block">GFG</Link>
        <Link href="/about" className="hover:text-blue-600 transition-colors hidden sm:block">About</Link>
        <a
          href="https://github.com/cvalingam/DSA-Solutions"
          target="_blank"
          rel="noopener noreferrer"
          className="hover:text-blue-600 transition-colors"
        >
          GitHub
        </a>
      </nav>
    </header>
  )
}
