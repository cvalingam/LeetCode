# DSA Solutions — Project Guidelines

## What this project is

A Next.js 14 (App Router) website at `website/` that serves:
- **802+ LeetCode C# solutions** from `solutions/NUMBER. Title/NUMBER.cs`
- **530+ GFG Java solutions** from `gfg-solutions/Problem Title/Problem Title.java`

Live at **https://dsasolved.com** — deployed on Vercel from `cvalingam/DSA-Solutions` on GitHub.

## Repository layout

```
solutions/          # LeetCode .cs files  (source of truth)
gfg-solutions/      # GFG .java files     (source of truth)
website/            # Next.js 14 app
  app/              # App Router pages
  components/       # Shared UI components
  lib/              # Data loaders + helpers
  public/           # Static assets
```

## Tech stack

| Layer | Technology |
|-------|-----------|
| Framework | Next.js 14.2, App Router, TypeScript |
| Styling | Tailwind CSS v3 |
| Syntax highlighting | Shiki v1.29 |
| Deployment | Vercel (auto-deploy on push to `main`) |
| Analytics | Google Tag Manager (`GTM-M7QWTWRM`) — fires GA4 (`G-GNGGLPG4SD`) + Microsoft Clarity (`vzu51pq6gv`) |
| Ads | Google AdSense `ca-pub-5486715116636186` |
| Contact form | Formspree `xnjgkaaa` |

## Key files

- `website/lib/constants.ts` — `SITE_URL`, `toLeetCodeSlug()`
- `website/lib/problems.ts` — reads LeetCode `.cs` files, returns `Problem[]`
- `website/lib/gfg-problems.ts` — reads GFG `.java` files, returns `GfgProblem[]`
- `website/lib/difficulty.ts` — maps problem number → difficulty
- `website/app/layout.tsx` — global metadata, GTM script in `<head>`, AdSense in `<head>`
- `website/components/GoogleTagManager.tsx` — GTM `<script>` + `<noscript>` components
- `website/app/sitemap.ts` — custom sitemap (no next-sitemap package)
- `website/app/robots.ts` — disallows `/*?q=`

## Coding conventions

- **Always** import `SITE_URL` from `@/lib/constants` — never hardcode `https://dsasolved.com`
- **Always** use `toLeetCodeSlug(title)` for URL slugs — never inline `.toLowerCase().replace(...)` logic
- JSON-LD structured data goes in the **JSX** as `<script type="application/ld+json" dangerouslySetInnerHTML={...} />` — **never** in `metadata.other` (which emits `<meta>` tags that Google ignores)
- Every page must export `alternates: { canonical: '/path' }` in its metadata
- `openGraph.url` must be set on every page's metadata
- All new pages must be added to `website/app/sitemap.ts`
- Use static dates for `lastModified` in sitemap — never `new Date()` (breaks crawl budget)

## Data model

```ts
// LeetCode
interface Problem {
  number: number      // e.g. 1
  title: string       // e.g. "Two Sum"
  slug: string        // e.g. "1-two-sum"
  difficulty: 'Easy' | 'Medium' | 'Hard' | 'Unknown'
  code: string        // full .cs file contents
}

// GFG
interface GfgProblem {
  title: string       // e.g. "Two Sum"
  slug: string        // kebab-case version of title
  code: string        // full .java file contents
}
```

## Build

```powershell
cd website
npm run build    # must pass before every push
npm run dev      # dev server on http://localhost:3000
```

## Git workflow

```powershell
Set-Location "D:\GitHubDesktop\LeetCode"
git add -A
git commit -m "message"
git push         # triggers Vercel deploy automatically
```

## Environment variables

| Variable | Value | Where set |
|----------|-------|-----------|
| `NEXT_PUBLIC_SITE_URL` | `https://dsasolved.com` | Vercel dashboard (add if missing) |

## SEO conventions

### Metadata — every page must have
```ts
export const metadata: Metadata = {
  title: 'Descriptive Page Title',          // expands via layout template: '%s | DSA Solutions'
  description: '...',
  alternates: { canonical: '/path' },       // REQUIRED — Next.js only emits <link rel="canonical"> when this is set
  openGraph: {
    title: '...',
    description: '...',
    url: '/path',                           // REQUIRED — set per-page, not just in layout
    type: 'website' | 'article',
  },
}
```

### Structured data (JSON-LD) rules
- **Always render as JSX `<script>` tag**, never in `metadata.other`:
  ```tsx
  <script
    type="application/ld+json"
    dangerouslySetInnerHTML={{ __html: JSON.stringify(jsonLd) }}
  />
  ```
- `metadata.other['application/ld+json']` emits a `<meta>` tag — Google ignores it completely
- Detail pages use `@graph` with both `TechArticle` + `BreadcrumbList` schemas
- `TechArticle` must include `datePublished`, `dateModified`, `image`, `url` (pointing to this site)
- Homepage has a `WebSite` schema with `SearchAction` (enables Google Sitelinks Search Box)

### Schemas in use

| Page | Schema(s) |
|------|-----------|
| Homepage (`/`) | `WebSite` + `SearchAction` |
| LeetCode detail (`/problems/[slug]`) | `TechArticle` + `BreadcrumbList` |
| GFG detail (`/gfg/[slug]`) | `TechArticle` + `BreadcrumbList` |

### Sitemap (`website/app/sitemap.ts`)
- Use **static dates** for `lastModified` — never `new Date()` (Googlebot treats daily date changes as low-quality signal)
- LeetCode problem pages: `lastModified: new Date('2024-01-01')`
- GFG problem pages: `lastModified: new Date('2025-06-01')`
- Static pages (about, contact, privacy): `lastModified: new Date('2025-01-01')`

### robots.ts
- Disallow `/*?q=` — prevents search-result URLs from being indexed as thin/duplicate content

### Verified integrations
- **Google Search Console** — verified via `public/googlec62613df22ca3732.html`
- **Bing Webmaster Tools** — verified via `public/BingSiteAuth.xml`
- **Microsoft Clarity** (`vzu51pq6gv`) — analytics script in `layout.tsx` `<head>`
- **Google AdSense** (`ca-pub-5486715116636186`) — script in `layout.tsx` `<head>`; ad slots use `<AdUnit>` component

### Checklist for any new page
- [ ] `alternates.canonical` set
- [ ] `openGraph.url` set
- [ ] Meaningful `title` (not just `'About'` — use `'About DSA Solutions'`)
- [ ] Added to `website/app/sitemap.ts` with a static `lastModified` date
- [ ] JSON-LD in JSX if the page has structured content

## Planned features (implement in this order)

1. **Time & Space complexity** — add `complexity` field to `Problem` (parse from a comment `// Time: O(n) Space: O(n)` in each .cs file); display on detail pages; add to TechArticle JSON-LD
2. **Topic/tag pages** — add `tags` field to `Problem` (from a static tag map in `lib/tags.ts`); create `/topics/[tag]` pages listing all problems for that tag; add tag chips on each detail page
3. **Difficulty stats on homepage** — compute Easy/Medium/Hard counts from problem list; display as summary row above search
4. **Dark mode** — Tailwind `dark:` classes + toggle in Header; persist in `localStorage`
5. **"Was this helpful?" widget** — simple thumbs up/down on detail pages (no backend needed — could link to GitHub Issues or be purely cosmetic)
