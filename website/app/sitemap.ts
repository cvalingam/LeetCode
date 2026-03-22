import { MetadataRoute } from 'next'
import { getAllProblemsMeta } from '@/lib/problems'
import { SITE_URL } from '@/lib/constants'

export default function sitemap(): MetadataRoute.Sitemap {
  const problems = getAllProblemsMeta()

  const staticPages: MetadataRoute.Sitemap = [
    { url: `${SITE_URL}/`,               lastModified: new Date(), changeFrequency: 'weekly',  priority: 1.0 },
    { url: `${SITE_URL}/about`,          lastModified: new Date(), changeFrequency: 'monthly', priority: 0.3 },
    { url: `${SITE_URL}/privacy-policy`, lastModified: new Date(), changeFrequency: 'yearly',  priority: 0.2 },
    { url: `${SITE_URL}/contact`,        lastModified: new Date(), changeFrequency: 'yearly',  priority: 0.2 },
  ]

  const problemPages: MetadataRoute.Sitemap = problems.map(p => ({
    url: `${SITE_URL}/problems/${p.slug}`,
    lastModified: new Date(),
    changeFrequency: 'monthly',
    priority: 0.7,
  }))

  return [...staticPages, ...problemPages]
}
