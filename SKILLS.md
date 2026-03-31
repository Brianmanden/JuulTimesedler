# Project Agent Skills

This document maps the specialized agent skills available in the `JuulTimesedler` project. These skills extend the AI's capabilities with domain-specific knowledge and automated workflows.

## Skill Registry

### 1. Umbraco Expert (`umbraco-expert`)
*   **Purpose:** Specialized expertise for Umbraco 13+ CMS development, content modeling, and backend API integration.
*   **Triggers:** When working on `JuulTimesedler_BE`, Document Types, Umbraco Controllers, or CMS configuration.
*   **Location:** `.agents/skills/umbraco-expert/`
*   **Status:** ✅ **Installed**

### 2. Blazor UI Specialist (`blazor-ui`)
*   **Purpose:** Guidance for Blazor WebAssembly/Server components, interactive UI patterns, and CSS styling.
*   **Triggers:** When editing `JuulTimesedler_FE`, Razor components, or UI layouts.
*   **Location:** `.agents/skills/blazor-ui/`
*   **Status:** ✅ **Installed**

### 3. Solution Architect (`solution-models`)
*   **Purpose:** Ensuring architectural consistency across the FE/BE layers, managing shared DTOs, and serialization logic.
*   **Triggers:** When modifying `SharedModels`, DTOs, or project-wide architectural patterns.
*   **Location:** `.agents/skills/solution-models/`
*   **Status:** ✅ **Installed**

## How to Use
These skills are automatically activated based on the context of your request. You can also manually manage them using:
- `/skills list` - See all currently active skills.
- `/skills reload` - Refresh the skills after an installation or update.
