import { MetadataRoute } from 'next'
import { getAllProblemsMeta } from '@/lib/problems'
import { getAllGfgProblemsMeta } from '@/lib/gfg-problems'
import { getAllTags } from '@/lib/tags'
import { SITE_URL } from '@/lib/constants'

export default function sitemap(): MetadataRoute.Sitemap {
  const problems = getAllProblemsMeta()

  const staticPages: MetadataRoute.Sitemap = [
    { url: `${SITE_URL}/`,               lastModified: new Date('2025-01-01'), changeFrequency: 'weekly',  priority: 1.0 },
    { url: `${SITE_URL}/about`,          lastModified: new Date('2025-01-01'), changeFrequency: 'monthly', priority: 0.3 },
    { url: `${SITE_URL}/privacy-policy`, lastModified: new Date('2025-01-01'), changeFrequency: 'yearly',  priority: 0.2 },
    { url: `${SITE_URL}/contact`,        lastModified: new Date('2025-01-01'), changeFrequency: 'yearly',  priority: 0.2 },
    { url: `${SITE_URL}/terms`,           lastModified: new Date('2026-04-06'), changeFrequency: 'yearly',  priority: 0.2 },
    { url: `${SITE_URL}/topics`,         lastModified: new Date('2026-03-22'), changeFrequency: 'monthly', priority: 0.8 },
  ]

  const tags = getAllTags()
  const topicPages: MetadataRoute.Sitemap = tags.map(({ tag }) => ({
    url: `${SITE_URL}/topics/${tag}`,
    lastModified: new Date('2026-03-22'),
    changeFrequency: 'monthly' as const,
    priority: 0.6,
  }))

  const problemPages: MetadataRoute.Sitemap = problems.map(p => ({
    url: `${SITE_URL}/problems/${p.slug}`,
    lastModified: new Date('2024-01-01'),
    changeFrequency: 'monthly' as const,
    priority: 0.7,
  }))

  const gfgProblems = getAllGfgProblemsMeta()
  const gfgPages: MetadataRoute.Sitemap = [
    { url: `${SITE_URL}/gfg`, lastModified: new Date('2025-01-01'), changeFrequency: 'weekly', priority: 0.9 },
    ...gfgProblems.map(p => ({
      url: `${SITE_URL}/gfg/${p.slug}`,
      lastModified: new Date('2025-06-01'),
      changeFrequency: 'monthly' as const,
      priority: 0.7,
    })),
  ]

  return [...staticPages, ...topicPages, ...problemPages, ...gfgPages]
}
