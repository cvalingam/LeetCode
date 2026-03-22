import { createHighlighter } from 'shiki'

let highlighter: Awaited<ReturnType<typeof createHighlighter>> | null = null

async function getHighlighter() {
  if (!highlighter) {
    highlighter = await createHighlighter({
      themes: ['github-dark'],
      langs: ['csharp'],
    })
  }
  return highlighter
}

export default async function CodeBlock({ code }: { code: string }) {
  const hl = await getHighlighter()
  const html = hl.codeToHtml(code, { lang: 'csharp', theme: 'github-dark' })

  return (
    <div
      className="rounded-lg overflow-hidden text-sm leading-relaxed"
      dangerouslySetInnerHTML={{ __html: html }}
    />
  )
}
