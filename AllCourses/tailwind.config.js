/** @type {import('tailwindcss').Config} */
module.exports = {
    content: [
        './Views/**/*.cshtml', // ֲסו Razor פאיכû
        './wwwroot/**/*.html', // HTML-פאיכû
        './Scripts/**/*.js',    // JavaScript
    ],
  theme: {
    extend: {},
  },
  plugins: [],
}

