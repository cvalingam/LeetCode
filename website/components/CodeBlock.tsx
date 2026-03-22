import { createHighlighter } from 'shiki'

type Lang = 'csharp' | 'java'

let highlighter: Awaited<ReturnType<typeof createHighlighter>> | null = null

async function getHighlighter() {
  if (!highlighter) {
    highlighter = await createHighlighter({
      themes: ['github-dark'],
      langs: ['csharp', 'java'],
    })
  }
  return highlighter
}

export default async function CodeBlock({ code, lang = 'csharp' }: { code: string; lang?: Lang }) {
  const hl = await getHighlighter()
  const html = hl.codeToHtml(code, { lang, theme: 'github-dark' })

  return (
    <div
      className="overflow-hidden text-sm leading-relaxed"
      dangerouslySetInnerHTML={{ __html: html }}
    />
  )
}
