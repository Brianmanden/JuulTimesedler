---
name: blazor-ui
description: Specialized expertise for Blazor WebAssembly/Server development in the JuulTimesedler solution. Use this skill when building Razor components, managing UI state (ViewModels), or implementing interactive front-end patterns in 'JuulTimesedler_FE'.
---

# Blazor UI Specialist

## Overview
This skill provides guidance for building modern, responsive, and interactive UIs using Blazor. It focuses on clean component architecture, efficient state management, and aesthetic consistency within the `JuulTimesedler_FE` project.

## Core Tasks

### 1. Component Architecture
When building Razor components (`.razor`):
- **Single Responsibility:** Break large layouts into small, reusable components.
- **Parameters & Callbacks:** Use `[Parameter]` for inputs and `[Parameter] public EventCallback<T> OnAction { get; set; }` for event bubbling.
- **Lifecycle Methods:** Correct use of `OnInitializedAsync`, `OnParametersSetAsync`, and `OnAfterRenderAsync`.

### 2. State & ViewModels
Implement the MVVM pattern (or similar) to decouple UI logic:
- **IndexViewModel:** Consolidate UI state and business logic into dedicated ViewModel classes.
- **Dependency Injection:** Inject services (`ProjectsService`, `TimesheetsService`) to handle API communication.
- **Reactive UI:** Use `StateHasChanged()` effectively to ensure UI updates.

### 3. Aesthetics & UX
Ensure a "visually alive" prototype:
- **Styling:** Use `app.css` for consistent spacing, typography, and interactive feedback.
- **Interactive States:** Provide loading indicators, success/error feedback, and smooth transitions.
- **Layouts:** Manage `MainLayout.razor` for project-wide navigation and branding.

### 4. Shared Models Integration
Use models from `SharedModels` to ensure consistency with the backend:
- **DTO Usage:** Bind UI forms to shared DTOs (e.g., `PutTimesheetDTO`).
- **Enums:** Utilize shared enums (e.g., `WeekDays`) for UI elements like day selection.

## Resources
- **references/blazor-patterns.md**: Common Blazor code snippets and component patterns.
- **references/ui-guidelines.md**: Spacing, color, and typography standards for the project.
