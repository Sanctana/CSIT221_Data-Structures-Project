# CSS Styling Guide

This guide explains where you can customize the look and feel of your Flight Ticketing System application.

## 📁 CSS File Locations

### 1. **Main Global Styles** - `wwwroot/css/app.css`
   - **Purpose**: Global styles that affect the entire application
   - **What to customize here**:
     - Color scheme (CSS variables in `:root`)
     - Global button styles
     - Card styles
     - Form controls
     - Typography
     - Container styles
     - Modal styles
     - Scrollbar styles

### 2. **Home Page Specific Styles** - `Pages/Home.razor.css`
   - **Purpose**: Styles specific to the Home page component
   - **What to customize here**:
     - Tab styling
     - Search form appearance
     - Seat picker styling
     - Reservation form appearance
     - Flight info display
     - Message/alert styling

### 3. **Layout Styles** - `Layout/MainLayout.razor.css`
   - **Purpose**: Overall page layout structure
   - **What to customize here**:
     - Page container layout
     - Sidebar appearance
     - Top navigation bar
     - Responsive breakpoints

### 4. **Navigation Menu Styles** - `Layout/NavMenu.razor.css`
   - **Purpose**: Navigation sidebar/menu styling
   - **What to customize here**:
     - Menu item appearance
     - Active/hover states
     - Icon styles
     - Mobile menu behavior

## 🎨 Key CSS Variables (in app.css)

These are defined in `:root` at the top of `app.css`. Change these to quickly update the color scheme:

```css
:root {
  --primary-color: #1b6ec2;      /* Main brand color */
  --primary-dark: #1861ac;       /* Darker shade */
  --primary-light: #258cfb;      /* Lighter shade */
  --success-color: #28a745;      /* Success messages */
  --danger-color: #dc3545;       /* Error/warning messages */
  --light-bg: #f8f9fa;          /* Light background */
  --dark-text: #212529;         /* Main text color */
  --border-color: #dee2e6;      /* Border colors */
  --shadow-sm: 0 2px 4px rgba(0,0,0,0.1);  /* Small shadow */
  --shadow-md: 0 4px 6px rgba(0,0,0,0.1);  /* Medium shadow */
  --shadow-lg: 0 10px 15px rgba(0,0,0,0.1); /* Large shadow */
  --transition: all 0.3s ease;  /* Default animation */
}
```

## 🎯 Quick Customization Guide

### To Change Colors:
1. Edit `wwwroot/css/app.css`
2. Update the `:root` CSS variables
3. Or modify the gradient colors in `.btn-primary`, `.card-header`, etc.

### To Change Button Styles:
- Location: `wwwroot/css/app.css`
- Look for: `.btn-primary`, `.btn-success`, `.btn-danger`
- You can change:
  - Background gradients
  - Border radius
  - Padding
  - Hover effects
  - Shadows

### To Change Card Styles:
- Location: `wwwroot/css/app.css`
- Look for: `.card`, `.card-header`, `.card-body`
- You can change:
  - Border radius
  - Shadows
  - Background colors
  - Hover effects

### To Change Tab Styles:
- Location: `wwwroot/css/app.css` and `Pages/Home.razor.css`
- Look for: `.nav-tabs`, `.nav-link`
- You can change:
  - Active tab colors
  - Tab padding
  - Border styles
  - Hover effects

### To Change Form Styles:
- Location: `wwwroot/css/app.css`
- Look for: `.form-control`, `.form-label`
- You can change:
  - Input border styles
  - Focus states
  - Padding
  - Border radius

### To Change Seat Picker Styles:
- Location: `Pages/Home.razor.css`
- Look for: `.seat-button`, `.seat-row-container`
- You can change:
  - Seat button size
  - Colors
  - Hover effects
  - Spacing

### To Change Reservation Form Styles:
- Location: `Pages/Home.razor.css`
- Look for: `.reservation-form-container`, `.reservation-info`
- You can change:
  - Background gradient
  - List item styling
  - Form layout

## 📱 Responsive Design

Responsive breakpoints are defined in the CSS files. Key breakpoints:
- Mobile: `@media (max-width: 576px)`
- Tablet: `@media (max-width: 768px)`
- Desktop: `@media (min-width: 641px)`

You can customize styles for different screen sizes by editing the media queries in:
- `wwwroot/css/app.css`
- `Pages/Home.razor.css`
- `Layout/MainLayout.razor.css`

## 💡 Tips for Customization

1. **Use Browser DevTools**: 
   - Right-click any element → Inspect
   - See which CSS file/styles apply
   - Test changes in real-time

2. **CSS Specificity**: 
   - Component-specific CSS (like `Home.razor.css`) will override global styles
   - Use `!important` sparingly

3. **Color Palette**:
   - Change the gradient colors in `.btn-primary` and `.card-header` for a different look
   - Current gradient: `linear-gradient(135deg, #667eea 0%, #764ba2 100%)`

4. **Shadows and Depth**:
   - Modify `--shadow-sm`, `--shadow-md`, `--shadow-lg` variables
   - Or change individual `box-shadow` properties

5. **Animations**:
   - Modify `--transition` variable for animation speed
   - Add custom `@keyframes` animations in the CSS files

## 🔄 After Making Changes

1. Save your CSS file
2. Refresh your browser (hard refresh: Ctrl+F5)
3. If using `dotnet watch run`, changes should auto-reload

## 📝 Current Styling Features

- ✨ Modern gradient buttons
- 🎨 Smooth transitions and hover effects
- 📦 Beautiful card designs with shadows
- 🎯 Clean form controls with focus states
- 📱 Fully responsive design
- 🌈 Custom scrollbar styling
- ⚡ Smooth animations

---

**Note**: All CSS improvements have been applied to give your application a modern, professional look. You can further customize any aspect by editing the files mentioned above!

