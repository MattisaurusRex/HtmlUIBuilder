# AGENTS.md
## Objective
Port the .cshtml files in the Views folder of the `HtmlUI` ASP.NET MVC project into straightforward, efficient xaml files inside the `HtmlWinUI` project **WinUI 3 desktop app** while preserving current behavior and information architecture where possible.

## Current project snapshot
- Platform: ASP.NET Core MVC (`Program.cs`, controllers, Razor views).
- UI construction is metadata/reflection-driven via helper methods:
  - `Helpers/HtmlHelpers.cs`
  - `Helpers/JavascriptHelpers.cs`
- Form schemas and tab schemas are encoded in model metadata:
  - `Models/IFormBase.cs`
  - `Models/Search/SearchBase.cs`, `Models/Search/FilesSearchModel.cs`
  - `Models/Details/IDetailHeader.cs`, `Models/Details/IDetailTabItem.cs`
  - `Models/Details/Files/*`
- Main functional areas currently visible:
  - Home dashboard and section dashboards (`HomeController.cs`, `Views/Home/*`)
  - Files search + search results + file detail tabs (`FilesController.cs`, `Views/Files/*`)
  - Customers/Quotes/Invoices are scaffold placeholders.

## Non-goals
- Do not preserve web stack concepts (Razor, controllers, jQuery, DataTables, Bootstrap).
- Do not create over-engineered abstractions or plugin systems.
- Do not re-implement the old HTML string builder approach in WinUI.

## Target architecture (keep simple)
Use MVVM with a small, pragmatic structure:
- `Models/` (existing domain/view-schema classes, adapted as needed)
- `ViewModels/`
- `Views/` (XAML pages/user controls)
- `Services/` (navigation, sample/mock data, optional mapping helpers)

Suggested shell:
- `App.xaml`
- `MainWindow.xaml` containing:
  - top header/nav area
  - main content frame/region
  - footer/status area

## Required behavior mapping
Map existing behavior from MVC to WinUI 3:

1. **Top navigation / shell**
   - Preserve top-level sections: Files, Customers, Quotes, Invoices.
   - Preserve visible version/connection status region from layout.

2. **Dashboards**
   - Home dashboard with icon + label actions.
   - Section dashboards (Files/Customers/Quotes/Invoices) with Search/Create actions.

3. **Files search**
   - Render `FilesSearchModel` fields in grouped sections (Client, Dates, Patient, Office).
   - Support text, bool, date, and select-like inputs.
   - Keep layout readable and responsive to window resize.

4. **Files search result**
   - Replace DataTables with WinUI `DataGrid` (or equivalent tabular control used in project).
   - Show columns from `FileEntity` (excluding hidden/internal state fields).
   - Include row-level “View” action that opens detail screen.

5. **File detail**
   - Header panel from `IDetailHeader` / `FileDetailHeader` metadata.
   - Tabbed detail area from `DetailTabItems`.
   - Forms/tables/buttons for each tab item with clear spacing and labels.

## Implementation constraints
- Prefer explicit XAML bindings over runtime reflection-heavy control generation.
- Reflection may be used in a contained adapter/mapping layer only if it reduces duplication and remains readable.
- Keep names clear and consistent with existing domain terms.
- Keep dependencies minimal; avoid unnecessary third-party UI frameworks.
- Preserve existing `DisplayName` semantics for labels wherever practical.

## Recommended migration strategy
1. Create WinUI 3 app shell and navigation.
2. Port shared domain models first (minimal changes).
3. Implement Files flow end-to-end (Search -> Results -> Detail) before placeholder modules.
4. Add Customers/Quotes/Invoices placeholders using same shell pattern.
5. Remove dead web-only concepts from migrated project.

## Practical translation notes
- MVC action routing -> WinUI navigation service + page/viewmodel parameters.
- HTML helper output -> XAML view composition and reusable `UserControl`s.
- jQuery click handlers -> `ICommand` bindings.
- DataTables -> native tabular control with sorting/filtering as needed.
- `Headings` metadata arrays -> explicit grouped sections in XAML and/or lightweight viewmodel adapters.

## Quality bar / acceptance criteria
The migration is considered complete when:
- App builds and runs as a WinUI 3 desktop app.
- Files Search/Result/Detail workflow is functional.
- Navigation across Files/Customers/Quotes/Invoices is functional.
- No Razor, controller, jQuery, or Bootstrap dependencies remain in the WinUI project.
- Code is easy to follow for a C# desktop developer unfamiliar with the original MVC implementation.

## Delivery expectations for the coding agent
- Work in small, reviewable commits.
- Keep each commit behaviorally coherent (shell, search, results, detail, cleanup).
- Add concise inline comments only where intent is non-obvious.
- If uncertain about behavior parity, prefer matching current UI semantics over inventing new behavior.
