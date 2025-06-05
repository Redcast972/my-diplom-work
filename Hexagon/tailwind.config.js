/** @type {import('tailwindcss').Config} */
module.exports = {
    content: [
        './Views/**/*.cshtml', // ��� Razor �����
        './wwwroot/**/*.html', // HTML-�����
        './Scripts/**/*.js',    // JavaScript
    ],
  theme: {
    extend: {},
  },
  plugins: [],
}

