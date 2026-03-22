'use client'

import Link from 'next/link'
import { usePathname, useRouter } from 'next/navigation'
import { useState } from 'react'

export default function Header() {
  const router  = useRouter()
  const pathname = usePathname()
  const [query, setQuery] = useState('')

  function handleSearch(e: React.KeyboardEvent<HTMLInputElement>) {
    if (e.key === 'Enter' && query.trim()) {
      router.push(`/?q=${encodeURIComponent(query.trim())}`)
    }
    if (e.key === 'Escape') setQuery('')
  }

  const isLc  = pathname === '/' || pathname.startsWith('/problems')
  const isGfg = pathname.startsWith('/gfg')

  return (
    <header className="fixed top-0 left-0 right-0 z-50 h-14 bg-white/80 backdrop-blur-md border-b border-gray-200/60 shadow-sm">
      <div className="max-w-5xl mx-auto px-4 sm:px-6 h-full flex items-center gap-3">

        {/* Logo */}
        <Link
          href="/"
          className="flex items-center gap-2 font-extrabold text-gray-900 tracking-tight shrink-0 hover:opacity-75 transition-opacity"
        >
          <span className="w-7 h-7 rounded-lg bg-gradient-to-br from-indigo-500 to-violet-600 text-white text-[11px] flex items-center justify-center font-black shadow-sm">
            D
          </span>
          <span className="hidden sm:inline">
            DSA <span className="text-indigo-600">Solutions</span>
          </span>
          <span className="sm:hidden text-indigo-600">DSA</span>
        </Link>

        {/* Search */}
        <div className="relative flex-1 max-w-xs hidden sm:block">
          <svg
            className="absolute left-3 top-1/2 -translate-y-1/2 w-3.5 h-3.5 text-gray-400 pointer-events-none"
            fill="none" viewBox="0 0 24 24" stroke="currentColor" strokeWidth={2.5}
          >
            <path strokeLinecap="round" strokeLinejoin="round" d="M21 21l-4.35-4.35M17 11A6 6 0 1 1 5 11a6 6 0 0 1 12 0z" />
          </svg>
          <input
            type="text"
            value={query}
            onChange={e => setQuery(e.target.value)}
            onKeyDown={handleSearch}
            placeholder="Search problems…"
            autoComplete="off"
            className="w-full pl-8 pr-9 py-1.5 text-sm border border-gray-200 rounded-lg bg-gray-50/80 focus:outline-none focus:border-indigo-400 focus:bg-white focus:ring-2 focus:ring-indigo-100 transition-all"
          />
          <kbd className="absolute right-2.5 top-1/2 -translate-y-1/2 pointer-events-none text-[10px] text-gray-300 font-mono">↵</kbd>
        </div>

        {/* Nav */}
        <nav className="ml-auto flex items-center gap-0.5 text-sm">
          <NavLink href="/"    active={isLc}  label="LeetCode" />
          <NavLink href="/gfg" active={isGfg} label="GFG"      activeColor="text-emerald-600 bg-emerald-50" hoverColor="hover:text-emerald-600 hover:bg-emerald-50/60" />
          <NavLink href="/about" active={pathname === '/about'} label="About" className="hidden md:inline-flex" />
          <NavLink href="/contact" active={pathname === '/contact'} label="Contact" className="hidden md:inline-flex" />
          <a
            href="https://github.com/cvalingam/DSA-Solutions"
            target="_blank"
            rel="noopener noreferrer"
            aria-label="GitHub repository"
            className="ml-1 p-2 rounded-lg text-gray-500 hover:text-gray-900 hover:bg-gray-100 transition-all"
          >
            <GitHubIcon />
          </a>
        </nav>

      </div>
    </header>
  )
}

function NavLink({
  href, active, label, className = '',
  activeColor = 'text-indigo-600 bg-indigo-50',
  hoverColor  = 'hover:text-indigo-600 hover:bg-indigo-50/60',
}: {
  href: string; active: boolean; label: string
  className?: string; activeColor?: string; hoverColor?: string
}) {
  return (
    <Link
      href={href}
      className={`px-3 py-1.5 rounded-lg font-medium transition-all ${className} ${
        active
          ? `${activeColor}`
          : `text-gray-500 ${hoverColor}`
      }`}
    >
      {label}
    </Link>
  )
}

function GitHubIcon() {
  return (
    <svg className="w-4 h-4" fill="currentColor" viewBox="0 0 24 24" aria-hidden="true">
      <path d="M12 2C6.477 2 2 6.484 2 12.017c0 4.425 2.865 8.18 6.839 9.504.5.092.682-.217.682-.483 0-.237-.008-.868-.013-1.703-2.782.605-3.369-1.343-3.369-1.343-.454-1.158-1.11-1.466-1.11-1.466-.908-.62.069-.608.069-.608 1.003.07 1.531 1.032 1.531 1.032.892 1.53 2.341 1.088 2.91.832.092-.647.35-1.088.636-1.338-2.22-.253-4.555-1.113-4.555-4.951 0-1.093.39-1.988 1.029-2.688-.103-.253-.446-1.272.098-2.65 0 0 .84-.27 2.75 1.026A9.564 9.564 0 0 1 12 6.844a9.59 9.59 0 0 1 2.504.337c1.909-1.296 2.747-1.027 2.747-1.027.546 1.379.202 2.398.1 2.651.64.7 1.028 1.595 1.028 2.688 0 3.848-2.339 4.695-4.566 4.943.359.309.678.92.678 1.855 0 1.338-.012 2.419-.012 2.747 0 .268.18.58.688.482A10.02 10.02 0 0 0 22 12.017C22 6.484 17.522 2 12 2z" />
    </svg>
  )
}
