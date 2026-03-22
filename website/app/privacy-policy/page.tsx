import type { Metadata } from 'next'
import Link from 'next/link'

export const metadata: Metadata = {
  title: 'Privacy Policy',
  description: 'Privacy Policy for the LeetCode C# Solutions website.',
}

export default function PrivacyPolicyPage() {
  return (
    <div className="max-w-2xl mx-auto py-10">
      <h1 className="text-3xl font-bold mb-2">Privacy Policy</h1>
      <p className="text-slate-400 text-sm mb-8"><em>Last updated: March 2026</em></p>

      <p className="text-slate-600 mb-6">
        This Privacy Policy describes how the LeetCode C# Solutions website collects, uses, and
        shares information when you visit.
      </p>

      <Section title="Information we collect">
        <p>
          We do not directly collect personal information. However, third-party services used by
          this site may collect data automatically, including pages visited, browser type, operating
          system, and approximate geographic location.
        </p>
      </Section>

      <Section title="Third-party advertising (Google AdSense)">
        <p>
          This site uses Google AdSense to display advertisements. Google, as a third-party vendor,
          uses cookies to serve ads based on your prior visits to this and other websites. You can
          opt out of personalised advertising by visiting{' '}
          <a href="https://www.google.com/settings/ads" target="_blank" rel="noopener noreferrer" className="text-blue-600 hover:underline">
            Google Ads Settings
          </a>.
        </p>
      </Section>

      <Section title="Analytics">
        <p>
          We may use Google Analytics to understand how visitors interact with the site. This
          information is aggregated and does not personally identify you.
        </p>
      </Section>

      <Section title="Cookies">
        <p>
          Cookies may be placed by Google AdSense or analytics providers. You can control cookies
          through your browser settings.
        </p>
      </Section>

      <Section title="External links">
        <p>
          This site contains links to LeetCode, GitHub, and other external sites. We are not
          responsible for their privacy practices.
        </p>
      </Section>

      <Section title="Children's privacy">
        <p>
          This site is not directed at children under 13 and we do not knowingly collect personal
          information from children.
        </p>
      </Section>

      <Section title="Contact">
        <p>
          If you have questions about this policy, please use the{' '}
          <Link href="/contact" className="text-blue-600 hover:underline">Contact page</Link>.
        </p>
      </Section>

      <div className="mt-10">
        <Link href="/" className="text-blue-600 hover:underline text-sm">← Back to all problems</Link>
      </div>
    </div>
  )
}

function Section({ title, children }: { title: string; children: React.ReactNode }) {
  return (
    <div className="mb-6">
      <h2 className="text-lg font-semibold mb-2">{title}</h2>
      <div className="text-slate-600">{children}</div>
    </div>
  )
}
