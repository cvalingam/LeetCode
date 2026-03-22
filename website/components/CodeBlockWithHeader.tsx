import CodeBlock, { type SupportedLang } from './CodeBlock'
import CopyButton from './CopyButton'

export type { SupportedLang }

const langLabel: Record<SupportedLang, string> = {
  csharp:     'C#',
  java:       'Java',
  typescript: 'TypeScript',
  sql:        'MySQL',
  go:         'Go',
  cpp:        'C++',
  python:     'Python',
  bash:       'Shell',
}

const langColors: Record<SupportedLang, string> = {
  csharp:     'bg-indigo-500/20 text-indigo-300',
  java:       'bg-orange-500/20 text-orange-300',
  typescript: 'bg-blue-500/20 text-blue-300',
  sql:        'bg-yellow-500/20 text-yellow-300',
  go:         'bg-cyan-500/20 text-cyan-300',
  cpp:        'bg-purple-500/20 text-purple-300',
  python:     'bg-green-500/20 text-green-300',
  bash:       'bg-gray-500/20 text-gray-300',
}

export default function CodeBlockWithHeader({
  code,
  lang = 'csharp',
  filename,
}: {
  code: string
  lang?: SupportedLang
  filename?: string
}) {
  return (
    <div className="rounded-xl overflow-hidden border border-gray-200 shadow-sm">
      {/* Header bar */}
      <div className="flex items-center justify-between px-4 py-2.5 bg-[#0d1117] border-b border-white/10">
        <div className="flex items-center gap-3">
          {/* Traffic-light dots */}
          <div className="flex gap-1.5" aria-hidden="true">
            <span className="w-3 h-3 rounded-full bg-red-500/70" />
            <span className="w-3 h-3 rounded-full bg-yellow-500/70" />
            <span className="w-3 h-3 rounded-full bg-green-500/70" />
          </div>
          {filename && (
            <span className="text-xs text-gray-400 font-mono">{filename}</span>
          )}
        </div>
        <div className="flex items-center gap-3">
          <span className={`text-[11px] px-2 py-0.5 rounded font-semibold font-mono ${langColors[lang]}`}>
            {langLabel[lang]}
          </span>
          <CopyButton code={code} />
        </div>
      </div>

      {/* Code */}
      <CodeBlock code={code} lang={lang} />
    </div>
  )
}
