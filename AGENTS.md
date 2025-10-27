# Homemade Recipe App - Design System

## Project Overview

Homemade is a recipe management application with a unique focus on ingredient-based recipe discovery. The primary use case is helping users find recipes based on ingredients they already have, particularly useful for utilizing leftovers from previous meals.

## Design Philosophy

The design system prioritizes:
- **Warmth and approachability** - Using warm colors associated with home cooking
- **Clarity and simplicity** - Clean interfaces that don't overwhelm
- **Efficiency** - Quick access to ingredient search and recipe browsing
- **Visual feedback** - Clear indication of user actions and state

## Color Palette

The color system uses **OKLCH color space** for perceptually uniform colors, ensuring consistent visual weight and better accessibility across all shades.
Do **not** use Tailwind built-in colours, only those defined in the colour palette.

### Color Definition Location
All colors are defined in `src/Homemade.Web/Styles/app.css` using TailwindCSS v4's `@theme` directive.

### Primary (Warm Orange)
**Purpose**: Main brand color, CTAs, active states, interactive elements

The warm orange evokes appetite, home cooking, and comfort.

**Usage**:
- `bg-primary-500` - Primary buttons, active states
- `bg-primary-600` - Hover states for primary actions
- `bg-primary-100` - Selected ingredient tags background
- `text-primary-800` - Tag text color
- `bg-primary-50` - Page background gradient start
- `from-primary-200 to-primary-300` - Recipe card placeholder gradients

**Shades**: 50, 100, 200, 300, 400, 500, 600, 700, 800, 900, 950

### Secondary (Soft Cream)
**Purpose**: Complementary neutral with warmth, secondary UI elements

Provides subtle backgrounds and supports the primary color scheme.

**Usage**:
- `bg-secondary-100` - Subtle background sections
- `text-secondary-700` - Secondary text elements
- `bg-secondary-50` - Very light backgrounds

**Shades**: 50, 100, 200, 300, 400, 500, 600, 700, 800, 900, 950

### Accent (Fresh Green)
**Purpose**: Highlighting fresh ingredients, herbs, and special features

Use sparingly for emphasis on ingredient-related content.

**Usage**:
- `bg-accent-500` - Accent buttons or badges
- `border-accent-400` - Highlighting fresh ingredient features
- `text-accent-700` - Accent text for ingredient callouts

**Shades**: 50, 100, 200, 300, 400, 500, 600, 700, 800, 900, 950

### Semantic Colors

#### Success (Leafy Green)
**Purpose**: Positive feedback, successful actions

**Usage**:
- `bg-success-500` - Success banners
- `text-success-700` - Success messages
- Examples: "Recipe saved", "Ingredient added"

**Shades**: 50, 100, 200, 300, 400, 500, 600, 700, 800, 900, 950

#### Warning (Golden Yellow)
**Purpose**: Cautionary messages, important notes

**Usage**:
- `bg-warning-100` - Warning backgrounds
- `text-warning-700` - Warning text
- Examples: "Missing ingredients", "Recipe notes"

**Shades**: 50, 100, 200, 300, 400, 500, 600, 700, 800, 900, 950

#### Error (Rich Red)
**Purpose**: Error states, destructive actions, validation failures

**Usage**:
- `bg-error-500` - Error alerts
- `text-error-700` - Error messages
- `border-error-300` - Invalid input borders
- Examples: "Search failed", "Delete recipe"

**Shades**: 50, 100, 200, 300, 400, 500, 600, 700, 800, 900, 950

### Neutral (Warm Grays)
**Purpose**: Text, borders, backgrounds - slightly warm to complement the orange theme

The neutral palette has a subtle warm tint to harmonize with the food-focused design.

**Usage**:
- **White** (`#ffffff`) - Card backgrounds, input backgrounds
- `text-neutral-900` - Primary headings
- `text-neutral-800` - Secondary headings
- `text-neutral-700` - Suggestion button text
- `text-neutral-600` - Body text, metadata
- `border-neutral-200` - Input borders
- `bg-neutral-100` - Ingredient tags, suggestion buttons
- `bg-neutral-300` - Disabled button state
- `bg-neutral-50` - Subtle background sections

**Shades**: 50, 100, 200, 300, 400, 500, 600, 700, 800, 900, 950

## Typography

### Font Stack
Uses system font stack (default TailwindCSS):
- `-apple-system, BlinkMacSystemFont, "Segoe UI", Roboto, "Helvetica Neue", Arial`

### Text Styles

#### Headings
- **H1** (`.text-5xl .font-bold`) - Main app title (48px)
  - Color: `text-neutral-900`
  - Use case: Hero section, app name

- **H2** (`.text-3xl .font-bold`) - Section headers (30px)
  - Color: `text-neutral-800`
  - Use case: "Featured Recipes", major page sections

- **H2** (`.text-2xl .font-semibold`) - Card headers (24px)
  - Color: `text-neutral-800`
  - Use case: "What's in your kitchen?", subsections

- **H3** (`.text-xl .font-semibold`) - Card titles (20px)
  - Color: `text-neutral-800`
  - Use case: Recipe names, quick action titles

#### Body Text
- **Large body** (`.text-xl`) - Hero tagline (20px)
  - Color: `text-neutral-600`

- **Regular body** (`.text-lg`) - Input text, primary buttons (18px)
  - Color: `text-neutral-900` or White

- **Small body** (`.text-sm`) - Tags, metadata, suggestions (14px)
  - Color: `text-neutral-600` or contextual

- **Extra small** (`.text-xs`) - Recipe ingredient tags (12px)
  - Color: `text-neutral-600`

## Spacing System

Uses TailwindCSS spacing scale (1 unit = 0.25rem = 4px):

### Page Layout
- **Container padding**: `px-4` (16px horizontal)
- **Section vertical spacing**: `py-12` (48px)
- **Section bottom margin**: `mb-16` (64px) for major sections, `mb-12` (48px) for hero

### Component Spacing
- **Card padding**: `p-6` or `p-8` (24px or 32px)
- **Element gaps**:
  - Small gap (tags, suggestions): `gap-2` (8px)
  - Medium gap (cards): `gap-6` (24px)
- **Internal margins**:
  - Between elements: `mb-3` to `mb-6` (12px to 24px)

## Components

### Cards

#### White Card (Container)
```css
bg-white rounded-2xl shadow-lg p-8
hover:shadow-lg (for interactive cards)
```

**Usage**: Main content containers, search boxes, recipe cards

**Variants**:
- **Large rounded**: `rounded-2xl` - Main search card
- **Medium rounded**: `rounded-xl` - Recipe cards, quick action cards

### Buttons

#### Primary Button
```css
bg-primary-500 text-white rounded-xl hover:bg-primary-600
px-6 py-4 (large) or px-6 py-2 (small)
font-semibold text-lg (large)
transition-colors
```

**Usage**: Main CTAs, "Find Recipes" button

**States**:
- Hover: `bg-primary-600`
- Disabled: `disabled:bg-neutral-300 disabled:cursor-not-allowed`

#### Suggestion Button (Secondary)
```css
bg-neutral-100 text-neutral-700 rounded-full
px-3 py-1 text-sm
hover:bg-primary-100 hover:text-primary-700
transition-colors
```

**Usage**: Popular ingredient suggestions, quick-add actions

#### Accent Button (Optional)
```css
bg-accent-500 text-white rounded-xl hover:bg-accent-600
px-4 py-2
transition-colors
```

**Usage**: Special actions related to fresh ingredients or featured content

### Input Fields

#### Text Input
```css
w-full px-6 py-4 text-lg
border-2 border-neutral-200 rounded-xl
focus:border-primary-500 focus:outline-none
transition-colors
```

**States**:
- Default: `border-neutral-200`
- Focus: `focus:border-primary-500`
- Error: `border-error-300 focus:border-error-500`

### Tags

#### Ingredient Tag (Removable)
```css
inline-flex items-center
px-4 py-2 rounded-full
bg-primary-100 text-primary-800
text-sm font-medium
```

**Features**:
- Remove button: `ml-2 text-primary-600 hover:text-primary-800 font-bold` (× symbol)
- Displayed in flex wrap container: `flex flex-wrap gap-2`

#### Recipe Ingredient Tag (Read-only)
```css
px-2 py-1 rounded-full
bg-neutral-100 text-neutral-600
text-xs
```

**Usage**: Display ingredients in recipe cards

#### Status Tags
```css
/* Success */
bg-success-100 text-success-700 px-2 py-1 rounded-full text-xs

/* Warning */
bg-warning-100 text-warning-700 px-2 py-1 rounded-full text-xs

/* Accent (Fresh) */
bg-accent-100 text-accent-700 px-2 py-1 rounded-full text-xs
```

**Usage**: Indicate recipe status, dietary tags, or ingredient freshness

### Recipe Cards

```html
<div class="bg-white rounded-xl shadow overflow-hidden hover:shadow-lg transition-shadow">
  <!-- Image placeholder: h-48 bg-gradient-to-br from-primary-200 to-primary-300 -->
  <!-- Content: p-6 -->
</div>
```

**Structure**:
- Image area: 192px height with gradient background (`from-primary-200 to-primary-300`)
- Emoji icon: `text-6xl` centered
- Title: H3 style (`text-neutral-800`)
- Ingredient tags: Flex wrap, gap-1 (using `bg-neutral-100 text-neutral-600`)
- Metadata row: Flex with icons (⏱️ time, 👥 servings) in `text-neutral-600`

**Variants**:
- Add `border-l-4 border-accent-500` for featured/fresh recipes
- Use `bg-secondary-50` background for alternative card style

### Quick Action Cards

```html
<a href="..." class="block p-6 bg-white rounded-xl shadow hover:shadow-lg transition-shadow">
  <div class="text-3xl mb-3">[emoji]</div>
  <h3 class="text-neutral-800">[title]</h3>
  <p class="text-neutral-600">[description]</p>
</a>
```

**Hover State**: Shadow increases from `shadow` to `shadow-lg`

## Layout Patterns

### Page Container
```css
min-h-screen bg-gradient-to-b from-primary-50 to-white
container mx-auto px-4 py-12
```

**Alternative**:
- Use `from-secondary-50` for a creamier background gradient

### Content Width Constraints
- **Narrow content** (forms, search): `max-w-4xl mx-auto`
- **Wide content** (recipe grid): `max-w-6xl mx-auto`

### Grid Layouts

#### Two-Column Grid (Quick Actions)
```css
grid md:grid-cols-2 gap-6
```

#### Three-Column Grid (Recipe Cards)
```css
grid md:grid-cols-3 gap-6
```

**Responsive behavior**: Single column on mobile, grid on `md` breakpoint (768px+)

## Icons & Emojis

The design uses emojis for visual interest and to maintain a friendly, approachable feel:

- **Recipe placeholders**: Food emojis (🍝, 🥘, 🍲)
- **Metadata**: Time (⏱️), Servings (👥)
- **Quick actions**: Book (📖), Plus (➕)
- **Close/remove**: × (multiplication symbol in button, not emoji)

## Interactive States

### Hover States
- **Buttons**: Darken color (`primary-500` → `primary-600`, `accent-500` → `accent-600`)
- **Cards**: Increase shadow (`shadow` → `shadow-lg`)
- **Suggestions**: Background color change (`neutral-100` → `primary-100`)
- **Links**: Subtle color shift (e.g., `text-neutral-700` → `text-primary-600`)

### Disabled States
- **Buttons**: Neutral background (`bg-neutral-300`), disabled cursor
- **Inputs**: Faded border (`border-neutral-200` with reduced opacity)
- Applies when: No ingredients selected for search, form validation fails

### Focus States
- **Inputs**: Primary border (`focus:border-primary-500`)
- **Buttons**: Ring with primary color (`focus:ring-2 focus:ring-primary-500`)
- Remove default outline: `focus:outline-none`

### Error States
- **Inputs**: Error border (`border-error-300 focus:border-error-500`)
- **Messages**: Error text color (`text-error-700`) with error background (`bg-error-50`)

### Success States
- **Messages**: Success text color (`text-success-700`) with success background (`bg-success-50`)
- **Badges**: Success tags (`bg-success-100 text-success-700`)

### Transitions
All interactive elements use `transition-colors` or `transition-shadow` for smooth state changes

## Responsive Design

### Breakpoints
Uses TailwindCSS default breakpoints:
- **sm**: 640px
- **md**: 768px (primary breakpoint used)
- **lg**: 1024px
- **xl**: 1280px

### Mobile-First Approach
- Default: Single column, full width
- `md:` prefix: Grid layouts, multi-column

### Container Behavior
- Padding: Consistent `px-4` on all screen sizes
- Max width: Uses `max-w-{size}` with `mx-auto` for centering

## Accessibility Considerations

### Semantic HTML
- Use proper heading hierarchy (h1 → h2 → h3)
- Links (`<a>`) for navigation
- Buttons (`<button>`) for actions

### Color Contrast
All colors in the OKLCH palette are designed for accessibility:

- Primary text (`text-neutral-900`) on white: High contrast (AAA)
- Primary buttons (`bg-primary-500`) with white text: Sufficient contrast (AA)
- Body text (`text-neutral-600`) on white: WCAG AA compliant
- Error states (`text-error-700`) on white: High contrast (AA)
- Success states (`text-success-700`) on white: High contrast (AA)

### Interactive Elements
- Buttons have clear hover states
- Disabled states are visually distinct
- Focus states provide keyboard navigation feedback

### Suggestions for Implementation
- Add `aria-label` to remove buttons (× symbols)
- Add `role="region"` to major sections
- Ensure keyboard navigation works for ingredient input
- Add screen reader text for icon-only elements

## Future Considerations

### Dark Mode
If implementing dark mode:
- Use TailwindCSS `dark:` variant
- Swap background gradients (e.g., `dark:from-neutral-950 dark:to-neutral-900`)
- Use lighter shades for dark backgrounds:
  - `dark:bg-primary-400` for primary buttons
  - `dark:text-neutral-100` for body text
  - `dark:bg-neutral-800` for cards
  - `dark:border-neutral-700` for borders
- Maintain contrast ratios with OKLCH's perceptual uniformity

### Additional States
- Loading states for search results
- Empty states when no recipes found
- Error states for failed searches

### Animation
- Consider adding subtle animations for ingredient tag addition/removal
- Page transitions when navigating to search results
- Skeleton loaders for recipe cards while loading

## Code Conventions

### CSS Classes
- Use TailwindCSS utility classes
- Group by category: layout → spacing → colors → typography → effects
- Use responsive prefixes before other variants: `md:hover:...`

### Component Organization
```
Components/
├── Pages/          # Page-level components (Home.razor, etc.)
├── Layout/         # Layout components (MainLayout.razor)
└── [future]        # Reusable components (RecipeCard, IngredientTag, etc.)
```

### File Structure
- Keep mockup data in `@code` block for now
- Move to separate models/services when implementing backend
- Component-specific styles in `.razor` files with TailwindCSS

## Resources

- **TailwindCSS Documentation**: https://tailwindcss.com/docs
- **Blazor Component Documentation**: https://learn.microsoft.com/en-us/aspnet/core/blazor/components/
- **Color Palette Tool**: Use https://tailwindcss.com/docs/customizing-colors for color reference
