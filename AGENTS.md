# AGENTS.md
## Objective
Port the `HtmlWinUI` **WinUI 3 desktop app** into a straightforward, efficient **WPF (.NET 8) desktop app** in a new `HtmlWpf` project, preserving current behavior, styling, and information architecture where possible.

## Current project snapshot
- Source: `HtmlWinUI/HtmlWinUI/HtmlWinUI.csproj` — `net8.0-windows10.0.19041.0`, `UseWinUI=true`, WinUI 3 (Windows App SDK).
- Shell: `MainWindow.xaml` — header (brand + section nav buttons + version/connection status), a `Frame` content region, and a footer (copyright/About link + current user).
- Navigation: `Services/NavigationService.cs` wraps a static `Frame` and exposes `Navigate(Type, object?)` / `GoBack()`.
- Pages (MVVM-lite, code-behind driven): `Views/HomePage`, `Views/SectionDashboardPage`, `Views/FilesSearchPage`, `Views/FilesSearchResultPage`, `Views/FileDetailPage`, `Views/PlaceholderPage`, `Views/AboutPage`.
- Domain/view-schema models carried over unchanged where possible:
  - `Models/IFormBase.cs`
  - `Models/Search/SearchBase.cs`, `Models/Search/FilesSearchModel.cs`
  - `Models/Details/IDetailHeader.cs`, `Models/Details/IDetailTabItem.cs`, `Models/Details/Files/*`
  - `Models/Entities/FileEntity.cs`, `Models/Entities/IEntityBase.cs`, `Models/Entities/ObjectState.cs`
  - `Models/Buttons/*`, `Models/Notes/*`
- Supporting code: `Services/SampleDataService.cs` (mock data), `ViewModels/DashboardItem.cs`, `Controls/SimpleTable.cs`, `Converters/DateTimeToDateTimeOffsetConverter.cs`.
- Main functional areas: Home dashboard, section dashboards (Files/Customers/Quotes/Invoices), Files search → results → detail (fully built); Customers/Quotes/Invoices are placeholders.
- `HtmlUI` (ASP.NET MVC) is the legacy web original; it is no longer the porting source and should not be modified as part of this work.

## Non-goals
- Do not preserve WinUI 3 / Windows App SDK concepts (`Microsoft.UI.Xaml.*` namespaces, `Frame.Navigate` semantics tied to WinUI, MSIX packaging via the `HtmlWinUI (Package)` wapproj).
- Do not create over-engineered abstractions or plugin systems.
- Do not touch the `HtmlUI` MVC project or the `HtmlWinUI (Package)` packaging project.

## Target architecture (keep simple)
New project `HtmlWpf/HtmlWpf/HtmlWpf.csproj`, sibling to `HtmlUI` and `HtmlWinUI`, added to `HtmlUIBuilder.sln`:
- SDK-style WPF project: `<Project Sdk="Microsoft.NET.Sdk">`, `<UseWPF>true</UseWPF>`, `<TargetFramework>net8.0-windows</TargetFramework>`, `<OutputType>WinExe</OutputType>`.
- Folder layout mirrors `HtmlWinUI`: `Models/`, `ViewModels/`, `Views/`, `Services/`, `Controls/`, `Converters/`, `Assets/`.
- `App.xaml` / `App.xaml.cs` — standard WPF application entry point.
- `MainWindow.xaml` containing:
  - top header/nav area (same sections: Files, Customers, Quotes, Invoices; same version/connection status region)
  - main content region — a WPF `Frame` (or `ContentControl` if page navigation history isn't needed) hosting `Page`s
  - footer/status area

## Required behavior mapping
Port each piece from WinUI 3 to WPF, preserving behavior:

1. **Top navigation / shell**
   - Reproduce `MainWindow.xaml`'s header/footer layout using WPF `Grid`/`Border`/`StackPanel`/`Button`/`TextBlock`.
   - `HyperlinkButton` → WPF `Hyperlink` inside a `TextBlock`, or a styled `Button`.

2. **Navigation service**
   - Port `Services/NavigationService.cs` to wrap a WPF `Frame`'s `Navigate`/`GoBack`, keeping the same static API so page code-behind stays structurally similar.

3. **Pages**
   - Port each `Views/*Page.xaml` + code-behind to a WPF `Page` (or `UserControl` if plain navigation is preferred) with equivalent layout and bindings.
   - `Views/FilesSearchResultPage` — replace the WinUI tabular control with WPF `DataGrid` (`System.Windows.Controls.DataGrid`, built into WPF).
   - `Controls/SimpleTable.cs` — port to a WPF custom control/`UserControl` if still needed, or replace with `DataGrid`/`ItemsControl` if simpler.

4. **Models, converters, sample data**
   - Carry over `Models/`, `Converters/`, `Services/SampleDataService.cs`, and `ViewModels/DashboardItem.cs` with minimal changes; adjust only what's required by WPF's binding/type system (e.g. `IValueConverter` namespace is `System.Windows.Data`, not `Microsoft.UI.Xaml.Data`).

5. **Resources/styles**
   - Port brushes/styles referenced via `StaticResource` (e.g. `NavBarBrush`, `NavButtonStyle`) into WPF `ResourceDictionary` files (`App.xaml` or a dedicated `Themes/` dictionary merged in).

## Implementation constraints
- Prefer explicit XAML bindings over runtime reflection-heavy control generation.
- Reflection may be used in a contained adapter/mapping layer only if it reduces duplication and remains readable.
- Keep names clear and consistent with the existing `HtmlWinUI` domain/type names so the two projects stay easy to compare.
- Keep dependencies minimal; avoid unnecessary third-party UI frameworks or MVVM toolkits unless they meaningfully reduce boilerplate (e.g. `CommunityToolkit.Mvvm` is acceptable if adopted consistently).
- Preserve existing `DisplayName` semantics for labels wherever practical.

## Recommended migration strategy
1. Create the `HtmlWpf` project skeleton and add it to `HtmlUIBuilder.sln`.
2. Port shared domain/view-schema models, converters, and sample data service first (minimal changes).
3. Port the app shell (`App.xaml`, `MainWindow.xaml`, `NavigationService`).
4. Port the Files flow end-to-end (Home → Section dashboard → Search → Results → Detail) before placeholder modules.
5. Port Customers/Quotes/Invoices placeholders using the same shell pattern.
6. Verify no `Microsoft.UI.Xaml.*` / Windows App SDK / MSIX-only APIs remain in `HtmlWpf`.

## Practical translation notes
- `Microsoft.UI.Xaml.Controls.Frame` navigation → `System.Windows.Controls.Frame` navigation (API is similar; adjust namespaces and event signatures).
- WinUI `x:Bind` → WPF `Binding` (no compiled bindings by default; mind `DataContext` propagation).
- `Click="Handler"` command patterns can stay as event handlers or move to `ICommand` bindings — match what each page already does in `HtmlWinUI`.
- WinUI tabular control → WPF `DataGrid` with sorting/filtering as needed.
- WinUI `Style`/`StaticResource` brushes/styles → WPF `ResourceDictionary` entries with equivalent keys.
- MSIX packaging (`HtmlWinUI (Package)`) has no WPF equivalent in scope — ship `HtmlWpf` as a plain executable/ClickOnce/MSI only if separately requested.

## Quality bar / acceptance criteria
The migration is considered complete when:
- `HtmlWpf` builds and runs as a WPF desktop app targeting `net10.0-windows`.
- Files Search/Result/Detail workflow is functional and behaviorally equivalent to `HtmlWinUI`.
- Navigation across Files/Customers/Quotes/Invoices is functional.
- No `Microsoft.UI.Xaml.*`, Windows App SDK, or WinUI-3-only dependencies remain in `HtmlWpf`.
- Code is easy to follow for a C# desktop developer unfamiliar with the original WinUI 3 implementation.

## Delivery expectations for the coding agent
- Work in small, reviewable commits.
- Keep each commit behaviorally coherent (project skeleton, models, shell, search, results, detail, cleanup).
- Add concise inline comments only where intent is non-obvious.
- If uncertain about behavior parity, prefer matching `HtmlWinUI`'s current UI semantics over inventing new behavior.
