'use client'

import { useState } from 'react'
import React from 'react'

const EXT_TO_LABEL: Record<string, string> = {
  cs:   'C#',
  java: 'Java',
  sql:  'MySQL',
  ts:   'TypeScript',
  go:   'Go',
  cpp:  'C++',
  py:   'Python',
  sh:   'Shell',
}

export default function LanguageTabs({
  extensions,
  children,
}: {
  extensions: string[]
  children: React.ReactNode
}) {
  const [activeIndex, setActiveIndex] = useState(0)
  const childArray = React.Children.toArray(children)

  return (
    <div>
      {/* Language pill tabs */}
      <div className="flex flex-wrap gap-1.5 mb-3">
        {extensions.map((ext, i) => (
          <button
            key={ext}
            onClick={() => setActiveIndex(i)}
            className={`px-3 py-1 text-xs font-medium rounded-full border transition-colors ${
              i === activeIndex
                ? 'bg-indigo-600 text-white border-indigo-600'
                : 'bg-white dark:bg-gray-800 text-gray-500 dark:text-gray-400 border-gray-200 dark:border-gray-700 hover:border-indigo-300 dark:hover:border-indigo-600 hover:text-indigo-600 dark:hover:text-indigo-400'
            }`}
          >
            {EXT_TO_LABEL[ext] ?? ext}
          </button>
        ))}
      </div>

      {/* Show only the active code block */}
      {childArray.map((child, i) => (
        <div key={i} className={i === activeIndex ? '' : 'hidden'}>
          {child}
        </div>
      ))}
    </div>
  )
}
