import type { Metadata } from 'next'
import Link from 'next/link'

export const metadata: Metadata = {
  title: 'Contact',
  description: 'Contact Sivalingam Ramasamy — LeetCode C# Solutions.',
  alternates: { canonical: '/contact' },
}

export default function ContactPage() {
  return (
    <div className="max-w-2xl mx-auto py-10">
      <h1 className="text-3xl font-bold mb-2 dark:text-gray-100">Contact</h1>
      <p className="text-slate-500 dark:text-slate-400 mb-8">Have a question or spotted an issue with a solution? Reach out below.</p>

      <h2 className="text-lg font-semibold mb-2 dark:text-gray-200">GitHub Issues (preferred)</h2>
      <p className="text-slate-600 dark:text-slate-300 mb-6">
        The fastest way to report a bug or suggest a fix is to open a{' '}
        <a
          href="https://github.com/cvalingam/DSA-Solutions/issues"
          target="_blank"
          rel="noopener noreferrer"
          className="text-blue-600 hover:underline"
        >
          GitHub Issue
        </a>.
      </p>

      <h2 className="text-lg font-semibold mb-4 dark:text-gray-200">Send a message</h2>

      <form
        action="https://formspree.io/f/xnjgkaaa"
        method="POST"
        className="flex flex-col gap-4 max-w-md"
      >
        <input
          type="text"
          name="name"
          placeholder="Your name"
          required
          className="px-3 py-2 border border-slate-200 dark:border-gray-700 rounded-lg text-sm bg-white dark:bg-gray-800 dark:text-gray-100 dark:placeholder-gray-500 focus:outline-none focus:border-blue-500 dark:focus:border-blue-400 transition-colors"
        />
        <input
          type="email"
          name="email"
          placeholder="Your email address"
          required
          className="px-3 py-2 border border-slate-200 dark:border-gray-700 rounded-lg text-sm bg-white dark:bg-gray-800 dark:text-gray-100 dark:placeholder-gray-500 focus:outline-none focus:border-blue-500 dark:focus:border-blue-400 transition-colors"
        />
        <input
          type="text"
          name="subject"
          placeholder="Subject"
          required
          className="px-3 py-2 border border-slate-200 dark:border-gray-700 rounded-lg text-sm bg-white dark:bg-gray-800 dark:text-gray-100 dark:placeholder-gray-500 focus:outline-none focus:border-blue-500 dark:focus:border-blue-400 transition-colors"
        />
        <textarea
          name="message"
          placeholder="Your message…"
          rows={5}
          required
          className="px-3 py-2 border border-slate-200 dark:border-gray-700 rounded-lg text-sm bg-white dark:bg-gray-800 dark:text-gray-100 dark:placeholder-gray-500 focus:outline-none focus:border-blue-500 dark:focus:border-blue-400 transition-colors resize-y"
        />
        <button
          type="submit"
          className="self-start px-6 py-2 bg-blue-600 text-white rounded-lg text-sm font-semibold hover:bg-blue-700 transition-colors"
        >
          Send Message
        </button>
      </form>

      <p className="mt-4 text-xs text-slate-400 dark:text-slate-500">
        We typically respond within 24–48 hours.
      </p>

      <div className="mt-10">
        <Link href="/" className="text-blue-600 hover:underline text-sm">← Back to all problems</Link>
      </div>
    </div>
  )
}
