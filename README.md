# Hexagon UI Guidelines

This document outlines the design principles used for the Razor MVC application in this repository.

## Theme

- **Dark base** with contrasting text and UI elements.
- Vibrant accent colors are defined in `tailwind.config.js` as `accent.pink`, `accent.violet` and `accent.cyan`.
- Glassmorphism is provided with the `.glass` utility in `site.css`.
- Dark mode is enabled via `class="dark"` on the `<html>` element.

## Layout

- Top navigation implemented in `_Layout.cshtml` with floating animated circles for visual interest.
- Responsive layout uses Tailwind CSS classes. The site font is `Inter`.

## Components

- Cards and detail sections use `bg-white` on a dark background to create contrast.
- Animations rely on custom keyframes defined in Tailwind (see the `float` animation).

## Example sidebar layout

```
@*
    Views/Shared/_DashboardLayout.cshtml
*@
<!DOCTYPE html>
<html lang="en" class="dark">
<head>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <title>@ViewData["Title"] - Hexagon</title>
    <link rel="stylesheet" href="~/css/output.css" asp-append-version="true" />
</head>
<body class="font-sans bg-slate-900 text-gray-200 min-h-screen flex">
    <aside class="w-64 p-4 space-y-2 bg-white/10 backdrop-blur-lg hidden md:block">
        <nav class="space-y-1">
            <a asp-controller="Home" asp-action="Index" class="block px-2 py-1 rounded hover:bg-accent-pink/20">Dashboard</a>
            <a asp-controller="Users" asp-action="Index" class="block px-2 py-1 rounded hover:bg-accent-violet/20">Users</a>
            <a asp-controller="Products" asp-action="Index" class="block px-2 py-1 rounded hover:bg-accent-cyan/20">Products</a>
        </nav>
    </aside>
    <main class="flex-1 p-6">
        @RenderBody()
    </main>
</body>
</html>
```

This layout demonstrates a sidebar that can be reused for dashboard pages when working with Entity Framework entities.

## Usage

Run `npm run build:css` to regenerate `wwwroot/css/output.css` after modifying `site.css` or `tailwind.config.js`.

